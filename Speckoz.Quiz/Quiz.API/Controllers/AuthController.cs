using Microsoft.AspNetCore.Mvc;

using Quiz.API.Models.Auxiliary;

using System;

namespace Speckoz.MobileQuiz.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        // POST: /auth
        [HttpPost]
        public IActionResult GenerateToken(LoginRequestModel login)
        {
            throw new NotImplementedException();
        }
    }
}