using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

using Quiz.Helpers;
using Quiz.Mobile.Properties;
using Quiz.Models;
using Quiz.Services;
using Quiz.Views.Starting;

using Xamarin.Forms;

namespace Quiz.ViewModels
{
    public class RegisterAccountViewModel : ViewModelBase
    {
        private ImageSource __image;
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

        public RegisterAccountViewModel()
        {
            Image = ConvertImageHelper.Convert(Resources.register);
            InitCommands();
        }

        private void InitCommands()
        {
            RegisterCommand = new RelayCommand(Register);
            BackCommand = new RelayCommand(Back);
        }

        private async void Back() => await Application.Current.MainPage.Navigation.PopModalAsync(true);

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