using MobileQuiz.Models;
using MobileQuiz.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
            UserModel user = new UserModel(this.loginLbl.Text, this.passwordLbl.Text);
            // Login Service
        }
    }
}
