using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectAccessManagement.Domain.Entities;

namespace ProjectAccessManagement.Repository.Configurations
{
    public class AutomationConfiguration : IEntityTypeConfiguration<Automation>
    {
        public void Configure(EntityTypeBuilder<Automation> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.BusinessId)
                .IsRequired();

            builder.HasOne(a => a.BusinessArea)
                .WithMany(b => b.Automations)
                .HasForeignKey("BusinessAreaId")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasMany(a => a.Modules)
                .WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "AutomationModules",
                    j => j.HasOne<Module>().WithMany().HasForeignKey("ModuleId").OnDelete(DeleteBehavior.Cascade),
                    j => j.HasOne<Automation>().WithMany().HasForeignKey("AutomationId").OnDelete(DeleteBehavior.NoAction)
                );

            builder.HasMany(a => a.Credentials)
                .WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "AutomationCredentials",
                    j => j.HasOne<Credential>().WithMany().HasForeignKey("CredentialId").OnDelete(DeleteBehavior.Cascade),
                    j => j.HasOne<Automation>().WithMany().HasForeignKey("AutomationId").OnDelete(DeleteBehavior.NoAction)
                );
        }
    }
} 