using Logikoz.ThemeBase.Enums;

using Quiz.Mobile.Util;
using Quiz.Mobile.Views.Starting;

using Xamarin.Forms;

namespace Quiz
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            ChangeThemeUtil.Change(ThemeEnum.Dark);
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