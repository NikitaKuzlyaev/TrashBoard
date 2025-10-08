using Microsoft.AspNetCore.Mvc;
using TrashBoard.Application.Services;

namespace TrashBoard.WebApi.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var token = await _authService.AuthenticateAsync(request.Login, request.Password);
            if (token == null)
                return Unauthorized("Invalid login or password.");

            return Ok(new { access_token = token });
        }
    }

    public record LoginRequest(string Login, string Password);
}
