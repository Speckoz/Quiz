using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

using MobileQuiz.Helpers;
using MobileQuiz.Models;
using MobileQuiz.Models.ManagerQuestions;

using Speckoz.MobileQuiz.Dependencies.Interfaces;

using System.Collections.ObjectModel;
using System.Linq;

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
                    IncorrectAnswersChips.Add(new SuggestQuestionChipModel
                    {
                        IncorrectAnswerText = NewQuestion.IncorrectAnswers,
                        IncorrectAnswerCommand = new RelayCommand<MaterialChip>(RemoveChipWithIncorretAnswer)
                    });
                else
                    SendMessageHelper.SendAsync("Já está na lista!", "Ops!");
            }
            else
                SendMessageHelper.SendAsync("Voce precisa digitar no campo!", "Ops!");
        }

        private async void RemoveChipWithIncorretAnswer(MaterialChip chip)
        {
            if (await Application.Current.MainPage.DisplayAlert("", "Tem certeza que quer excluir este item? ", "Sim", "Cancelar"))
                foreach (SuggestQuestionChipModel incorret in IncorrectAnswersChips.ToList())
                    if (incorret.IncorrectAnswerText == chip.Text)
                        IncorrectAnswersChips.Remove(incorret);
        }

        private bool FieldsIsEmpty() => true;

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