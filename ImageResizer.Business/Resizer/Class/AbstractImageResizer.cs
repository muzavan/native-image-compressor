using ImageResizer.Business.Resizer.Interface;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;

namespace ImageResizer.Business.Resizer.Class
{
    public abstract class AbstractImageResizer : IResizer
    {
        public abstract string Resize(string filePath, int quality = 100);

        public ImageCodecInfo GetImageCodec(Bitmap bmp)
        {
            foreach (var codec in ImageCodecInfo.GetImageEncoders())
            {
                if (codec.FormatID.Equals(bmp.RawFormat.Guid))
                {
                    return codec;
                }
            }

            return null;
        }

        public string GetNewFileName(string oldFileName, int quality)
        {
            var newFileNameBuilder = new StringBuilder(); ;
            var lastBackSlash = oldFileName.LastIndexOf('\\');
            if (lastBackSlash != -1)
            {
                newFileNameBuilder.AppendFormat("{0}\\{1}_compressed_{2}", oldFileName.Substring(0, lastBackSlash), quality, oldFileName.Substring(lastBackSlash + 1)); //lastBackSlash should not be last character
            }
            return newFileNameBuilder.ToString();
        }
    }
}
