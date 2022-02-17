using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDirectory.DirectoryApplicationCore.DTOs
{
    public class CreatePersonDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }
    }
}
