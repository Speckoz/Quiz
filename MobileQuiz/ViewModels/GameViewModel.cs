using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

using MobileQuiz.Helpers;
using MobileQuiz.Models;
using MobileQuiz.Services;
using MobileQuiz.Views;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using Xamarin.Forms;

namespace MobileQuiz.ViewModels
{
    public class GameViewModel : ViewModelBase
    {
        private readonly CategoryEnum _category;

        private int __points;
        private int __round;
        private string __question;
        private ObservableCollection<GameModel> __answerButtons;

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

        public string Question
        {
            get => __question;
            set
            {
                __question = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<GameModel> AnswerButtons
        {
            get => __answerButtons;
            set
            {
                __answerButtons = value;
                RaisePropertyChanged();
            }
        }

        public GameViewModel(CategoryEnum category)
        {
            _category = category;
            Mount();
        }

        private void Mount()
        {
            QuestionModel question = _category == CategoryEnum.Todas ? QuestionService.GetRandomQuestion() : QuestionService.GetRandomQuestion(_category);
            Question = question.Question;
            CreateButtons(question);
        }

        private void CreateButtons(QuestionModel question)
        {
            AnswerButtons = new ObservableCollection<GameModel>();
            GetAnswersFromQuestion(question)
                .ForEach(q => AnswerButtons.Add(CreateAnswerButton(q, question)));
        }

        private GameModel CreateAnswerButton(string answer, QuestionModel question)
        {
            return new GameModel
            {
                IsCorrectAnswer = (answer == question.CorrectAnswer).ToString().ToLower(),
                AnswerText = answer,
                AnswerCommand = new RelayCommand<Button>(CheckAnswerAsync)
            };
        }

        private async void CheckAnswerAsync(Button button)
        {
            if (bool.Parse(button.ClassId))
            {
                await Application.Current.MainPage.DisplayAlert("Parabéns", "Você acertou!", "OK");
                Round++;
                Points = Points == 0 ? 10 : Points * 2;
                NextLevel();
            }
            else
            {
                if (await Application.Current.MainPage.DisplayAlert("Fim de jogo", $"Você Perdeu!\nVocê fez: {Points} pontos", "Jogar Novamente", "Voltar"))
                {
                    Application.Current.MainPage = new GameView(_category);
                }
                else
                    GameOver();
            }
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