using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageResizer.Business.Resizer.Interface;
using System.Drawing;
using System.Drawing.Imaging;

namespace ImageResizer.Business.Resizer.Class
{
    public class ImageResizer : IResizer
    {
        bool IResizer.Resize(string filePath, int quality)
        {
            using (var bmp = new Bitmap(filePath))
            {
                var imageCodec = _GetImageCodec(bmp);
                if (imageCodec == null)
                {
                    return false;
                }

                var qualityEncoder = Encoder.Quality;
                var encoderParameters = new EncoderParameters(1); // Only gonna modify quality parameters ("qualityEncoderParameter")
                var qualityEncoderParameter = new EncoderParameter(qualityEncoder, quality);
                encoderParameters.Param[0] = qualityEncoderParameter;
                bmp.Save(_GetNewFileName(filePath,quality),imageCodec, encoderParameters);

                return true;
            };
        }

        private ImageCodecInfo _GetImageCodec(Bitmap bmp)
        {
            foreach(var codec in ImageCodecInfo.GetImageEncoders())
            {
                if (codec.FormatID.Equals(bmp.RawFormat.Guid))
                {
                    return codec;
                }
            }

            return null;
        }

        private string _GetNewFileName(string oldFileName, int quality)
        {
            var newFileNameBuilder = new System.Text.StringBuilder(); ;
            var lastBackSlash = oldFileName.LastIndexOf('\\');
            if ( lastBackSlash != -1)
            {
                newFileNameBuilder.AppendFormat("{0}\\{1}_compressed_{2}",oldFileName.Substring(0, lastBackSlash+1),quality,oldFileName.Substring(lastBackSlash+1)); //lastBackSlash should not be last character
            }            
            return newFileNameBuilder.ToString();
        }
    }
}
