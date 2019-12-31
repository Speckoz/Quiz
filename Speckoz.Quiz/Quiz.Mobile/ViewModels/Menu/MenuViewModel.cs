using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

using Quiz.Helpers;
using Quiz.Mobile.Properties;
using Quiz.Models.Menu;
using Quiz.Views;
using Quiz.Views.Starting;

using System;
using System.Collections.ObjectModel;

using Xamarin.Forms;

namespace Quiz.ViewModels.Menu
{
    internal class MenuViewModel : ViewModelBase
    {
        private ImageSource __userImage;
        private string __userName;
        private ObservableCollection<MenuModel> __menuItems;

        public ImageSource UserImage
        {
            get => __userImage;
            set => Set(ref __userImage, value);
        }

        public string UserName
        {
            get => __userName;
            set => Set(ref __userName, value);
        }

        public ObservableCollection<MenuModel> MenuItems
        {
            get => __menuItems;
            set => Set(ref __menuItems, value);
        }

        public MenuViewModel()
        {
            UserImage = ConvertImageHelper.Convert(Resources.choose);
            UserName = "Ruan Carlos CS";

            MenuItems = new ObservableCollection<MenuModel>
            {
                new MenuModel { Text = "Inicio", ItemId = ItemIdEnum.Home, MenuItemCommand = new RelayCommand<Grid>(MenuItemSelected)},
                new MenuModel { Text = "Ver Perfil", ItemId = ItemIdEnum.Perfil, MenuItemCommand = new RelayCommand<Grid>(MenuItemSelected)},
                new MenuModel { Text = "Deslogar", ItemId = ItemIdEnum.Logout, MenuItemCommand = new RelayCommand<Grid>(MenuItemSelected)},
                new MenuModel { Text = string.Empty, ItemId = ItemIdEnum.VOID, MenuItemCommand = new RelayCommand<Grid>(MenuItemSelected)},
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

                case ItemIdEnum.Perfil:
                    //add perfil here
                    break;

                case ItemIdEnum.Logout:
                    if (await Application.Current.MainPage.DisplayAlert("ATENÇAO!", "Realmente deseja deslogar da conta atual?", "Deslogar", "Cancelar"))
                        Application.Current.MainPage = new AuthAccountView();
                    break;

                case ItemIdEnum.About:
                    //add about here
                    break;
            }
            obj.BackgroundColor = Color.Transparent;
        }
    }
}