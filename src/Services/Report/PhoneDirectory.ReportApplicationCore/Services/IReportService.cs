using PhoneDirectory.ReportApplicationCore.DTOs;
using PhoneDirectory.Shared.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDirectory.ReportApplicationCore.Services
{
    public interface IReportService
    {
        Task<Response<Guid>> CreateReport();
        Task<Response<NoContent>> PrepareReportDetail(Guid reportId);
        Task<Response<List<ReportDto>>> GetAllReports();
        Task<Response<DetailsDto>> GetReportDetail(Guid reportId);
    }
}
