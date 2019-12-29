using Quiz.Dependencies.Interfaces;

using Speckoz.MobileQuiz.Dependencies.Interfaces;

using System.Text.Json.Serialization;

namespace Quiz.Mobile.Models.Starting
{
    public class UserToken : IUserLogin
    {
        [JsonPropertyName("user")]
        public IUser User { get; set; }

        [JsonPropertyName("token")]
        public string Token { get; set; }
    }
}