using Microsoft.AspNetCore.Mvc;

using Quiz.API.Models;
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
        public async Task<IActionResult> GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        // POST /users
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody]UserModel user)
        {
            if (ModelState.IsValid)
            {
                var newUser = await _userRepository.CreateTaskAync(user);
                return Created($"/users/{newUser.UserID}", newUser);
            }

            return BadRequest();
        }
    }
}