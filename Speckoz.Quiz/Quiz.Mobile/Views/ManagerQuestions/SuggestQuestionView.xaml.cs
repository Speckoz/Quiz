using Quiz.ViewModels.ManagerQuestions;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Quiz.Views.ManagerQuestions
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