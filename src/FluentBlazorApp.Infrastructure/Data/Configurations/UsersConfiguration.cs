using FluentBlazorApp.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FluentBlazorApp.Infrastructure.Data.Configurations;

public class UsersConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        // Define all configurations for the User entity here.
        // Configure: UserId
        builder.HasKey(u => u.UserId);

        // Configure: Username
        builder.Property(u => u.Username)
               .IsRequired()
               .HasMaxLength(50);

        // Configure: UsernameToLower
        builder.Property(u => u.UsernameToLower)
               .IsRequired()
               .HasMaxLength(50);

        // Configure: UsernameToLower: UNIQUE
        builder.HasIndex(u => u.UsernameToLower)
               .IsUnique();

        // Configure: Email
        builder.Property(u => u.Email)
              .IsRequired()
              .HasMaxLength(50);

        // Configure: EmailToLower
        builder.Property(u => u.EmailToLower)
              .IsRequired()
              .HasMaxLength(50);

        // Configure: EmailToLower: UNIQUE
        builder.HasIndex(u => u.EmailToLower)
               .IsUnique();

        // Other configurations...
    }
}