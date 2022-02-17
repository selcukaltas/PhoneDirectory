using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDirectory.ReportApplicationCore.DTOs
{
    public class ReportDetailsDto
    {
        public ReportDto Report { get; set; }
        public List<DetailsDto> ReportDetails { get; set; }
    }
}
