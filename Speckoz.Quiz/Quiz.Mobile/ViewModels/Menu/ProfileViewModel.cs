using GalaSoft.MvvmLight;

using Quiz.Mobile.Helpers;
using Quiz.Mobile.Models.Starting;

namespace Quiz.Mobile.ViewModels.Menu
{
    internal class ProfileViewModel : ViewModelBase
    {
        private UserBaseModel __user;

        public UserBaseModel User
        {
            get => __user;
            set => Set(ref __user, value);
        }

        public ProfileViewModel() => Init();

        private void Init()
        {
            User = GetDataHelper.CurrentUser.User;
        }
    }
}