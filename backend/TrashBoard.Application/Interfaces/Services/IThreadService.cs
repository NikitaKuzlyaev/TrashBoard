namespace TrashBoard.Application.Interfaces.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TrashBoard.Application.ResultModels;
    using TrashBoard.Domain.ValueObjects;

    public interface IThreadService
    {
        Task<List<ThreadResult>> GetLatestThreadsAsync(int count = 10);
        Task<ThreadResult?> GetThreadByIdAsync(int threadId);
        Task<ThreadResult> CreateThreadAsync(string name, string description, int creatorId, Visibility visibility);
    }
}
