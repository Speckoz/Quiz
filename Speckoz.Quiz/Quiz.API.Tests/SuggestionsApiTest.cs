using Microsoft.AspNetCore.Mvc.Testing;

using Newtonsoft.Json;

using Quiz.API.Models;
using Quiz.Dependencies.Enums;

using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xunit;

namespace Quiz.API.Tests
{
    public class SuggestionsApiTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public SuggestionsApiTest(WebApplicationFactory<Startup> factory) => _client = ConnectionFactory.GetClient(factory);

        [Fact]
        public async Task ApiRetornaListaDasSugestoesComOsStatus()
        {
            // Arranje
            using var request = new HttpRequestMessage(new HttpMethod("GET"), $"/suggestions");

            // Act
            using HttpResponseMessage response = await _client.SendAsync(request);

            // Assert
            List<QuestionModel> suggestions = JsonConvert.DeserializeObject<List<QuestionModel>>(await response.Content.ReadAsStringAsync());
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotEmpty(suggestions[0].QuestionID.ToString());
            Assert.NotEmpty(suggestions[0].Status.ToString());
            Assert.NotEmpty(suggestions[0].AuthorID.ToString());
            Assert.NotEmpty(suggestions[0].IncorrectAnswers);
        }

        [Fact]
        public async Task DadaSugestaoDeQuestaoValidaApiRetornaCreated()
        {
            var question = new QuestionModel
            {
                Question = "Questão inserida por teste automatizado",
                Category = CategoryEnum.Arte,
                CorrectAnswer = "Teste",
                IncorrectAnswers = "e/e/e",
            };

            using var request = new HttpRequestMessage(new HttpMethod("POST"), "/suggestions")
            {
                Content = new StringContent(JsonConvert.SerializeObject(question), Encoding.UTF8, "application/json")
            };

            using HttpResponseMessage response = await _client.SendAsync(request);

            string value = await response.Content.ReadAsStringAsync();
            QuestionModel resultSuggestion = JsonConvert.DeserializeObject<QuestionModel>(value);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal(QuestionStatusEnum.Pending, resultSuggestion.Status);
            Assert.NotEmpty(resultSuggestion.QuestionID.ToString());
            Assert.NotEmpty(resultSuggestion.AuthorID.ToString());
            Assert.NotEmpty(resultSuggestion.Question);

            // Delete created suggestion
            using var delete = new HttpRequestMessage(new HttpMethod("DELETE"), $"/suggestions/{resultSuggestion.QuestionID}");
        }
    }
}