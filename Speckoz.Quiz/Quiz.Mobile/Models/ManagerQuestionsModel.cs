using GalaSoft.MvvmLight.Command;

using Xamarin.Forms;

namespace Quiz.Mobile.Models
{
    public class ManagerQuestionsModel
    {
        public ImageSource ActionImage { get; set; }
        public string ActionName { get; set; }
        public string ActionDescription { get; set; }
        public RelayCommand ActionOpen { get; set; }
    }
}