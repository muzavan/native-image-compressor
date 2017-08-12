using ImageCompressor.Business.Compressor.Interface;
using ImageCompressor.Business.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Threading.Tasks;

namespace ImageCompressor.Business.Compressor.Class
{
    public abstract class AbstractImageCompressor : ICompressor
    {
        private static log4net.ILog _Log = LogUtil.GetInstance().GetLogger(typeof(AbstractImageCompressor).ToString());
        public abstract string Resize(string filePath, int quality = 50);
        public void BatchResize(List<string> filePaths, int quality = 50)
        {
            Parallel.ForEach(filePaths, (filePath) =>
            {
                try
                {
                    Resize(filePath, quality);
                }
                catch (Exception ex)
                {
                    _Log.InfoFormat("Can't compress {0} because of {1} ",filePath,ex);
                }
                
            });
        }

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
            var lastDot = oldFileName.LastIndexOf('.');
            if (lastDot == -1) // Somehow, file does not have any extensions
            {
                newFileNameBuilder.AppendFormat("{0}_{1}_compressed",oldFileName,quality);
            }
            else
            {
                var newFileName = oldFileName.Substring(0, lastDot);
                var extension = oldFileName.Substring(lastDot);
                newFileNameBuilder.AppendFormat("{0}_{1}_compressed{2}",newFileName,quality,extension);
            }
            return newFileNameBuilder.ToString();
        }
    }
}
