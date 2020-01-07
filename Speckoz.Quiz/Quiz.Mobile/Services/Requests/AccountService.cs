using Quiz.Mobile.Helpers;

using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Threading.Tasks;

namespace Quiz.Mobile.Services.Requests
{
    internal class AccountService
    {
        public static IRestResponse AuthAccountTaskAsync(string login, string password)
        {
            var request = new RestRequest(Method.POST);
            request.AddHeader("Accept", "application/json");
            request.AddJsonBody(new { Login = login, Password = password });
            return new RestClient($"{GetDataHelper.Uri}/Auth").Execute(request);
        }

        public static IRestResponse RegisterAccountTaskAsync(string username, string email, string password)
        {
            var request = new RestRequest(Method.POST);
            request.AddHeader("Accept", "application/json");
            request.AddJsonBody(new { Username = username, Email = email, Password = password });
            return new RestClient($"{GetDataHelper.Uri}/Register").Execute(request);
        }
    }
}