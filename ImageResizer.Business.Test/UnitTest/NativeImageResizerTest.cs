using ImageResizer.Business.Resizer.Class;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageResizer.Business.Test.UnitTest
{
    [TestClass]
    public class NativeImageResizerTest
    {
        public AbstractImageResizer Resizer;
        public string FileTestPathFormat = @"D:\My Toy\C#\ImageResizer\ImageResizer.Business.Test\UnitTest\TestFiles\{0}";

        public NativeImageResizerTest()
        {
            Resizer = new NativeImageResizer();
        }

        [TestMethod]
        public void TestResize()
        {
            Resizer.Resize(string.Format(FileTestPathFormat, "Blue Sky.jpg"), 0);
            Resizer.Resize(string.Format(FileTestPathFormat, "Marbles.PNG"), 30);
        }
    }
}
