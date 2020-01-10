using Quiz.Mobile.Helpers;

using RestSharp;

using System.Threading;
using System.Threading.Tasks;

namespace Quiz.Mobile.Services.Requests
{
    internal class AccountService
    {
        public static async Task<IRestResponse> AuthAccountTaskAsync(string login, string password)
        {
            var request = new RestRequest(Method.POST);
            request.AddHeader("Accept", "application/json");
            request.AddJsonBody(new { Login = login, Password = password });
            return await new RestClient($"{GetDataHelper.Uri}/Auth").ExecuteAsync(request, new CancellationTokenSource().Token);
        }

        public static async Task<IRestResponse> RegisterAccountTaskAsync(string username, string email, string password)
        {
            var request = new RestRequest(Method.POST);
            request.AddHeader("Accept", "application/json");
            request.AddJsonBody(new { Username = username, Email = email, Password = password });
            return await new RestClient($"{GetDataHelper.Uri}/Register").ExecuteAsync(request, new CancellationTokenSource().Token);
        }
    }
}