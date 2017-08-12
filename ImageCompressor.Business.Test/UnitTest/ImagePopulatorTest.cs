using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ImageCompressor.Business.Populator;

namespace ImageCompressor.Business.Test.UnitTest
{
    [TestClass]
    public class ImagePopulatorTest
    {
        public string FileTestPathFormat = @"D:\My Toy\C#\ImageCompressor\ImageCompressor.Business.Test\UnitTest\TestFiles\{0}";
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
