using Quiz.Mobile.Models.Starting;

namespace Quiz.Mobile.Helpers
{
    internal class GetDataHelper
    {
        public static string Uri { get; } = "http://201.75.156.51:5000";

        public static UserLogin CurrentUser { get; set; }
    }
}