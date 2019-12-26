using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Speckoz.MobileQuiz.Dependencies.Auxiliary;


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