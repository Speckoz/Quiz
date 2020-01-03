using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

using Quiz.API.Models;
using Quiz.API.Repository.Interfaces;
using Quiz.Dependencies.Models.Auxiliary;

using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Speckoz.MobileQuiz.API.Controllers
{
    [AllowAnonymous]
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public AuthController(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        // POST: /auth
        [HttpPost]
        public async Task<IActionResult> GenerateToken(LoginRequestModel login)
        {
            UserBaseModel user = await _userRepository.FindUserTaskAsync(login.Login, login.Password);
            if (user == null) return BadRequest();

            var token = new JwtSecurityToken(
                issuer: "Speckoz",
                audience: "Speckoz",
                claims: new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.UserID.ToString()),
                    new Claim(ClaimTypes.Role, user.UserType.ToString()),
                },
                expires: DateTime.Now.AddYears(2),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecurityKey"])),
                    SecurityAlgorithms.HmacSha256
                ));

            return base.Ok(new { user, token = new JwtSecurityTokenHandler().WriteToken(token) });
        }
    }
}