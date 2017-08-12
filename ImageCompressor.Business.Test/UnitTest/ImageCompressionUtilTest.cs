using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ImageCompressor.Business.Compressor.Class;
using System.Diagnostics;

namespace ImageCompressor.Business.Test.UnitTest
{
    [TestClass]
    public class ImageCompressionUtilTest
    {
        private Util.ImageCompressionUtil<NativeImageCompressor> _Util;

        public ImageCompressionUtilTest()
        {
            _Util = new Util.ImageCompressionUtil<NativeImageCompressor>(50);
        }
        [TestMethod]
        public void TestCompress()
        {
            var stopwatch = Stopwatch.StartNew();
            _Util.Compress();
            var time = stopwatch.ElapsedMilliseconds;
        }
    }
}
