using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

using Logikoz.XamarinUtilities.Utilities;

using Quiz.Dependencies.Interfaces;
using Quiz.Mobile.Models;
using Quiz.Mobile.Models.ManagerQuestions;
using Quiz.Mobile.Services.Requests;
using Quiz.Mobile.Views.ManagerQuestions;

using RestSharp;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;

using XF.Material.Forms.UI.Dialogs;

namespace Quiz.Mobile.ViewModels.ManagerQuestions
{
    public class StatusSuggestionsViewModel : ViewModelBase
    {
        public ObservableCollection<StatusQuestionsCardModel> StatusQuestions { get; private set; }

        public RelayCommand BackToManagerQuestionsCommand { get; private set; }

        public StatusSuggestionsViewModel() => Init();

        private async void Init()
        {
            StatusQuestions = new ObservableCollection<StatusQuestionsCardModel>();
            BackToManagerQuestionsCommand = new RelayCommand(() => PopPushViewUtil.PopNavModalAsync<StatusSuggestionsView>(true));

            using IMaterialModalPage dialog = await MaterialDialog.Instance.LoadingDialogAsync("Recolhendo informaçoes...");
            IRestResponse response = await ManagerQuestionsService.StatusQuestionsTaskAsync();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                (await DeselializeAsync(response)).ForEach(question =>
                {
                    StatusQuestions.Add(new StatusQuestionsCardModel
                    {
                        Question = question,
                        ViewStatusCommand = new RelayCommand<IQuestion>(ViewStatus)
                    });
                });
            }
            else
            {
                await MaterialDialog.Instance.AlertAsync("Algo de errado nao está certo", "Ops");
            }
        }

        private async static Task<List<QuestionModel>> DeselializeAsync(IRestResponse response)
        {
            return await JsonSerializer.DeserializeAsync<List<QuestionModel>>(
                new MemoryStream(Encoding.UTF8.GetBytes(response.Content)),
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
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