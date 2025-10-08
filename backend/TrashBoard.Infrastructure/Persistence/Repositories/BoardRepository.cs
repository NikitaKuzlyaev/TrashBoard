using Microsoft.EntityFrameworkCore;
using TrashBoard.Application.Interfaces;
using TrashBoard.Domain.Entities;

namespace TrashBoard.Infrastructure.Persistence.Repositories
{
    public class BoardRepository : IBoardRepository
    {
        private readonly AppDbContext _db;
        public BoardRepository(AppDbContext db) => _db = db;

        public Task<Board?> GetByIdAsync(int id, CancellationToken ct = default)
            => _db.Boards.Include(b => b.Pages).FirstOrDefaultAsync(b => b.Id == id, ct);

        public async Task AddAsync(Board board, CancellationToken ct = default)
        {
            await _db.Boards.AddAsync(board, ct);
        }

        public Task RemoveAsync(Board board, CancellationToken ct = default)
        {
            _db.Boards.Remove(board);
            return Task.CompletedTask;
        }
    }
}

