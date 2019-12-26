using GalaSoft.MvvmLight.Command;

using System.ComponentModel;

using XF.Material.Forms.UI;

namespace Quiz.Models.ManagerQuestions
{
    internal class SuggestQuestionChipModel
    {
        public RelayCommand<MaterialChip> IncorrectAnswerCommand { get; set; }
        public string IncorrectAnswerText { get; set; }
    }

    internal class SuggestQuestionModel : QuestionModel, INotifyPropertyChanged
    {
        private string __category;

        public new string Category
        {
            get => __category;
            set
            {
                __category = value;
                PC?.Invoke(this, new PropertyChangedEventArgs(nameof(Category)));
            }
        }

        public event PropertyChangedEventHandler PC;
    }
}