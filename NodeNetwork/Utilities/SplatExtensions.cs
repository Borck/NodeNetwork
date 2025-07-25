using System.IO;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Splat;

namespace NodeNetwork.Utilities
{
    public static class SplatExtensions
    {
        public static async Task<BitmapSource> ToNativeAsync(this IBitmap bitmap)
        {
            // ReSharper disable once ConvertToUsingDeclaration
            using (var ms = new MemoryStream())
            {
                await bitmap.Save(CompressedBitmapFormat.Png, 1.0f, ms);
                ms.Seek(0, SeekOrigin.Begin);

                var img = new BitmapImage();
                img.BeginInit();
                img.CacheOption = BitmapCacheOption.OnLoad;
                img.StreamSource = ms;
                img.EndInit();
                img.Freeze(); // optional: allow cross-thread use
                return img;
            }
        }
    }
}