using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

using Quiz.Mobile.Helpers;
using Quiz.Mobile.Models.Menu;
using Quiz.Mobile.Models.Starting;
using Quiz.Mobile.Properties;
using Quiz.Mobile.Util;
using Quiz.Mobile.Views;
using Quiz.Mobile.Views.Starting;

using System;
using System.Collections.ObjectModel;

using Xamarin.Forms;

using XF.Material.Forms.UI.Dialogs;

namespace Quiz.Mobile.ViewModels.Menu
{
    internal class MenuViewModel : ViewModelBase
    {
        private ImageSource __userImage;
        private ObservableCollection<MenuModel> __menuItems;
        private string __userType;

        public ImageSource UserImage
        {
            get => __userImage;
            set => Set(ref __userImage, value);
        }

        public string UserName
        {
            get => GetDataHelper.CurrentUser.User.Username;
            set
            {
                GetDataHelper.CurrentUser.User.Username = value;
                RaisePropertyChanged();
            }
        }

        public string UserType
        {
            get => __userType;
            set => Set(ref __userType, value);
        }

        public ObservableCollection<MenuModel> MenuItems
        {
            get => __menuItems;
            set => Set(ref __menuItems, value);
        }

        public MenuViewModel() => Init();

        private void Init()
        {
            UserImage = ConvertImageUtil.Convert(Resources.choose);
            UserName = GetDataHelper.CurrentUser.User.Email;
            UserType = DescriptionValueUtil.Get(GetDataHelper.CurrentUser.User.UserType);

            MenuItems = new ObservableCollection<MenuModel>
            {
                new MenuModel { Text = "Inicio", ItemId = ItemIdEnum.Home, MenuItemCommand = new RelayCommand<Grid>(MenuItemSelected) },
                new MenuModel { Text = "Ver Perfil", ItemId = ItemIdEnum.Profile, MenuItemCommand = new RelayCommand<Grid>(MenuItemSelected) },
                new MenuModel { Text = "Deslogar", ItemId = ItemIdEnum.Logout, MenuItemCommand = new RelayCommand<Grid>(MenuItemSelected) },
                new MenuModel { Text = string.Empty, ItemId = ItemIdEnum.VOID, MenuItemCommand = new RelayCommand<Grid>(MenuItemSelected) },
                new MenuModel { Text = "Desenvolvedores", ItemId = ItemIdEnum.Devs, MenuItemCommand = new RelayCommand<Grid>(MenuItemSelected) },
                new MenuModel { Text = "Sobre", ItemId = ItemIdEnum.About, MenuItemCommand = new RelayCommand<Grid>(MenuItemSelected) }
            };
        }

        private async void MenuItemSelected(Grid obj)
        {
            obj.BackgroundColor = Color.LightGray;

            switch (Enum.Parse<ItemIdEnum>(obj.ClassId))
            {
                case ItemIdEnum.Home:
                    (Application.Current.MainPage as MasterDetailPage).Detail = new NavigationPage(new MainTabListView());
                    break;

                case ItemIdEnum.Profile:
                    UserBase user = GetDataHelper.CurrentUser.User;
                    await MaterialDialog.Instance.AlertAsync($"Username: {user.Username}\nEmail: {user.Email}\nTipo: {user.UserType}\nLevel: {user.Level}", "Perfil", "OK");
                    break;

                case ItemIdEnum.Logout:
                    if ((await MaterialDialog.Instance.ConfirmAsync("Realmente deseja deslogar da conta atual?", "ATENÇAO!", "Deslogar", "Cancelar")) == true)
                        Application.Current.MainPage = new AuthAccountView();
                    break;

                case ItemIdEnum.Devs:
                    await MaterialDialog.Instance.AlertAsync("Ruan Carlos CS (@Logikoz)\nMarco Pandolfo (@lolgamarco2)", "Desenvolvedores", "OK");
                    break;

                case ItemIdEnum.About:
                    await MaterialDialog.Instance.AlertAsync("Vai criar uma view vagabundo", "Sobre", "OK");
                    break;
            }
            obj.BackgroundColor = Color.Transparent;
        }
    }
}