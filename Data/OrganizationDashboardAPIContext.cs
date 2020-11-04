﻿using Microsoft.EntityFrameworkCore;
using OrganizationDashboardAPI.Models;

namespace OrganizationDashboardAPI.Data
{
    public class OrganizationDashboardAPIContext : DbContext
    {
        public OrganizationDashboardAPIContext(DbContextOptions<OrganizationDashboardAPIContext> opt) : base(opt)
        {

        }
        public DbSet<Commitment> Commitments { get; set; }
    }
}
