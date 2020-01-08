using Quiz.Mobile.ViewModels.Starting;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace Quiz.Mobile.Views.Starting
{
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthAccountView : ContentPage
    {
        public AuthAccountView()
        {
            InitializeComponent();
            BindingContext = new AuthAccountViewModel();
        }
    }
}