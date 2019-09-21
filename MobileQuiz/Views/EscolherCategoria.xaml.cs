using MobileQuiz.Models;
using MobileQuiz.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static MobileQuiz.Services.QuestionService;

namespace MobileQuiz.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EscolherCategoria : ContentPage
    {
        public EscolherCategoria()
        {
            InitializeComponent();
        }

        private void Categoria_Clicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            QuestionModel question = btn.Text == "Todas" ? GetRandomQuestion() : GetRandomQuestion(btn.Text);
            //Application.Current.MainPage = new Jogo(question);
        }
    }
}