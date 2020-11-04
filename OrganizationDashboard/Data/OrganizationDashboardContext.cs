using Microsoft.EntityFrameworkCore;
using OrganizationDashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationDashboard.Data
{
    public class OrganizationDashboardContext : DbContext
    {
        public OrganizationDashboardContext(DbContextOptions<OrganizationDashboardContext> opt) : base(opt)
        {

        }

        public DbSet<Commitment> Commitments { get; set; }
    }
}
