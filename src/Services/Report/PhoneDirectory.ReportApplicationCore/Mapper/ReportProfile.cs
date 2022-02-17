using AutoMapper;
using PhoneDirectory.ReportApplicationCore.Domain;
using PhoneDirectory.ReportApplicationCore.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDirectory.ReportApplicationCore.Mapper
{
    public class ReportProfile : Profile
    {
        public ReportProfile()
        {
            CreateMap<ReportDto, Report>().ReverseMap();

        }
    }
}
