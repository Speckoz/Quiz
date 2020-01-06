using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Quiz.API.Models;
using Quiz.API.Repository.Interfaces;
using Quiz.Dependencies.Enums;

using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Quiz.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SuggestionsController : ControllerBase
    {
        private readonly IQuestionRepository _questionsRepository;
        public SuggestionsController(IQuestionRepository questionRepository)
        {
            _questionsRepository = questionRepository;
        }

        // POST: /suggestions
        [Authorize(Roles = "Normal,Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateNewSuggestion(QuestionModel question)
        {
            if (question == null)
                throw new ArgumentNullException(nameof(question));

            if (ModelState.IsValid)
            {
                string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                question.AuthorID = Guid.Parse(userId);
                QuestionModel suggestion = await _questionsRepository.CreateSuggestionTaskAsync(question);

                return Created(new Uri($"/suggestions/{suggestion.QuestionID}"), suggestion);
            }
            return BadRequest();
        }

        // GET: /suggestions
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetSuggestions()
        {
            List<QuestionModel> suggestions = await _questionsRepository.
                GetQuestionsByStatusTaskAsync(QuestionStatusEnum.Pending);

            return Ok(suggestions);
        }

        // DELETE: /suggestions/2
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public Task<IActionResult> DeleteSuggestion(int id)
        {
            throw new NotImplementedException();
        }

        // PUT: /suggestions/approve/2
        [HttpPut("approve/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ApproveSuggestion(int id)
        {
            // Verifica se a questão existe
            var question = await _questionsRepository.FindByID(id);
            if (question == null) return BadRequest();

            question.Status = QuestionStatusEnum.Approved;
            await _questionsRepository.UpdateTaskAsync(question);

            return Ok(question);
        }

        // GET: /suggestions/status
        [HttpGet("status")]
        [Authorize]
        public async Task<IActionResult> GetStatus()
        {
            if (User.HasClaim(ClaimTypes.Role, UserTypeEnum.Admin.ToString()))
            {
                return Ok(await _questionsRepository.GetQuestionsByStatusTaskAsync(QuestionStatusEnum.Pending));
            }

            var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            return Ok(await _questionsRepository.GetQuestionsByStatusTaskAsync(QuestionStatusEnum.Pending, userId));
        }
    }
}