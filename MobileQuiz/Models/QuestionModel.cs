using Newtonsoft.Json;

namespace MobileQuiz.Models
{
    public class QuestionModel
    {
        public string Id { get; set; }

        public string Question { get; set; }

        public string CorrectAnswer { get; set; }

        public string Category { get; set; }

        public string IncorrectAnswers { get; set; }
    }
}