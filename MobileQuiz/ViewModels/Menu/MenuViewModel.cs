using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MobileQuiz.Helpers;
using MobileQuiz.Models.Menu;
using System;
using System.Collections.ObjectModel;

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
                new MenuModel { Text = "Inicio", ItemId = 0, MenuItemCommand = new RelayCommand<Grid>(MenuItemSelected)},
                new MenuModel { Text = "Ver Perfil", ItemId = 1, MenuItemCommand = new RelayCommand<Grid>(MenuItemSelected)},
                new MenuModel { Text = "Deslogar", ItemId = 2, MenuItemCommand = new RelayCommand<Grid>(MenuItemSelected)},
                new MenuModel { Text = string.Empty, ItemId = 3, MenuItemCommand = new RelayCommand<Grid>(MenuItemSelected)},
                new MenuModel { Text = "Sobre", ItemId = 4, MenuItemCommand = new RelayCommand<Grid>(MenuItemSelected) }
            };
        }

        private async void MenuItemSelected(Grid obj)
        {
            obj.BackgroundColor = Color.LightGray;
            byte item = byte.Parse(obj.ClassId);
            if (item != 3)
            {
                await App.Current.MainPage.DisplayAlert(item + " " + (obj.Children[0] as Label).Text, "parece que foi", "OK");
            }
            obj.BackgroundColor = Color.Transparent;
        }
    }
}