using Microsoft.EntityFrameworkCore;
using TrashBoard.Application.Interfaces;
using TrashBoard.Domain.Entities;

namespace TrashBoard.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _db;
        public UserRepository(AppDbContext db) => _db = db;

        public Task<User?> GetByIdAsync(int id, CancellationToken ct = default)
            => _db.Users.FirstOrDefaultAsync(p => p.Id == id, ct);

        public async Task AddAsync(User user, CancellationToken ct = default)
        {
            await _db.Users.AddAsync(user, ct);
        }

        public Task RemoveAsync(User user, CancellationToken ct = default)
        {
            _db.Users.Remove(user);
            return Task.CompletedTask;
        }

        public async Task<User?> GetByLoginAsync(string login, CancellationToken ct = default)
        {
            return await _db.Users.FirstOrDefaultAsync(u => u.Login == login, ct);
        }

        public async Task SaveChangesAsync(CancellationToken ct = default)
        {
            await _db.SaveChangesAsync(ct);
        }

    }
}

