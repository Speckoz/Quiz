using Quiz.API.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quiz.API.Repository.Interfaces
{
    public interface IQuestionsStatusRepository
    {
        Task<QuestionsStatusModel> CreateTaskAync(QuestionsStatusModel status);

        Task<IEnumerable<QuestionsStatusModel>> GetQuestionsStatusTaskAsync();

        Task DeleteAsync(int id);

        Task<QuestionsStatusModel> FindByIdTaskAsync(int id);

        Task<QuestionsStatusModel> UpdateTaskAync(QuestionsStatusModel status);

        Task<IEnumerable<QuestionsStatusModel>> GetStatus();
    }
}