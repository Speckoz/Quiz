using Speckoz.MobileQuiz.Dependencies.Enums;
using Speckoz.MobileQuiz.Dependencies.Interfaces;

namespace MobileQuiz.Models
{
    public class QuestionModel : IQuestion
    {
        public int Id { get; set; }

        public string Question { get; set; }

        public string CorrectAnswer { get; set; }

        public CategoryEnum Category { get; set; }

        public string IncorrectAnswers { get; set; }
    }
}