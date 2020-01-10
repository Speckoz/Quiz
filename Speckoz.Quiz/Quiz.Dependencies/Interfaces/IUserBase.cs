using Quiz.Dependencies.Enums;

using System;

namespace Speckoz.MobileQuiz.Dependencies.Interfaces
{
    public interface IUserBase
    {
        public Guid UserID { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public int Level { get; set; }
        public UserTypeEnum UserType { get; set; }
    }
}