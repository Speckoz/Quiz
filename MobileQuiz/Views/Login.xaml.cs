using MobileQuiz.Models;
using MobileQuiz.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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

            Application.Current.MainPage = new ChooseCategoryView();
        }

        private void Register_Clicked(object sender, EventArgs e) => Application.Current.MainPage = new Registrar();

        private async void About_Clicked(object sender, EventArgs e)
        {
            //await DisplayAlert("Sobre", $"Criado por Specko\n\nModificado por Logikoz\n\n{System.Text.Encoding.Default.GetString(Properties.Resources.Questions)}", "Fechar");
            try
            {

                string value = System.Text.Encoding.UTF8.GetString(Properties.Resources.Questions);
                await DisplayAlert("Json", value, "OK");
                List<QuestionModel> qs = JsonConvert.DeserializeObject<List<QuestionModel>>(value);
                await DisplayAlert(qs[0].Question, qs[0].CorrectAnswer, "Ok");
            }
            catch (Exception ex)
            {
                if(await DisplayAlert("Error", ex.GetType().FullName + $"\n{ex.Message}\n\n{ex.StackTrace}", "Aceitar", "Cancelar") == true)
                {
                    await DisplayAlert("Hu rhuu", "Voce aceitou", "OK");
                }
            }
        }
    }
}