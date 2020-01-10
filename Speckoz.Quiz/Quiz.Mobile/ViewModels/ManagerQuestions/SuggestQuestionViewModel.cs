using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

using Quiz.Dependencies.Enums;
using Quiz.Dependencies.Interfaces;
using Quiz.Mobile.Models;
using Quiz.Mobile.Models.ManagerQuestions;
using Quiz.Mobile.Services.Requests;
using Quiz.Mobile.Util;

using RestSharp;

using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using XF.Material.Forms.UI;
using XF.Material.Forms.UI.Dialogs;

namespace Quiz.Mobile.ViewModels.ManagerQuestions
{
    public class SuggestQuestionViewModel : ViewModelBase
    {
        private IQuestion __newQuestion;

        private string[] __categoryChoice;

        public IQuestion NewQuestion
        {
            get => __newQuestion;
            set => Set(ref __newQuestion, value);
        }

        public string[] CategoryChoice
        {
            get => __categoryChoice;
            set => Set(ref __categoryChoice, value);
        }

        public string SelectedCategory
        {
            get => NewQuestion.Category.ToString();
            set
            {
                if (Enum.TryParse(value, out CategoryEnum category))
                {
                    NewQuestion.Category = category;
                }
            }
        }

        public RelayCommand SendSugestionCommand { get; private set; }

        public RelayCommand AddIncorrectAnswerCommand { get; private set; }
        public RelayCommand ExitSuggestScreenCommand { get; private set; }

        public ObservableCollection<SuggestQuestionChipModel> IncorrectAnswersChips { get; set; }

        public SuggestQuestionViewModel() => Init();

        private async void AddChipWithIncorrectAnswer()
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
                    await MaterialDialog.Instance.SnackbarAsync("Já está na lista!", MaterialSnackbar.DurationLong);
            else
                await MaterialDialog.Instance.SnackbarAsync("Voce precisa digitar algo no campo!", MaterialSnackbar.DurationLong);
        }

        private async void RemoveChipWithIncorretAnswer(MaterialChip chip)
        {
            if (await Continue())
                foreach (SuggestQuestionChipModel incorret in IncorrectAnswersChips.ToList())
                    if (incorret.IncorrectAnswerText == chip.Text)
                        IncorrectAnswersChips.Remove(incorret);

            static async Task<bool> Continue() => (await MaterialDialog.Instance.ConfirmAsync("Tem certeza que quer excluir este item? ", "Confirmar", "Sim", "Cancelar")) == true;
        }

        private async Task<bool> FieldsIsEmpty()
        {
            if (string.IsNullOrEmpty(NewQuestion.Question))
            {
                await MaterialDialog.Instance.AlertAsync("Voce precisa informar a pergunta!", "Ops!", "Ok");
                return true;
            }
            else if (string.IsNullOrEmpty(NewQuestion.CorrectAnswer))
            {
                await MaterialDialog.Instance.AlertAsync("Voce precisa informar a resposta correta da pergunta!", "Ops!", "Ok");
                return true;
            }
            else if (!(IncorrectAnswersChips.Count >= 3))
            {
                await MaterialDialog.Instance.AlertAsync("Voce precisa informar pelo menos 3 respostas incorretas!", "Ops!", "Ok");
                return true;
            }
            else if (!(NewQuestion.Category >= 0))
            {
                await MaterialDialog.Instance.AlertAsync("Voce precisa selecionar a categoria que mais se encaixa com a pergunta!", "Ops!", "Ok");
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
                await PopPushViewUtil.PopModalAsync(true);
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
            if ((await MaterialDialog.Instance.ConfirmAsync("Realmente deseja sair dessa tela?\nTodos os dados nao salvos seram perdidos!", "ATENÇAO", "Sim", "Cancelar")) == true)
                await PopPushViewUtil.PopModalAsync(true);
        }
    }
}