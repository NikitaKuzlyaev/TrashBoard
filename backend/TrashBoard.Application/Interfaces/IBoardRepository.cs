using TrashBoard.Domain.Entities;

namespace TrashBoard.Application.Interfaces
{
    public interface IBoardRepository
    {
        Task<Board?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task AddAsync(Board board, CancellationToken cancellationToken = default);
        Task RemoveAsync(Board board, CancellationToken cancellationToken = default);
    }
}

