﻿using MobileQuiz.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileQuiz.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterAccountView : ContentPage
    {
        public RegisterAccountView()
        {
            InitializeComponent();
            BindingContext = new RegisterAccountViewModel();
        }
    }
}