using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDirectory.DirectoryApplicationCore.DTOs
{
    public class PersonDetailDto
    {
        public PersonDto Person { get; set; } = new();
        public List<ContactInformationDto> ContactInformations { get; set; } = new();
    }
}
