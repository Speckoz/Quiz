using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

using MobileQuiz.Helpers;
using MobileQuiz.Models;
using MobileQuiz.Models.ManagerQuestions;

using Speckoz.MobileQuiz.Dependencies.Interfaces;

using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;

using XF.Material.Forms.UI;

namespace MobileQuiz.ViewModels.ManagerQuestions
{
    internal class SuggestQuestionViewModel : ViewModelBase
    {
        private IQuestion __newQuestion;
        private ObservableCollection<SuggestQuestionChipModel> __incorrectAnswersChips;

        public IQuestion NewQuestion
        {
            get => __newQuestion;
            set
            {
                __newQuestion = value;
                RaisePropertyChanged();
            }
        }

        public RelayCommand SendSugestionCommand { get; private set; }

        public RelayCommand AddIncorrectAnswerCommand { get; private set; }

        public ObservableCollection<SuggestQuestionChipModel> IncorrectAnswersChips
        {
            get => __incorrectAnswersChips;
            set
            {
                __incorrectAnswersChips = value;
                RaisePropertyChanged();
            }
        }

        public SuggestQuestionViewModel() => Init();

        private void AddIncorrectAnswer()
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
            bool i3 = IncorrectAnswersChips.Count > 3;
            //bool i4 =

            return true;
        }

        private async void SendSugestion()
        {
            if (FieldsIsEmpty())
            {
                await Application.Current.MainPage.DisplayAlert("Ops!", "Voce precisa preencher todos os campos", "Ok");
                return;
            }

            //request here
        }

        private void Init()
        {
            NewQuestion = new QuestionModel();
            SendSugestionCommand = new RelayCommand(SendSugestion);
            AddIncorrectAnswerCommand = new RelayCommand(AddIncorrectAnswer);
            IncorrectAnswersChips = new ObservableCollection<SuggestQuestionChipModel>();
        }
    }
}