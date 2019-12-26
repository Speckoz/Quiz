using Quiz.API.Models;
using Quiz.Dependencies.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz.API.Repository.Interfaces
{
    public interface IQuestionRepository
    {
        Task<QuestionModel> CreateTaskAsync(QuestionModel question);
        Task DeleteAsync(int id);
        Task<QuestionModel> UpdateTaskAsync(QuestionModel question);
        Task<QuestionModel> GetRandomTaskAsync(CategoryEnum category = CategoryEnum.Todas);
    }
}
