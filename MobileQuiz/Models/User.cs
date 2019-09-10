using System;
using System.Collections.Generic;
using System.Text;

namespace MobileQuiz.Models
{
    public class User
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public User(string login, string password)
        {
            this.Login = login;
            this.Password = password;
        }

    }
}
