using Microsoft.AspNetCore.Mvc;
using PhoneDirectory.DirectoryApplicationCore.DTOs;
using PhoneDirectory.DirectoryApplicationCore.Interfaces;
using PhoneDirectory.Shared.ControllerBase;

namespace PhoneDirectory.DirectoryAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class PersonController : CustomBaseController
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
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
        public async Task<IActionResult> CreatePerson([FromBody] PersonDto personDto)
        {
            var response = await _personService.CreatePerson(personDto);

            return CreateActionResultInstance(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _personService.DeletePerson(id);

            return CreateActionResultInstance(response);
        }
    }
}
