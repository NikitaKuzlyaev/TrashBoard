using Microsoft.EntityFrameworkCore;
using TrashBoard.Domain.Entities;
using TrashBoard.Domain.ValueObjects;
using ThreadEntity = TrashBoard.Domain.Entities.Thread;

namespace TrashBoard.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<ThreadEntity> Threads => Set<ThreadEntity>();
        public DbSet<Board> Boards => Set<Board>();
        public DbSet<Page> Pages => Set<Page>();
        public DbSet<User> Users => Set<User>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Automatic applying of all configurations in (./Configurations)
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}

