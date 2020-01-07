using System.IO;

using Xamarin.Forms;

namespace Quiz.Mobile.Util
{
    public class ConvertImageUtil
    {
        /// <summary>
        /// Converte um Byte[] para ImageSource.
        /// </summary>
        public static ImageSource Convert(byte[] img) => ImageSource.FromStream(() => new MemoryStream(img));
    }
}