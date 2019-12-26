using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

using Quiz.Helpers;
using Quiz.Mobile.Properties;
using Quiz.Models;
using Quiz.Views.ManagerQuestions;

using System.Collections.ObjectModel;

namespace Quiz.ViewModels.ManagerQuestions
{
    internal class ManagerQuestionsViewModel : ViewModelBase
    {
        private ObservableCollection<ManagerQuestionsModel> __questionOptions;
        private ManagerQuestionsModel __suggestQuestion;

        //alterar depois...
        private bool __isAdmin = true;

        public ObservableCollection<ManagerQuestionsModel> QuestionOptions
        {
            get => __questionOptions;
            set
            {
                __questionOptions = value;
                RaisePropertyChanged();
            }
        }

        public ManagerQuestionsModel SuggestQuestion
        {
            get => __suggestQuestion;
            set
            {
                __suggestQuestion = value;
                RaisePropertyChanged();
            }
        }

        public bool IsAdmin
        {
            get => __isAdmin;
            set
            {
                __isAdmin = value;
                RaisePropertyChanged();
            }
        }

        public ManagerQuestionsViewModel()
        {
            SuggestQuestion = new ManagerQuestionsModel
            {
                ActionImage = ConvertImageHelper.Convert(Resources.choose),
                ActionOpen = new RelayCommand<ManagerQuestionsView>(async (s) => await s.Navigation.PushAsync(new SuggestQuestionView(), true))
            };

            if (IsAdmin)
                AdminAreaItems();
        }

        private void AdminAreaItems()
        {
            QuestionOptions = new ObservableCollection<ManagerQuestionsModel>
                {
                    new ManagerQuestionsModel
                    {
                        ActionImage = ConvertImageHelper.Convert(Resources.register),
                        ActionName = "Consultar Questao",
                        ActionDescription= "Abre uma tela com campos para mostrar uma questao",
                        ActionOpen = new RelayCommand<ManagerQuestionsView>(async (s) => await App.Current.MainPage.DisplayAlert("", "Consultar questao", "OK"))
                    },new ManagerQuestionsModel
                    {
                        ActionImage = ConvertImageHelper.Convert(Resources.heartLogo),
                        ActionName = "Editar Questao",
                        ActionDescription= "Abre uma tela com campos para editar uma questao",
                        ActionOpen = new RelayCommand<ManagerQuestionsView>(async (s) => await App.Current.MainPage.DisplayAlert("", "Editar questao", "OK"))
                    },new ManagerQuestionsModel
                    {
                        ActionImage = ConvertImageHelper.Convert(Resources.choose),
                        ActionName = "Excluir Questao",
                        ActionDescription= "Abre uma tela com campos para excluir uma questao",
                        ActionOpen = new RelayCommand<ManagerQuestionsView>(async (s) => await App.Current.MainPage.DisplayAlert("", "Excluir questao", "OK"))
                    }
                };
        }
    }
}