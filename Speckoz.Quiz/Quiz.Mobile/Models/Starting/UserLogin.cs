using Quiz.Dependencies.Models;

namespace Quiz.Mobile.Models.Starting
{
    public class UserLogin
    {
        public UserBaseModel User { get; set; }

        public string Token { get; set; }
    }
}