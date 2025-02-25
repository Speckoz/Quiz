﻿using Microsoft.AspNetCore.Mvc.Testing;

using Newtonsoft.Json;

using Quiz.API.Models.Auxiliary;
using Quiz.Dependencies.Models;

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
            var user = new RegisterRequestModel
            {
                Email = "email@gmail.com",
                Password = "1234",
                Username = "speckoz",
            };

            using var request = new HttpRequestMessage(new HttpMethod("POST"), "/register")
            {
                Content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json")
            };

            using HttpResponseMessage response = await _client.SendAsync(request);

            UserBaseModel createdUser = JsonConvert.DeserializeObject<UserBaseModel>(await response.Content.ReadAsStringAsync());
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.NotEmpty(createdUser.UserID.ToString());
            Assert.NotEmpty(createdUser.Username);

            // Delete created user
            using var delete = new HttpRequestMessage(new HttpMethod("DELETE"), $"/users/{createdUser.UserID}");
            await _client.SendAsync(delete);
        }

        [Theory]
        [InlineData("quiz@speckoz.net", "username")]
        [InlineData("emailValid323s@speckoz.net", "quiz")]
        public async Task DadoEmailOuUsernameJaExistenteAoCriarContaApiRetornaBadRequest(string email, string username)
        {
            var user = new RegisterRequestModel
            {
                Email = email,
                Password = "1234",
                Username = username,
            };

            using var request = new HttpRequestMessage(new HttpMethod("POST"), "/register")
            {
                Content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json")
            };

            using HttpResponseMessage response = await _client.SendAsync(request);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}