using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Quiz.API.Repository.Interfaces;
using Quiz.Dependencies.Enums;
using Quiz.Dependencies.Models;

using System;
using System.Threading.Tasks;

namespace Speckoz.MobileQuiz.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuestionsController : ControllerBase
    {
        private IQuestionRepository _questionRepository;

        public QuestionsController(IQuestionRepository questionRepository) =>
            _questionRepository = questionRepository;

        // GET: /Questions
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetRandomQuestion(string cat = "0")
        {
            // Verifica se a categoria existe, senao atribui como categoria 0
            CategoryEnum category = Enum.IsDefined(typeof(CategoryEnum), int.Parse(cat)) ? (CategoryEnum)int.Parse(cat) : 0;
            QuestionModel question = await _questionRepository.GetRandomTaskAsync(category);
            return Ok(question);
        }

        // GET: /Questions/2
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetQuestionById(int id)
        {
            QuestionModel question = await _questionRepository.FindByID(id);
            return question == null ? NotFound() : (IActionResult)Ok(question);
        }

        // Delete /Questions/12
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            await _questionRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}