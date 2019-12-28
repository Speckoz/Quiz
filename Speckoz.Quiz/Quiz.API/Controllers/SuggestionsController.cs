using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
    }
}