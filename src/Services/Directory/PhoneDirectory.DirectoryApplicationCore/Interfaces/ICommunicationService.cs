using PhoneDirectory.Shared.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDirectory.DirectoryApplicationCore.Interfaces
{
    public interface ICommunicationService
    {
        Task<Response<NoContent>> Publish();
    }
}
