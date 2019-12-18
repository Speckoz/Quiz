using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

using MobileQuiz.Views;

using System.IO;

using Xamarin.Forms;

namespace MobileQuiz.ViewModels
{
    internal class ChooseCategoryViewModel : ViewModelBase
    {
        private readonly ChooseCategoryView _page;

        private ImageSource __image = Convert();
        private string __chooseCategory = "Escolha aqui";

        public ImageSource Image
        {
            get => __image;
            set
            {
                __image = value;
                RaisePropertyChanged();
            }
        }

        public string ChooseCategoryText
        {
            get => __chooseCategory;
            set
            {
                __chooseCategory = value;
                RaisePropertyChanged();
            }
        }

        public RelayCommand ChooseAnswerCommand { get; private set; }

        public ChooseCategoryViewModel(ChooseCategoryView page)
        {
            _page = page;
            ChooseAnswerCommand = new RelayCommand(ChooseCategory);
        }

        private void ChooseCategory()
        {
            ChooseCategoryText = "Escolha mudou";
        }

        private async void ChooseCategory(Button bt)
        {
            //Application.Current.MainPage = new GameView(obj.Text);
            await _page.DisplayAlert("Botao", bt.Text, "OK");
        }

        private static ImageSource Convert()
        {
            Stream stream = new MemoryStream(Properties.Resources.choose);
            return ImageSource.FromStream(() => stream);
        }
    }
}