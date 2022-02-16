using PhoneDirectory.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDirectory.DirectoryApplicationCore.Domain.PersonAggregate
{
    public class ContactInformation : IEntity
    {
        public Guid Id { get; private set; }
        public InformationType InformationType { get; set; }
        public string InformationContent { get; set; }
        public Guid PersonId { get; set; }
    }
    public enum InformationType
    {
        [Description("Telefon Numarası")]
        PhoneNumber,
        [Description("E-Mail Adresi")]
        EmailAddress,
        [Description("Konum")]
        Location
    }
}
