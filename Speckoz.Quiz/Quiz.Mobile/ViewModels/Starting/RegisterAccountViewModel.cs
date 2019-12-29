using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

using Quiz.Helpers;
using Quiz.Mobile.Properties;
using Quiz.Mobile.Services.Requests;
using Quiz.Views.Starting;

using RestSharp;

using System.Net;
using System.Threading.Tasks;

using Xamarin.Forms;

using XF.Material.Forms.UI.Dialogs;

namespace Quiz.ViewModels
{
    public class RegisterAccountViewModel : ViewModelBase
    {
        private ImageSource __image;
        private string __username;
        private string __newPassword;
        private string __confirmNewPassword;
        private string __email;

        public ImageSource Image
        {
            get => __image;
            set => Set(ref __image, value);
        }

        public string Username
        {
            get => __username;
            set => Set(ref __username, value);
        }

        public string Email
        {
            get => __email;
            set => Set(ref __email, value);
        }

        public string NewPassword
        {
            get => __newPassword;
            set => Set(ref __newPassword, value);
        }

        public string ConfirmNewPassword
        {
            get => __confirmNewPassword;
            set => Set(ref __confirmNewPassword, value);
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
            if (!string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(NewPassword))
            {
                ConfirmNewPassword = await Application.Current.MainPage.DisplayPromptAsync("Cadastro", "Por favor, confirme sua senha!", "Confirmar", "Esqueci", "Senha");

                if (ConfirmNewPassword == null)
                    return;

                if (NewPassword != ConfirmNewPassword)
                {
                    await Application.Current.MainPage.DisplayAlert("Ops!", "As senhas nao coincidem!", "OK");
                    return;
                }

                using (IMaterialModalPage dialog = await MaterialDialog.Instance.LoadingDialogAsync("Processando cadastro..."))
                {
                    IRestResponse response = await AccountService.RegisterAccountTaskAsync(Username, Email, NewPassword);

                    if (response.StatusCode == HttpStatusCode.Created)
                    {
                        dialog.MessageText = "Cadastro efetuado com sucesso!";
                        await Task.Delay(1000);

                        Application.Current.MainPage = new AuthAccountView();
                    }
                    else
                    {
                        await dialog.DismissAsync();
                        await Application.Current.MainPage.DisplayAlert("Algo deu errado!", "Nao foi possivel efetuar o cadastro!\nVerifique sua conexao e tente novamente.", "OK");
                    }
                }
            }
            else
                await Application.Current.MainPage.DisplayAlert("Oh nao!", "Voce precisa preencher os campos!\n", "OK");
        }
    }
}