using Quiz.Dependencies.Enums;
using Quiz.Dependencies.Interfaces;

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Quiz.Models
{
    public class QuestionModel : IQuestion, INotifyPropertyChanged
    {
        private int? __questionId;
        private string __question;
        private string __correctAnswer;
        private CategoryEnum __category;
        private string __incorrectAnswer;

        public int? QuestionID
        {
            get => __questionId;
            set
            {
                __questionId = value;
                OnPropertyChanged();
            }
        }

        public string Question
        {
            get => __question;
            set
            {
                __question = value;
                OnPropertyChanged();
            }
        }

        public string CorrectAnswer
        {
            get => __correctAnswer;
            set
            {
                __correctAnswer = value;
                OnPropertyChanged();
            }
        }

        public CategoryEnum Category
        {
            get => __category;
            set
            {
                __category = value;
                OnPropertyChanged();
            }
        }

        public string IncorrectAnswers
        {
            get => __incorrectAnswer;
            set
            {
                __incorrectAnswer = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string property = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
    }
}