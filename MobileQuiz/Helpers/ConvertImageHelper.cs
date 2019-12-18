using System.IO;
using Xamarin.Forms;

namespace MobileQuiz.Helpers
{
    class ConvertImageHelper
    {
        /// <summary>
        /// Converte um Byte[] para ImageSource.
        /// </summary>
        public static ImageSource Convert(byte[] img)
        {
            Stream stream = new MemoryStream(img);
            return ImageSource.FromStream(() => stream);
        }
    }
}
