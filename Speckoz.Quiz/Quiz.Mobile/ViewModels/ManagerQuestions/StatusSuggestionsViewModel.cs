using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

using Quiz.Dependencies.Interfaces;
using Quiz.Mobile.Models;
using Quiz.Mobile.Models.ManagerQuestions;
using Quiz.Mobile.Services.Requests;
using Quiz.Mobile.Util;
using Quiz.Mobile.Views.ManagerQuestions;

using RestSharp;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Text.Json;

using Xamarin.Forms;
using Xamarin.Forms.Internals;

using XF.Material.Forms.UI.Dialogs;

namespace Quiz.Mobile.ViewModels.ManagerQuestions
{
    public class StatusSuggestionsViewModel : ViewModelBase
    {
        private ObservableCollection<StatusQuestionsCardModel> __statusQuestions;

        public ObservableCollection<StatusQuestionsCardModel> StatusQuestions
        {
            get => __statusQuestions;
            set => Set(ref __statusQuestions, value);
        }

        public RelayCommand BackToManagerQuestionsCommand { get; private set; }

        public StatusSuggestionsViewModel() => Init();

        private async void Init()
        {
            StatusQuestions = new ObservableCollection<StatusQuestionsCardModel>();
            BackToManagerQuestionsCommand = new RelayCommand(() => PopPushViewUtil.PopModalAsync<StatusSuggestionsView>(true));

            using (IMaterialModalPage dialog = await MaterialDialog.Instance.LoadingDialogAsync("Recolhendo informaçoes..."))
            {
                IRestResponse response = await ManagerQuestionsService.StatusQuestionsTaskAsync();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    List<QuestionModel> list = JsonSerializer
                        .Deserialize<List<QuestionModel>>(response.Content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    foreach (IQuestion question in list)
                    {
                        StatusQuestions.Add(new StatusQuestionsCardModel
                        {
                            Question = question,
                            ViewStatusCommand = new RelayCommand<IQuestion>(ViewStatus)
                        });
                    }
                }
                else
                {
                    await MaterialDialog.Instance.AlertAsync("Algo de errado nao está certo", "Ops", "OK");
                }
            }
        }

        private void ViewStatus(IQuestion question)
        {
            Application.Current.MainPage.Navigation.ModalStack.ForEach(async page =>
            {
                var navigationPage = page as NavigationPage;
                if (navigationPage.RootPage is StatusSuggestionsView)
                {
                    await navigationPage.Navigation.PushAsync(new ShowStatusSuggestionView()
                    {
                        BindingContext = new ShowStatusSuggestionViewModel(page)
                        {
                            Suggestion = question
                        }
                    });
                }
            });
        }
    }
}