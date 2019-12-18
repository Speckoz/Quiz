using MobileQuiz.Models;
using MobileQuiz.Services;

using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileQuiz.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterAccountView : ContentPage
    {
        public RegisterAccountView() => InitializeComponent();

        private async void Register_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(loginLbl.Text) && !string.IsNullOrEmpty(passwordLbl.Text))
            {
                UserService.SaveUser(new UserModel { Login = loginLbl.Text, Password = passwordLbl.Text });
                await DisplayAlert("Cadastrado", "Usuario cadastrado com sucesso!\n", "OK");

                Application.Current.MainPage = new AuthAccountView();
            }
            else
                await DisplayAlert("Oh nao!", "Voce precisa preencher os campos!\n", "OK");
        }

        private void Back_Clicked(object sender, EventArgs e) => Application.Current.MainPage = new AuthAccountView();
    }
}