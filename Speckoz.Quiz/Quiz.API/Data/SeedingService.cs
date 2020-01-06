using Quiz.API.Models;
using Quiz.Dependencies.Enums;
using System;
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
                    Status = QuestionStatusEnum.Approved,
                    Category = CategoryEnum.Historia,
                    AuthorID = Guid.Parse("{9F708217-9FFB-4F29-89E1-DA85B3B72259}"),
                    Question = "De quem é a famosa frase Penso, logo existo?",
                    CorrectAnswer = "Descartes",
                    IncorrectAnswers = "Platão/Sócrates/Galileu"
                });

                _context.Questions.Add(new QuestionModel
                {
                    Status = QuestionStatusEnum.Approved,
                    Category = CategoryEnum.Geograria,
                    AuthorID = Guid.Parse("{9F708217-9FFB-4F29-89E1-DA85B3B72259}"),
                    Question = "Quais o menor e o maior país do mundo?",
                    CorrectAnswer = "Vaticano e Rússia",
                    IncorrectAnswers = "Nauru e China/Mônaco e Canadá/Malta e Estados Unidos"
                });

                _context.Questions.Add(new QuestionModel
                {
                    Status = QuestionStatusEnum.Approved,
                    Category = CategoryEnum.Geograria,
                    AuthorID = Guid.Parse("{9F708217-9FFB-4F29-89E1-DA85B3B72259}"),
                    Question = "Qual o nome do presidente do Brasil que ficou conhecido como Jango?",
                    CorrectAnswer = "João Goulart",
                    IncorrectAnswers = "Jânio Quadros/Getúlio Vargas/João Figueiredo"
                });

                _context.Questions.Add(new QuestionModel
                {
                    Status = QuestionStatusEnum.Approved,
                    Category = CategoryEnum.Geograria,
                    AuthorID = Guid.Parse("{9F708217-9FFB-4F29-89E1-DA85B3B72259}"),
                    Question = "Quais os países que têm a maior e a menor expectativa de vida do mundo?",
                    CorrectAnswer = "Japão e Serra Leoa",
                    IncorrectAnswers = "Estados Unidos e Angola/Brasil e Congo/Austrália e Afeganistão"
                });
                _context.Questions.Add(new QuestionModel
                {
                    Status = QuestionStatusEnum.Approved,
                    Category = CategoryEnum.Esporte,
                    AuthorID = Guid.Parse("{9F708217-9FFB-4F29-89E1-DA85B3B72259}"),
                    Question = "Qual o número mínimo de jogadores numa partida de futebol?",
                    CorrectAnswer = "7",
                    IncorrectAnswers = "8/10/5"
                });
                _context.Questions.Add(new QuestionModel
                {
                    Status = QuestionStatusEnum.Approved,
                    Category = CategoryEnum.Arte,
                    AuthorID = Guid.Parse("{9F708217-9FFB-4F29-89E1-DA85B3B72259}"),
                    Question = "Quem pintou 'Guernica'?",
                    CorrectAnswer = "Pablo Picasso",
                    IncorrectAnswers = "Paul Cézanne/Diego Rivera/arsila do Amaral"
                });

                _context.Questions.Add(new QuestionModel
                {
                    Status = QuestionStatusEnum.Approved,
                    Category = CategoryEnum.Ciencia,
                    AuthorID = Guid.Parse("{9F708217-9FFB-4F29-89E1-DA85B3B72259}"),
                    Question = "Quanto tempo a luz do Sol demora para chegar à Terra?",
                    CorrectAnswer = "8 minutos",
                    IncorrectAnswers = "12 horas/1 dia/12 minutos"
                });

                _context.Questions.Add(new QuestionModel
                {
                    Status = QuestionStatusEnum.Approved,
                    Category = CategoryEnum.Historia,
                    AuthorID = Guid.Parse("{9F708217-9FFB-4F29-89E1-DA85B3B72259}"),
                    Question = "Qual a nacionalidade de Che Guevara?",
                    CorrectAnswer = "Argentina",
                    IncorrectAnswers = "Boliviana/Panamenha/Cubana"
                });

                _context.Questions.Add(new QuestionModel
                {
                    Status = QuestionStatusEnum.Approved,
                    Category = CategoryEnum.Geograria,
                    AuthorID = Guid.Parse("{9F708217-9FFB-4F29-89E1-DA85B3B72259}"),
                    Question = "Em que período da pré-história o fogo foi descoberto?",
                    CorrectAnswer = "Paleolítico",
                    IncorrectAnswers = "Idade Média/Neolítico/Idade dos Metais"
                });

                _context.Questions.Add(new QuestionModel
                {
                    Status = QuestionStatusEnum.Approved,
                    Category = CategoryEnum.Geograria,
                    AuthorID = Guid.Parse("{9F708217-9FFB-4F29-89E1-DA85B3B72259}"),
                    Question = "Qual o maior animal terrestre ?",
                    CorrectAnswer = "Elefante africano",
                    IncorrectAnswers = "Girafa/Tubarão Branco/Dinossauro"
                });

                _context.Questions.Add(new QuestionModel
                {
                    Status = QuestionStatusEnum.Approved,
                    Category = CategoryEnum.Geograria,
                    AuthorID = Guid.Parse("{9F708217-9FFB-4F29-89E1-DA85B3B72259}"),
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
                    UserID = Guid.Parse("{9F708217-9FFB-4F29-89E1-DA85B3B72259}"),
                    Email = "quiz@speckoz.net",
                    Password = "quiz",
                    Level = 1,
                    Username = "quiz",
                    UserType = UserTypeEnum.Admin,
                });
            }

            #endregion Users

            _context.SaveChanges();
        }
    }
}