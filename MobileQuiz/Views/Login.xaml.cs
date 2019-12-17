using MobileQuiz.Models;
using MobileQuiz.Services;

using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileQuiz.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login() => InitializeComponent();

        private async void Login_Clicked(object sender, EventArgs e)
        {
            UserModel user = UserService.SearchUser(loginLbl.Text, passwordLbl.Text);
            if (user == null)
            {
                await DisplayAlert("Erro", "Usuario não encontrado!", "OK");
                return;
            }

            Application.Current.MainPage = new EscolherCategoria();
        }

        private void Register_Clicked(object sender, EventArgs e) => Application.Current.MainPage = new Registrar();

        private async void About_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Sobre", $"Criado por Specko\n\nModificado por Logikoz\n\n{System.Text.Encoding.Default.GetString(Properties.Resources.Questions)}", "Fechar");
        }
    }
}