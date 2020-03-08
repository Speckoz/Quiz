using GalaSoft.MvvmLight;

using Quiz.Dependencies.Models;
using Quiz.Mobile.Helpers;

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

        private void Init() => User = GetDataHelper.CurrentUser.User;
    }
}