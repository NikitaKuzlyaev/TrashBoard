using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TrashBoard.Application.Interfaces;
using TrashBoard.Domain.Entities;

namespace TrashBoard.Application.Services
{
    public class AuthService
    {
        private readonly IUserRepository _userRepo;
        private readonly PasswordHasher<User> _hasher;
        private readonly IConfiguration _config;

        public AuthService(IUserRepository userRepo, IConfiguration config)
        {
            _userRepo = userRepo;
            _config = config;
            _hasher = new PasswordHasher<User>();
        }

        public async Task<string?> AuthenticateAsync(string login, string password)
        {
            var user = await _userRepo.GetByLoginAsync(login);
            if (user == null)
                return null;

            var verify = _hasher.VerifyHashedPassword(user, GetPasswordHash(user), password);
            if (verify == PasswordVerificationResult.Failed)
                return null;

            return GenerateJwtToken(user);
        }

        private static string GetPasswordHash(User user)
        {
            // Reflection workaround if PasswordHash is private
            var prop = typeof(User).GetProperty("PasswordHash",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            return (string)prop!.GetValue(user)!;
        }

        private string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.GivenName, user.Login)
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1), // todo: make configurable
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
