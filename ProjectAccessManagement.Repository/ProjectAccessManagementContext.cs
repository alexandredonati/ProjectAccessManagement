using Microsoft.EntityFrameworkCore;
using ProjectAccessManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAccessManagement.Repository
{
    public class ProjectAccessManagementContext : DbContext
    {
        public ProjectAccessManagementContext(DbContextOptions<ProjectAccessManagementContext> options) : base(options)
        {
        }
        public DbSet<BusinessArea> BusinessAreas { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Automation> Automations { get; set; }
        public DbSet<Credential> Credentials { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
