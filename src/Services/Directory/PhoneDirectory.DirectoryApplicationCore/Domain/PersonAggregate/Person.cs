using PhoneDirectory.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDirectory.DirectoryApplicationCore.Domain.PersonAggregate
{
    public class Person : IAggregateRoot, IEntity
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Company { get; private set; }

        private readonly List<ContactInformation> _contactInformations = new ();
        public IReadOnlyCollection<ContactInformation> ContactInformations => _contactInformations.AsReadOnly();


        private Person() { } //Ef Required

        public Person( string name, string surname,string company)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            if (string.IsNullOrWhiteSpace(company)) throw new ArgumentNullException(nameof(company));
            if (string.IsNullOrWhiteSpace(surname)) throw new ArgumentNullException(nameof(surname));



            Name = name;
            Surname = surname;
            Company = company;
        }
    }
}
