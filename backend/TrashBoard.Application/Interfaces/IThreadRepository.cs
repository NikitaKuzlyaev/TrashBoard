using TrashBoard.Domain.Entities;

namespace TrashBoard.Application.Interfaces
{
    public interface IThreadRepository
    {
        Task<Thread?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task AddAsync(Thread thread, CancellationToken cancellationToken = default);
        Task RemoveAsync(Thread thread, CancellationToken cancellationToken = default);
    }
}

