using GalaSoft.MvvmLight.Command;

using Xamarin.Forms;

namespace Quiz.Models
{
    public class GameModel
    {
        public string AnswerText { get; set; }
        public string IsCorrectAnswer { get; set; }
        public RelayCommand<Button> AnswerCommand { get; set; }
    }
}