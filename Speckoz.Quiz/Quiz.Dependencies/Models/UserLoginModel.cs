namespace Quiz.Dependencies.Models
{
    public class UserLoginModel
    {
        public UserBaseModel User { get; set; }

        public string Token { get; set; }
    }
}