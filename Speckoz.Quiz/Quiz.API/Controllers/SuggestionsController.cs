using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Quiz.API.Models;
using Quiz.API.Repository.Interfaces;
using Quiz.Dependencies.Enums;

using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Quiz.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SuggestionsController : ControllerBase
    {
        private readonly IQuestionSuggestionRepository _questionSuggestionRepository;
        private readonly IQuestionsStatusRepository _questionsStatusRepository;

        public SuggestionsController(IQuestionSuggestionRepository questionSuggestionRepository,
            IQuestionsStatusRepository questionsStatusRepository)
        {
            _questionSuggestionRepository = questionSuggestionRepository;
            _questionsStatusRepository = questionsStatusRepository;
        }

        // POST: /suggestions
        [Authorize(Roles = "Normal,Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateNewSuggestion(QuestionSuggestionModel question)
        {
            if (ModelState.IsValid)
            {
                string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                var suggestion = await _questionSuggestionRepository.CreateTaskAync(question);

                await _questionsStatusRepository.CreateTaskAync(new QuestionsStatusModel
                {
                    QuestionID = question.QuestionSuggestionID,
                    QuestionStatus = QuestionStatusEnum.Pending,
                    UserID = int.Parse(userId)
                });
                return Created($"/suggestions/{suggestion.QuestionSuggestionID}", suggestion);
            }
            return BadRequest();
        }

        // GET: /suggestions
        [HttpGet]
        public async Task<IActionResult> GetSuggestions()
        {
            var suggestions = await _questionSuggestionRepository.GetSuggestionsTaskAsync();
            return Ok(suggestions);
        }

        // DELETE: /suggestions/2
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteSuggestion(int id)
        {
            // Coloca o status denied na tabela de status
            QuestionsStatusModel suggestion = await _questionsStatusRepository.FindByIdTaskAsync(id);
            if (suggestion == null) return NoContent();
            suggestion.QuestionStatus = QuestionStatusEnum.Denied;
            await _questionsStatusRepository.UpdateTaskAync(suggestion);

            await _questionSuggestionRepository.DeleteSuggestionTaskAsync(id);
            return NoContent();
        }

        // PUT: /suggestions/approve/2
        [HttpPut("approve/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ApproveSuggestion(int id)
        {
            try
            {
                // Coloca o status approved na tabela de status
                QuestionsStatusModel suggestion = await _questionsStatusRepository.FindByIdTaskAsync(id);
                if (suggestion == null) return BadRequest();
                suggestion.QuestionStatus = QuestionStatusEnum.Approved;
                await _questionsStatusRepository.UpdateTaskAync(suggestion);

                await _questionSuggestionRepository.ApproveSuggestion(id);
                return Ok();
            }
            catch (KeyNotFoundException)
            {
                return BadRequest();
            }
        }

        // GET: /suggestions/status
        [HttpGet("status")]
        public async Task<IActionResult> GetStatus() =>
            Ok(await _questionsStatusRepository.GetQuestionsStatusTaskAsync());
    }
}