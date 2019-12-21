using Speckoz.MobileQuiz.Dependencies.Enums;

namespace Speckoz.MobileQuiz.Dependencies.Interfaces
{
    public interface IQuestion
    {
        int QuestionID { get; set; }

        string Question { get; set; }

        string CorrectAnswer { get; set; }

        CategoryEnum Category { get; set; }

        string IncorrectAnswers { get; set; }
    }
}