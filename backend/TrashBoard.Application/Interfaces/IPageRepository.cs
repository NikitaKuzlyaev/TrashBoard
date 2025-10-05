using TrashBoard.Domain.Entities;

namespace TrashBoard.Application.Interfaces
{
    public interface IPageRepository
    {
        Task<Page?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task AddAsync(Page page, CancellationToken cancellationToken = default);
        Task RemoveAsync(Page page, CancellationToken cancellationToken = default);
    }
}

