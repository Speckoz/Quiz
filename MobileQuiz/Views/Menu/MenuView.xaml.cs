using MobileQuiz.ViewModels.Menu;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileQuiz.Views.Menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuView : ContentPage
    {
        public MenuView()
        {
            InitializeComponent();
            BindingContext = new MenuViewModel();
        }
    }
}