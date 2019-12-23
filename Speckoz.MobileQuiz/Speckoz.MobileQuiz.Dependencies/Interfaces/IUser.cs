using System;
using System.Collections.Generic;
using System.Text;

namespace Speckoz.MobileQuiz.Dependencies.Interfaces
{
    public interface IUser
    {
        public int UserID { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public int Level { get; set; }
        public string Password { get; set; }
    }
}
