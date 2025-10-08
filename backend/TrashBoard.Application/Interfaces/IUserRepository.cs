using TrashBoard.Domain.Entities;

namespace TrashBoard.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<User?> GetByLoginAsync(string login, CancellationToken ct = default);
        Task SaveChangesAsync(CancellationToken ct = default);
        Task AddAsync(User user, CancellationToken ct = default);
        Task RemoveAsync(User user, CancellationToken ct = default);
    }
}

