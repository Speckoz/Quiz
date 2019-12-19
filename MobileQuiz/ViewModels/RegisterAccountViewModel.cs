using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

using MobileQuiz.Helpers;
using MobileQuiz.Models;
using MobileQuiz.Services;
using MobileQuiz.Views;

using Xamarin.Forms;

namespace MobileQuiz.ViewModels
{
    public class RegisterAccountViewModel : ViewModelBase
    {
        private ImageSource __image = ConvertImageHelper.Convert(Properties.Resources.register);
        private string __login;
        private string __newPassword;
        private string __confirmNewPassword;

        public ImageSource Image
        {
            get => __image;
            set
            {
                __image = value;
                RaisePropertyChanged();
            }
        }

        public string Login
        {
            get => __login;
            set
            {
                __login = value;
                RaisePropertyChanged();
            }
        }

        public string NewPassword
        {
            get => __newPassword;
            set
            {
                __newPassword = value;
                RaisePropertyChanged();
            }
        }

        public string ConfirmNewPassword
        {
            get => __confirmNewPassword;
            set
            {
                __confirmNewPassword = value;
                RaisePropertyChanged();
            }
        }

        public RelayCommand RegisterCommand { get; private set; }
        public RelayCommand BackCommand { get; private set; }

        public RegisterAccountViewModel() => InitCommands();

        private void InitCommands()
        {
            RegisterCommand = new RelayCommand(Register);
            BackCommand = new RelayCommand(Back);
        }

        private void Back() => Application.Current.MainPage = new AuthAccountView();

        private async void Register()
        {
            if (!string.IsNullOrEmpty(Login) && !string.IsNullOrEmpty(NewPassword) && !string.IsNullOrEmpty(ConfirmNewPassword))
            {
                if (NewPassword != ConfirmNewPassword)
                {
                    await Application.Current.MainPage.DisplayAlert("Ops!", "As senhas nao coincidem!", "OK");
                    return;
                }

                UserService.SaveUser(new UserModel { Login = Login, Password = NewPassword });
                await Application.Current.MainPage.DisplayAlert("Cadastrado", "Usuario cadastrado com sucesso!\n", "OK");

                Application.Current.MainPage = new AuthAccountView();
            }
            else
                await Application.Current.MainPage.DisplayAlert("Oh nao!", "Voce precisa preencher os campos!\n", "OK");
        }
    }
}