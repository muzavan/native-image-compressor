using ImageCompressor.Business.Resizer.Class;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageCompressor.Business.Test.UnitTest
{
    [TestClass]
    public class NativeImageCompressorTest
    {
        public AbstractImageCompressor Resizer;
        public string FileTestPathFormat = @"D:\My Toy\C#\ImageResizer\ImageResizer.Business.Test\UnitTest\TestFiles\{0}";

        public NativeImageCompressorTest()
        {
            Resizer = new NativeImageResizer();
        }

        [TestMethod]
        public void TestResize()
        {
            var newBlue = Resizer.Resize(string.Format(FileTestPathFormat, "Blue Sky.jpg"), 50);
            Assert.IsTrue(_IsSuccessfulResize(newBlue, string.Format(FileTestPathFormat, "Blue Sky.jpg")));
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
