using Quiz.Dependencies.Enums;

using Speckoz.MobileQuiz.Dependencies.Interfaces;

namespace Quiz.Mobile.Models.Starting
{
    public class UserBase : IUserBase
    {
        public System.Guid UserID { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public int Level { get; set; }

        public string Password { get; set; }

        public UserTypeEnum UserType { get; set; }
    }
}