using MobileQuiz.Models;
using MobileQuiz.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobileQuiz.Services
{
    public static class UserService
    {
        public static List<UserModel> users { get; set; } = Seed.SeedUsers();

        public static void SaveUser(UserModel user) => users.Add(user);

        public static UserModel SearchUser(string login, string password)
        {
            return users.Find(u => u.Login == login && u.Password == password);
        }
    }
}
