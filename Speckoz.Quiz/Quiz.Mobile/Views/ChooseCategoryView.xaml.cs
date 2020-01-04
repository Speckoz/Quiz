using Quiz.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Quiz.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChooseCategoryView : ContentPage
    {
        public ChooseCategoryView()
        {
            InitializeComponent();

            BindingContext = new ChooseCategoryViewModel();
        }
    }
}