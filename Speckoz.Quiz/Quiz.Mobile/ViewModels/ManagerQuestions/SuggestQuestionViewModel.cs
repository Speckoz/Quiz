using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

using Quiz.Dependencies.Enums;
using Quiz.Dependencies.Interfaces;
using Quiz.Helpers;
using Quiz.Mobile.Services.Requests;
using Quiz.Models;
using Quiz.Models.ManagerQuestions;

using RestSharp;

using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using Xamarin.Forms;

using XF.Material.Forms.UI;
using XF.Material.Forms.UI.Dialogs;

namespace Quiz.ViewModels.ManagerQuestions
{
    internal class SuggestQuestionViewModel : ViewModelBase
    {
        private QuestionModel __newQuestion;
        private ObservableCollection<SuggestQuestionChipModel> __incorrectAnswersChips;
        private string[] __categoryChoice;

        public QuestionModel NewQuestion
        {
            get => __newQuestion;
            set => Set(ref __newQuestion, value);
        }

        public string[] CategoryChoice
        {
            get => __categoryChoice;
            set => Set(ref __categoryChoice, value);
        }

        public int Index
        {
            get => (int)NewQuestion.Category;
            set => NewQuestion.Category = (CategoryEnum)value;
        }

        public RelayCommand SendSugestionCommand { get; private set; }

        public RelayCommand AddIncorrectAnswerCommand { get; private set; }

        public ObservableCollection<SuggestQuestionChipModel> IncorrectAnswersChips
        {
            get => __incorrectAnswersChips;
            set => Set(ref __incorrectAnswersChips, value);
        }

        public SuggestQuestionViewModel() => Init();

        private void AddChipWithIncorrectAnswer()
        {
            if (!string.IsNullOrEmpty(NewQuestion.IncorrectAnswers))
            {
                if (!IncorrectAnswersChips.Any(i => i.IncorrectAnswerText == NewQuestion.IncorrectAnswers))
                {
                    IncorrectAnswersChips.Add(new SuggestQuestionChipModel
                    {
                        IncorrectAnswerText = NewQuestion.IncorrectAnswers,
                        IncorrectAnswerCommand = new RelayCommand<MaterialChip>(RemoveChipWithIncorretAnswer)
                    });

                    NewQuestion.IncorrectAnswers = string.Empty;
                }
                else
                    SendMessageHelper.SendAsync("Já está na lista!", "Ops!");
            }
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
            {
                return;
            }
            string aux = "";
            IncorrectAnswersChips.ToList().ForEach(a => aux += $"{a.IncorrectAnswerText}/");

            IQuestion question = NewQuestion;
            question.IncorrectAnswers = aux;

            using (IMaterialModalPage dialog = await MaterialDialog.Instance.LoadingDialogAsync("Enviando..."))
            {
                IRestResponse response = await ManagerQuestionsService.SuggestQuestionTaskAsync(question);

                if (response.StatusCode == HttpStatusCode.Created)
                {
                    dialog.MessageText = "Enviado com sucesso!";
                }
                else
                    dialog.MessageText = "Nao foi possivel enviar, verifique a conexao!";

                await Task.Delay(2000);
                if (response.StatusCode == HttpStatusCode.Created)
                    await Application.Current.MainPage.Navigation.PopModalAsync(true);
            }
        }

        private void Init()
        {
            NewQuestion = new SuggestQuestionModel();
            CategoryChoice = Enum.GetNames(typeof(CategoryEnum));
            SendSugestionCommand = new RelayCommand(SendSugestion);
            AddIncorrectAnswerCommand = new RelayCommand(AddChipWithIncorrectAnswer);
            IncorrectAnswersChips = new ObservableCollection<SuggestQuestionChipModel>();
        }
    }
}