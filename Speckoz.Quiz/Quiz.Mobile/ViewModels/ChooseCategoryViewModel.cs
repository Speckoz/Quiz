using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

using Logikoz.ThemeBase.Enums;
using Logikoz.ThemeBase.Helpers;

using Quiz.Dependencies.Enums;
using Quiz.Mobile.Models;
using Quiz.Mobile.Util;
using Quiz.Mobile.Views;

using System;
using System.Collections.ObjectModel;

using Xamarin.Forms;

namespace Quiz.Mobile.ViewModels
{
    internal class ChooseCategoryViewModel : ViewModelBase
    {
        private ObservableCollection<ChooseCategoryModel> __chooseCategories;

        public ObservableCollection<ChooseCategoryModel> ChooseCategories
        {
            get => __chooseCategories;
            set => Set(ref __chooseCategories, value);
        }

        public ChooseCategoryViewModel() => Init();

        private void CreateButtonsChoose()
        {
            ChooseCategories = new ObservableCollection<ChooseCategoryModel>
            {
                new ChooseCategoryModel
                {
                    BackgroundColor = (Color)GetResourceColorHelper.GetResourceColor(ColorsEnum.PrimaryColor).color,
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
                await PopPushViewUtil.PushModalAsync(new NavigationPage(new GameView(result)), true);
        }

        private void Init()
        {
            CreateButtonsChoose();
        }
    }
}