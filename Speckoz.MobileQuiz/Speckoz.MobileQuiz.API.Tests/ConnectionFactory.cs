using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Speckoz.MobileQuiz.API.Tests
{
    public static class ConnectionFactory
    {
        public static HttpClient GetClient(WebApplicationFactory<Startup> factory)
        {
            return factory.WithWebHostBuilder(builder => builder
                .ConfigureAppConfiguration((context, conf) =>
                    conf.AddJsonFile("appsettings.json"))).CreateClient();
        }
    }
}
