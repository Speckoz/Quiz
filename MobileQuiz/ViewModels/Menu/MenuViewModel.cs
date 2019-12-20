using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

using MobileQuiz.Helpers;
using MobileQuiz.Models.Menu;
using MobileQuiz.Views;
using MobileQuiz.Views.Starting;

using System;
using System.Collections.ObjectModel;
using System.Threading;

using Xamarin.Forms;

namespace MobileQuiz.ViewModels.Menu
{
    internal class MenuViewModel : ViewModelBase
    {
        private ImageSource __userImage;
        private string __userName;
        private ObservableCollection<MenuModel> __menuItems;

        public ImageSource UserImage
        {
            get => __userImage;
            set
            {
                __userImage = value;
                RaisePropertyChanged();
            }
        }

        public string UserName
        {
            get => __userName;
            set
            {
                __userName = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<MenuModel> MenuItems
        {
            get => __menuItems;
            set
            {
                __menuItems = value;
                RaisePropertyChanged();
            }
        }

        public MenuViewModel()
        {
            UserImage = ConvertImageHelper.Convert(Properties.Resources.choose);
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
                    //App.Current.MainPage.Navigation.PushModalAsync
                    break;

                case ItemIdEnum.Logout:
                    if (await Application.Current.MainPage.DisplayAlert("ATENÇAO!", "Realmente deseja deslogar da conta atual?", "Deslogar", "Cancelar"))
                        Application.Current.MainPage = new AuthAccountView();
                    break;

                case ItemIdEnum.About:
                    //add about here
                    //Application.Current.MainPage.Navigation
                    break;
            }
            obj.BackgroundColor = Color.Transparent;
        }
    }
}