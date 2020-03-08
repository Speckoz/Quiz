using GalaSoft.MvvmLight.Command;

using Quiz.Dependencies.Models;

namespace Quiz.Mobile.Models.ManagerQuestions
{
    public class StatusQuestionsCardModel
    {
        public QuestionModel Question { get; set; }
        public RelayCommand<QuestionModel> ViewStatusCommand { get; set; }
    }
}