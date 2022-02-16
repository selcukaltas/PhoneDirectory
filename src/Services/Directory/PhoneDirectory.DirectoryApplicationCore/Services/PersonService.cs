using PhoneDirectory.DirectoryApplicationCore.Domain.PersonAggregate;
using PhoneDirectory.DirectoryApplicationCore.DTOs;
using PhoneDirectory.DirectoryApplicationCore.Interfaces;
using PhoneDirectory.Shared.Repository;
using PhoneDirectory.Shared.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDirectory.DirectoryApplicationCore.Services
{
    public class PersonService : IPersonService
    {
        private readonly IAsyncRepository<Person> _personRepository;
        private readonly IAsyncRepository<Person> _personRepository;
        public PersonService(IAsyncRepository<Person> personRepository)
        {
            _personRepository = personRepository;
        }
        public Task<Response<PersonDto>> CreatePerson(PersonDto personDto)
        {
            throw new NotImplementedException();
        }

        public Task<Response<NoContent>> DeletePerson(Guid personId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<List<PersonDto>>> GetAllPersons()
        {
            throw new NotImplementedException();
        }

        public Task<Response<PersonDto>> GetPerson(Guid personId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<PersonDetailDto>> GetPersonDetail(Guid personId)
        {
            throw new NotImplementedException();
        }
    }
}
