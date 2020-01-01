using Quiz.API.Models;
using Quiz.Dependencies.Enums;

using System.Linq;

namespace Quiz.API.Data
{
    public class SeedingService
    {
        private readonly ApiContext _context;

        public SeedingService(ApiContext context) => _context = context;

        public void Seed()
        {
            #region Questions

            if (!_context.Questions.Any())
            {
                _context.Questions.Add(new QuestionModel
                {
                    Category = CategoryEnum.Historia,
                    Question = "De quem é a famosa frase Penso, logo existo?",
                    CorrectAnswer = "Descartes",
                    IncorrectAnswers = "Platão/Sócrates/Galileu"
                });

                _context.Questions.Add(new QuestionModel
                {
                    Category = CategoryEnum.Geograria,
                    Question = "Quais o menor e o maior país do mundo?",
                    CorrectAnswer = "Vaticano e Rússia",
                    IncorrectAnswers = "Nauru e China/Mônaco e Canadá/Malta e Estados Unidos"
                });

                _context.Questions.Add(new QuestionModel
                {
                    Category = CategoryEnum.Geograria,
                    Question = "Qual o nome do presidente do Brasil que ficou conhecido como Jango?",
                    CorrectAnswer = "João Goulart",
                    IncorrectAnswers = "Jânio Quadros/Getúlio Vargas/João Figueiredo"
                });

                _context.Questions.Add(new QuestionModel
                {
                    Category = CategoryEnum.Geograria,
                    Question = "Quais os países que têm a maior e a menor expectativa de vida do mundo?",
                    CorrectAnswer = "Japão e Serra Leoa",
                    IncorrectAnswers = "Estados Unidos e Angola/Brasil e Congo/Austrália e Afeganistão"
                });
                _context.Questions.Add(new QuestionModel
                {
                    Category = CategoryEnum.Esporte,
                    Question = "Qual o número mínimo de jogadores numa partida de futebol?",
                    CorrectAnswer = "7",
                    IncorrectAnswers = "8/10/5"
                });
                _context.Questions.Add(new QuestionModel
                {
                    Category = CategoryEnum.Arte,
                    Question = "Quem pintou 'Guernica'?",
                    CorrectAnswer = "Pablo Picasso",
                    IncorrectAnswers = "Paul Cézanne/Diego Rivera/arsila do Amaral"
                });

                _context.Questions.Add(new QuestionModel
                {
                    Category = CategoryEnum.Ciencia,
                    Question = "Quanto tempo a luz do Sol demora para chegar à Terra?",
                    CorrectAnswer = "8 minutos",
                    IncorrectAnswers = "12 horas/1 dia/12 minutos"
                });

                _context.Questions.Add(new QuestionModel
                {
                    Category = CategoryEnum.Historia,
                    Question = "Qual a nacionalidade de Che Guevara?",
                    CorrectAnswer = "Argentina",
                    IncorrectAnswers = "Boliviana/Panamenha/Cubana"
                });

                _context.Questions.Add(new QuestionModel
                {
                    Category = CategoryEnum.Geograria,
                    Question = "Em que período da pré-história o fogo foi descoberto?",
                    CorrectAnswer = "Paleolítico",
                    IncorrectAnswers = "Idade Média/Neolítico/Idade dos Metais"
                });

                _context.Questions.Add(new QuestionModel
                {
                    Category = CategoryEnum.Geograria,
                    Question = "Qual o maior animal terrestre ?",
                    CorrectAnswer = "Elefante africano",
                    IncorrectAnswers = "Girafa/Tubarão Branco/Dinossauro"
                });

                _context.Questions.Add(new QuestionModel
                {
                    Category = CategoryEnum.Geograria,
                    Question = "Em quantas compas do mundo a pátria amada brasil foi campeã?",
                    CorrectAnswer = "5",
                    IncorrectAnswers = "3/6/1"
                });
            }

            #endregion Questions

            #region Users

            if (!_context.Users.Any())
            {
                _context.Users.Add(new UserBaseModel
                {
                    Email = "quiz@speckoz.net",
                    Password = "quiz",
                    Level = 1,
                    Username = "quiz",
                    UserType = UserTypeEnum.Admin,
                });
            }

            #endregion Users

            #region Suggestions

            if (!_context.Suggestions.Any())
            {
                _context.Suggestions.Add(new QuestionSuggestionModel
                {
                    Category = CategoryEnum.Ciencia,
                    CorrectAnswer = "CorrectA",
                    IncorrectAnswers = "e/e/e",
                    Question = "Question for tests",
                });
            }

            #endregion Suggestions

            #region QuestionsStatus

            if (!_context.QuestionsStatus.Any())
            {
                _context.QuestionsStatus.Add(new QuestionsStatusModel
                {
                    QuestionID = 1,
                    QuestionStatus = QuestionStatusEnum.Pending,
                    UserID = 1,
                });
            }

            #endregion QuestionsStatus

            _context.SaveChanges();
        }
    }
}