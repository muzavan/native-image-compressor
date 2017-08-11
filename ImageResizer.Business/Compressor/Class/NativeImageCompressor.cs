using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageCompressor.Business.Compressor.Interface;
using System.Drawing;
using System.Drawing.Imaging;

namespace ImageCompressor.Business.Compressor.Class
{
    public class NativeImageCompressor : AbstractImageCompressor
    {
        public override string Resize(string filePath, int quality)
        {
            using (var bmp = new Bitmap(filePath))
            {
                var imageCodec = GetImageCodec(bmp);
                if (imageCodec == null)
                {
                    return null;
                }

                var qualityEncoder = Encoder.Quality;
                var encoderParameters = new EncoderParameters(1); // Only gonna modify quality parameters ("qualityEncoderParameter")
                var qualityEncoderParameter = new EncoderParameter(qualityEncoder, quality);
                encoderParameters.Param[0] = qualityEncoderParameter;
                var newFile = GetNewFileName(filePath, quality);
                bmp.Save(newFile,imageCodec, encoderParameters);
                return newFile;
            };
        }

        
    }
}
