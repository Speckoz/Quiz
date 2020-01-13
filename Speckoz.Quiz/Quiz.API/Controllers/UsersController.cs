using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Quiz.API.Repository.Interfaces;

using System;
using System.Threading.Tasks;

namespace Speckoz.MobileQuiz.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository) => _userRepository = userRepository;

        // GET: /users/2
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public Task<IActionResult> GetUserById(Guid id)
        {
            throw new NotImplementedException();
        }

        // DELETE: /users/2
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            await _userRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}