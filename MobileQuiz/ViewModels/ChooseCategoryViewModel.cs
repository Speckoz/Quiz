using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MobileQuiz.Views;
using System.IO;

using Xamarin.Forms;

namespace MobileQuiz.ViewModels
{
    internal class ChooseCategoryViewModel : ViewModelBase
    {
        public ImageSource Image
        {
            get
            {
                using Stream stream = new MemoryStream(Properties.Resources.choose);
                return ImageSource.FromStream(() => stream);
            }
        }
        public RelayCommand<Button> ChooseAnswerCommand { get; private set; }

        public ChooseCategoryViewModel()
        {
            ChooseAnswerCommand = new RelayCommand<Button>(ChooseAnswer);
        }

        private void ChooseAnswer(Button obj) => Application.Current.MainPage = new GameView(obj.Text);
    }
}