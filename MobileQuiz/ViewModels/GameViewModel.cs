using GalaSoft.MvvmLight;

namespace MobileQuiz.ViewModels
{
    class GameViewModel : ViewModelBase
    {
        private int __points;
        private int __round;

        public int Points
        {
            get => __points;
            set
            {
                __points = value;
                RaisePropertyChanged();
            }
        }
        public int Round
        {
            get => __round;
            set
            {
                __round = value;
                RaisePropertyChanged();
            }
        }
    }
}
