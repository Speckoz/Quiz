using MobileQuiz.Helpers;
using MobileQuiz.Models;
using MobileQuiz.Services;
using MobileQuiz.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileQuiz.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GameView : ContentPage
    {
        private int ActualRound;

        private readonly string _category;
        private readonly int _points;

        public GameView(string category, int round = 0, int points = 10)
        {
            InitializeComponent();
            BindingContext = new GameViewModel();
            QuestionModel question = (_category = category) == "Todas" ? QuestionService.GetRandomQuestion() : QuestionService.GetRandomQuestion(category);
            Mount(question, ActualRound = round, _points = points);
        }

        private void Mount(QuestionModel question, int round, int pontos)
        {
            CreateButtons(question);
            CreateTitle(question.Question);
            RenderInfos(round, pontos);
        }

        private void CreateTitle(string question) => ((Label)FindByName("Title")).Text = question;

        private void CreateButtons(QuestionModel question)
        {
            foreach (string answer in GetAnswersFromQuestion(question))
            {
                _ = CreateAnswerButton(answer, question);
            }
        }

        private async void CheckAnswer(object sender, EventArgs e)
        {
            if (((Button)sender).ClassId == "correct")
            {
                await DisplayAlert("Parabéns", "Você acertou!", "OK");
                NextLevel(++ActualRound, _points * 2);
            }
            else
            {
                await DisplayAlert("Fim de jogo", $"Você Perdeu!\nVocê fez: {_points} pontos", "OK");
                GameOver();
            }
        }

        private Button CreateAnswerButton(string answer, QuestionModel question)
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

            return btn;
        }

        private List<string> GetAnswersFromQuestion(QuestionModel question)
        {
            var answerList = question.IncorrectAnswers.Split('/').ToList();
            answerList.Add(question.CorrectAnswer);
            return answerList.Randomize().ToList();
        }

        private void RenderInfos(int round, int points)
        {
            ((Label)FindByName("Round")).Text = $"Round: {round.ToString()}";
            ((Label)FindByName("Pontos")).Text = $"Pontos: {points.ToString()}";
        }

        private void NextLevel(int round, int points) => Application.Current.MainPage = new GameView(_category, round, points);

        private void GameOver() => Application.Current.MainPage = new ChooseCategoryView();
    }
}