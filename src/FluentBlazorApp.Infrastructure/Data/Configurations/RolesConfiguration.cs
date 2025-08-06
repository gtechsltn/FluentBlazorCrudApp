using FluentBlazorApp.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FluentBlazorApp.Infrastructure.Data.Configurations;

public class RolesConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        // Define all configurations for the Role entity here.
        builder.HasKey(u => u.RoleId);

        // Configure unique Rolename
        builder.HasIndex(u => u.Rolename)
               .IsUnique();

        // Configure a string property
        builder.Property(u => u.Rolename)
               .IsRequired()
               .HasMaxLength(50);

        // Other configurations...
    }
}