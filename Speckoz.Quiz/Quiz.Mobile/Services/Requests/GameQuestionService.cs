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
            var request = new RestRequest(Method.GET) { RequestFormat = DataFormat.Json };
            request.AddHeader("Accept", "application/json");
            return await new RestClient($"{GetDataHelper.Uri}/questions{(isRandom ? $"?cat={((int)category).ToString()}" : string.Empty)}").ExecuteTaskAsync(request);
        }
    }
}