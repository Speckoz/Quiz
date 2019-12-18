using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

using MobileQuiz.Views;

using Xamarin.Forms;

namespace MobileQuiz.ViewModels
{
    public class AuthAccountViewModel : ViewModelBase
    {
        public RelayCommand RegisterCommand { get; private set; }

        public AuthAccountViewModel() => RegisterCommand = new RelayCommand(Register);

        private void Register() => Application.Current.MainPage = new RegisterAccountView();
    }
}