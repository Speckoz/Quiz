using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MobileQuiz.Helpers;
using MobileQuiz.Views;

using System.IO;

using Xamarin.Forms;

namespace MobileQuiz.ViewModels
{
    internal class ChooseCategoryViewModel : ViewModelBase
    {
        private readonly ChooseCategoryView _page;

        private ImageSource __image = ConvertImageHelper.Convert(Properties.Resources.choose);

        public ImageSource Image
        {
            get => __image;
            set
            {
                __image = value;
                RaisePropertyChanged();
            }
        }

        public RelayCommand<Button> ChooseAnswerCommand { get; private set; }

        public ChooseCategoryViewModel(ChooseCategoryView page)
        {
            _page = page;
            ChooseAnswerCommand = new RelayCommand<Button>(ChooseCategory);
        }

        private void ChooseCategory(Button bt)
        {
            Application.Current.MainPage = new GameView(bt.Text);
        }
    }
}