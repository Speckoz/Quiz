using Quiz.Dependencies.Enums;
using Quiz.Dependencies.Interfaces;

using System.Text.Json.Serialization;

namespace Quiz.Models
{
    public class QuestionModel : IQuestion
    {
        [JsonPropertyName("questionID")]
        public int? QuestionID { get; set; }

        [JsonPropertyName("question")]
        public string Question { get; set; }

        [JsonPropertyName("correctAnswer")]
        public string CorrectAnswer { get; set; }

        [JsonPropertyName("category")]
        public virtual CategoryEnum Category { get; set; }

        [JsonPropertyName("incorrectAnswers")]
        public virtual string IncorrectAnswers { get; set; }
    }
}