using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

using Quiz.API.Models.Auxiliary;
using Quiz.API.Repository.Interfaces;

using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Speckoz.MobileQuiz.API.Controllers
{
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
            var user = await _userRepository.FindUserTaskAsync(login.Login, login.Password);
            if (user == null) return BadRequest();

            var token = new JwtSecurityToken(
                issuer: "Speckoz",
                audience: "Speckoz",
                claims: new[]
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.UserType.ToString()),
                },
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecurityKey"])),
                    SecurityAlgorithms.HmacSha256
                ));

            var stringToken = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(new { user, token = stringToken });
        }
    }
}