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
                new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjEiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJBZG1pbiIsImV4cCI6MTY0MTAxNTY3NywiaXNzIjoiU3BlY2tveiIsImF1ZCI6IlNwZWNrb3oifQ.3X1RADhxOkPOkRIOTUB7KuqrcfTklLGsX-hfq4bjpp8");

            return client;
        }
    }
}