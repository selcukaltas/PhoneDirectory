using PhoneDirectory.DirectoryApplicationCore.DTOs;
using PhoneDirectory.Shared.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDirectory.DirectoryApplicationCore.Interfaces
{
    public interface IPersonService
    {
        Task<Response<PersonDto>> CreatePerson(PersonDto personDto);
        Task<Response<NoContent>> DeletePerson(Guid personId);
        Task<Response<List<PersonDto>>> GetAllPersons();
        Task<Response<PersonDto>> GetPerson(Guid personId);
        Task<Response<PersonDetailDto>> GetPersonDetail(Guid personId);
    }
}
