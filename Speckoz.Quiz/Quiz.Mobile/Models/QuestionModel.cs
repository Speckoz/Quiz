using Quiz.Dependencies.Enums;
using Quiz.Dependencies.Interfaces;

namespace Quiz.Models
{
    public class QuestionModel : IQuestion
    {
        public int? QuestionID { get; set; }

        public string Question { get; set; }

        public string CorrectAnswer { get; set; }

        public CategoryEnum Category { get; set; }

        public string IncorrectAnswers { get; set; }
    }
}