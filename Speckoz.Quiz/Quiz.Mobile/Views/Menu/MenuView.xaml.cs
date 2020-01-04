using Quiz.Mobile.ViewModels.Menu;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Quiz.Mobile.Views.Menu
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