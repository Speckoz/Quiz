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

        public async Task DeleteAsync(int id)
        {
            QuestionsStatusModel status = await _context.QuestionsStatus.SingleOrDefaultAsync(s => s.ID == id);

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

        public async Task<IEnumerable<QuestionsStatusModel>> GetQuestionsStatusTaskAsync() =>
            await _context.QuestionsStatus.ToListAsync();

        public async Task<QuestionsStatusModel> FindByIdTaskAsync(int id) =>
            await _context.QuestionsStatus.SingleOrDefaultAsync(s => s.ID == id);

        public async Task<QuestionsStatusModel> UpdateTaskAync(QuestionsStatusModel status)
        {
            if (!await ExistsTaskAync(status.ID))
                return null;
            try
            {
                _context.Entry(await _context.QuestionsStatus.SingleOrDefaultAsync(s => s.ID == status.ID))
                    .CurrentValues.SetValues(status);
                await _context.SaveChangesAsync();

                return status;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ExistsTaskAync(int id) =>
            await _context.QuestionsStatus.AnyAsync(s => s.ID == id);

        public async Task<IEnumerable<QuestionsStatusModel>> GetStatus() =>
            await _context.QuestionsStatus.ToListAsync();
    }
}