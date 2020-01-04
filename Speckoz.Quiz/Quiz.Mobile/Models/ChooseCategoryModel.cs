using GalaSoft.MvvmLight.Command;

using Quiz.Dependencies.Enums;

using Xamarin.Forms;

namespace Quiz.Mobile.Models
{
    internal class ChooseCategoryModel
    {
        public Thickness PaddingButton { get; set; } = 5;
        public Color BackgroundColor { get; set; } = Color.Gray;
        public RelayCommand<Button> ChooseAnswerCommand { get; set; }
        public CategoryEnum TextButton { get; set; }
    }
}