using Quiz.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Quiz.Views
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