using GalaSoft.MvvmLight;

using MobileQuiz.Helpers;
using MobileQuiz.Models;
using MobileQuiz.Services;
using MobileQuiz.Views;

using System;
using System.Collections.Generic;
using System.Linq;

using Xamarin.Forms;

namespace MobileQuiz.ViewModels
{
    public class GameViewModel : ViewModelBase
    {
        private readonly string _category;
        private readonly GameView _page;

        private int __points;
        private int __round;
        private string __title;

        public int Points
        {
            get => __points;
            set
            {
                __points = value;
                RaisePropertyChanged();
            }
        }

        public int Round
        {
            get => __round;
            set
            {
                __round = value;
                RaisePropertyChanged();
            }
        }

        public string Title
        {
            get => __title;
            set
            {
                __title = value;
                RaisePropertyChanged();
            }
        }

        public GameViewModel(GameView page, string category)
        {
            _page = page;
            _category = category;
            Mount();
        }

        private void Mount()
        {
            QuestionModel question = _category == "Todas" ? QuestionService.GetRandomQuestion() : QuestionService.GetRandomQuestion(_category);
            Title = question.Question;
            CreateButtons(question);
        }

        private void CreateButtons(QuestionModel question)
        {
            _page.ClearButtons();
            GetAnswersFromQuestion(question)
                .ForEach(q => _page.AddButtons(CreateAnswerButton(q, question)));
        }

        private async void CheckAnswerAsync(object sender, EventArgs e)
        {
            if (((Button)sender).ClassId == "correct")
            {
                await _page.DisplayAlert("Parabéns", "Você acertou!", "OK");
                Round++;
                Points = Points == 0 ? 10 : Points * 2;
                NextLevel();
            }
            else
            {
                if (await _page.DisplayAlert("Fim de jogo", $"Você Perdeu!\nVocê fez: {Points} pontos", "Jogar Novamente", "Voltar"))
                {
                    Application.Current.MainPage = new GameView(_category);
                }
                else
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

            btn.Clicked += CheckAnswerAsync;

            return btn;
        }

        private List<string> GetAnswersFromQuestion(QuestionModel question)
        {
            var answerList = question.IncorrectAnswers.Split('/').ToList();
            answerList.Add(question.CorrectAnswer);
            return answerList.Randomize().ToList();
        }

        private void NextLevel() => Mount();

        private void GameOver() => Application.Current.MainPage = new MainScreenView();
    }
}