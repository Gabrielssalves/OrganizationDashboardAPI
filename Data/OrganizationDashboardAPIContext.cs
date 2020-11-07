using Microsoft.EntityFrameworkCore;
using OrganizationDashboardAPI.Models;

namespace OrganizationDashboardAPI.Data
{
    public class OrganizationDashboardAPIContext : DbContext
    {
        public OrganizationDashboardAPIContext(DbContextOptions<OrganizationDashboardAPIContext> opt) : base(opt)
        {

        }
        public DbSet<Space> Spaces { get; set; }
        public DbSet<Commitment> Commitments { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
