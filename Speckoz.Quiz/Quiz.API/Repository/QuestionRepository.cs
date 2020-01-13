using Microsoft.EntityFrameworkCore;

using Quiz.API.Data;
using Quiz.API.Models;
using Quiz.API.Repository.Interfaces;
using Quiz.Dependencies.Enums;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz.API.Repository
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly ApiContext _context;

        public QuestionRepository(ApiContext context) => _context = context;

        /// <summary>
        /// Cria uma nova questão no banco de dados
        /// </summary>
        /// <param name="question">Modelo da Questão</param>
        public async Task<QuestionModel> CreateTaskAsync(QuestionModel question)
        {
            try
            {
                await _context.Questions.AddAsync(question);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return question;
        }

        /// <summary>
        /// Procura uma questão pelo ID
        /// </summary>
        /// <param name="id">ID da questão</param>
        public async Task<QuestionModel> FindByID(int id)
        {
            IQueryable<QuestionModel> query = _context.Questions
                .Where(q => (q.QuestionID == id));

            return await query.FirstOrDefaultAsync();
        }

        /// <summary>
        /// Deleta uma questão.
        /// </summary>
        /// <param name="id">ID da questão</param>
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
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna todas as questão de um determinado status
        /// </summary>
        /// <param name="status">Status da questão</param>
        public async Task<List<QuestionModel>> GetQuestionsByStatusTaskAsync(QuestionStatusEnum status) =>
            await _context.Questions.Where(q => q.Status == status).ToListAsync();

        /// <summary>
        /// Retorna todas as questão de um determinado status de um usuario
        /// </summary>
        /// <param name="status">Status das questões</param>
        /// <param name="userId">ID do usuario</param>
        public async Task<List<QuestionModel>> GetQuestionsByStatusTaskAsync(QuestionStatusEnum status, Guid userId) =>
            await _context.Questions.Where(q => q.Status == status && q.AuthorID == userId).ToListAsync();

        /// <summary>
        /// Atualiza os dados de uma questão
        /// </summary>
        /// <param name="question">Questão atualizada</param>
        public async Task<QuestionModel> UpdateTaskAsync(QuestionModel question)
        {
            if (question == null) throw new ArgumentNullException(nameof(question));

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
            catch (Exception)
            {
                throw;
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
                var questionsAll = await _context.Questions
                    .Where(q => q.Status == QuestionStatusEnum.Approved)
                    .ToListAsync();

                var selectedQuestion = questionsAll[new Random().Next(questionsAll.Count)];

                return selectedQuestion;
            }

            var questionsCategory = await _context.Questions.
                Where(q => q.Status == QuestionStatusEnum.Approved && q.Category == category).
                ToListAsync();

            var selected = questionsCategory[new Random().Next(questionsCategory.Count)];

            return selected;
        }

        /// <summary>
        /// Procura uma questão pelo ID
        /// </summary>
        /// <param name="id">ID da questão</param>
        private async Task<bool> ExistsTaskAsync(int id) =>
            await _context.Questions.AnyAsync(q => q.QuestionID == id);

        /// <summary>
        /// Cria uma nova questão com o status Pending
        /// </summary>
        /// <param name="question">Modelo da questao</param>
        public async Task<QuestionModel> CreateSuggestionTaskAsync(QuestionModel question)
        {
            if (question == null) throw new ArgumentOutOfRangeException(nameof(question));

            try
            {
                question.Status = QuestionStatusEnum.Pending;
                await _context.Questions.AddAsync(question);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return question;
        }

        public Task ApproveSuggestion(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<QuestionModel>> GetQuestionsByUserTaskAsync(Guid userId) =>
            await _context.Questions.Where(q => q.AuthorID == userId).ToListAsync();
    }
}