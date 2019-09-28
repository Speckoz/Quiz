using MobileQuiz.Models;
using MobileQuiz.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileQuiz.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registrar : ContentPage
    {
        public Registrar()
        {
            InitializeComponent();
        }

        private async void Register_Clicked(object sender, EventArgs e)
        {
            UserModel user = new UserModel(this.loginLbl.Text, this.passwordLbl.Text);
            UserService.SaveUser(user);
            await DisplayAlert("Cadastrado", "Usuario cadastrado com sucesso!\n", "OK");
            Application.Current.MainPage = new Login();
        }

        private void Back_Clicked(object sender, EventArgs e) => Application.Current.MainPage = new Login();
    }
}