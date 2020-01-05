using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

using Quiz.Mobile.Models.ManagerQuestions;
using Quiz.Mobile.Services.Requests;

using RestSharp;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Text.Json;

using Xamarin.Forms;

using XF.Material.Forms.UI.Dialogs;

namespace Quiz.Mobile.ViewModels.ManagerQuestions
{
    public class StatusQuestionsViewModel : ViewModelBase
    {
        private ObservableCollection<StatusQuestionsCardModel> __statusQuestions;

        public ObservableCollection<StatusQuestionsCardModel> StatusQuestions
        {
            get => __statusQuestions;
            set => Set(ref __statusQuestions, value);
        }

        public StatusQuestionsViewModel() => Init();

        private async void Init()
        {
            StatusQuestions = new ObservableCollection<StatusQuestionsCardModel>();
            using (IMaterialModalPage dialog = await MaterialDialog.Instance.LoadingDialogAsync("Recolhendo informaçoes..."))
            {
                IRestResponse response = await ManagerQuestionsService.StatusQuestionsTaskAsync();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    List<StatusQuestionsModel> list = JsonSerializer
                        .Deserialize<List<StatusQuestionsModel>>(response.Content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    foreach(var i in list)
                    {
                        StatusQuestions.Add(new StatusQuestionsCardModel
                        {
                            Status = i,
                            Question = new SuggestQuestionModel { Question = "Como vai pessoas?" },
                            ViewStatusCommand = new RelayCommand(async () => await Application.Current.MainPage.DisplayAlert("😋", "Tudo certo", "OK"))
                        });
                    }
                    //list.ForEach(i => StatusQuestions.Add(new StatusQuestionsCardModel
                    //{
                    //    Status = i,
                    //    Question = new SuggestQuestionModel { Question = "Como vai pessoas?" },
                    //    ViewStatusCommand = new RelayCommand(async () => await Application.Current.MainPage.DisplayAlert("😋", "Tudo certo", "OK"))
                    //}));
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Ops", "Algo de errado nao está certo", "OK");
                }
            }
        }
    }
}