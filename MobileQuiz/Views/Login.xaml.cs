using MobileQuiz.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MobileQuiz.Services;

namespace MobileQuiz.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Clicked(object sender, EventArgs e)
        {
            var user = UserService.SearchUser(this.loginLbl.Text, this.passwordLbl.Text);
            if (user == null)
            {
                DisplayAlert("Erro", "Usuario não encontrado!", "OK");
                return;
            }

            Application.Current.MainPage = new EscolherCategoria();
        }
    }
}
