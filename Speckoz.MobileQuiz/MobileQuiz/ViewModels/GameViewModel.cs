using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

using MobileQuiz.Helpers;
using MobileQuiz.Models;
using MobileQuiz.Services;
using MobileQuiz.Views;

using Speckoz.MobileQuiz.Dependencies.Enums;
using Speckoz.MobileQuiz.Dependencies.Interfaces;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.Material.Forms.Resources;
using XF.Material.Forms.UI.Dialogs;
using XF.Material.Forms.UI.Dialogs.Configurations;

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

        public RelayCommand ForceGameOverCommand { get; private set; }

        public GameViewModel(CategoryEnum category)
        {
            _category = category;
            Mount();

            ForceGameOverCommand = new RelayCommand(async () =>
            {
                if (await Application.Current.MainPage.DisplayAlert("Aviso", "Realmente deseja abandonar o jogo atual?\nVoce perderá todos os pontos!", "Sair", "Cancelar"))
                    await Application.Current.MainPage.Navigation.PopModalAsync(true);
            });
        }

        private void Mount()
        {
            IQuestion question = _category == CategoryEnum.Todas ? QuestionService.GetRandomQuestion() : QuestionService.GetRandomQuestion(_category);
            Question = question.Question;
            CreateButtons(question);
        }

        private void CreateButtons(IQuestion question)
        {
            AnswerButtons = new ObservableCollection<GameModel>();
            GetAnswersFromQuestion(question)
                .ForEach(q => AnswerButtons.Add(CreateAnswerButton(q, question)));
        }

        private GameModel CreateAnswerButton(string answer, IQuestion question)
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

                SendMessageHelper.SendAsync("Parabéns", $"Você acertou!\n\n+{(isDefault ? 10 : Points / 2)} pontos.");
                NextLevel();
            }
            else
            {
                (button.BackgroundColor, button.BorderColor) = (Color.Red, Color.Red);

                if (await Application.Current.MainPage.DisplayAlert("Fim de jogo", $"Você Perdeu!\nA alternativa correta é: {GetAnswerCorrect()}\n\nVocê fez: {Points} pontos", "Jogar Novamente", "Voltar"))
                {
                    GameOverAsync();
                    await Application.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(new GameView(_category)), true);
                }
                else
                    GameOverAsync();
            }
        }

        private List<string> GetAnswersFromQuestion(IQuestion question)
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