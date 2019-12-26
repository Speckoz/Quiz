using Quiz.Models;
using Quiz.Services.Helpers;

using Quiz.Dependencies.Enums;
using Quiz.Dependencies.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;

namespace Quiz.Services
{
    public static class QuestionService
    {
        private static readonly List<QuestionModel> _questions = Seed.SeedQuestions();

        public static IQuestion GetRandomQuestion() => _questions[new Random().Next(_questions.Count)];

        public static IQuestion GetRandomQuestion(CategoryEnum category)
        {
            var categoryQuestions = _questions.Where(q => q.Category == category).ToList();
            return categoryQuestions[new Random().Next(categoryQuestions.Count)];
        }
    }
}