using Quiz.Dependencies.Enums;

using System.ComponentModel.DataAnnotations;

namespace Quiz.API.Models
{
    public class QuestionSuggestionModel
    {
        public int QuestionSuggestionID { get; set; }

        [Required]
        public string Question { get; set; }

        [Required]
        public string CorrectAnswer { get; set; }

        [Required]
        public CategoryEnum Category { get; set; }

        [Required]
        public string IncorrectAnswers { get; set; }
    }
}