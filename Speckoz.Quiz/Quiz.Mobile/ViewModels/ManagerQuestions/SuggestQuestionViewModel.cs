using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

using Quiz.Dependencies.Enums;
using Quiz.Mobile.Helpers;
using Quiz.Mobile.Models;
using Quiz.Mobile.Models.ManagerQuestions;
using Quiz.Mobile.Services.Requests;

using RestSharp;

using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using Xamarin.Forms;

using XF.Material.Forms.UI;
using XF.Material.Forms.UI.Dialogs;

namespace Quiz.Mobile.ViewModels.ManagerQuestions
{
    public class SuggestQuestionViewModel : ViewModelBase
    {
        private SuggestQuestionModel __newQuestion;

        private string[] __categoryChoice;

        public SuggestQuestionModel NewQuestion
        {
            get => __newQuestion;
            set => Set(ref __newQuestion, value);
        }

        public string[] CategoryChoice
        {
            get => __categoryChoice;
            set => Set(ref __categoryChoice, value);
        }

        public byte Index
        {
            get => (byte)NewQuestion.Category;
            set => NewQuestion.Category = (CategoryEnum)value;
        }

        public RelayCommand SendSugestionCommand { get; private set; }

        public RelayCommand AddIncorrectAnswerCommand { get; private set; }
        public RelayCommand ExitSuggestScreenCommand { get; private set; }

        public ObservableCollection<SuggestQuestionChipModel> IncorrectAnswersChips { get; set; }

        public SuggestQuestionViewModel() => Init();

        private void AddChipWithIncorrectAnswer()
        {
            if (!string.IsNullOrEmpty(NewQuestion.IncorrectAnswers))
                if (!IncorrectAnswersChips.Any(i => i.IncorrectAnswerText == NewQuestion.IncorrectAnswers))
                {
                    IncorrectAnswersChips.Add(new SuggestQuestionChipModel
                    {
                        IncorrectAnswerText = NewQuestion.IncorrectAnswers.Replace("/", ""),
                        IncorrectAnswerCommand = new RelayCommand<MaterialChip>(RemoveChipWithIncorretAnswer)
                    });

                    NewQuestion.IncorrectAnswers = string.Empty;
                }
                else
                    SendMessageHelper.SendAsync("Já está na lista!", "Ops!");
            else
                SendMessageHelper.SendAsync("Voce precisa digitar algo no campo!", "Ops!");
        }

        private async void RemoveChipWithIncorretAnswer(MaterialChip chip)
        {
            if (await Continue())
                foreach (SuggestQuestionChipModel incorret in IncorrectAnswersChips.ToList())
                    if (incorret.IncorrectAnswerText == chip.Text)
                        IncorrectAnswersChips.Remove(incorret);

            static async Task<bool> Continue() => await Application.Current.MainPage.DisplayAlert("", "Tem certeza que quer excluir este item? ", "Sim", "Cancelar");
        }

        private async Task<bool> FieldsIsEmpty()
        {
            if (string.IsNullOrEmpty(NewQuestion.Question))
            {
                await Application.Current.MainPage.DisplayAlert("🥱 Ops!", "Voce precisa informar a pergunta!", "Ok");
                return true;
            }
            else if (string.IsNullOrEmpty(NewQuestion.CorrectAnswer))
            {
                await Application.Current.MainPage.DisplayAlert("🥱 Ops!", "Voce precisa informar a resposta correta da pergunta!", "Ok");
                return true;
            }
            else if (!(IncorrectAnswersChips.Count >= 3))
            {
                await Application.Current.MainPage.DisplayAlert("🥱 Ops!", "Voce precisa informar pelo menos 3 respostas incorretas!", "Ok");
                return true;
            }
            else if (!(NewQuestion.Category >= 0))
            {
                await Application.Current.MainPage.DisplayAlert("🥱 Ops!", "Voce precisa selecionar a categoria que mais se encaixa com a pergunta!", "Ok");
                return true;
            }
            else
                return false;
        }

        private async void SendSugestion()
        {
            if (await FieldsIsEmpty())
                return;
            string aux = "";
            IncorrectAnswersChips.ToList().ForEach(i => aux += $"{i.IncorrectAnswerText.ToString()}/");

            using IMaterialModalPage dialog = await MaterialDialog.Instance.LoadingDialogAsync("Enviando...");
            IRestResponse response = await ManagerQuestionsService.SuggestQuestionTaskAsync(new QuestionModel
            {
                Question = NewQuestion.Question,
                Category = NewQuestion.Category,
                CorrectAnswer = NewQuestion.CorrectAnswer,
                IncorrectAnswers = aux
            });

            dialog.MessageText = response.StatusCode == HttpStatusCode.Created ? "Enviado com sucesso!" : "Nao foi possivel enviar, verifique a conexao!";

            await Task.Delay(1500);
            if (response.StatusCode == HttpStatusCode.Created)
                await Application.Current.MainPage.Navigation.PopModalAsync(true);
        }

        private void Init()
        {
            NewQuestion = new SuggestQuestionModel() { Category = 0 };
            CategoryChoice = Enum.GetNames(typeof(CategoryEnum));
            SendSugestionCommand = new RelayCommand(SendSugestion);
            AddIncorrectAnswerCommand = new RelayCommand(AddChipWithIncorrectAnswer);
            ExitSuggestScreenCommand = new RelayCommand(ExitSuggestScreen);
            IncorrectAnswersChips = new ObservableCollection<SuggestQuestionChipModel>();
        }

        private async void ExitSuggestScreen()
        {
            if (await Application.Current.MainPage.DisplayAlert("ATENÇAO", "Realmente deseja sair dessa tela?\nTodos os dados nao salvos seram perdidos!", "Sim", "Cancelar"))
                await Application.Current.MainPage.Navigation.PopModalAsync(true);
        }
    }
}