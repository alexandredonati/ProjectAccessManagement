using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectAccessManagement.Domain.Entities;

namespace ProjectAccessManagement.Repository.Configurations
{
    public class ModuleConfiguration : IEntityTypeConfiguration<Module>
    {
        public void Configure(EntityTypeBuilder<Module> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasOne(m => m.Application)
                .WithMany(a => a.Modules)
                .HasForeignKey("ApplicationId")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
} 