using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageResizer.Business.Resizer.Interface;
using System.Drawing;
using System.Drawing.Imaging;

namespace ImageResizer.Business.Resizer.Class
{
    public class NativeImageResizer : AbstractImageResizer
    {
        public override bool Resize(string filePath, int quality)
        {
            using (var bmp = new Bitmap(filePath))
            {
                var imageCodec = GetImageCodec(bmp);
                if (imageCodec == null)
                {
                    return false;
                }

                var qualityEncoder = Encoder.Quality;
                var encoderParameters = new EncoderParameters(1); // Only gonna modify quality parameters ("qualityEncoderParameter")
                var qualityEncoderParameter = new EncoderParameter(qualityEncoder, quality);
                encoderParameters.Param[0] = qualityEncoderParameter;
                bmp.Save(GetNewFileName(filePath,quality),imageCodec, encoderParameters);

                return true;
            };
        }

        
    }
}
