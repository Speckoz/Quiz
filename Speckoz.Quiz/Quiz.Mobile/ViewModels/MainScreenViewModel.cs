using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

using Logikoz.ThemeBase.Enums;

using Quiz.Mobile.Util;

namespace Quiz.Mobile.ViewModels
{
    internal class MainScreenViewModel : ViewModelBase
    {
        private ThemeEnum currentTheme;

        public RelayCommand ChangeThemeCommand { get; set; }

        public MainScreenViewModel() => Init();

        private void Init()
        {
            ChangeThemeCommand = new RelayCommand(() => ChangeThemeUtil.Change(currentTheme = (currentTheme == ThemeEnum.Light) ? ThemeEnum.Dark : ThemeEnum.Light));
        }
    }
}