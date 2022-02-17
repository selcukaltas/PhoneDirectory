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
    public class ContactInformationService : IContactInformation
    {
        private readonly IAsyncRepository<ContactInformation> _contactInformationRepo;
        private readonly IAsyncRepository<Person> _personRepo;
        private readonly IMapper _mapper;


        public ContactInformationService(IAsyncRepository<ContactInformation> contactInformationRepo, IMapper mapper)
        {
            _contactInformationRepo = contactInformationRepo;
            _mapper = mapper;
        }

        public async Task<Response<ContactInformationDto>> CreateContactInformation(Guid personId, ContactInformationDto contactInformationDto)
        {
            var person = _personRepo.Get(x => x.Id == personId);
            if (person == null) { return Response<ContactInformationDto>.Fail("Person not found", 404); }

            var contactInformation = new ContactInformation(contactInformationDto.Id, contactInformationDto.InformationType, contactInformationDto.InformationContent,personId);

            var contactInfoAdd = await _contactInformationRepo.AddAsync(contactInformation);
            return Response<ContactInformationDto>.Success(_mapper.Map<ContactInformationDto>(contactInfoAdd), 201);
        }

        public async Task<Response<NoContent>> DeleteContactInformation(Guid contactInformationId)
        {
            var contactInfo = await _contactInformationRepo.Get(x=>x.Id == contactInformationId);
            if (contactInfo == null) { return Response<NoContent>.Fail("Contact information not found", 400); }

            await _contactInformationRepo.DeleteAsync(contactInfo);
            return Response<NoContent>.Success(204);

        }

        public async Task<Response<List<ContactInformationDto>>> GetAllContactInformations()
        {
            var contactInformations = await _contactInformationRepo.GetAllAsync();
            if (contactInformations.Any())
            {
                return Response<List<ContactInformationDto>>.Success(_mapper.Map<List<ContactInformationDto>>(contactInformations), 200);

            }
            return Response<List<ContactInformationDto>>.Fail("There is no contact informations", 404);

        }
    }
}
