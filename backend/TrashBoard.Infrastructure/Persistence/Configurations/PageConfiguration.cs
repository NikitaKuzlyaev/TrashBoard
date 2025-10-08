using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrashBoard.Domain.Entities;
using TrashBoard.Domain.ValueObjects;


namespace TrashBoard.Infrastructure.Persistence.Configurations
{
    internal class PageConfiguration : IEntityTypeConfiguration<Page>
    {
        public void Configure(EntityTypeBuilder<Page> b)
        {
            b.ToTable("pages");
            b.HasKey(x => x.Id);
            b.Property(x => x.Name).IsRequired().HasMaxLength(Domain.DomainRules.MaxPageLength);
            b.Property(x => x.Content).HasMaxLength(Domain.DomainRules.MaxPageContentLength);
            b.Property(x => x.BoardId).IsRequired();
            b.Property(x => x.Visibility)
                .HasConversion(
                    v => v.ToString(),
                    s => Visibility.ParseVisibility(s))
                .HasColumnName("visibility")
                .IsRequired();
            b.HasOne<Board>()
                .WithMany("Pages")
                .HasForeignKey(x => x.BoardId)
                .OnDelete(DeleteBehavior.Cascade);
            b.Property(x => x.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired();
            b.Property(x => x.UpdatedAt)
                .HasColumnName("updated_at");
        }
    }
}
