using Quiz.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz.API.Repository.Interfaces
{
    public interface IQuestionSuggestionRepository
    {
        Task<QuestionSuggestionModel> CreateTaskAync(QuestionSuggestionModel question);
    }
}
