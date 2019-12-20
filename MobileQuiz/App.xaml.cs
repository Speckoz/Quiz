using MobileQuiz.Views.Starting;

using Xamarin.Forms;

namespace MobileQuiz
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            XF.Material.Forms.Material.Init(this);
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