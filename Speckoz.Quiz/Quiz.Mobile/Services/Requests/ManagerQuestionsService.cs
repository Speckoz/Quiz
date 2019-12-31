using Quiz.Mobile.Helpers;
using Quiz.Models;

using RestSharp;

using System.Text.Json;
using System.Threading.Tasks;

namespace Quiz.Mobile.Services.Requests
{
    internal class ManagerQuestionsService
    {
        public static async Task<IRestResponse> SuggestQuestionTaskAsync(QuestionModel question, string token = "")
        {
            var request = new RestRequest(Method.POST) { RequestFormat = DataFormat.Json };
            request.AddHeader("Accept", "application/json");
            request.AddJsonBody(JsonSerializer.Serialize(question));
            return await new RestClient($"{GetDataHelper.Uri}/Suggestions").ExecuteTaskAsync(request);

            //var request = new RestRequest(Method.POST);
            //request.AddHeader("Accept", "application/json");
            //request.AddJsonBody(new { question.Question, question.CorrectAnswer, question.Category, question.IncorrectAnswers });
            //return await new RestClient($"{GetDataHelper.Uri}/Suggestions").ExecuteTaskAsync(request);
        }
    }
}