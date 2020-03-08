using Quiz.Dependencies.Enums;
using Quiz.Dependencies.Helpers;

using RestSharp;
using RestSharp.Authenticators;

using System.Threading;
using System.Threading.Tasks;

namespace Quiz.Mobile.Services.Requests
{
    internal class GameQuestionService
    {
        public static async Task<IRestResponse> GetQuestionTaskAsync(bool isRandom, CategoryEnum category = 0)
        {
            var request = new RestRequest(Method.GET);
            request.AddHeader("Accept", "application/json");
            return await new RestClient($"{DataHelper.Uri}/questions{(isRandom ? $"?cat={((int)category).ToString()}" : string.Empty)}")
            {
                Authenticator = new JwtAuthenticator(DataHelper.CurrentUser.Token)
            }.ExecuteAsync(request, new CancellationTokenSource().Token);
        }
    }
}