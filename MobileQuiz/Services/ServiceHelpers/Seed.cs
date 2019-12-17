using MobileQuiz.Models;
using MobileQuiz.Properties;

using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;

namespace MobileQuiz.Services.Helpers
{
    public static class Seed
    {
        // Seed Users
        public static List<UserModel> SeedUsers()
        {
            return new List<UserModel>
            {
                new UserModel(){ Login = "admin", Password = "admin" },
                new UserModel(){ Login = "marco", Password = "123" },
                new UserModel(){ Login = "heart", Password = "password" },
                new UserModel(){ Login = "gmail", Password = "777"},
                new UserModel(){ Login = "specko", Password = "2020"},
                new UserModel(){ Login = "javaf", Password = "javafx"}
            };
        }

        // Seed Questions
        public static List<QuestionModel> SeedQuestions()
        {
            return JsonConvert.DeserializeObject<List<QuestionModel>>(Encoding.Default.GetString(Resources.Questions));
        }
    }
}