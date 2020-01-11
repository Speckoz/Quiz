using Quiz.Mobile.ViewModels.Starting;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Quiz.Mobile.Views.Starting
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterAccountView : ContentPage
    {
        public RegisterAccountView()
        {
            InitializeComponent();
            BindingContext = new RegisterAccountViewModel();
        }

        protected override bool OnBackButtonPressed()
        {
            (BindingContext as RegisterAccountViewModel).BackCommand.Execute(null);

            return true;
        }
    }
}