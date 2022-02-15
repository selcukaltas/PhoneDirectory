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

        private readonly List<ContactInformation> _items = new ();
        public IReadOnlyCollection<ContactInformation> Items => _items.AsReadOnly();
    }
}
