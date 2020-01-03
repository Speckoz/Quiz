using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;

using System.Net.Http;
using System.Net.Http.Headers;

namespace Quiz.API.Tests
{
    public static class ConnectionFactory
    {
        public static HttpClient GetClient(WebApplicationFactory<Startup> factory)
        {
            var client = factory.WithWebHostBuilder(builder => builder
                .ConfigureAppConfiguration((context, conf) =>
                    conf.AddJsonFile("appsettings.json"))).CreateClient();

            // JWT
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6ImMyZTEyZjZmLWVjYTEtNGI0Ni04M2RhLTgwZDU3NDc1MzJkYyIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IkFkbWluIiwiZXhwIjoxNjQxMjQ2MjY2LCJpc3MiOiJTcGVja296IiwiYXVkIjoiU3BlY2tveiJ9.sW9tcYEBTo1R6o_XuVyPhOwjxK-F1mlMCeJw3uODjp8");

            return client;
        }
    }
}