using ImageResizer.Business.Resizer.Class;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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
            var newBlue = Resizer.Resize(string.Format(FileTestPathFormat, "Blue Sky.jpg"), 0);
            var newMarble = Resizer.Resize(string.Format(FileTestPathFormat, "Marbles.PNG"), 30);

            Assert.IsTrue(_IsSuccessfulResize(newBlue, string.Format(FileTestPathFormat, "Blue Sky.jpg")));
            Assert.IsTrue(_IsSuccessfulResize(newMarble, string.Format(FileTestPathFormat, "Marbles.PNG")));
        }


        private bool _IsSuccessfulResize(string newFile, string oldFile)
        {
            //Check the success of resizing by comparing their size
            var newFileInfo = new FileInfo(newFile);
            var oldFileInfo = new FileInfo(oldFile);

            return newFileInfo.Length <= oldFileInfo.Length;
        }
    }
}
