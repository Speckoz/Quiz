using Logikoz.XamarinUtilities.Enums;
using Logikoz.XamarinUtilities.Utilities;

using Xamarin.Forms;

using XF.Material.Forms.UI.Dialogs;
using XF.Material.Forms.UI.Dialogs.Configurations;

namespace Quiz.Mobile.Helpers
{
    public class DialogThemeConfigHelper
    {
        static DialogThemeConfigHelper() => Init();

        public static void Init()
        {
            MaterialDialog.Instance.SetGlobalStyles
            (
                dialogConfiguration: GetThemeAlert(),
                loadingDialogConfiguration: GetThemeLoadiing(),
                confirmationDialogConfiguration: GetThemeConfirm(),
                inputDialogConfiguration: GetThemeInput(),
                customContentDialogConfiguration: GetThemeAlert(),
                snackbarConfiguration: GetThemeSnack()
            );
        }

        private static MaterialSnackbarConfiguration GetThemeSnack()
        {
            return new MaterialSnackbarConfiguration
            {
                BackgroundColor = (Color)ResourceColorUtil.GetResourceColor(ColorsEnum.SnackBarColor).color,
                MessageTextColor = (Color)ResourceColorUtil.GetResourceColor(ColorsEnum.SnackBarTextColor).color,
                TintColor = (Color)ResourceColorUtil.GetResourceColor(ColorsEnum.PrimaryColor).color
            };
        }

        private static MaterialInputDialogConfiguration GetThemeInput()
        {
            return new MaterialInputDialogConfiguration
            {
                BackgroundColor = (Color)ResourceColorUtil.GetResourceColor(ColorsEnum.DialogBackgroundColor).color,
                MessageTextColor = (Color)ResourceColorUtil.GetResourceColor(ColorsEnum.BackgroundTextColor).color,
                InputTextColor = (Color)ResourceColorUtil.GetResourceColor(ColorsEnum.BackgroundTextColor).color,
                InputPlaceholderColor = (Color)ResourceColorUtil.GetResourceColor(ColorsEnum.PrimaryColor).color,
                TintColor = (Color)ResourceColorUtil.GetResourceColor(ColorsEnum.PrimaryColor).color,
                TitleTextColor = (Color)ResourceColorUtil.GetResourceColor(ColorsEnum.BackgroundTextColor).color
            };
        }

        public static MaterialAlertDialogConfiguration GetThemeAlert()
        {
            return new MaterialAlertDialogConfiguration
            {
                BackgroundColor = (Color)ResourceColorUtil.GetResourceColor(ColorsEnum.DialogBackgroundColor).color,
                MessageTextColor = (Color)ResourceColorUtil.GetResourceColor(ColorsEnum.BackgroundTextColor).color,
                TintColor = (Color)ResourceColorUtil.GetResourceColor(ColorsEnum.PrimaryColor).color,
                TitleTextColor = (Color)ResourceColorUtil.GetResourceColor(ColorsEnum.BackgroundTextColor).color
            };
        }

        public static MaterialLoadingDialogConfiguration GetThemeLoadiing()
        {
            return new MaterialLoadingDialogConfiguration
            {
                BackgroundColor = (Color)ResourceColorUtil.GetResourceColor(ColorsEnum.DialogBackgroundColor).color,
                MessageTextColor = (Color)ResourceColorUtil.GetResourceColor(ColorsEnum.BackgroundTextColor).color,
                TintColor = (Color)ResourceColorUtil.GetResourceColor(ColorsEnum.PrimaryColor).color
            };
        }

        public static MaterialConfirmationDialogConfiguration GetThemeConfirm()
        {
            return new MaterialConfirmationDialogConfiguration
            {
                BackgroundColor = (Color)ResourceColorUtil.GetResourceColor(ColorsEnum.DialogBackgroundColor).color,
                TextColor = (Color)ResourceColorUtil.GetResourceColor(ColorsEnum.BackgroundTextColor).color,
                TintColor = (Color)ResourceColorUtil.GetResourceColor(ColorsEnum.PrimaryColor).color,
                TitleTextColor = (Color)ResourceColorUtil.GetResourceColor(ColorsEnum.BackgroundTextColor).color
            };
        }
    }
}