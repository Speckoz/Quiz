using Speckoz.MobileQuiz.Dependencies.Interfaces;

namespace Quiz.Dependencies.Interfaces
{
    public interface IUserLogin
    {
        IUser User { get; set; }
        string Token { get; set; }
    }
}