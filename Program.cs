using ImageCompressor.Business.Compressor.Class;
using ImageCompressor.Business.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageCompressor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Image compression is started.");
            var imageCompressorUtil = new ImageCompressionUtil<NativeImageCompressor>();
            imageCompressorUtil.Compress();
            Console.WriteLine("Done.");
        }
    }
}
