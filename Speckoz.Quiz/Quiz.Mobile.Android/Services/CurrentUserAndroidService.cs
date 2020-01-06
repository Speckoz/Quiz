using Android.App;
using Android.Content;

namespace Quiz.Mobile.Droid.Services
{
    internal class CurrentUserAndroidService
    {
        private const string Name = "DataUser";

        public static string GetCurrentUser()
        {
            using ISharedPreferences data = Application.Context.GetSharedPreferences(Name, FileCreationMode.Private);
            return data.GetString("CurrentUser", null);
        }

        public static bool SetCurrentUser(string json)
        {
            using ISharedPreferences data = Application.Context.GetSharedPreferences(Name, FileCreationMode.Private);

            ISharedPreferencesEditor editor = data.Edit();
            editor.PutString("CurrentUser", json);
            return editor.Commit();
        }
    }
}