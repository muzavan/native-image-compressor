using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ImageResizer.Business.Populator;

namespace ImageResizer.Business.Test.UnitTest
{
    [TestClass]
    public class ImagePopulatorTest
    {
        public string FileTestPathFormat = @"D:\My Toy\C#\ImageResizer\ImageResizer.Business.Test\UnitTest\TestFiles\{0}";
        public ImagePopulator populator;

        public ImagePopulatorTest()
        {
            populator = new ImagePopulator(string.Format(FileTestPathFormat,""));
        }

        [TestMethod]
        public void TestPopulateFileList()
        {
            var fileList = populator.FilePathList;

            Assert.AreNotEqual(fileList.Count, 0);
        }
    }
}
