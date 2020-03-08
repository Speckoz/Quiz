using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

using Logikoz.XamarinUtilities.Enums;
using Logikoz.XamarinUtilities.Utilities;

using Quiz.Dependencies.Enums;
using Quiz.Dependencies.Interfaces;
using Quiz.Mobile.Models;
using Quiz.Mobile.Services.Requests;
using Quiz.Mobile.Util;
using Quiz.Mobile.Views;

using RestSharp;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text.Json;

using Xamarin.Forms;

using XF.Material.Forms.UI.Dialogs;

namespace Quiz.Mobile.ViewModels
{
    public class GameViewModel : ViewModelBase
    {
        private CategoryEnum category;

        private int __points;
        private int __round;
        private string __question;
        private ObservableCollection<GameModel> __answerButtons;

        public int Points
        {
            get => __points;
            set => Set(ref __points, value);
        }

        public int Round
        {
            get => __round;
            set => Set(ref __round, value);
        }

        public string Question
        {
            get => __question;
            set => Set(ref __question, value);
        }

        public ObservableCollection<GameModel> AnswerButtons
        {
            get => __answerButtons;
            set => Set(ref __answerButtons, value);
        }

        public RelayCommand ForceGameOverCommand { get; private set; }

        public GameViewModel(CategoryEnum category) => Init(category);

        private void Init(CategoryEnum category)
        {
            this.category = category;
            Mount();

            ForceGameOverCommand = new RelayCommand(async () =>
            {
                if ((await MaterialDialog.Instance.ConfirmAsync("Realmente deseja abandonar o jogo atual?\nVoce perderá todos os pontos!", "Aviso", "Sair", "Cancelar")) == true)
                    PopPushViewUtil.PopNavModalAsync<GameView>(true);
            });
        }

        private async void Mount()
        {
            using (IMaterialModalPage dialog = await MaterialDialog.Instance.LoadingDialogAsync("Sorteando..."))
            {
                IRestResponse response = await GameQuestionService.GetQuestionTaskAsync(category != CategoryEnum.Todas, category);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    QuestionModel question = JsonSerializer.Deserialize<QuestionModel>(response.Content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    Question = question.Question;
                    CreateButtons(question);
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    GameOverAsync();
                    await MaterialDialog.Instance.AlertAsync("Nao existe nenhuma pergunta para essa categoria.", ":/", "OK");
                }
                else
                {
                    GameOverAsync();
                    await MaterialDialog.Instance.AlertAsync("Nao foi possivel preparar o jogo, verifique sua conexao e tente novamente!", "Erro", "OK");
                }
            }
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
                button.BorderColor = (Color)ResourceColorUtil.GetResourceColor(ColorsEnum.PrimaryColor).color;

                Round++;
                Points = Points == default ? 10 : Points * 2;
                //proximo nivel.
                Mount();
            }
            else
            {
                button.BorderColor = Color.Red;

                if ((await MaterialDialog.Instance.ConfirmAsync($"Você Perdeu!\nA alternativa correta é: {GetAnswerCorrect()}\n\nVocê fez: {Points} pontos", "Fim de jogo",
                    "Jogar Novamente", "Voltar")) == true)
                {
                    GameOverAsync();
                    PopPushViewUtil.PopNavModalAsync<GameView>();
                    await PopPushViewUtil.PushModalAsync(new NavigationPage(new GameView(category)), true);
                }
                else
                    GameOverAsync();
            }
        }

        private List<string> GetAnswersFromQuestion(IQuestion question)
        {
            var answerList = question.IncorrectAnswers.Split('/').ToList();
            foreach (string i in answerList.Where(i => i == string.Empty).Select(i => i))
                answerList.Remove(i);

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

        private void GameOverAsync() => PopPushViewUtil.PopNavModalAsync<GameView>(true);
    }
}