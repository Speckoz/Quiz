using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

using Quiz.Dependencies.Enums;
using Quiz.Mobile.Helpers;
using Quiz.Mobile.Models;
using Quiz.Mobile.Util;
using Quiz.Mobile.Views.ManagerQuestions;
using Quiz.Mobile.Views.ManagerQuestions.Admin;

using System.Collections.ObjectModel;

using Xamarin.Forms;

using XF.Material.Forms.UI.Dialogs;

namespace Quiz.Mobile.ViewModels.ManagerQuestions
{
    public class ManagerQuestionsViewModel : ViewModelBase
    {
        private ObservableCollection<ManagerQuestionsModel> __questionOptions;
        private ManagerQuestionsModel __suggestQuestion;
        private bool __isAdmin;
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
                ActionOpen = new RelayCommand(async () =>
                {
                    PopPushViewUtil.PopModalAsync<SuggestQuestionView>();
                    await PopPushViewUtil.PushModalAsync(new NavigationPage(new SuggestQuestionView()), true);
                })
            };

            StatusSuggestions = new ManagerQuestionsModel
            {
                ActionOpen = new RelayCommand(async () =>
                {
                    PopPushViewUtil.PopModalAsync<StatusSuggestionsView>();
                    await PopPushViewUtil.PushModalAsync(new NavigationPage(new StatusSuggestionsView()
                    {
                        BindingContext = new StatusSuggestionsViewModel()
                    }), true);
                })
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
                    ActionImage = ImageSource.FromFile("adminStatus.png"),
                    ActionName = "Avaliar Sugestoes",
                    ActionDescription= "Abre uma tela com as sugestoes de questoes.",
                    ActionOpen = new RelayCommand(async () => 
                    {
                        PopPushViewUtil.PopModalAsync<ApproveQuestionsView>();
                        await PopPushViewUtil.PushModalAsync(new NavigationPage(new ApproveQuestionsView()), true); 
                    })
                },new ManagerQuestionsModel
                {
                    ActionImage = ImageSource.FromFile("heartLogo.png"),
                    ActionName = "Editar Questao",
                    ActionDescription= "Abre uma tela com campos para editar uma questao",
                    ActionOpen = new RelayCommand(async () => await MaterialDialog.Instance.AlertAsync("Editar questao", "", "OK"))
                },new ManagerQuestionsModel
                {
                    ActionImage = ImageSource.FromFile("removeQuestion.png"),
                    ActionName = "Excluir Questao",
                    ActionDescription= "Abre uma tela com campos para excluir uma questao",
                    ActionOpen = new RelayCommand(async () => await MaterialDialog.Instance.AlertAsync("Excluir questao", "", "OK"))
                }
            };
        }
    }
}