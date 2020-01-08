using Quiz.Mobile.Helpers;
using Quiz.Mobile.Views.Starting;

using Xamarin.Forms;
using Xamarin.Forms.Internals;

using XF.Material.Forms;

namespace Quiz
{
    [Preserve(AllMembers = true)]
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Material.Init(this);
            DialogThemeConfigHelper.Init();

            MainPage = new AuthAccountView();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}