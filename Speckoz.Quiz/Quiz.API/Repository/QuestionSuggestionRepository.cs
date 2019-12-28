using Quiz.API.Data;
using Quiz.API.Models;
using System;
using System.Threading.Tasks;
using Quiz.API.Repository.Interfaces;

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
    }
}
