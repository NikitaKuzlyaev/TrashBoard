using Microsoft.AspNetCore.Mvc;

namespace TrashBoard.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RandomController : ControllerBase
    {
        private static readonly Random RandomGenerator = new Random();

        [HttpGet]
        public IActionResult Get()
        {
            var value = RandomGenerator.Next(1, 101);
            return Ok(new { value });
        }
    }
}


