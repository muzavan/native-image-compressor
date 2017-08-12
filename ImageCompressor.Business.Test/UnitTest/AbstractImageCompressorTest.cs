using ImageCompressor.Business.Compressor.Class;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageCompressor.Business.Test.UnitTest
{
    [TestClass]
    public class AbstractImageCompressorTest
    {
        public AbstractImageCompressor Resizer;
        public string FileTestPathFormat = @"D:\My Toy\C#\ImageCompressor\ImageCompressor.Business.Test\UnitTest\TestFiles\{0}";

        public AbstractImageCompressorTest()
        {
            Resizer = new NativeImageCompressor();
        }

        [TestMethod]
        public void TestGetName()
        {
            string blueSkyName = Resizer.GetNewFileName(string.Format(FileTestPathFormat, "Blue Sky.jpg"), 50);
            string marbleName = Resizer.GetNewFileName(string.Format(FileTestPathFormat, "Marbles.PNG"), 78);

            Assert.AreEqual(blueSkyName, string.Format(FileTestPathFormat, "Blue Sky_50_compressed.jpg"));
            Assert.AreEqual(marbleName, string.Format(FileTestPathFormat, "Marbles_78_compressed.PNG"));
        }

        [TestMethod]
        public void TestGetImageCodec()
        {
            var blueSkyCodec = Resizer.GetImageCodec(new Bitmap(string.Format(FileTestPathFormat, "Blue Sky.jpg")));
            var marbleCodec = Resizer.GetImageCodec(new Bitmap(string.Format(FileTestPathFormat, "Marbles.PNG")));

            Assert.IsNotNull(blueSkyCodec);
            Assert.IsNotNull(marbleCodec);
        }

        [TestMethod]
        public void TestBatchResize()
        {
            var paths = new List<string>() { string.Format(FileTestPathFormat, "Blue Sky.jpg"), string.Format(FileTestPathFormat, "Marbles.PNG") };
            var result = Resizer.BatchResize(paths,23);
            Assert.AreEqual(paths.Count, result.Count);
        }
    }
}
