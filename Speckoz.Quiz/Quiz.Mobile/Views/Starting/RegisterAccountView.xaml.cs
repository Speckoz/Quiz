using Quiz.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Quiz.Views.Starting
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterAccountView : ContentPage
    {
        public RegisterAccountView()
        {
            InitializeComponent();
            BindingContext = new RegisterAccountViewModel();
        }
    }
}