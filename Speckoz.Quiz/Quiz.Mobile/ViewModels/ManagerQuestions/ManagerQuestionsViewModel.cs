using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

using Quiz.Dependencies.Enums;
using Quiz.Mobile.Helpers;
using Quiz.Mobile.Models;
using Quiz.Mobile.Properties;
using Quiz.Mobile.Views.ManagerQuestions;
using Quiz.Mobile.Views.ManagerQuestions;

using System.Collections.ObjectModel;

using Xamarin.Forms;

namespace Quiz.Mobile.ViewModels.ManagerQuestions
{
    internal class ManagerQuestionsViewModel : ViewModelBase
    {
        private ObservableCollection<ManagerQuestionsModel> __questionOptions;
        private ManagerQuestionsModel __suggestQuestion;
        private bool __isAdmin = true;
        private ManagerQuestionsModel __statusSuggestions;

        public ObservableCollection<ManagerQuestionsModel> QuestionOptions
        {
            get => __questionOptions;
            set => Set(ref __questionOptions, value);
        }

        public ManagerQuestionsModel SuggestQuestion
        {
            get => __suggestQuestion;
            set => Set(ref __suggestQuestion, value);
        }

        public ManagerQuestionsModel StatusSuggestions
        {
            get => __statusSuggestions;
            set => Set(ref __statusSuggestions, value);
        }

        public bool IsAdmin
        {
            get => __isAdmin;
            set => Set(ref __isAdmin, value);
        }

        public ManagerQuestionsViewModel()
        {
            SuggestQuestion = new ManagerQuestionsModel
            {
                ActionImage = ConvertImageHelper.Convert(Resources.choose),
                ActionOpen = new RelayCommand(async () => await Application.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(new SuggestQuestionView()), true))
            };

            StatusSuggestions = new ManagerQuestionsModel
            {
                ActionImage = ConvertImageHelper.Convert(Resources.choose),
                ActionOpen = new RelayCommand(async () => await Application.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(new StatusQuestionsView()), true))
            };

            if (IsAdmin = GetDataHelper.CurrentUser.User.UserType == UserTypeEnum.Admin)
                AdminAreaItems();
        }

        private void AdminAreaItems()
        {
            QuestionOptions = new ObservableCollection<ManagerQuestionsModel>
                {
                    new ManagerQuestionsModel
                    {
                        ActionImage = ConvertImageHelper.Convert(Resources.register),
                        ActionName = "Avaliar Sugestoes",
                        ActionDescription= "Abre uma tela com as sugestoes de questoes.",
                        ActionOpen = new RelayCommand(async () => await Application.Current.MainPage.DisplayAlert("", "Avaliar Sugestoes", "OK"))
                    },new ManagerQuestionsModel
                    {
                        ActionImage = ConvertImageHelper.Convert(Resources.heartLogo),
                        ActionName = "Editar Questao",
                        ActionDescription= "Abre uma tela com campos para editar uma questao",
                        ActionOpen = new RelayCommand(async () => await Application.Current.MainPage.DisplayAlert("", "Editar questao", "OK"))
                    },new ManagerQuestionsModel
                    {
                        ActionImage = ConvertImageHelper.Convert(Resources.choose),
                        ActionName = "Excluir Questao",
                        ActionDescription= "Abre uma tela com campos para excluir uma questao",
                        ActionOpen = new RelayCommand(async () => await Application.Current.MainPage.DisplayAlert("", "Excluir questao", "OK"))
                    }
                };
        }
    }
}