using TrashBoard.Domain.Entities;

namespace TrashBoard.Application.Interfaces
{
    public interface IPageRepository
    {
        Task<Page?> GetByIdAsync(int id, CancellationToken ct = default);
        Task AddAsync(Page page, CancellationToken ct = default);
        Task RemoveAsync(Page page, CancellationToken ct = default);
    }
}

