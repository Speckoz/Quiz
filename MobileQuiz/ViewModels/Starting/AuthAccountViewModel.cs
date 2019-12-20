using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

using MobileQuiz.Helpers;
using MobileQuiz.Models;
using MobileQuiz.Services;
using MobileQuiz.Views;
using MobileQuiz.Views.Starting;

using Xamarin.Forms;

namespace MobileQuiz.ViewModels
{
    public class AuthAccountViewModel : ViewModelBase
    {
        private readonly AuthAccountView _page;
        private string __login;
        private string __password;
        private ImageSource __image = ConvertImageHelper.Convert(Properties.Resources.heartLogo);

        public string Login
        {
            get => __login;
            set
            {
                __login = value;
                RaisePropertyChanged();
            }
        }

        public string Password
        {
            get => __password;
            set
            {
                __password = value;
                RaisePropertyChanged();
            }
        }

        public ImageSource Image
        {
            get => __image;
            set
            {
                __image = value;
                RaisePropertyChanged();
            }
        }

        public RelayCommand AuthCommand { get; private set; }
        public RelayCommand RegisterCommand { get; private set; }
        public RelayCommand AboutCommand { get; private set; }

        public AuthAccountViewModel(AuthAccountView page)
        {
            _page = page;
            InitCommands();
        }

        private void InitCommands()
        {
            AuthCommand = new RelayCommand(Auth);
            RegisterCommand = new RelayCommand(Register);
            AboutCommand = new RelayCommand(About);
        }

        private async void Auth()
        {
            if (string.IsNullOrEmpty(Login) || string.IsNullOrEmpty(Password))
            {
                await _page.DisplayAlert("Ops!", "Voce precisa preencher os campos!", "OK");
                return;
            }

            UserModel user = UserService.SearchUser(Login, Password);
            if (user == null)
            {
                await _page.DisplayAlert("Erro", "Usuario não encontrado!", "OK");
                return;
            }

            Application.Current.MainPage = new MainScreenView();
        }

        private async void About() => await _page.DisplayAlert("Sobre", $"Criado por Specko\n\nModificado por Logikoz", "Fechar");

        private void Register() => Application.Current.MainPage = new RegisterAccountView();
    }
}