using Quiz.Mobile.Helpers;
using Quiz.Mobile.Views.Starting;

using Xamarin.Forms;

using XF.Material.Forms;

namespace Quiz
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Material.Init(this);
            DialogThemeConfigHelper.Init();
        }

        protected override void OnStart() => MainPage = new AuthAccountView();

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