using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Quiz.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainTabListView : TabbedPage
    {
        public MainTabListView() => InitializeComponent();
    }
}