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
        public InformationType InformationType { get; private set; }
        public string InformationContent { get; private set; }
        public Guid PersonId { get; private set; }

        private ContactInformation() { }

        public ContactInformation(Guid informationId, InformationType informationType, string informationContent, Guid personId)
        {

            if (string.IsNullOrWhiteSpace(personId.ToString())) throw new ArgumentNullException(nameof(personId));
            if (string.IsNullOrWhiteSpace(informationId.ToString())) throw new ArgumentNullException(nameof(informationId));
            if (string.IsNullOrWhiteSpace(informationContent)) throw new ArgumentNullException(nameof(informationContent));


            Id = personId;
            InformationType = informationType;
            InformationContent = informationContent;
            PersonId = personId;
        }

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
