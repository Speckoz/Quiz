using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quiz.API.Models;
using Quiz.API.Repository.Interfaces;

namespace Quiz.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SuggestionsController : ControllerBase
    {
        private readonly IQuestionSuggestionRepository _questionSuggestionRepository;

        public SuggestionsController(IQuestionSuggestionRepository questionSuggestionRepository) =>
            _questionSuggestionRepository = questionSuggestionRepository;
        

        // POST: /suggestions
        [HttpPost]
        public async Task<IActionResult> CreateNewSuggestion(QuestionSuggestionModel question)
        {
            if (ModelState.IsValid)
            {
                var suggestion = await _questionSuggestionRepository.CreateTaskAync(question);
                return Created($"/suggestions/{suggestion.QuestionSuggestionID}", suggestion);
            }
            return BadRequest();
        }

        // GET: /suggestions
        [HttpGet]
        public async Task<IActionResult> GetSuggestions()
        {

            var suggestions =  await _questionSuggestionRepository.GetSuggestionsTaskAsync();
            return Ok(suggestions);
        }


        // DELETE: /suggestions/2
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSuggestion(int id)
        {
            await _questionSuggestionRepository.DeleteSuggestionTaskAsync(id);
            return NoContent();
        }

        // PUT: /suggestions/approve/2
        [HttpPut("approve/{id}")]
        public async Task<IActionResult> ApproveSuggestion(int id)
        {
            try
            {
                await _questionSuggestionRepository.ApproveSuggestion(id);
                return Ok();
            }
            catch (KeyNotFoundException)
            {
                return BadRequest();
            }
        }
    }
}