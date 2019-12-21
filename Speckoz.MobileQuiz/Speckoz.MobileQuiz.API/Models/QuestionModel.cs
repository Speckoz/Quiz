using Speckoz.MobileQuiz.Dependencies.Enums;
using Speckoz.MobileQuiz.Dependencies.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Speckoz.MobileQuiz.API.Models
{
    public class QuestionModel : IQuestion
    {
        public int QuestionID { get; set; }
        [Required]
        public string Question { get; set; }
        [Required]
        public string CorrectAnswer { get; set; }
        [Required]
        public CategoryEnum Category { get; set; }
        [Required]
        public string IncorrectAnswers { get; set; }

        public static implicit operator QuestionModel(List<QuestionModel> v)
        {
            throw new NotImplementedException();
        }
    }
}
