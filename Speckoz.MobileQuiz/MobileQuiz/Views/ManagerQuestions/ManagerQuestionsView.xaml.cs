using MobileQuiz.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileQuiz.Views.ManagerQuestions
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