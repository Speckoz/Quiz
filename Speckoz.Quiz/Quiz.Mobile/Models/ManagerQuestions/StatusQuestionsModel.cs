using GalaSoft.MvvmLight.Command;

using Quiz.Dependencies.Interfaces;

namespace Quiz.Mobile.Models.ManagerQuestions
{
    public class StatusQuestionsCardModel
    {
        public IQuestion Question { get; set; }
        public RelayCommand<IQuestion> ViewStatusCommand { get; set; }
    }
}