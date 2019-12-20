using GalaSoft.MvvmLight.Command;

using Xamarin.Forms;

namespace MobileQuiz.Models.Menu
{
    internal class MenuModel
    {
        public byte ItemId { get; set; }
        public string Text { get; set; }
        public RelayCommand<Grid> MenuItemCommand { get; set; }
    }
}