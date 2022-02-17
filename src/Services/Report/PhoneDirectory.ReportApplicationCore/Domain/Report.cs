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
        public Report(Guid id, DateTime requestDate, ReportStatus reportStatus)
        {
            if (string.IsNullOrWhiteSpace(id.ToString())) throw new ArgumentNullException(nameof(id));
            Id = id;
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
