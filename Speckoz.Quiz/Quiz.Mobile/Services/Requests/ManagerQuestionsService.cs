using Quiz.Mobile.Helpers;
using Quiz.Mobile.Models;

using RestSharp;
using RestSharp.Authenticators;

using System.Text.Json;

namespace Quiz.Mobile.Services.Requests
{
    internal class ManagerQuestionsService
    {
        public static IRestResponse SuggestQuestionTaskAsync(QuestionModel question)
        {
            var request = new RestRequest(Method.POST);
            request.AddHeader("Accept", "application/json");
            request.AddJsonBody(JsonSerializer.Serialize(question));
            return new RestClient($"{GetDataHelper.Uri}/Suggestions")
            {
                Authenticator = new JwtAuthenticator(GetDataHelper.CurrentUser.Token)
            }.Execute(request);
        }

        public static IRestResponse StatusQuestionsTaskAsync()
        {
            var request = new RestRequest(Method.GET);
            request.AddHeader("Accept", "application/json");
            return new RestClient($"{GetDataHelper.Uri}/Suggestions")
            {
                Authenticator = new JwtAuthenticator(GetDataHelper.CurrentUser.Token)
            }.Execute(request);
        }
    }
}