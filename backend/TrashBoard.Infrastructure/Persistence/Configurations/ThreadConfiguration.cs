using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrashBoard.Domain.Entities;
using TrashBoard.Domain.ValueObjects;
using ThreadEntity = TrashBoard.Domain.Entities.Thread;

namespace TrashBoard.Infrastructure.Persistence.Configurations
{
    internal class ThreadConfiguration : IEntityTypeConfiguration<ThreadEntity>
    {
        public void Configure(EntityTypeBuilder<ThreadEntity> b)
        {
            b.ToTable("threads");
            b.HasKey(x => x.Id);
            b.Property(x => x.Name).IsRequired().HasMaxLength(Domain.DomainRules.MaxThreadnameLength);
            b.Property(x => x.Description).HasMaxLength(Domain.DomainRules.MaxThreadDescriptionLength);
            b.Property(x => x.CreatorId).IsRequired();
            b.Property(x => x.Visibility)
                 .HasConversion(
                     v => v.ToString(),
                     s => Visibility.ParseVisibility(s))
                 .HasColumnName("visibility")
                 .IsRequired();
            b.HasMany(typeof(Board), "Boards");
            b.Property(x => x.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired();
            b.Property(x => x.UpdatedAt)
                .HasColumnName("updated_at");
        }

    }
}
