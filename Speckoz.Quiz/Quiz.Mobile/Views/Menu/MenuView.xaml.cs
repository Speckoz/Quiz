using Quiz.ViewModels.Menu;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Quiz.Views.Menu
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