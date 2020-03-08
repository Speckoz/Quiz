using Quiz.Dependencies.Enums;

using System;
using System.ComponentModel.DataAnnotations;

namespace Quiz.Dependencies.Models
{
    public class QuestionModel
    {
        public int? QuestionID { get; set; }

        [Required]
        public string Question { get; set; }

        [Required]
        public Guid AuthorID { get; set; }

        [Required]
        public QuestionStatusEnum Status { get; set; } = QuestionStatusEnum.Pending;

        [Required]
        public string CorrectAnswer { get; set; }

        [Required]
        public virtual CategoryEnum Category { get; set; }

        [Required]
        public virtual string IncorrectAnswers { get; set; }
    }
}