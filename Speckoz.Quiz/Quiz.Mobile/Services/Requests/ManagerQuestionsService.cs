using Quiz.Dependencies.Interfaces;
using Quiz.Mobile.Helpers;

using RestSharp;

using System.Text.Json;
using System.Threading.Tasks;

namespace Quiz.Mobile.Services.Requests
{
    internal class ManagerQuestionsService
    {
        public static async Task<IRestResponse> SuggestQuestionTaskAsync(IQuestion question, string token = "")
        {
            var request = new RestRequest(Method.POST) { RequestFormat = DataFormat.Json };
            request.AddHeader("Accept", "application/json");
            request.AddJsonBody(JsonSerializer.Serialize(question));
            return await new RestClient($"{GetDataHelper.Uri}/Suggestions").ExecuteTaskAsync(request);
        }
    }
}