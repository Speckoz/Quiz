using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileQuiz.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EscolherCategoria : ContentPage
    {
        public EscolherCategoria() => InitializeComponent();

        private void Category_Clicked(object sender, EventArgs e) => Application.Current.MainPage = new Jogo(((Button)sender).Text);
    }
}