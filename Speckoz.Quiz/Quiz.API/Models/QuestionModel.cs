using Quiz.Dependencies.Enums;
using Quiz.Dependencies.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace Quiz.API.Models
{
    public class QuestionModel : IQuestion
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
        public CategoryEnum Category { get; set; }

        [Required]
        public string IncorrectAnswers { get; set; }
    }
}