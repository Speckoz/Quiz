using Quiz.Mobile.Models.Starting;

namespace Quiz.Mobile.Helpers
{
    public class GetDataHelper
    {
        public static string Uri { get; } = "http://192.168.1.243:5000";//"http://marcopandolfo.ddns.net:5000";

        public static UserLogin CurrentUser { get; set; }
    }
}