using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MobileQuiz.Models;
using Speckoz.MobileQuiz.Dependencies.Interfaces;

namespace MobileQuiz.ViewModels.ManagerQuestions
{
    internal class SuggestQuestionViewModel : ViewModelBase
    {
        private IQuestion __newQuestion;

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

        public SuggestQuestionViewModel()
        {
            NewQuestion = new QuestionModel();
            SendSugestionCommand = new RelayCommand(SendSugestion);
        }

        private async void SendSugestion()
        {
            //implementar aqui
            await App.Current.MainPage.DisplayAlert("", NewQuestion.Question, "OK");
        }
    }
}