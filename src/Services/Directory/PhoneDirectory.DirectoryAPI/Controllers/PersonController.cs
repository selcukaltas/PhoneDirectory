using Microsoft.AspNetCore.Mvc;
using PhoneDirectory.DirectoryApplicationCore.DTOs;
using PhoneDirectory.DirectoryApplicationCore.Interfaces;
using PhoneDirectory.Shared.ControllerBase;

namespace PhoneDirectory.DirectoryAPI.Controllers
{
    [Route("api/[Controller]/[Action]")]
    [ApiController]
    public class PersonController : CustomBaseController
    {
        private readonly IPersonService _personService;
        private readonly IContactInformation _contactInformationService;

        public PersonController(IPersonService personService, IContactInformation contactInformationService)
        {
            _personService = personService;
            _contactInformationService = contactInformationService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _personService.GetAllPersons();

            return CreateActionResultInstance(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPerson(Guid id)
        {
            var response = await _personService.GetPerson(id);

            return CreateActionResultInstance(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPersonDetail(Guid id)
        {
            var response = await _personService.GetPersonDetail(id);

            return CreateActionResultInstance(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePerson([FromBody] CreatePersonDto personDto)
        {
            var response = await _personService.CreatePerson(personDto);

            return CreateActionResultInstance(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> PersonDelete(Guid id)
        {
            var response = await _personService.DeletePerson(id);

            return CreateActionResultInstance(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllContactInformations()
        {
            var response = await _contactInformationService.GetAllContactInformations();

            return CreateActionResultInstance(response);
        }
        [HttpPost]
        public async Task<IActionResult> CreateContactInformation( [FromBody] CreateContactInfoDto contactInformationDto)
        {
           

            var response = await _contactInformationService.CreateContactInformation(contactInformationDto);

            return CreateActionResultInstance(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteContactInformation([FromRoute] Guid Id)
        {
            var response = await _contactInformationService.DeleteContactInformation(Id);

            return CreateActionResultInstance(response);
        }
    }
}
