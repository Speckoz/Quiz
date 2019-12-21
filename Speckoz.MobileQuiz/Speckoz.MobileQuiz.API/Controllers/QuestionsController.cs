using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Speckoz.MobileQuiz.API.Repository.Interfaces;
using Speckoz.MobileQuiz.Dependencies.Enums;

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
        public async Task<IActionResult> GetRandomQuestion(string cat)
        {
            var category = (CategoryEnum)int.Parse(cat);
            var question = await _questionRepository.GetRandomTaskAsync(category);
            return Ok(question);
        }
    }
}