using Quiz.Dependencies.Enums;
using Quiz.Mobile.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Quiz.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GameView : ContentPage
    {
        public GameView(CategoryEnum category)
        {
            InitializeComponent();
            BindingContext = new GameViewModel(category);
        }

        protected override bool OnBackButtonPressed()
        {
            (BindingContext as GameViewModel).ForceGameOverCommand.Execute(null);
            return true;
        }
    }
}