using Microsoft.EntityFrameworkCore;
using TrashBoard.Domain.Entities;
using TrashBoard.Domain.ValueObjects;

namespace TrashBoard.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<Thread> Threads => Set<Thread>();
        public DbSet<Board> Boards => Set<Board>();
        public DbSet<Page> Pages => Set<Page>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Thread>(b =>
            {
                b.ToTable("threads");
                b.HasKey(x => x.Id);
                b.Property(x => x.Name).IsRequired().HasMaxLength(Domain.DomainRules.MaxThreadnameLength);
                b.Property(x => x.Description).HasMaxLength(Domain.DomainRules.MaxThreadDescriptionLength);
                b.Property(x => x.CreatorId).IsRequired();
                b.Property(x => x.Visibility)
                    .HasConversion(v => v.ToString(), s => s switch
                    {
                        "Public" => Visibility.Public,
                        "Protected" => Visibility.Protected,
                        _ => Visibility.Private
                    })
                    .HasColumnName("visibility")
                    .IsRequired();

                b.HasMany(typeof(Board), "Boards");
            });

            modelBuilder.Entity<Board>(b =>
            {
                b.ToTable("boards");
                b.HasKey(x => x.Id);
                b.Property(x => x.Name).IsRequired().HasMaxLength(Domain.DomainRules.MaxBoardnameLength);
                b.Property(x => x.Description).HasMaxLength(Domain.DomainRules.MaxBoardDescriptionLength);
                b.Property(x => x.ThreadId).IsRequired();
                b.Property(x => x.Visibility)
                    .HasConversion(v => v.ToString(), s => s switch
                    {
                        "Public" => Visibility.Public,
                        "Protected" => Visibility.Protected,
                        _ => Visibility.Private
                    })
                    .HasColumnName("visibility")
                    .IsRequired();

                b.HasMany(typeof(Page), "Pages");
                b.HasOne<Thread>()
                    .WithMany("Boards")
                    .HasForeignKey(x => x.ThreadId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Page>(b =>
            {
                b.ToTable("pages");
                b.HasKey(x => x.Id);
                b.Property(x => x.Name).IsRequired().HasMaxLength(Domain.DomainRules.MaxPageLength);
                b.Property(x => x.Content).HasMaxLength(Domain.DomainRules.MaxPageContentLength);
                b.Property(x => x.BoardId).IsRequired();
                b.Property(x => x.Visibility)
                    .HasConversion(v => v.ToString(), s => s switch
                    {
                        "Public" => Visibility.Public,
                        "Protected" => Visibility.Protected,
                        _ => Visibility.Private
                    })
                    .HasColumnName("visibility")
                    .IsRequired();

                b.HasOne<Board>()
                    .WithMany("Pages")
                    .HasForeignKey(x => x.BoardId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}

