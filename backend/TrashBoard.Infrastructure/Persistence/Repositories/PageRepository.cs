using Microsoft.EntityFrameworkCore;
using TrashBoard.Application.Interfaces;
using TrashBoard.Domain.Entities;

namespace TrashBoard.Infrastructure.Persistence
{
    public class PageRepository : IPageRepository
    {
        private readonly AppDbContext _db;
        public PageRepository(AppDbContext db) => _db = db;

        public Task<Page?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
            => _db.Pages.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

        public async Task AddAsync(Page page, CancellationToken cancellationToken = default)
        {
            await _db.Pages.AddAsync(page, cancellationToken);
        }

        public Task RemoveAsync(Page page, CancellationToken cancellationToken = default)
        {
            _db.Pages.Remove(page);
            return Task.CompletedTask;
        }
    }
}

