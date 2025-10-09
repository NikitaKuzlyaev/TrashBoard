using Microsoft.AspNetCore.Mvc;
using TrashBoard.Api.DTOs;
using TrashBoard.Application.Interfaces;
using TrashBoard.Application.Interfaces.Services;
using TrashBoard.Application.Services;
using Thread = TrashBoard.Domain.Entities.Thread;

namespace TrashBoard.Api.Controllers
{
    [ApiController]
    [Route("api/thread")]
    public class ThreadController : ControllerBase
    {
        private readonly IThreadService _threadService;
        private readonly IConfiguration _config;

        public ThreadController(IThreadService threadService, IConfiguration config)
        {
            _threadService = threadService;
            _config = config;
        }

        [HttpGet("latest-public")]
        public async Task<ActionResult<List<ThreadDto>>> GetLatestPublicThreads()
        {
            int count = _config.GetValue<int>("LatestThreadsCount", 10);
            var results = await _threadService.GetLatestThreadsAsync(count);

            var dtos = results.Select(r => new ThreadDto
            {
                Id = r.Id,
                Name = r.Name,
                PublishedAt = r.CreatedAt.ToString("O"),
            }).ToList();

            return Ok(dtos);
        }


    }
}
