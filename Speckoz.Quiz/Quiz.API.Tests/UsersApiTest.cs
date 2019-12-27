using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Quiz.API.Models;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Quiz.API.Tests
{
    public class UsersApiTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public UsersApiTest(WebApplicationFactory<Startup> factory) => _client = ConnectionFactory.GetClient(factory);
        

        [Fact]
        public async Task DadoUsuarioValidoApiRetornaCreated()
        {
            var user = new UserModel
            {
                Email = "speckoz@gmail.com",
                Level = 0,
                Password = "1234",
                Username = "speckoz",
                UserType = Dependencies.Enums.UserType.Normal
            };

            using var request = new HttpRequestMessage(new HttpMethod("POST"), "/users")
            {
                Content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json")
            };

            using HttpResponseMessage response = await _client.SendAsync(request);

            UserModel createdUser = JsonConvert.DeserializeObject<UserModel>(await response.Content.ReadAsStringAsync());
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.NotEmpty(createdUser.UserID.ToString());
            Assert.NotEmpty(createdUser.Username);

            // Delete created user
            using var delete = new HttpRequestMessage(new HttpMethod("DELETE"), $"/users/{createdUser.UserID}");
        }
    }
}
