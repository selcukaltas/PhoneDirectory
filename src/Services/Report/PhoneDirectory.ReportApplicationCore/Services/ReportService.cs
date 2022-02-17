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
        public ReportService(IAsyncRepository<Report> reportRepository)
        {
            _reportRepository = reportRepository;
        }
        public async Task<Response<Guid>> CreateReport()
        {
            var report = new Report(DateTime.Now,ReportStatus.Preparing);

            await _reportRepository.AddAsync(report);

            return Response<Guid>.Success(report.Id, 201);

        }

        public Task<Response<List<ReportDto>>> GetAllReports()
        {
            throw new NotImplementedException();
        }

        public Task<Response<DetailsDto>> GetReportDetail(Guid reportId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<NoContent>> PrepareReportDetail(Guid reportId)
        {
            throw new NotImplementedException();
        }
    }
}
