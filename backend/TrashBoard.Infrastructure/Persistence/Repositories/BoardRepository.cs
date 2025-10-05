using Microsoft.EntityFrameworkCore;
using TrashBoard.Application.Interfaces;
using TrashBoard.Domain.Entities;

namespace TrashBoard.Infrastructure.Persistence
{
    public class BoardRepository : IBoardRepository
    {
        private readonly AppDbContext _db;
        public BoardRepository(AppDbContext db) => _db = db;

        public Task<Board?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
            => _db.Boards.Include(b => b.Pages).FirstOrDefaultAsync(b => b.Id == id, cancellationToken);

        public async Task AddAsync(Board board, CancellationToken cancellationToken = default)
        {
            await _db.Boards.AddAsync(board, cancellationToken);
        }

        public Task RemoveAsync(Board board, CancellationToken cancellationToken = default)
        {
            _db.Boards.Remove(board);
            return Task.CompletedTask;
        }
    }
}

