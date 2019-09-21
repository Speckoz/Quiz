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
    public partial class EscolherCategoria : ContentPage
    {
        public EscolherCategoria()
        {
            InitializeComponent();
        }

        private void Todas_Clicked(object sender, EventArgs e)
        {
            QuestionService.GetRandomQuestion();
            Application.Current.MainPage = new Jogo();
        }
        private void Ciencia_Clicked(object sender, EventArgs e)
        {
            QuestionService.GetRandomQuestion("Ciencia");
        }
        private void Arte_Clicked(object sender, EventArgs e)
        {
            QuestionService.GetRandomQuestion("Arte");
        }
        private void Historia_Clicked(object sender, EventArgs e)
        {
            QuestionService.GetRandomQuestion("Historia");
        }
        private void Geografia_Clicked(object sender, EventArgs e)
        {
            QuestionService.GetRandomQuestion("Geografia");
        }
    }
}