using System.Threading.Tasks;

using Xamarin.Forms;

namespace Quiz.Mobile.Util
{
    internal class PopPushViewUtil
    {
        public static async Task PushAsync(Page page, bool animated = false)
        {
            await Task.Delay(200);
            await Application.Current.MainPage.Navigation.PushAsync(page, animated);
        }

        public static async Task PopAsync(bool animated = false)
        {
            await Task.Delay(200);
            try
            {
                await Application.Current.MainPage.Navigation.PopAsync(animated);
            }
            catch { }
        }

        public static async Task PushModalAsync(Page page, bool animated = false)
        {
            await Task.Delay(200);
            await Application.Current.MainPage.Navigation.PushModalAsync(page, animated);
        }

        public static async Task PopModalAsync(bool animated = false)
        {
            await Task.Delay(200);
            try
            {
                await Application.Current.MainPage.Navigation.PopModalAsync(animated);
            }
            catch { }
        }
    }
}