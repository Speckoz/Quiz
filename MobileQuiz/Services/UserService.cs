using MobileQuiz.Models;
using MobileQuiz.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobileQuiz.Services
{
    public class UserService
    {
        public List<UserModel> users { get; set; } = Seed.SeedUsers();

        public UserService()
        {
        }
        public void SaveUser(UserModel user) => users.Add(user);

        public UserModel SearchUser(string login, string password)
        {
            return users.Find(u => u.Login == login && u.Password == password);
        }
    }
}
