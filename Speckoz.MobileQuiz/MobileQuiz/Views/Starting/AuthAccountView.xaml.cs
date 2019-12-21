using MobileQuiz.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileQuiz.Views.Starting
{
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