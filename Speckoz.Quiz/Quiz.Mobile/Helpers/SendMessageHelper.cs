using XF.Material.Forms.UI.Dialogs;

namespace Quiz.Mobile.Helpers
{
    public static class SendMessageHelper
    {
        public static async void SendAsync(string message, string title)
        {
            try
            {
                await MaterialDialog.Instance.SnackbarAsync($"{title}, {message}", MaterialSnackbar.DurationLong);
            }
            catch
            {
                await MaterialDialog.Instance.AlertAsync(message, title, "OK");
            }
        }
    }
}