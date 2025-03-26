using Microsoft.EntityFrameworkCore;
using ProjectAccessManagement.Domain.Entities;
using ProjectAccessManagement.Infrastructure.Data.Configurations;

namespace ProjectAccessManagement.Infrastructure.Data
{
    public class ProjectAccessManagementContext : DbContext
    {
        public ProjectAccessManagementContext(DbContextOptions<ProjectAccessManagementContext> options)
            : base(options)
        {
        }

        public DbSet<Application> Applications { get; set; }
        public DbSet<Credential> Credentials { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Automation> Automations { get; set; }
        public DbSet<BusinessArea> BusinessAreas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CredentialConfiguration());
            modelBuilder.ApplyConfiguration(new AutomationConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
} 