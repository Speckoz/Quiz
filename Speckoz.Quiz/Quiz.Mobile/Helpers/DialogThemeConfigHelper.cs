using Quiz.Mobile.Properties;
using Xamarin.Forms;
using XF.Material.Forms.UI.Dialogs.Configurations;

namespace Quiz.Mobile.Helpers
{
    public class DialogThemeConfigHelper
    {
        public MaterialLoadingDialogConfiguration GetThemeDefault()
        {
            return new MaterialLoadingDialogConfiguration
            {
                BackgroundColor = Color.Default
            };
        }
    }
}