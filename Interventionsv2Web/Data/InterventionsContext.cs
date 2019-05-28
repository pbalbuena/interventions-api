using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interventionsv2Web.Models;

namespace Interventionsv2Web.Data
{
    public class InterventionsContext : DbContext
    {
        public InterventionsContext(DbContextOptions<InterventionsContext> options) : base(options)
        {
        }

        public DbSet<Interventionsv2Web.Models.System> Systems { get; set; }

        public DbSet<Interventionsv2Web.Models.Employee> Employee { get; set; }

        public DbSet<Interventionsv2Web.Models.Intervention> Intervention { get; set; }
    }
}
