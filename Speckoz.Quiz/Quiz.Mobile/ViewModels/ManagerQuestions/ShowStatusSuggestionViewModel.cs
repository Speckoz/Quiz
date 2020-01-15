using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

using Logikoz.XamarinUtilities.Utilities;

using Quiz.Dependencies.Interfaces;
using Quiz.Mobile.Views.ManagerQuestions;

using Xamarin.Forms;

namespace Quiz.Mobile.ViewModels.ManagerQuestions
{
    internal class ShowStatusSuggestionViewModel : ViewModelBase
    {
        private IQuestion __suggestion;

        public IQuestion Suggestion
        {
            get => __suggestion;
            set => Set(ref __suggestion, value);
        }

        public RelayCommand BackToStatusQuestionsCommand { get; private set; }

        public ShowStatusSuggestionViewModel(Page page) => Init(page);

        private void Init(Page page) => BackToStatusQuestionsCommand = new RelayCommand(() => PopPushViewUtil.Pop<ShowStatusSuggestionView>(page.Navigation));
    }
}