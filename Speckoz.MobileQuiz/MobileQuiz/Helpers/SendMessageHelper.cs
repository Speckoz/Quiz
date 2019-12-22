using Xamarin.Forms;

using XF.Material.Forms.UI.Dialogs;

namespace MobileQuiz.Helpers
{
    internal static class SendMessageHelper
    {
        public static async void SendAsync(string message, string title)
        {
            try
            {
                await MaterialDialog.Instance.SnackbarAsync($"{title}, {message}", MaterialSnackbar.DurationLong);
            }
            catch
            {
                await Application.Current.MainPage.DisplayAlert(title, message, "OK");
            }
        }
    }
}