using ImageResizer.Business.Resizer.Class;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageResizer.Business.Test.UnitTest
{
    [TestClass]
    public class AbstractImageResizerTest
    {
        public AbstractImageResizer Resizer;
        public string FileTestPathFormat = @"D:\My Toy\C#\ImageResizer\ImageResizer.Business.Test\UnitTest\TestFiles\{0}";

        public AbstractImageResizerTest()
        {
            Resizer = new NativeImageResizer();
        }

        [TestMethod]
        public void TestGetName()
        {
            string blueSkyName = Resizer.GetNewFileName(string.Format(FileTestPathFormat, "Blue Sky.jpg"), 50);
            string marbleName = Resizer.GetNewFileName(string.Format(FileTestPathFormat, "Marbles.PNG"), 78);

            Assert.AreEqual(blueSkyName, string.Format(FileTestPathFormat, "50_compressed_Blue Sky.jpg"));
            Assert.AreEqual(marbleName, string.Format(FileTestPathFormat, "78_compressed_Marbles.PNG"));
        }

        [TestMethod]
        public void TestGetImageCodec()
        {
            var blueSkyCodec = Resizer.GetImageCodec(new Bitmap(string.Format(FileTestPathFormat, "Blue Sky.jpg")));
            var marbleCodec = Resizer.GetImageCodec(new Bitmap(string.Format(FileTestPathFormat, "Marbles.PNG")));

            Assert.IsNotNull(blueSkyCodec);
            Assert.IsNotNull(marbleCodec);
        }
    }
}
