using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

using MobileQuiz.Helpers;
using MobileQuiz.Models;
using MobileQuiz.Services;
using MobileQuiz.Views;

using Speckoz.MobileQuiz.Dependencies.Enums;

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
            button.BorderWidth = 5;
            if (bool.Parse(button.ClassId))
            {
                Round++;
                bool isDefault = Points == default;
                Points = isDefault ? 10 : Points * 2;
                await Application.Current.MainPage.DisplayAlert("Parabéns", $"Você acertou!\n\n+{(isDefault ? 10 : Points / 2)} pontos.", "OK");
                NextLevel();
            }
            else
            {
                (button.BackgroundColor, button.BorderColor) = (Color.Red, Color.Red);

                if (await Application.Current.MainPage.DisplayAlert("Fim de jogo", $"Você Perdeu! A alternativa correta é: {GetAnswerCorrect()}\n\nVocê fez: {Points} pontos", "Jogar Novamente", "Voltar"))
                {
                    GameOverAsync();
                    await Application.Current.MainPage.Navigation.PushModalAsync(new GameView(_category), true);
                }
                else
                    GameOverAsync();
            }
        }

        private List<string> GetAnswersFromQuestion(QuestionModel question)
        {
            var answerList = question.IncorrectAnswers.Split('/').ToList();
            answerList.Add(question.CorrectAnswer);
            return answerList.Randomize().ToList();
        }

        private string GetAnswerCorrect()
        {
            foreach (GameModel gm in AnswerButtons)
                if (bool.Parse(gm.IsCorrectAnswer))
                    return gm.AnswerText;
            return null;
        }

        private void NextLevel() => Mount();

        private async void GameOverAsync() => await Application.Current.MainPage.Navigation.PopModalAsync();
    }
}