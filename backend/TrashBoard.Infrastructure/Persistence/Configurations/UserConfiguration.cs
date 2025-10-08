using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrashBoard.Domain.Entities;

namespace TrashBoard.Infrastructure.Persistence.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> b)
        {
            b.ToTable("users");
            b.HasKey(x => x.Id);
            b.Property(x => x.Username).IsRequired().HasMaxLength(Domain.DomainRules.MaxUsernameLength);
            b.Property(x => x.Login).IsRequired().HasMaxLength(Domain.DomainRules.MaxLoginLength);
            b.Property<string>("PasswordHash")
                .HasColumnName("password_hash")
                .IsRequired();
            b.HasIndex(x => x.Login)
                .IsUnique();
            b.Property(x => x.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired();
            b.Property(x => x.UpdatedAt)
                .HasColumnName("updated_at");
        }
    }
}
