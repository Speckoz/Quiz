namespace MobileQuiz.Models
{
    public class QuestionModel
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string CorrectAnswer { get; set; }
        public string Category { get; set; }
        public string IncorrectAnswers { get; set; }

        public QuestionModel()
        {
        }

        public QuestionModel(int id, string question, string correctAnswer, string category, string incorrectAnswers)
        {
            Id = id;
            Question = question;
            CorrectAnswer = correctAnswer;
            Category = category;
            IncorrectAnswers = incorrectAnswers;
        }
    }
}