namespace MobileQuiz.Models
{
    public enum CategoryEnum
    {
        Todas, Ciencia, Arte, Historia, Geograria, Esporte
    }

    public class QuestionModel
    {
        public int Id { get; set; }

        public string Question { get; set; }

        public string CorrectAnswer { get; set; }

        public CategoryEnum Category { get; set; }

        public string IncorrectAnswers { get; set; }
    }
}