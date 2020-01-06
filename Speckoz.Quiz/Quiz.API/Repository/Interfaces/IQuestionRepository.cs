using Quiz.API.Models;
using Quiz.Dependencies.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quiz.API.Repository.Interfaces
{
    public interface IQuestionRepository
    {
        Task<QuestionModel> CreateTaskAsync(QuestionModel question);

        Task<QuestionModel> CreateSuggestionTaskAsync(QuestionModel question);
        Task DeleteAsync(int id);

        Task<QuestionModel> UpdateTaskAsync(QuestionModel question);

        Task<QuestionModel> GetRandomTaskAsync(CategoryEnum category = CategoryEnum.Todas);

        Task<List<QuestionModel>> GetQuestionsByStatusTaskAsync(QuestionStatusEnum status);
        Task<List<QuestionModel>> GetQuestionsByStatusTaskAsync(QuestionStatusEnum pending, Guid userId);
        Task<QuestionModel> FindByID(int id);
        Task ApproveSuggestion(int id);
    }
}