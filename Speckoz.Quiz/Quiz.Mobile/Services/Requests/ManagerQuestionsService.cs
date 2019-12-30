using Quiz.Mobile.Helpers;
using Quiz.Models;

using RestSharp;

using System.Threading.Tasks;

namespace Quiz.Mobile.Services.Requests
{
    internal class ManagerQuestionsService
    {
        public static async Task<IRestResponse> SuggestQuestionTaskAsync(QuestionModel question, string token = "")
        {
            var request = new RestRequest(Method.POST) { RequestFormat = DataFormat.Json };
            request.AddHeader("Accept", "application/json");
            request.AddJsonBody(question);
            return await new RestClient($"{GetDataHelper.Uri}/Suggestions").ExecuteTaskAsync(request);
        }
    }
}