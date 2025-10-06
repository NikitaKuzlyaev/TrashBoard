using Microsoft.AspNetCore.Mvc;
using System;
using TrashBoard.Infrastructure.Persistence;

namespace TrashBoard.API.Controllers
{
    [ApiController]
    [Route("api/test-db")]
    public class TestDatabaseController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TestDatabaseController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var canConnect = _context.Database.CanConnect();
                return Ok(new { DatabaseConnected = canConnect });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }
    }
}
