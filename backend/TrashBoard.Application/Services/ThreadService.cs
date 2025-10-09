using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrashBoard.Application.Interfaces;
using TrashBoard.Application.Interfaces.Services;
using TrashBoard.Application.ResultModels;
using TrashBoard.Domain.Entities;
using TrashBoard.Domain.ValueObjects;
using Thread = TrashBoard.Domain.Entities.Thread;

namespace TrashBoard.Application.Services
{
    public class ThreadService : IThreadService
    {
        private readonly IThreadRepository _threadRepo;

        public ThreadService(IThreadRepository threadRepo)
        {
            _threadRepo = threadRepo;
        }

        public async Task<List<ThreadResult>> GetLatestThreadsAsync(int count = 10)
        {
            var threads = await _threadRepo.GetLatestThreadsAsync(count);

            return threads.Select(t => new ThreadResult
            {
                Id = t.Id,
                Name = t.Name,
                CreatedAt = t.CreatedAt
            }).ToList();
        }

        public async Task<ThreadResult?> GetThreadByIdAsync(int threadId)
        {
            var thread = await _threadRepo.GetByIdAsync(threadId);
            if (thread == null) return null;

            return new ThreadResult
            {
                Id = thread.Id,
                Name = thread.Name,
                CreatedAt = thread.CreatedAt
            };
        }

        public async Task<ThreadResult> CreateThreadAsync(string name, string description, int creatorId, Visibility visibility)
        {
            var thread = new Thread(name, description, creatorId, visibility);

            await _threadRepo.AddAsync(thread);

            return new ThreadResult
            {
                Id = thread.Id,
                Name = thread.Name,
                CreatedAt = thread.CreatedAt
            };
        }

    }

    

}
