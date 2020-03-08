using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

using Logikoz.XamarinUtilities.Enums;
using Logikoz.XamarinUtilities.Utilities;

using Quiz.Dependencies.Enums;
using Quiz.Mobile.Models;
using Quiz.Mobile.Views;

using System;
using System.Collections.ObjectModel;

using Xamarin.Forms;

namespace Quiz.Mobile.ViewModels
{
    internal class ChooseCategoryViewModel : ViewModelBase
    {
        public ObservableCollection<ChooseCategoryModel> ChooseCategories { get; private set; }

        public ChooseCategoryViewModel() => Init();

        private void Init() => CreateButtonsChoose();

        private void CreateButtonsChoose()
        {
            ChooseCategories = new ObservableCollection<ChooseCategoryModel>
            {
                new ChooseCategoryModel
                {
                    BackgroundColor = (Color)ResourceColorUtil.GetResourceColor(ColorsEnum.PrimaryColor).color,
                    PaddingButton = new Thickness(0,30,0,20),
                    ChooseAnswerCommand = new RelayCommand<Button>(CategoryChosenAsync),
                    TextButton = CategoryEnum.Todas
                },
                CreateButtonGray(CategoryEnum.Arte),
                CreateButtonGray(CategoryEnum.Ciencia),
                CreateButtonGray(CategoryEnum.Esporte),
                CreateButtonGray(CategoryEnum.Geograria),
                CreateButtonGray(CategoryEnum.Historia)
            };
        }

        private ChooseCategoryModel CreateButtonGray(CategoryEnum category)
        {
            return new ChooseCategoryModel
            {
                ChooseAnswerCommand = new RelayCommand<Button>(CategoryChosenAsync),
                TextButton = category
            };
        }

        private async void CategoryChosenAsync(Button bt)
        {
            if (Enum.TryParse(bt.Text, out CategoryEnum result))
            {
                PopPushViewUtil.PopNavModalAsync<GameView>();
                await PopPushViewUtil.PushModalAsync(new NavigationPage(new GameView(result)), true);
            }
        }
    }
}