using Logikoz.ThemeBase.Enums;
using Logikoz.ThemeBase.Helpers;

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
                BackgroundColor = (Color)GetResourceColorHelper.GetResourceColor(ColorsEnum.SnackBarColor).color,
                MessageTextColor = (Color)GetResourceColorHelper.GetResourceColor(ColorsEnum.SnackBarTextColor).color,
                TintColor = (Color)GetResourceColorHelper.GetResourceColor(ColorsEnum.PrimaryColor).color
            };
        }

        private static MaterialInputDialogConfiguration GetThemeInput()
        {
            return new MaterialInputDialogConfiguration
            {
                BackgroundColor = (Color)GetResourceColorHelper.GetResourceColor(ColorsEnum.DialogBackgroundColor).color,
                MessageTextColor = (Color)GetResourceColorHelper.GetResourceColor(ColorsEnum.BackgroundTextColor).color,
                TintColor = (Color)GetResourceColorHelper.GetResourceColor(ColorsEnum.PrimaryColor).color,
                TitleTextColor = (Color)GetResourceColorHelper.GetResourceColor(ColorsEnum.BackgroundTextColor).color
            };
        }

        public static MaterialAlertDialogConfiguration GetThemeAlert()
        {
            return new MaterialAlertDialogConfiguration
            {
                BackgroundColor = (Color)GetResourceColorHelper.GetResourceColor(ColorsEnum.DialogBackgroundColor).color,
                MessageTextColor = (Color)GetResourceColorHelper.GetResourceColor(ColorsEnum.BackgroundTextColor).color,
                TintColor = (Color)GetResourceColorHelper.GetResourceColor(ColorsEnum.PrimaryColor).color,
                TitleTextColor = (Color)GetResourceColorHelper.GetResourceColor(ColorsEnum.BackgroundTextColor).color
            };
        }

        public static MaterialLoadingDialogConfiguration GetThemeLoadiing()
        {
            return new MaterialLoadingDialogConfiguration
            {
                BackgroundColor = (Color)GetResourceColorHelper.GetResourceColor(ColorsEnum.DialogBackgroundColor).color,
                MessageTextColor = (Color)GetResourceColorHelper.GetResourceColor(ColorsEnum.BackgroundTextColor).color,
                TintColor = (Color)GetResourceColorHelper.GetResourceColor(ColorsEnum.PrimaryColor).color
            };
        }

        public static MaterialConfirmationDialogConfiguration GetThemeConfirm()
        {
            return new MaterialConfirmationDialogConfiguration
            {
                BackgroundColor = (Color)GetResourceColorHelper.GetResourceColor(ColorsEnum.DialogBackgroundColor).color,
                TextColor = (Color)GetResourceColorHelper.GetResourceColor(ColorsEnum.BackgroundTextColor).color,
                TintColor = (Color)GetResourceColorHelper.GetResourceColor(ColorsEnum.PrimaryColor).color,
                TitleTextColor = (Color)GetResourceColorHelper.GetResourceColor(ColorsEnum.BackgroundTextColor).color
            };
        }
    }
}