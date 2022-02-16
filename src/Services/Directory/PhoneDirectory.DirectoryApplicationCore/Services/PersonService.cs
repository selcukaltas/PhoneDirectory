using AutoMapper;
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
        private readonly IMapper _mapper;

        public PersonService(IAsyncRepository<Person> personRepository,IMapper mapper)
        {
            _mapper= mapper;    
            _personRepository = personRepository;
        }
        public async Task<Response<PersonDto>> CreatePerson(PersonDto personDto)
        {
            var person = new Person(personDto.Id,personDto.Name,personDto.Surname,personDto.Company);

            var personAdded= await _personRepository.AddAsync(person);

            return Response<PersonDto>.Success(_mapper.Map<PersonDto>(personAdded), 200);
        }

        public async Task<Response<NoContent>> DeletePerson(Guid personId)
        {
            var deletedPerson = await _personRepository.Get(x=>x.Id==personId);

            if(deletedPerson != null)
            {
                await _personRepository.DeleteAsync(deletedPerson);
                return Response<NoContent>.Success(204);
            }
            else
            {
                return Response<NoContent>.Fail("Person not found", 404);
            }
        }

        public async Task<Response<List<PersonDto>>> GetAllPersons()
        {
            var persons = await _personRepository.GetAllAsync();

            return Response<List<PersonDto>>.Success(_mapper.Map<List<PersonDto>>(persons), 200);
        }

        public async Task<Response<PersonDto>> GetPerson(Guid personId)
        {
            var person = await _personRepository.Get(x=>x.Id == personId);  

            if (person == null)
            {
                return Response<PersonDto>.Fail("Person not found", 404);
            }

            return Response<PersonDto>.Success(_mapper.Map<PersonDto>(person), 200);
        }

        public async Task<Response<PersonDetailDto>> GetPersonDetail(Guid personId)
        {
            var person = await _personRepository.Get(p => p.Id == personId, "ContactInformations");

            if (person==null)
            {
                return Response<PersonDetailDto>.Fail("Person not found", 404);
            }

            PersonDetailDto personDetailDto = new();

            personDetailDto.Person.Name=person.Name;
            personDetailDto.Person.Surname=person.Surname;
            personDetailDto.Person.Company=person.Company;
            personDetailDto.ContactInformations= (List<ContactInformationDto>)person.ContactInformations;

            return Response<PersonDetailDto>.Success(personDetailDto, 200);
        }
    }
}
