using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;

using Xamarin.Forms.Platform.Android;

namespace Quiz.Droid
{
    [Activity(Label = "Quiz", Icon = "@mipmap/icon", Theme = "@style/LightTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.abc_screen_toolbar;
            ToolbarResource = Resource.Layout.abc_screen_toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            Xamarin.Forms.Forms.Init(this, savedInstanceState);
            XF.Material.Droid.Material.Init(this, savedInstanceState);

            ImageCircle.Forms.Plugin.Droid.ImageCircleRenderer.Init();

            Xamarin.Forms.FormsMaterial.Init(this, savedInstanceState);

            LoadApplication(new App());
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}