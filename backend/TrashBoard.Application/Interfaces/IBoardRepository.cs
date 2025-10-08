using TrashBoard.Domain.Entities;

namespace TrashBoard.Application.Interfaces
{
    public interface IBoardRepository
    {
        Task<Board?> GetByIdAsync(int id, CancellationToken ct = default);
        Task AddAsync(Board board, CancellationToken ct = default);
        Task RemoveAsync(Board board, CancellationToken ct = default);
    }
}

