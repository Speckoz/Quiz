namespace MobileQuiz.Models
{
    public class QuestionModel
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string CorrectAnswer { get; set; }
        public string Category { get; set; }
        public string IncorrectAnswers { get; set; }
    }
}