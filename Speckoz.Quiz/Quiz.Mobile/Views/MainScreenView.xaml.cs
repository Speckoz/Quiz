﻿using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Quiz.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainScreenView : MasterDetailPage
    {
        public MainScreenView() => InitializeComponent();
    }
}