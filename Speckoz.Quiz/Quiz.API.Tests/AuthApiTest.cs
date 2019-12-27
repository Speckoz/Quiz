using Microsoft.AspNetCore.Mvc.Testing;

using Newtonsoft.Json;

using Quiz.API.Models;
using Quiz.API.Models.Auxiliary;

using Speckoz.MobileQuiz.Dependencies.Interfaces;

using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xunit;

namespace Quiz.API.Tests
{
    public class AuthApiTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public AuthApiTest(WebApplicationFactory<Startup> factory) => _client = ConnectionFactory.GetClient(factory);

        [Fact]
        public async Task DadoUsuarioValidoApiRetornaToken()
        {
            LoginRequestModel login = new LoginRequestModel
            {
                Login = "Specko",
                Password = "1234"
            };

            // Arranje
            using var request = new HttpRequestMessage(new HttpMethod("POST"), "/Auth")
            {
                Content = new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json")
            };

            //Act
            using HttpResponseMessage response = await _client.SendAsync(request);

            // Assert
            IUser usuario = JsonConvert.DeserializeObject<UserModel>(await response.Content.ReadAsStringAsync());
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        public class UserTokenResponse
        {
            public string Token { get; set; }
            public UserModel User { get; set; }
        }
    }
}