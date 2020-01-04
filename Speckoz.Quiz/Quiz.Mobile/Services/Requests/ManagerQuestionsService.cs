using Quiz.Mobile.Helpers;
using Quiz.Mobile.Models;

using RestSharp;

using System.Text.Json;
using System.Threading.Tasks;

namespace Quiz.Mobile.Services.Requests
{
    internal class ManagerQuestionsService
    {
        public static async Task<IRestResponse> SuggestQuestionTaskAsync(QuestionModel question)
        {
            var request = new RestRequest(Method.POST);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", $"Bearer {GetDataHelper.CurrentUser.Token}");
            request.AddJsonBody(JsonSerializer.Serialize(question));
            return await new RestClient($"{GetDataHelper.Uri}/Suggestions").ExecuteTaskAsync(request);
        }
    }
}