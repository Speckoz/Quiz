using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quiz.API.Models;
using Quiz.API.Models.Auxiliary;
using Quiz.API.Repository.Interfaces;
using Quiz.Dependencies.Enums;

namespace Quiz.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public RegisterController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // POST: /Register
        [HttpPost]
        public async Task<IActionResult> Register([FromBody]RegisterRequestModel user)
        {
            if (ModelState.IsValid)
            {
                var createdUser = await _userRepository.CreateTaskAync(new UserModel 
                {
                    Email = user.Email,
                    Level = 0,
                    Password = user.Password,
                    Username = user.Username,
                    UserType = UserTypeEnum.Normal
                });

                return Created($"/users/{createdUser.UserID}", createdUser);
            }
            return BadRequest();
        }
    }
}