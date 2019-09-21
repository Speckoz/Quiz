using MobileQuiz.Models;
using MobileQuiz.Services;
using System;
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

        private void Categoria_Clicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Application.Current.MainPage = new Jogo(btn.Text);
        }
    }
}