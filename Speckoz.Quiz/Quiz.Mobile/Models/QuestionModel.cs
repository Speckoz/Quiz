using Quiz.Dependencies.Enums;
using Quiz.Dependencies.Interfaces;

namespace Quiz.Mobile.Models
{
    public class QuestionModel : IQuestion
    {
        public int? QuestionID { get; set; }

        public string Question { get; set; }

        public string CorrectAnswer { get; set; }

        public virtual CategoryEnum Category { get; set; }

        public virtual string IncorrectAnswers { get; set; }
    }
}