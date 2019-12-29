using Quiz.Dependencies.Enums;

using Speckoz.MobileQuiz.Dependencies.Interfaces;

using System.Text.Json.Serialization;

namespace Quiz.Mobile.Models.Starting
{
    public class UserBase : IUserBase
    {
        [JsonPropertyName("userID")]
        public int UserID { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("level")]
        public int Level { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("userType")]
        public UserTypeEnum UserType { get; set; }
    }
}