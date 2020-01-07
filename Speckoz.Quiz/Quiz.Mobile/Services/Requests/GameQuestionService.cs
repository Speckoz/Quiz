using Quiz.Dependencies.Enums;
using Quiz.Mobile.Helpers;

using RestSharp;
using RestSharp.Authenticators;

using System.Threading.Tasks;

namespace Quiz.Mobile.Services.Requests
{
    internal class GameQuestionService
    {
        public static IRestResponse GetQuestionTaskAsync(bool isRandom, CategoryEnum category = 0)
        {
            var request = new RestRequest(Method.GET);
            request.AddHeader("Accept", "application/json");
            return new RestClient($"{GetDataHelper.Uri}/questions{(isRandom ? $"?cat={((int)category).ToString()}" : string.Empty)}")
            {
                Authenticator = new JwtAuthenticator(GetDataHelper.CurrentUser.Token)
            }.Execute(request);
        }
    }
}