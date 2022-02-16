using PhoneDirectory.DirectoryApplicationCore.Domain.PersonAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDirectory.DirectoryApplicationCore.DTOs
{
    public class ContactInformationDto
    {
        public Guid UUID { get; set; }
        public InformationType InformationType { get; set; }
        public string InformationContent { get; set; }
        public Guid PersonId { get; set; }
    }
}
