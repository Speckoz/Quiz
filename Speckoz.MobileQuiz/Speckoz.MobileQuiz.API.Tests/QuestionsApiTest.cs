using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Speckoz.MobileQuiz.API.Models;
using Speckoz.MobileQuiz.Dependencies.Enums;
using Speckoz.MobileQuiz.Dependencies.Interfaces;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using Xunit;

namespace Speckoz.MobileQuiz.API.Tests
{
    public class QuestionsApiTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public QuestionsApiTest(WebApplicationFactory<Startup> factory) => _client = ConnectionFactory.GetClient(factory);


        [Theory]
        [InlineData(CategoryEnum.Arte)]
        [InlineData(CategoryEnum.Ciencia)]
        [InlineData(CategoryEnum.Todas)]
        public async void DadaCategoriaValidaNaURIApiRetornaOkEQuestao(CategoryEnum cat)
        {
            // Arranje
            using var request = new HttpRequestMessage(new HttpMethod("GET"), $"/questions?cat={(int)cat}");

            //Act
            using HttpResponseMessage response = await _client.SendAsync(request);

            // Assert
            QuestionModel question = JsonConvert.DeserializeObject<QuestionModel>(await response.Content.ReadAsStringAsync());
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotEmpty(question.Category.ToString());
            Assert.NotEmpty(question.Question);
            Assert.NotEmpty(question.IncorrectAnswers);
            Assert.NotEmpty(question.CorrectAnswer);
        }
    }
}
