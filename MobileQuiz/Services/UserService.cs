using MobileQuiz.Models;
using MobileQuiz.Services.Helpers;
using System.Collections.Generic;

namespace MobileQuiz.Services
{
    public static class UserService
    {
        public static List<UserModel> Users { get; set; } = Seed.SeedUsers();

        public static void SaveUser(UserModel user) => Users.Add(user);

        public static UserModel SearchUser(string login, string password)
        {
            return Users.Find(u => u.Login == login && u.Password == password);
        }
    }
}
