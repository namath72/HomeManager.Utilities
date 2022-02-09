using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HomeManager.Utilities.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ProccessFileTest()
        {
            var result = FileHelper.ProccessFiles();
            Assert.AreNotEqual(true, result);
        }
        [TestMethod]
        public void FileReaderTest()
        {
            var result = FileHelper.FileReader();
            Assert.AreNotEqual(0, result.Count);
        }
    }
}
