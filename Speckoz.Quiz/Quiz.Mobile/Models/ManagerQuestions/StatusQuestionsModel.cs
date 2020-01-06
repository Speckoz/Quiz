using GalaSoft.MvvmLight.Command;

using Quiz.Dependencies.Enums;

using System;

namespace Quiz.Mobile.Models.ManagerQuestions
{
    public class StatusQuestionsModel
    {
        public int QuestionID { get; set; }
        public Guid UserID { get; set; }
        public QuestionStatusEnum QuestionStatus { get; set; }
    }

    public class StatusQuestionsCardModel
    {
        public StatusQuestionsModel Status { get; set; }
        public SuggestQuestionModel Question { get; set; }
        public RelayCommand ViewStatusCommand { get; set; }
    }
}