using Microsoft.EntityFrameworkCore;

using Quiz.API.Data;
using Quiz.API.Models;
using Quiz.API.Repository.Interfaces;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quiz.API.Repository
{
    public class QuestionsStatusRepository : IQuestionsStatusRepository
    {
        private readonly ApiContext _context;

        public QuestionsStatusRepository(ApiContext apiContext) => _context = apiContext;

        /// <summary>
        /// Cria um novo status de questão.
        /// </summary>
        /// <param name="status">Modelo do status</param>
        public async Task<QuestionsStatusModel> CreateTaskAync(QuestionsStatusModel status)
        {
            try
            {
                await _context.QuestionsStatus.AddAsync(status);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return status;
        }

        /// <summary>
        /// Deleta um registro de status.
        /// </summary>
        /// <param name="id">ID do registro</param>
        public async Task DeleteAsync(int id)
        {
            QuestionsStatusModel status = await _context.QuestionsStatus.SingleOrDefaultAsync(s => s.QuestionID == id);

            try
            {
                if (status != null)
                {
                    _context.QuestionsStatus.Remove(status);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Recupera todos os status do banco.
        /// </summary>
        public async Task<IEnumerable<QuestionsStatusModel>> GetQuestionsStatusTaskAsync() =>
            await _context.QuestionsStatus.ToListAsync();

        /// <summary>
        /// Procura um registro de status.
        /// </summary>
        /// <param name="id">ID do registro</param>
        /// <returns></returns>
        public async Task<QuestionsStatusModel> FindByIdTaskAsync(int id) =>
            await _context.QuestionsStatus.SingleOrDefaultAsync(s => s.QuestionID == id);

        /// <summary>
        /// Atualiza os dados de um registro
        /// </summary>
        /// <param name="status">Dados atualizados</param>
        public async Task<QuestionsStatusModel> UpdateTaskAync(QuestionsStatusModel status)
        {
            if (!await ExistsTaskAync(status.QuestionID))
                return null;
            try
            {
                _context.Entry(await _context.QuestionsStatus.SingleOrDefaultAsync(s => s.QuestionID == status.QuestionID))
                    .CurrentValues.SetValues(status);
                await _context.SaveChangesAsync();

                return status;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Verifica se um registro existe.
        /// </summary>
        /// <param name="id">ID do registro</param>
        public async Task<bool> ExistsTaskAync(int id) =>
            await _context.QuestionsStatus.AnyAsync(s => s.QuestionID == id);
    }
}