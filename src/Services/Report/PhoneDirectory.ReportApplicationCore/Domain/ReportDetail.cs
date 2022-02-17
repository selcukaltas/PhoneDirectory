using PhoneDirectory.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDirectory.ReportApplicationCore.Domain
{
    public class ReportDetail : IEntity
    {
        public string Location { get; private set; }
        public int PersonCount { get; private set; }
        public int NumberCount { get; private set; }
        public Guid ReportId { get; private set; }
        public Guid Id { get; private set; }

        private ReportDetail() { }

        public ReportDetail(Guid id, Guid reportId, int personCount, int numberCount, string location)
        {
            if (string.IsNullOrWhiteSpace(id.ToString())) throw new ArgumentNullException(nameof(id));
            if (string.IsNullOrWhiteSpace(reportId.ToString())) throw new ArgumentNullException(nameof(reportId));
            if (string.IsNullOrWhiteSpace(location)) throw new ArgumentNullException(nameof(location));
            Id = id;
            ReportId = reportId;
            PersonCount = personCount;
            NumberCount = numberCount;
            Location = location;

        }
    }
}
