using Microsoft.EntityFrameworkCore;

using Speckoz.MobileQuiz.API.Data;
using Speckoz.MobileQuiz.API.Models;
using Speckoz.MobileQuiz.API.Repository.Interfaces;
using Speckoz.MobileQuiz.Dependencies.Enums;

using System;
using System.Linq;
using System.Threading.Tasks;

namespace Speckoz.MobileQuiz.API.Repository
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly ApiContext _context;

        public QuestionRepository(ApiContext context) => _context = context;

        /// <summary>
        /// Cria uma nova questão no banco de dados
        /// </summary>
        /// <param name="question">Questão</param>
        public async Task<QuestionModel> CreateTaskAsync(QuestionModel question)
        {
            try
            {
                await _context.Questions.AddAsync(question);
                await _context.SaveChangesAsync();
            }
            catch (Exception exc)
            {
                throw exc;
            }

            return question;
        }

        /// <summary>
        /// Deleta um usuario
        /// </summary>
        /// <param name="id">ID do usuario</param>
        public async Task DeleteAsync(int id)
        {
            QuestionModel question = await _context.Questions.SingleOrDefaultAsync(q => q.QuestionID == id);

            try
            {
                if (question != null)
                {
                    _context.Questions.Remove(question);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        /// <summary>
        /// Atualiza os dados de uma questão
        /// </summary>
        /// <param name="question">Questão atualizada</param>
        public async Task<QuestionModel> UpdateTaskAsync(QuestionModel question)
        {
            if (!await ExistsTaskAsync((int)question.QuestionID))
                return null;

            try
            {
                _context.Entry(await _context.Questions
                    .SingleOrDefaultAsync(q => q.QuestionID == question.QuestionID))
                    .CurrentValues.SetValues(question);

                await _context.SaveChangesAsync();

                return question;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        /// <summary>
        /// Retorna uma questão aleatória
        /// </summary>
        /// <param name="category">Categoria da questão</param>
        public async Task<QuestionModel> GetRandomTaskAsync(CategoryEnum category = CategoryEnum.Todas)
        {
            if (category == CategoryEnum.Todas)
            {
                var questionsAll = await _context.Questions.ToListAsync();
                var selectedQuestion = questionsAll[new Random().Next(questionsAll.Count)];

                return selectedQuestion;
            }

            var questionsCategory = await _context.Questions.Where(q => q.Category == category).ToListAsync();
            var selected = questionsCategory[new Random().Next(questionsCategory.Count)];

            return selected;
        }

        /// <summary>
        /// Procura uma questão pelo ID
        /// </summary>
        /// <param name="id">ID da questão</param>
        private async Task<bool> ExistsTaskAsync(int id) =>
            await _context.Questions.AnyAsync(q => q.QuestionID == id);
    }
}