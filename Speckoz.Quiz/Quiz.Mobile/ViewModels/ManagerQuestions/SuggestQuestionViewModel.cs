using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

using Quiz.Dependencies.Enums;
using Quiz.Helpers;
using Quiz.Models;
using Quiz.Models.ManagerQuestions;

using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;

using XF.Material.Forms.UI;

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
                SendMessageHelper.SendAsync("Voce precisa digitar no campo!", "Ops!");
        }

        private async void RemoveChipWithIncorretAnswer(MaterialChip chip)
        {
            if (await Continue())
                foreach (SuggestQuestionChipModel incorret in IncorrectAnswersChips.ToList())
                    if (incorret.IncorrectAnswerText == chip.Text)
                        IncorrectAnswersChips.Remove(incorret);

            static async Task<bool> Continue() => await Application.Current.MainPage.DisplayAlert("", "Tem certeza que quer excluir este item? ", "Sim", "Cancelar");
        }

        private bool FieldsIsEmpty()
        {
            bool i1 = string.IsNullOrEmpty(NewQuestion.Question);
            bool i2 = string.IsNullOrEmpty(NewQuestion.CorrectAnswer);
            bool i3 = !(IncorrectAnswersChips.Count >= 3);
            bool i4 = !(NewQuestion.Category >= 0);

            return i1 || i2 || i3 || i4;
        }

        private async void SendSugestion()
        {
            if (FieldsIsEmpty())
            {
                await Application.Current.MainPage.DisplayAlert("Ops!", "Voce precisa preencher todos os campos", "Ok");
                return;
            }
            string aux = "";
            foreach (SuggestQuestionChipModel s in IncorrectAnswersChips)
            {
                aux += $"{s.IncorrectAnswerText}/";
            }
            //request here
            await Application.Current.MainPage.DisplayAlert("Show", $"{NewQuestion.Question}\n{NewQuestion.Category} - {(int)NewQuestion.Category}\n{NewQuestion.CorrectAnswer}\n{aux}", "OK");
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