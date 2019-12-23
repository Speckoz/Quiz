using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Speckoz.MobileQuiz.API.Models;

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
