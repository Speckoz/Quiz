﻿using MobileQuiz.Models;
using MobileQuiz.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileQuiz.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GameView : ContentPage
    {
        public GameView(CategoryEnum category)
        {
            InitializeComponent();
            BindingContext = new GameViewModel(category);
        }
    }
}