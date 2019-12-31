using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

using Quiz.Helpers;
using Quiz.Mobile.Helpers;
using Quiz.Mobile.Models.Starting;
using Quiz.Mobile.Properties;
using Quiz.Mobile.Services.Requests;
using Quiz.Views;
using Quiz.Views.Starting;

using RestSharp;

using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

using Xamarin.Forms;

using XF.Material.Forms.UI.Dialogs;

namespace Quiz.ViewModels
{
    public class AuthAccountViewModel : ViewModelBase
    {
        private string __login;
        private string __password;
        private ImageSource __image;

        public string Login
        {
            get => __login;
            set => Set(ref __login, value);
        }

        public string Password
        {
            get => __password;
            set => Set(ref __password, value);
        }

        public ImageSource Image
        {
            get => __image;
            set => Set(ref __image, value);
        }

        public RelayCommand AuthCommand { get; private set; }
        public RelayCommand RegisterCommand { get; private set; }

        public AuthAccountViewModel() => InitCommands();

        private void InitCommands()
        {
            Image = ConvertImageHelper.Convert(Resources.heartLogo);
            AuthCommand = new RelayCommand(Auth);
            RegisterCommand = new RelayCommand(Register);
        }

        private async void Auth()
        {
            if (string.IsNullOrEmpty(Login) || string.IsNullOrEmpty(Password))
            {
                await Application.Current.MainPage.DisplayAlert("Ops!", "Voce precisa preencher os campos!", "OK");
                return;
            }

            using (var dialog = await MaterialDialog.Instance.LoadingDialogAsync("Autenticando..."))
            {
                IRestResponse response = await AccountService.AuthAccountTaskAsync(Login, Password);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    dialog.MessageText = "Autenticado com sucesso!";

                    GetDataHelper.User = JsonSerializer.Deserialize<UserLogin>(response.Content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    await Task.Delay(1000);

                    Application.Current.MainPage = new MainScreenView();
                }
                else if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    await dialog.DismissAsync();
                    await Application.Current.MainPage.DisplayAlert("🤔", "Usuario ou Senha está incorreto!", "OK");
                }
                else
                {
                    await dialog.DismissAsync();
                    await Application.Current.MainPage.DisplayAlert("😑", "Algo deu errado, verifique sua conexao e tente novamente!", "OK");
                }
            }
        }

        private async void Register() => await Application.Current.MainPage.Navigation.PushModalAsync(new RegisterAccountView(), true);
    }
}