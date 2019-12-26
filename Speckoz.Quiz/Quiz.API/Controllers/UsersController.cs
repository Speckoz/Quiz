using Microsoft.AspNetCore.Mvc;

using Quiz.API.Models;

using System;
using System.Threading.Tasks;

namespace Speckoz.MobileQuiz.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
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
            }

            throw new NotImplementedException();
        }
    }
}