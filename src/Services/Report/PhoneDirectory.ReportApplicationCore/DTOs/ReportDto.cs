using PhoneDirectory.ReportApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDirectory.ReportApplicationCore.DTOs
{
    public class ReportDto
    {
        public Guid Id { get; set; }
        public DateTime RequestDate { get; set; }
        public ReportStatus ReportStatus { get; set; }
        public string ReportStatusContent => EnumDecryptor(ReportStatus);

        public  string EnumDecryptor(ReportStatus reportStatus)
        {
            FieldInfo fi = reportStatus.GetType().GetField(reportStatus.ToString());

            if (fi == null)
                return string.Empty;

            var description = fi.GetCustomAttribute<DescriptionAttribute>(false)?.Description ?? string.Empty;

            return description;
        }
    }
 
}
