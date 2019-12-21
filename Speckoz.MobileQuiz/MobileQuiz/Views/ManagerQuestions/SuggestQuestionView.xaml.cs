using MobileQuiz.ViewModels.ManagerQuestions;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileQuiz.Views.ManagerQuestions
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SuggestQuestionView : ContentPage
    {
        public SuggestQuestionView()
        {
            InitializeComponent();
            BindingContext = new SuggestQuestionViewModel();
        }
    }
}