using Quiz.Mobile.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace Quiz.Mobile.Views
{
    [Preserve(AllMembers = true)]
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