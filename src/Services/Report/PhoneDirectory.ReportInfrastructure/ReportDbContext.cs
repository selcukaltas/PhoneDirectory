using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PhoneDirectory.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PhoneDirectory.ReportApplicationCore.Domain;

namespace PhoneDirectory.DirectoryInfrastructure
{
    public class ReportDbContext : DbContext
    {

        public ReportDbContext(DbContextOptions<ReportDbContext> options):base(options)
        {

        }


        public DbSet<Report> Reports { get; set; }
        public DbSet<ReportDetail> ReportDetails { get; set; }
    }
}
