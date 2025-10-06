using Microsoft.EntityFrameworkCore;
using TrashBoard.Application.Interfaces;
using ThreadEntity = TrashBoard.Domain.Entities.Thread;

namespace TrashBoard.Infrastructure.Persistence
{
    public class ThreadRepository : IThreadRepository
    {
        private readonly AppDbContext _db;
        public ThreadRepository(AppDbContext db) => _db = db;

        public Task<ThreadEntity?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
            => _db.Threads.Include(t => t.Boards).ThenInclude(b => b.Pages).FirstOrDefaultAsync(t => t.Id == id, cancellationToken);

        public async Task AddAsync(ThreadEntity thread, CancellationToken cancellationToken = default)
        {
            await _db.Threads.AddAsync(thread, cancellationToken);
        }

        public Task RemoveAsync(ThreadEntity thread, CancellationToken cancellationToken = default)
        {
            _db.Threads.Remove(thread);
            return Task.CompletedTask;
        }
    }
}

