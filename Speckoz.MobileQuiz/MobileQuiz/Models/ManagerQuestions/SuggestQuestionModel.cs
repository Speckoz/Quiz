using GalaSoft.MvvmLight.Command;

using XF.Material.Forms.UI;

namespace MobileQuiz.Models.ManagerQuestions
{
    internal class SuggestQuestionChipModel
    {
        public RelayCommand<MaterialChip> IncorrectAnswerCommand { get; set; }
        public string IncorrectAnswerText { get; set; }
    }
}