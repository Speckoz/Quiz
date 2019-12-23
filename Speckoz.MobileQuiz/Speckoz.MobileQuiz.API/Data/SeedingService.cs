using Speckoz.MobileQuiz.API.Models;
using Speckoz.MobileQuiz.Dependencies.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Speckoz.MobileQuiz.API.Data
{
    public class SeedingService
    {
        private readonly ApiContext _context;

        public SeedingService(ApiContext context) => _context = context;

        public void Seed()
        {
            if (_context.Questions.Any() && _context.Users.Any())
                return;

            #region Questions
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

            #endregion

            #region Users
            _context.Users.Add(new UserModel 
            {
                Email = "admin@gmail.com",
                Password = "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4",
                Level = 1,
                Username = "Specko"
            });
            #endregion

            _context.SaveChanges();
        }
    }
}
