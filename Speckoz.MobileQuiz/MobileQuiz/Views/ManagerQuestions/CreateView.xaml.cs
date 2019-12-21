using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileQuiz.Views.ManagerQuestions
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateView : ContentPage
    {
        public CreateView() => InitializeComponent();

        private async void ToolbarItem_Clicked(object sender, EventArgs e) =>
            await Application.Current.MainPage.Navigation.PopModalAsync(true);
    }
}