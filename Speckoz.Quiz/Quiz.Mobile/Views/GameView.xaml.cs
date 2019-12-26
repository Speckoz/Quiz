using Quiz.ViewModels;

using Quiz.Dependencies.Enums;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Quiz.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GameView : ContentPage
    {
        public GameView(CategoryEnum category)
        {
            InitializeComponent();
            BindingContext = new GameViewModel(category);
        }
    }
}