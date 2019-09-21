using MobileQuiz.Helpers;
using MobileQuiz.Models;
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
        public Jogo(QuestionModel question, int round = 0, int pontos = 0)
        {
            InitializeComponent();
            Mount(question, round, pontos);
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
                // Proxima fase
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

        }
    }
}