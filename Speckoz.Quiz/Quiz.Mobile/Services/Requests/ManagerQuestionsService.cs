using Quiz.Mobile.Helpers;
using Quiz.Mobile.Models;

using RestSharp;
using RestSharp.Authenticators;

using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Quiz.Mobile.Services.Requests
{
    internal class ManagerQuestionsService
    {
        public static async Task<IRestResponse> SuggestQuestionTaskAsync(QuestionModel question)
        {
            var request = new RestRequest(Method.POST);
            request.AddHeader("Accept", "application/json");
            request.AddJsonBody(JsonSerializer.Serialize(question));
            return await new RestClient($"{GetDataHelper.Uri}/Suggestions")
            {
                Authenticator = new JwtAuthenticator(GetDataHelper.CurrentUser.Token)
            }.ExecuteAsync(request, new CancellationTokenSource().Token);
        }

        public static async Task<IRestResponse> StatusQuestionsTaskAsync()
        {
            var request = new RestRequest(Method.GET);
            request.AddHeader("Accept", "application/json");
            return await new RestClient($"{GetDataHelper.Uri}/Suggestions")
            {
                Authenticator = new JwtAuthenticator(GetDataHelper.CurrentUser.Token)
            }.ExecuteAsync(request, new CancellationTokenSource().Token);
        }
    }
}