using Microsoft.AspNetCore.Mvc;
using PhoneDirectory.ReportApplicationCore.Services;
using PhoneDirectory.Shared.ControllerBase;

namespace PhoneDirectory.ReportAPI.Controllers
{
    [Route("api/[Controller]/[Action]")]
    [ApiController]
    public class ReportController : CustomBaseController
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpPost]
        public async Task<IActionResult> ReportRequest()
        {
            var result = await _reportService.CreateReport();

            return CreateActionResultInstance(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReports()
        {
            var result = await _reportService.GetAllReports();
            return CreateActionResultInstance(result);
        }

        [HttpGet("{reportId}")]
     
        public async Task<IActionResult> GetReportDetail(Guid reportId)
        {
            var result = await _reportService.GetReportDetail(reportId);

            return CreateActionResultInstance(result);
        }
     
    }
}
