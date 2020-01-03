using Quiz.Mobile.Models.Starting;

namespace Quiz.Mobile.Helpers
{
    internal class GetDataHelper
    {
        public static string Uri { get; } = "http://192.168.1.243:5000";

        public static UserLogin User { get; set; }
    }
}