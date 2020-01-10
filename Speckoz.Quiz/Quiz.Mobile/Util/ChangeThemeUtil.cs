using Logikoz.ThemeBase.Enums;
using Logikoz.ThemeBase.Services;

using Xamarin.Forms;

using XF.Material.Forms;

namespace Quiz.Mobile.Util
{
    internal static class ChangeThemeUtil
    {
        /// <summary>
        /// Altera o tema (dark/light) do app e inicia o XF-Material.
        /// </summary>
        /// <param name="theme"></param>
        public static void Change(ThemeEnum theme)
        {
            ThemeManagerService.ChangeTheme(theme);
            Material.Init(Application.Current);
        }
    }
}