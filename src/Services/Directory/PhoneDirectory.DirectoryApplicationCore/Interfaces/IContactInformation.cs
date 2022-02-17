using PhoneDirectory.DirectoryApplicationCore.DTOs;
using PhoneDirectory.Shared.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDirectory.DirectoryApplicationCore.Interfaces
{
    public interface IContactInformation
    {
        Task<Response<ContactInformationDto>> CreateContactInformation(ContactInformationDto contactInformationDto);
        Task<Response<NoContent>> DeleteContactInformation(Guid contactInformationId);
        Task<Response<List<ContactInformationDto>>> GetAllContactInformations();
    }
}
