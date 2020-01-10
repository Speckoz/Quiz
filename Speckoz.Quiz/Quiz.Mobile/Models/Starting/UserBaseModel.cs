using Quiz.Dependencies.Enums;

using Speckoz.MobileQuiz.Dependencies.Interfaces;

using System;

namespace Quiz.Mobile.Models.Starting
{
    public class UserBaseModel : IUserBase
    {
        public Guid UserID { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public int Level { get; set; }

        public string Password { get; set; }

        public UserTypeEnum UserType { get; set; }
    }
}