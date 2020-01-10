using Quiz.Mobile.Models.Starting;

namespace Quiz.Mobile.Helpers
{
    public class GetDataHelper
    {
        public static string Uri { get; } = "http://marcopandolfo.ddns.net:5000";

        public static UserLogin CurrentUser { get; set; }
    }
}