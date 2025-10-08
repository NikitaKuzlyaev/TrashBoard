using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrashBoard.Domain.Entities;
using TrashBoard.Domain.ValueObjects;
using ThreadEntity = TrashBoard.Domain.Entities.Thread;

namespace TrashBoard.Infrastructure.Persistence.Configurations
{
    internal class BoardConfiguration : IEntityTypeConfiguration<Board>
    {
        public void Configure(EntityTypeBuilder<Board> b)
        {
            b.ToTable("boards");
            b.HasKey(x => x.Id);
            b.Property(x => x.Name).IsRequired().HasMaxLength(Domain.DomainRules.MaxBoardnameLength);
            b.Property(x => x.Description).HasMaxLength(Domain.DomainRules.MaxBoardDescriptionLength);
            b.Property(x => x.ThreadId).IsRequired();
            b.Property(x => x.Visibility)
                .HasConversion(
                    v => v.ToString(),
                    s => Visibility.ParseVisibility(s))
                .HasColumnName("visibility")
                .IsRequired();
            b.HasMany(typeof(Page), "Pages");
            b.HasOne<ThreadEntity>()
                .WithMany("Boards")
                .HasForeignKey(x => x.ThreadId)
                .OnDelete(DeleteBehavior.Cascade);
            b.Property(x => x.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired();
            b.Property(x => x.UpdatedAt)
                .HasColumnName("updated_at");
        }
    }
}

