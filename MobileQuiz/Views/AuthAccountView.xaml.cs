using MobileQuiz.Models;
using MobileQuiz.Services;
using MobileQuiz.ViewModels;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileQuiz.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthAccountView : ContentPage
    {
        public AuthAccountView()
        {
            InitializeComponent();
            BindingContext = new AuthAccountViewModel(this);
        }
    }
}