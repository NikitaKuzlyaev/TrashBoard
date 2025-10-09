using Microsoft.EntityFrameworkCore;
using TrashBoard.Application.Interfaces;
using ThreadEntity = TrashBoard.Domain.Entities.Thread;
using TrashBoard.Domain.ValueObjects;

namespace TrashBoard.Infrastructure.Persistence.Repositories
{
    public class ThreadRepository : IThreadRepository
    {
        private readonly AppDbContext _db;
        public ThreadRepository(AppDbContext db) => _db = db;

        public Task<ThreadEntity?> GetByIdAsync(int id, CancellationToken ct = default)
            => _db.Threads.Include(t => t.Boards).ThenInclude(b => b.Pages).FirstOrDefaultAsync(t => t.Id == id, ct);

        public async Task AddAsync(ThreadEntity thread, CancellationToken ct = default)
        {
            await _db.Threads.AddAsync(thread, ct);
        }

        public Task RemoveAsync(ThreadEntity thread, CancellationToken ct = default)
        {
            _db.Threads.Remove(thread);
            return Task.CompletedTask;
        }

        public async Task<List<ThreadEntity>> GetLatestThreadsAsync(int count, CancellationToken ct = default)
        {
            return await _db.Threads
                .Where(t => t.Visibility == Visibility.Public)
                .OrderByDescending(t => t.CreatedAt)
                .Take(count)
                .ToListAsync(ct);
        }
    }
}

