using GalaSoft.MvvmLight.Command;
using MobileQuiz.Views.ManagerQuestions;
using Xamarin.Forms;

namespace MobileQuiz.Models
{
    public class ManagerQuestionsModel
    {
        public ImageSource ActionImage { get; set; }
        public string ActionName { get; set; }
        public string ActionDescription { get; set; }
        public RelayCommand<ManagerQuestionsView> ActionOpen { get; set; }
    }
}