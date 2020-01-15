using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

using Logikoz.XamarinUtilities.Utilities;

using Quiz.Mobile.Helpers;
using Quiz.Mobile.Models.Menu;
using Quiz.Mobile.Views;
using Quiz.Mobile.Views.Menu;
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
        private string __userName;

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
            //UserImage = ImageSource.FromFile("heartLogo.png");
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
                    var mainTabListView = ((Application.Current.MainPage as MasterDetailPage).Detail as NavigationPage).RootPage as MainTabListView;
                    mainTabListView.CurrentPage = mainTabListView.Children[0];
                    break;

                case ItemIdEnum.Profile:

                    var mainScreenView = Application.Current.MainPage as MainScreenView;
                    INavigation navigation = (mainScreenView.Detail as NavigationPage).RootPage.Navigation;

                    PopPushViewUtil.Pop<ProfileView>(navigation);
                    await PopPushViewUtil.PushAsync(navigation, new ProfileView(), true);
                    mainScreenView.IsPresented = false;

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