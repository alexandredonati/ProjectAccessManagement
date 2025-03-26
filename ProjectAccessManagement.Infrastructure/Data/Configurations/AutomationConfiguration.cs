using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectAccessManagement.Domain.Entities;

namespace ProjectAccessManagement.Infrastructure.Data.Configurations
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
                .WithMany()
                .HasForeignKey("BusinessAreaId")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired()
                .Metadata.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.HasMany(a => a.Modules)
                .WithMany()
                .UsingEntity(j => j.ToTable("AutomationModules"));

            builder.HasMany(a => a.Credentials)
                .WithMany()
                .UsingEntity(j => j.ToTable("AutomationCredentials"));
        }
    }
} 