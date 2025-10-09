using TrashBoard.Domain.Entities;
using ThreadEntity = TrashBoard.Domain.Entities.Thread;

namespace TrashBoard.Application.Interfaces
{
    public interface IThreadRepository
    {
        Task<ThreadEntity?> GetByIdAsync(int id, CancellationToken ct = default);
        Task AddAsync(ThreadEntity thread, CancellationToken ct = default);
        Task RemoveAsync(ThreadEntity thread, CancellationToken ct = default);
        Task<List<ThreadEntity>> GetLatestThreadsAsync(int count, CancellationToken ct = default);
    }
}

