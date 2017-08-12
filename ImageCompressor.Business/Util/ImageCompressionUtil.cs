using ImageCompressor.Business.Compressor.Class;
using ImageCompressor.Business.Populator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageCompressor.Business.Util
{
    public class ImageCompressionUtil<T> where T : AbstractImageCompressor, new()
    {
        private ImagePopulator _Populator;
        private AbstractImageCompressor _Compressor;
        private int _Quality;

        public ImageCompressionUtil(int quality) : this(ConfigUtil.GetFolderPath(), quality)
        {
            // do nothing
        }

        public ImageCompressionUtil(string folderPath,  int quality)
        {
            _Populator = new ImagePopulator(folderPath);
            _Compressor = new T();
            _Quality =  quality;
        }

        public void Compress()
        {
            var filePaths = _Populator.FilePathList;
            _Compressor.BatchResize(filePaths, _Quality);
        }
    }
}
