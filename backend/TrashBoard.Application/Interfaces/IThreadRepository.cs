using TrashBoard.Domain.Entities;
using ThreadEntity = TrashBoard.Domain.Entities.Thread;

namespace TrashBoard.Application.Interfaces
{
    public interface IThreadRepository
    {
        Task<ThreadEntity?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task AddAsync(ThreadEntity thread, CancellationToken cancellationToken = default);
        Task RemoveAsync(ThreadEntity thread, CancellationToken cancellationToken = default);
    }
}

