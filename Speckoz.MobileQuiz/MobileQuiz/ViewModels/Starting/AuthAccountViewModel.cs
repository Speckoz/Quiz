using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

using MobileQuiz.Helpers;
using MobileQuiz.Models;
using MobileQuiz.Services;
using MobileQuiz.Views;
using MobileQuiz.Views.Starting;

using Xamarin.Forms;
using XF.Material.Forms.UI.Dialogs;

namespace MobileQuiz.ViewModels
{
    public class AuthAccountViewModel : ViewModelBase
    {
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

        public AuthAccountViewModel() => InitCommands();

        private void InitCommands()
        {
            AuthCommand = new RelayCommand(Auth);
            RegisterCommand = new RelayCommand(Register);
            AboutCommand = new RelayCommand(About);
        }

        private async void Auth()
        {
            using (await MaterialDialog.Instance.LoadingDialogAsync("Autenticando..."))
            {
                if (string.IsNullOrEmpty(Login) || string.IsNullOrEmpty(Password))
                {
                    await Application.Current.MainPage.DisplayAlert("Ops!", "Voce precisa preencher os campos!", "OK");
                    return;
                }

                UserModel user = UserService.SearchUser(Login.ToLower(), Password.ToLower());
                if (user == null)
                {
                    await Application.Current.MainPage.DisplayAlert("Erro", "Usuario não encontrado!", "OK");
                    return;
                }

                Application.Current.MainPage = new MainScreenView();
            }
        }

        private async void About() => await Application.Current.MainPage.DisplayAlert("Sobre", $"Criado por Specko\n\nModificado por Logikoz", "Fechar");

        private async void Register() => await Application.Current.MainPage.Navigation.PushModalAsync(new RegisterAccountView(), true);
    }
}