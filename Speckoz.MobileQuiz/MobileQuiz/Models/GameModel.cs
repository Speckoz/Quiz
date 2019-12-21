using GalaSoft.MvvmLight.Command;

using Xamarin.Forms;

namespace MobileQuiz.Models
{
    public class GameModel
    {
        public string AnswerText { get; set; }
        public string IsCorrectAnswer { get; set; }
        public RelayCommand<Button> AnswerCommand { get; set; }
    }
}