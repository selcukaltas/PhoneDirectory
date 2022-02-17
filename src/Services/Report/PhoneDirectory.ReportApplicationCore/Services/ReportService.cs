using AutoMapper;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PhoneDirectory.ReportApplicationCore.Domain;
using PhoneDirectory.ReportApplicationCore.DTOs;
using PhoneDirectory.Shared.Repository;
using PhoneDirectory.Shared.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDirectory.ReportApplicationCore.Services
{
    public class ReportService : IReportService
    {
        private readonly IAsyncRepository<Report> _reportRepository;
        private readonly IAsyncRepository<ReportDetail> _reportDetailRepository;
        private readonly IMapper _mapper;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<ReportService> _logger;
        public ReportService(IAsyncRepository<Report> reportRepository, IMapper mapper, IHttpClientFactory httpClientFactory, ILogger<ReportService> logger)
        {
            _reportRepository = reportRepository;
            _mapper = mapper;
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }
        public async Task<Response<Guid>> CreateReport()
        {
            var report = new Report(DateTime.UtcNow, ReportStatus.Preparing);

            var reportAdded= await _reportRepository.AddAsync(report);

            return Response<Guid>.Success(reportAdded.Id, 201);

        }

        public async Task<Response<List<ReportDto>>> GetAllReports()
        {
            var reports = await _reportRepository.GetAllAsync();
            var reportsDto = _mapper.Map<List<ReportDto>>(reports);

            if (reports.Count > 0)
            {
                return Response<List<ReportDto>>.Success(reportsDto, 200);

            }
            return Response<List<ReportDto>>.Fail("Reports not found", 404);


        }

        public async Task<Response<DetailsDto>> GetReportDetail(Guid reportId)
        {
            var reportDetails = await _reportRepository.Get(x => x.Id == reportId, "ReportDetails");
            if (reportDetails == null) { return Response<DetailsDto>.Fail("Report details not found", 404); }

            var reportDetailsDto = _mapper.Map<DetailsDto>(reportDetails);
            return Response<DetailsDto>.Success(reportDetailsDto, 200);
        }

        public async Task PrepareReportDetail(Guid reportId)
        {
            var report = await _reportRepository.Get(x=>x.Id== reportId);

            if (report == null)
            {
                _logger.LogError("There is no report.");
                throw new Exception();
            }

            var client = _httpClientFactory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"http://localhost:5002/api/Person/GetAllContactInformations");
            var response = await client.SendAsync(request);

            var responseStream = await response.Content.ReadAsStringAsync();
            var contactInformations = JsonConvert.DeserializeObject<IEnumerable<ContactInformationDto>>(responseStream);

            var location = contactInformations.Where(x => x.InformationType == 2).Select(x => x.InformationContent).Distinct().FirstOrDefault();
            var personCount = contactInformations.Where(y => y.InformationType == 2 && y.InformationContent == location).Count();
            var numberCount = contactInformations.Where(y => y.InformationType == 0 && contactInformations.Where(y => y.InformationType == 2 && y.InformationContent == location).Select(x => x.PersonId).Contains(y.PersonId)).Count();
          

            var reportDetail = new ReportDetail(report.Id,personCount,numberCount,location);
            await ChangeStatus(report,ReportStatus.Completed);
            await _reportDetailRepository.AddAsync(reportDetail);
        }
        public async Task ChangeStatus(Report report,ReportStatus status)
        {
           
            report.UpdateStatus(status);

            await _reportRepository.UpdateAsync(report);
        }
    }
}
