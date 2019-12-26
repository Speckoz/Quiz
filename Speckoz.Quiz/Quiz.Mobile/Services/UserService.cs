using Quiz.Models;
using Quiz.Services.Helpers;

using System.Collections.Generic;

namespace Quiz.Services
{
    public static class UserService
    {
        public static List<UserModel> Users { get; set; } = Seed.SeedUsers();

        public static void SaveUser(UserModel user) => Users.Add(user);

        public static UserModel SearchUser(string login, string password) => Users.Find(u => u.Login == login && u.Password == password);
    }
}