using MobileQuiz.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileQuiz.Services.Helpers
{
    public static class Seed
    {
        // Seed Users
        public static List<UserModel> SeedUsers()
        {
            return new List<UserModel>
            {
                new UserModel("admin", "admin"),
                new UserModel("marco", "123"),
                new UserModel("heart", "password"),
                new UserModel("gmail", "777"),
                new UserModel("specko", "2020"),
                new UserModel("javaf", "javafx")
            };
        }

        // Seed Questions
        public static List<QuestionModel> SeedQuestions()
        {
            return new List<QuestionModel>
            {
                new QuestionModel(1, "De quem é a famosa frase Penso, logo existo?", "Descartes", "Arte", "Platão/Sócrates/Galileu Galilei"),
                new QuestionModel(2, "Quais o menor e o maior país do mundo?", "Vaticano e Rússia", "Geografia", "Nauru e China/Mônaco e Canadá/Malta e Estados Unidos"),
                new QuestionModel(3, "Qual o nome do presidente do Brasil que ficou conhecido como Jango?", "João Goulart", "Historia", "Jânio Quadros/Getúlio Vargas/João Figueiredo"),
                new QuestionModel(4, "Quais os países que têm a maior e a menor expectativa de vida do mundo?", "Japão e Serra Leoa", "Geografia", "Estados Unidos e Angola/Brasil e Congo/Austrália e Afeganistão"),
                new QuestionModel(5, "Qual o número mínimo de jogadores numa partida de futebol?", "7", "Entreterimento", "8/10/5"),
                new QuestionModel(6, "Quem pintou 'Guernica'?", "Pablo Picasso", "Arte", "Paul Cézanne/Diego Rivera/arsila do Amaral"),
                new QuestionModel(7, "Quanto tempo a luz do Sol demora para chegar à Terra?", "8 minutos", "Ciencia", "12 horas/1 dia/12 minutos"),
                new QuestionModel(8, "Qual a nacionalidade de Che Guevara?", "Argentina", "Historia", "Boliviana/Panamenha/Cubana"),
                new QuestionModel(9, "Em que período da pré-história o fogo foi descoberto?", "Paleolítico", "Historia", "Idade Média/Neolítico/Idade dos Metais"),
                new QuestionModel(10, "Qual o maior animal terrestre?", "Elefante africano", "Ciencia", "Girafa/Tubarão Branco/Dinossauro"),
            };
        }
    }
}
