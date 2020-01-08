using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace Quiz.Mobile.Views
{
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainTabListView : TabbedPage
    {
        public MainTabListView() => InitializeComponent();
    }
}