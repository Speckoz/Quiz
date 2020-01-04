using GalaSoft.MvvmLight.Command;

using Xamarin.Forms;

namespace Quiz.Mobile.Models.Menu
{
    internal class MenuModel
    {
        public ItemIdEnum ItemId { get; set; }
        public string Text { get; set; }
        public RelayCommand<Grid> MenuItemCommand { get; set; }
    }

    internal enum ItemIdEnum
    {
        Home, Perfil, Logout, VOID, About
    }
}