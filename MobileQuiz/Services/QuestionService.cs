using MobileQuiz.Models;
using MobileQuiz.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobileQuiz.Services
{
    public static class QuestionService
    {
        public static List<QuestionModel> Questions { get; set; } = Seed.SeedQuestions();

        // Get random question
        public static QuestionModel GetRandomQuestion() => Questions[new Random().Next(Questions.Count)];

        // Get random question by category
        public static QuestionModel GetRandomQuestion(string category)
        {
            var categoryQuestions = Questions.Where(q => q.Category == category).ToList();
            return categoryQuestions[new Random().Next(categoryQuestions.Count)];
        }
    }
}
