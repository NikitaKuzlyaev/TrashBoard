using Microsoft.EntityFrameworkCore;
using TrashBoard.Application.Interfaces;
using TrashBoard.Domain.Entities;

namespace TrashBoard.Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _db;
        public UserRepository(AppDbContext db) => _db = db;

        public Task<User?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
            => _db.Users.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

        public async Task AddAsync(User user, CancellationToken cancellationToken = default)
        {
            await _db.Users.AddAsync(user, cancellationToken);
        }

        public Task RemoveAsync(User user, CancellationToken cancellationToken = default)
        {
            _db.Users.Remove(user);
            return Task.CompletedTask;
        }
    }
}

