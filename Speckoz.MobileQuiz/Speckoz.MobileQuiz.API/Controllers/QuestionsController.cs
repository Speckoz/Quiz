using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Speckoz.MobileQuiz.API.Repository.Interfaces;

namespace Speckoz.MobileQuiz.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuestionsController : ControllerBase
    {
        private IQuestionRepository _questionRepository;

        public QuestionsController(IQuestionRepository questionRepository) =>
            _questionRepository = questionRepository;
        

        // GET: api/Questions
        [HttpGet]
        public IActionResult GetRandomQuestion()
        {
            return Ok("Salve");
        }
    }
}