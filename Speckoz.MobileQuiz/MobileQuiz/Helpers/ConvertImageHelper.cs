using System.IO;

using Xamarin.Forms;

namespace MobileQuiz.Helpers
{
    internal class ConvertImageHelper
    {
        /// <summary>
        /// Converte um Byte[] para ImageSource.
        /// </summary>
        public static ImageSource Convert(byte[] img) => ImageSource.FromStream(() => new MemoryStream(img));
    }
}