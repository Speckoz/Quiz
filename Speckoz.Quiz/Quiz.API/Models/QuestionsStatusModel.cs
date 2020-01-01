using Quiz.Dependencies.Enums;
using System.ComponentModel.DataAnnotations;

namespace Quiz.API.Models
{
    public class QuestionsStatusModel
    {
        public int ID { get; set; }

        [Required]
        public int QuestionID { get; set; }

        [Required]
        public int UserID { get; set; }

        [Required]
        public QuestionStatusEnum QuestionStatus { get; set; }
    }
}