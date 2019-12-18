using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

using MobileQuiz.Helpers;
using MobileQuiz.Models;
using MobileQuiz.Services;
using MobileQuiz.Views;

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

            Application.Current.MainPage = new ChooseCategoryView();
        }

        private async void About()
        {
            await _page.DisplayAlert("Sobre", $"Criado por Specko\n\nModificado por Logikoz", "Fechar");

            //try
            //{
            //    string value = System.Text.Encoding.UTF8.GetString(Properties.Resources.Questions);
            //    await _page.DisplayAlert("Json", value, "OK");
            //    List<QuestionModel> qs = JsonConvert.DeserializeObject<List<QuestionModel>>(value);
            //    await _page.DisplayAlert(qs[0].Question, qs[0].CorrectAnswer, "Ok");
            //}
            //catch (Exception ex)
            //{
            //    if (await _page.DisplayAlert("Error", ex.GetType().FullName + $"\n{ex.Message}\n\n{ex.StackTrace}", "Aceitar", "Cancelar") == true)
            //    {
            //        await _page.DisplayAlert("Hu rhuu", "Voce aceitou", "OK");
            //    }
            //}
        }

        private void Register() => Application.Current.MainPage = new RegisterAccountView();
    }
}