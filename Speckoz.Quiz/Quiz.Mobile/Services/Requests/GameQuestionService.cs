using Quiz.Dependencies.Enums;
using Quiz.Mobile.Helpers;

using RestSharp;

using System.Threading.Tasks;

namespace Quiz.Mobile.Services.Requests
{
    internal class GameQuestionService
    {
        public static async Task<IRestResponse> GetQuestionTaskAsync(bool isRandom, CategoryEnum category = 0)
        {
            var request = new RestRequest(Method.GET);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", $"Bearer {GetDataHelper.User.Token}");
            var restClient = new RestClient($"{GetDataHelper.Uri}/questions{(isRandom ? $"?cat={((int)category).ToString()}" : string.Empty)}");
            return await restClient.ExecuteGetTaskAsync(request);
        }
    }
}