using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PhoneDirectory.DirectoryApplicationCore.Domain.PersonAggregate;
using PhoneDirectory.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PhoneDirectory.DirectoryInfrastructure
{
    public class DirectoryDbContext : DbContext
    {

        public DirectoryDbContext(DbContextOptions<DirectoryDbContext> options):base(options)
        {

        }


        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<ContactInformation> ContactInformations { get; set; }

    }
}
