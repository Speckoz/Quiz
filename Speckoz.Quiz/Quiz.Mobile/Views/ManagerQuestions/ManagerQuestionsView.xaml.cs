using Quiz.Mobile.ViewModels.ManagerQuestions;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Quiz.Mobile.Views.ManagerQuestions
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ManagerQuestionsView : ContentPage
    {
        public ManagerQuestionsView()
        {
            InitializeComponent();
            BindingContext = new ManagerQuestionsViewModel();
        }
    }
}