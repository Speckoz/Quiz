using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

using MobileQuiz.Helpers;
using MobileQuiz.Models;
using MobileQuiz.Views;

using System;
using System.Collections.ObjectModel;

using Xamarin.Forms;

namespace MobileQuiz.ViewModels
{
    internal class ChooseCategoryViewModel : ViewModelBase
    {
        private ImageSource __image = ConvertImageHelper.Convert(Properties.Resources.choose);
        private ObservableCollection<ChooseCategoryModel> __chooseCategories;

        public ObservableCollection<ChooseCategoryModel> ChooseCategories
        {
            get => __chooseCategories;
            set
            {
                __chooseCategories = value;
                RaisePropertyChanged();
            }
        }

        public ImageSource Image
        {
            get => __image;
            set
            {
                __image = value;
                RaisePropertyChanged();
            }
        }

        public ChooseCategoryViewModel() => CreateButtonsChoose();

        private void CreateButtonsChoose()
        {
            ChooseCategories = new ObservableCollection<ChooseCategoryModel>
            {
                new ChooseCategoryModel
                {
                    BackgroundColor = Color.FromHex("#9d0af5"),
                    PaddingButton = new Thickness(0,30,0,20),
                    ChooseAnswerCommand = new RelayCommand<Button>(CategoryChosen),
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
                ChooseAnswerCommand = new RelayCommand<Button>(CategoryChosen),
                TextButton = category
            };
        }

        private void CategoryChosen(Button bt)
        {
            if (Enum.TryParse(bt.Text, out CategoryEnum result))
                Application.Current.MainPage = new GameView(result);
        }
    }
}