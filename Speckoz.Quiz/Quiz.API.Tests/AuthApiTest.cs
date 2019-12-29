using Microsoft.AspNetCore.Mvc.Testing;

using Newtonsoft.Json;

using Quiz.API.Models;
using Quiz.Dependencies.Models.Auxiliary;

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
            var login = new LoginRequestModel
            {
                Login = "quiz",
                Password = "quiz"
            };

            // Arranje
            using var request = new HttpRequestMessage(new HttpMethod("POST"), "/Auth")
            {
                Content = new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json")
            };

            //Act
            using HttpResponseMessage response = await _client.SendAsync(request);

            // Assert
            IUserBase usuario = JsonConvert.DeserializeObject<UserBaseModel>(await response.Content.ReadAsStringAsync());
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        public class UserTokenResponse
        {
            public string Token { get; set; }
            public UserBaseModel User { get; set; }
        }
    }
}