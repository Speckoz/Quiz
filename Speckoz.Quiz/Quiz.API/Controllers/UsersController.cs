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
        public Task<IActionResult> GetUserById(int id)
        {
            throw new NotImplementedException();
        }
    }
}