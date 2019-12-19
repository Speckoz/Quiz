using MobileQuiz.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileQuiz.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GameView : ContentPage
    {
        public GameView(string category)
        {
            InitializeComponent();
            BindingContext = new GameViewModel(this, category);
        }

        public void AddButtons(Button bt) => Buttons_st.Children.Add(bt);

        public void AddButtons(params Button[] bts)
        {
            foreach (Button b in bts)
                Buttons_st.Children.Add(b);
        }

        public void ClearButtons() => Buttons_st.Children.Clear();
    }
}