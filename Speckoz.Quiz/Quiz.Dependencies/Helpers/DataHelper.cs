using Quiz.Dependencies.Models;

namespace Quiz.Dependencies.Helpers
{
    public class DataHelper
    {
        public static string Uri { get; } = "http://192.168.1.243:5000";//"http://marcopandolfo.ddns.net:5000";

        public static UserLoginModel CurrentUser { get; set; }
    }
}