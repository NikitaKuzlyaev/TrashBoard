using Microsoft.EntityFrameworkCore;
using TrashBoard.Application.Interfaces;
using TrashBoard.Domain.Entities;

namespace TrashBoard.Infrastructure.Persistence.Repositories
{
    public class PageRepository : IPageRepository
    {
        private readonly AppDbContext _db;
        public PageRepository(AppDbContext db) => _db = db;

        public Task<Page?> GetByIdAsync(int id, CancellationToken ct = default)
            => _db.Pages.FirstOrDefaultAsync(p => p.Id == id, ct);

        public async Task AddAsync(Page page, CancellationToken ct = default)
        {
            await _db.Pages.AddAsync(page, ct);
        }

        public Task RemoveAsync(Page page, CancellationToken ct = default)
        {
            _db.Pages.Remove(page);
            return Task.CompletedTask;
        }
    }
}

