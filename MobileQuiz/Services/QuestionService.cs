using MobileQuiz.Models;
using MobileQuiz.Services.Helpers;

using System;
using System.Collections.Generic;
using System.Linq;

namespace MobileQuiz.Services
{
    public static class QuestionService
    {
        private static readonly List<QuestionModel> _questions = Seed.SeedQuestions();

        public static QuestionModel GetRandomQuestion() => _questions[new Random().Next(_questions.Count)];

        public static QuestionModel GetRandomQuestion(CategoryEnum category)
        {
            var categoryQuestions = _questions.Where(q => q.Category == category).ToList();
            return categoryQuestions[new Random().Next(categoryQuestions.Count)];
        }
    }
}