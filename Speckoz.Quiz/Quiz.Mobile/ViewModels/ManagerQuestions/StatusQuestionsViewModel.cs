using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

using Quiz.Dependencies.Interfaces;
using Quiz.Mobile.Models;
using Quiz.Mobile.Models.ManagerQuestions;
using Quiz.Mobile.Services.Requests;

using RestSharp;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Text.Json;

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
                IRestResponse response = ManagerQuestionsService.StatusQuestionsTaskAsync();

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

        private async void ViewStatus(IQuestion question)
        {
            await MaterialDialog.Instance.AlertAsync(
                $"Pergunta: {question.Question}\nCorreta: {question.CorrectAnswer}\nErradas: {question.IncorrectAnswers}\nCategoria: {question.Category}\nID: {question.QuestionID}",
                $"{question.AuthorID}", "OK");
        }
    }
}