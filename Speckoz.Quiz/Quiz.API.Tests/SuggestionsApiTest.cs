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
        public async Task ApiRetornaListaDasSugestoes()
        {
            // Arranje
            using var request = new HttpRequestMessage(new HttpMethod("GET"), $"/suggestions");

            // Act
            using HttpResponseMessage response = await _client.SendAsync(request);

            // Assert
            List<QuestionSuggestionModel> suggestions = JsonConvert.DeserializeObject<List<QuestionSuggestionModel>>(await response.Content.ReadAsStringAsync());
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotEmpty(suggestions[0].IncorrectAnswers);
            Assert.NotEmpty(suggestions[0].QuestionSuggestionID.ToString());
        }

        [Fact]
        public async Task ApiRetornaListaDoStatusDasSugestoes()
        {
            using var request = new HttpRequestMessage(new HttpMethod("GET"), $"/suggestions/status");

            using HttpResponseMessage response = await _client.SendAsync(request);

            List<QuestionsStatusModel> status = JsonConvert.DeserializeObject<List<QuestionsStatusModel>>(await response.Content.ReadAsStringAsync());
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotEmpty(status[0].QuestionID.ToString());
            Assert.NotEmpty(status[0].QuestionStatus.ToString());
            Assert.NotEmpty(status[0].AuthorID.ToString());
        }

        [Fact]
        public async Task DadaSugestaoDeQuestaoValidaApiRetornaCreated()
        {
            var question = new QuestionModel
            {
                Question = "Questão Teste",
                Category = CategoryEnum.Arte,
                CorrectAnswer = "Certa",
                IncorrectAnswers = "e/e/e",
            };

            using var request = new HttpRequestMessage(new HttpMethod("POST"), "/suggestions")
            {
                Content = new StringContent(JsonConvert.SerializeObject(question), Encoding.UTF8, "application/json")
            };

            using HttpResponseMessage response = await _client.SendAsync(request);

            string value = await response.Content.ReadAsStringAsync();
            QuestionSuggestionModel resultSuggestion = JsonConvert.DeserializeObject<QuestionSuggestionModel>(value);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.NotEmpty(resultSuggestion.QuestionSuggestionID.ToString());
            Assert.NotEmpty(resultSuggestion.Question);

            // Delete created suggestion
            using var delete = new HttpRequestMessage(new HttpMethod("DELETE"), $"/suggestions/{resultSuggestion.QuestionSuggestionID}");
        }
    }
}