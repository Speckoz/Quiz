using GalaSoft.MvvmLight.Command;

using Quiz.Dependencies.Enums;

using System.ComponentModel;
using System.Runtime.CompilerServices;

using XF.Material.Forms.UI;

namespace Quiz.Mobile.Models.ManagerQuestions
{
    internal class SuggestQuestionChipModel
    {
        public RelayCommand<MaterialChip> IncorrectAnswerCommand { get; set; }
        public string IncorrectAnswerText { get; set; }
    }

    internal class SuggestQuestionModel : QuestionModel, INotifyPropertyChanged
    {
        private CategoryEnum __category;
        private string __incorrectAnswers;

        public override string IncorrectAnswers
        {
            get => __incorrectAnswers;
            set => OnPropertyChanged(ref __incorrectAnswers, value);
        }

        public override CategoryEnum Category
        {
            get => __category;
            set => OnPropertyChanged(ref __category, value);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged<T>(ref T item, T value, [CallerMemberName] string property = null)
        {
            item = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}