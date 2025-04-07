using Microsoft.EntityFrameworkCore;
using ProjectAccessManagement.Domain.Entities;
using ProjectAccessManagement.Repository.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAccessManagement.Repository
{
    public class ProjectAccessManagementContext : DbContext
    {
        public ProjectAccessManagementContext(DbContextOptions<ProjectAccessManagementContext> options)
            : base(options)
        {
        }

        public DbSet<App> Applications { get; set; }
        public DbSet<Credential> Credentials { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Automation> Automations { get; set; }
        public DbSet<BusinessArea> BusinessAreas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ApplicationConfiguration());
            modelBuilder.ApplyConfiguration(new CredentialConfiguration());
            modelBuilder.ApplyConfiguration(new ModuleConfiguration());
            modelBuilder.ApplyConfiguration(new AutomationConfiguration());
            modelBuilder.ApplyConfiguration(new BusinessAreaConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
