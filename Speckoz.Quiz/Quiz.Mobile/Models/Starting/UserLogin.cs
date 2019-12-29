using System.Text.Json.Serialization;

namespace Quiz.Mobile.Models.Starting
{
    public class UserLogin
    {
        [JsonPropertyName("user")]
        public UserBase User { get; set; }

        [JsonPropertyName("token")]
        public string Token { get; set; }
    }
}