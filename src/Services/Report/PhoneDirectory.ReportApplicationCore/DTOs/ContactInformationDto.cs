using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDirectory.ReportApplicationCore.DTOs
{
    public class ContactInformationDto
    {
        public Guid Id { get; set; }
        public int InformationType { get; set; }
        public string InformationContent { get; set; }
        public Guid PersonId { get; set; }
    }
}
