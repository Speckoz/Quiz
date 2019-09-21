using MobileQuiz.Helpers;
using MobileQuiz.Models;
using MobileQuiz.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileQuiz.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Jogo : ContentPage
    {
        private string Category { get; set; }
        private int ActualRound { get; set; }
        public int Points { get; set; }
        public Jogo(QuestionModel question, int round = 0, int pontos = 10)
        {
            InitializeComponent();
            Mount(question, round, pontos);
            this.Category = question.Category;
            this.ActualRound = round;
            this.Points = pontos;
        }

        private void Mount(QuestionModel question, int round, int pontos)
        {
            CreateButtons(question);
            CreateTitle(question.Question);
            RenderInfos(round, pontos);
        }

        private void CreateTitle(string question)
        {
            var label = (Label)FindByName("Title");
            label.Text = question;
        }

        private void CreateButtons(QuestionModel question)
        {
            foreach (var answer in GetAnswersFromQuestion(question))
            {
                var btn = new Button()
                {
                    Text = answer,
                    FontSize = 19,
                };

                if (answer == question.CorrectAnswer) btn.ClassId = "correct";
                

                // Add handler
                btn.Clicked += CheckAnswer;

                MyButtons.Children.Add(btn);
            }
        }

        private void CheckAnswer(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            if (btn.ClassId == "correct")
            {
                DisplayAlert("Parabéns", "Você acertou!", "OK");
                NextLevel(++this.ActualRound, (this.Points * 2), this.Category);
            }
            else
            {
                DisplayAlert("Fim de jogo", "Você Perdeu!", "OK");
                // Fim de jogo
            }
        }

        private List<string> GetAnswersFromQuestion(QuestionModel question)
        {
            List<string> answerList = question.IncorrectAnswers.Split('/').ToList();
            answerList.Add(question.CorrectAnswer);
            return answerList.Randomize().ToList();
        }

        private void RenderInfos(int round, int pontos)
        {
            Label roundLabel = (Label)FindByName("Round");
            Label pointsLabel = (Label)FindByName("Pontos");

            roundLabel.Text = $"Round: {round.ToString()}";
            pointsLabel.Text = $"Pontos: {pontos.ToString()}";
        }

        private void NextLevel(int round, int poins, string category = "")
        {
            QuestionModel question = QuestionService.GetRandomQuestion(category);
            Application.Current.MainPage = new Jogo(question, round, poins);
        }
    }
}