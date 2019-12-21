using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

using MobileQuiz.Helpers;
using MobileQuiz.Models;
using MobileQuiz.Properties;
using MobileQuiz.Views.ManagerQuestions;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace MobileQuiz.ViewModels
{
    internal class ManagerQuestionsViewModel : ViewModelBase
    {
        private ObservableCollection<ManagerQuestionsModel> __questionOptions;

        public ObservableCollection<ManagerQuestionsModel> QuestionOptions
        {
            get => __questionOptions;
            set
            {
                __questionOptions = value;
                RaisePropertyChanged();
            }
        }

        public ManagerQuestionsViewModel()
        {
            QuestionOptions = new ObservableCollection<ManagerQuestionsModel>
            {
                new ManagerQuestionsModel
                {
                    ActionImage = ConvertImageHelper.Convert(Resources.choose),
                    ActionName = "Nova Questao",
                    ActionDescription= "Abre uma tela com campos para cadastrar uma nova questao",
                    ActionOpen = new RelayCommand(async () => await Application.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(new CreateView()), true))
                },new ManagerQuestionsModel
                {
                    ActionImage = ConvertImageHelper.Convert(Resources.register),
                    ActionName = "Consultar Questao",
                    ActionDescription= "Abre uma tela com campos para mostrar uma questao",
                    ActionOpen = new RelayCommand(async () => await App.Current.MainPage.DisplayAlert("", "Consultar questao", "OK"))
                },new ManagerQuestionsModel
                {
                    ActionImage = ConvertImageHelper.Convert(Resources.heartLogo),
                    ActionName = "Editar Questao",
                    ActionDescription= "Abre uma tela com campos para editar uma questao",
                    ActionOpen = new RelayCommand(async () => await App.Current.MainPage.DisplayAlert("", "Editar questao", "OK"))
                },new ManagerQuestionsModel
                {
                    ActionImage = ConvertImageHelper.Convert(Resources.choose),
                    ActionName = "Excluir Questao",
                    ActionDescription= "Abre uma tela com campos para excluir uma questao",
                    ActionOpen = new RelayCommand(async () => await App.Current.MainPage.DisplayAlert("", "Excluir questao", "OK"))
                }
            };
        }
    }
}