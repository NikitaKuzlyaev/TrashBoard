using Microsoft.EntityFrameworkCore;
using TrashBoard.Application.Interfaces;
using TrashBoard.Domain.Entities;

namespace TrashBoard.Infrastructure.Persistence
{
    public class ThreadRepository : IThreadRepository
    {
        private readonly AppDbContext _db;
        public ThreadRepository(AppDbContext db) => _db = db;

        public Task<Thread?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
            => _db.Threads.Include(t => t.Boards).ThenInclude(b => b.Pages).FirstOrDefaultAsync(t => t.Id == id, cancellationToken);

        public async Task AddAsync(Thread thread, CancellationToken cancellationToken = default)
        {
            await _db.Threads.AddAsync(thread, cancellationToken);
        }

        public Task RemoveAsync(Thread thread, CancellationToken cancellationToken = default)
        {
            _db.Threads.Remove(thread);
            return Task.CompletedTask;
        }
    }
}

