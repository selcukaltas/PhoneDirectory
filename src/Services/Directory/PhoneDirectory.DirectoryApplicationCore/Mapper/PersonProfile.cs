using AutoMapper;
using PhoneDirectory.DirectoryApplicationCore.Domain.PersonAggregate;
using PhoneDirectory.DirectoryApplicationCore.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDirectory.DirectoryApplicationCore.Mapper
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<PersonDto, Person>().ReverseMap();
        }
    }
}
