using MobileQuiz.Models;
using MobileQuiz.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobileQuiz.Services
{
    public class QuestionService
    {
        public List<QuestionModel> questions { get; set; } = Seed.SeedQuestions();

        public QuestionService()
        {
        }

        // Get random question
        public QuestionModel GetRandomQuestion() => questions[new Random().Next(questions.Count)];

        // Get random question by category
        public QuestionModel GetRandomQuestion(string category)
        {
            var aux = questions.Where(q => q.Category == category).ToList();
            return aux[new Random().Next(aux.Count)];
        }
    }
}
