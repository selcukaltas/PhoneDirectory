using Microsoft.AspNetCore.Mvc;
using PhoneDirectory.DirectoryApplicationCore.Interfaces;
using PhoneDirectory.Shared.ControllerBase;

namespace PhoneDirectory.DirectoryAPI.Controllers
{
    [Route("api/[Controller]/[Action]")]
    [ApiController]
    public class ReportRequestController : CustomBaseController
    {
        private readonly ICommunicationService _communicationService;

        public ReportRequestController(ICommunicationService communicationService)
        {
            _communicationService = communicationService;
        }
        [HttpPost]
        public async Task<IActionResult> PrepareReport()
        {
            var response = await _communicationService.Publish();
            return CreateActionResultInstance(response);
        }
    }
}
