using PhoneDirectory.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDirectory.ReportApplicationCore.Domain
{
    public class Report : IAggregateRoot, IEntity
    {
        public DateTime RequestDate { get; private set; }
        public ReportStatus ReportStatus { get; private set; }

        private readonly List<ReportDetail> _reportDetails = new();
        public IReadOnlyCollection<ReportDetail> ContactInformations => _reportDetails.AsReadOnly();
        public Guid Id { get; private set; }

        private Report()
        {

        }
        public Report(DateTime requestDate, ReportStatus reportStatus)
        {
            RequestDate = requestDate;
            ReportStatus = reportStatus;
        }
    }
    public enum ReportStatus
    {
        [Description("Hazırlanıyor")]
        Preparing,
        [Description("Tamamlandı")]
        Completed
    }
}
