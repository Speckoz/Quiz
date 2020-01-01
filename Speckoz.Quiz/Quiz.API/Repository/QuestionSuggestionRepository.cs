using Microsoft.EntityFrameworkCore;

using Quiz.API.Data;
using Quiz.API.Models;
using Quiz.API.Repository.Interfaces;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quiz.API.Repository
{
    public class QuestionSuggestionRepository : IQuestionSuggestionRepository
    {
        private readonly ApiContext _context;

        public QuestionSuggestionRepository(ApiContext context) => _context = context;

        /// <summary>
        /// Cria uma nova sugestão de questão.
        /// </summary>
        /// <param name="question">Dados da questão</param>
        public async Task<QuestionSuggestionModel> CreateTaskAync(QuestionSuggestionModel question)
        {
            try
            {
                await _context.Suggestions.AddAsync(question);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return question;
        }

        /// <summary>
        /// Recupera todas as sugestões de questão.
        /// </summary>
        public async Task<List<QuestionSuggestionModel>> GetSuggestionsTaskAsync() =>
            await _context.Suggestions.ToListAsync();

        /// <summary>
        /// Deleta uma sugestao
        /// </summary>
        /// <param name="id">ID da sugestao</param>
        public async Task DeleteSuggestionTaskAsync(int id)
        {
            QuestionSuggestionModel suggestion = await _context.Suggestions.SingleOrDefaultAsync(s => s.QuestionSuggestionID == id);

            try
            {
                if (suggestion != null)
                {
                    _context.Suggestions.Remove(suggestion);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        /// <summary>
        /// Procura uma sugestao pelo ID
        /// </summary>
        /// <param name="id">ID da sugestao</param>
        public async Task<QuestionSuggestionModel> FindById(int id)
        {
            return await _context.Suggestions.SingleOrDefaultAsync(s => s.QuestionSuggestionID == id);
        }

        /// <summary>
        /// Aprova uma sugestão
        /// </summary>
        /// <param name="id">ID da sugestão</param>
        public async Task ApproveSuggestion(int id)
        {
            QuestionSuggestionModel suggestion = await FindById(id);
            if (suggestion == null) throw new KeyNotFoundException();

            await _context.Questions.AddAsync(new QuestionModel
            {
                Category = suggestion.Category,
                CorrectAnswer = suggestion.CorrectAnswer,
                IncorrectAnswers = suggestion.IncorrectAnswers,
                Question = suggestion.Question
            });

            await DeleteSuggestionTaskAsync(id);
            await _context.SaveChangesAsync();
        }
    }
}