using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DefensiveProgrammingFramework.Test.Files
{
    [TestClass]
    public class WhenExtensionsTest
    {
        #region Public Methods

        [DataTestMethod]
        public void WhenDoesDirectoryExist()
        {
            if (!Directory.Exists(@".\Temp"))
            {
                Directory.CreateDirectory(@".\Temp");
            }

            Assert.AreEqual("aaa", @".\Temp".WhenDoesDirectoryExist("aaa"));

            if (Directory.Exists(@".\Temp"))
            {
                Directory.Delete(@".\Temp");
            }

            Assert.AreEqual(@".\Temp", @".\Temp".WhenDoesDirectoryExist("aaa"));
        }

        [DataTestMethod]
        public void WhenDoesFileExist()
        {
            if (!File.Exists(@".\Tmp.txt"))
            {
                File.WriteAllText(@".\Tmp.txt", "tmp");
            }

            Assert.AreEqual("aaa", @".\Tmp.txt".WhenDoesFileExist("aaa"));

            if (File.Exists(@".\Tmp.txt"))
            {
                File.Delete(@".\Tmp.txt");
            }

            Assert.AreEqual(@".\Tmp.txt", @".\Tmp.txt".WhenDoesFileExist("aaa"));
        }

        [DataRow(null, "aaa", true)]
        [DataRow(".", "aaa", false)]
        [DataRow(@".\bin\Debug", "aaa", false)]
        [DataRow(@"c:\", "aaa", true)]
        [DataRow(@"c:", "aaa", false)]
        [DataRow(@"c:\apps\MyApp\bin\Debug", "aaa", true)]
        [DataRow(@"d:\apps\MyApp\bin\Debug", "aaa", true)]
        [DataRow(@"e:\apps\MyApp\bin\Debug", "aaa", true)]
        [DataTestMethod]
        public void WhenIsAbsoluteDirectoryPath(string filePath, string defaultValue, bool expected)
        {
            Assert.AreEqual(expected ? defaultValue : filePath, filePath.WhenIsAbsoluteDirectoryPath(defaultValue));
        }

        [DataRow("")]
        [DataRow(@"e:\apps\M|yApp\bin\Debug")]
        [DataTestMethod]
        public void WhenIsAbsoluteDirectoryPathFail(string filePath)
        {
            try
            {
                filePath.WhenIsAbsoluteDirectoryPath("aaa");

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Value must be a valid directory path.", ex.Message);
            }
        }

        [DataRow(null, "aaa", true)]
        [DataRow(@".\file.exe", "aaa", false)]
        [DataRow(@".\bin\Debug\file.exe", "aaa", false)]
        [DataRow(@"c:\file.exe", "aaa", true)]
        [DataRow(@"c:\apps\MyApp\bin\Debug\file.exe", "aaa", true)]
        [DataRow(@"d:\apps\MyApp\bin\Debug\file.exe", "aaa", true)]
        [DataRow(@"e:\apps\MyApp\bin\Debug\file.exe", "aaa", true)]
        [DataTestMethod]
        public void WhenIsAbsoluteFilePath(string filePath, string defaultValue, bool expected)
        {
            Assert.AreEqual(expected ? defaultValue : filePath, filePath.WhenIsAbsoluteFilePath(defaultValue));
        }

        [DataRow(@"")]
        [DataRow(@"e:\apps\M|yApp\bin\Debug\file.exe")]
        [DataTestMethod]
        public void WhenIsAbsoluteFilePathFail(string filePath)
        {
            try
            {
                filePath.WhenIsAbsoluteFilePath("aaa");

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Value must be a valid file path.", ex.Message);
            }
        }

        [TestMethod]
        public void WhenIsEmptyDirectory()
        {
            string directoryPath = @".\Tmp5";
            string filePath = Path.Combine(directoryPath, "tmp.txt");

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            Assert.AreEqual("aaa", directoryPath.WhenIsEmptyDirectory("aaa"));

            File.WriteAllText(filePath, "text");

            Assert.AreEqual(directoryPath, directoryPath.WhenIsEmptyDirectory("aaa"));

            File.Delete(filePath);
            Directory.Delete(directoryPath);
        }

        [DataRow(null, "aaa", true)]
        [DataRow("", "aaa", false)]
        [DataRow("f", "aaa", true)]
        [DataRow("file", "aaa", true)]
        [DataRow("file.exe", "aaa", true)]
        [DataRow(@"C:\Users\User1\source\repos\WpfApp1\WpfApp1\bin\Debug", "aaa", true)]
        [DataRow(@"C:\Users\User1\source\repos\WpfApp1\WpfApp1\bin\Debug\", "aaa", true)]
        [DataRow(@"C:\Users\User1\source\repos\WpfApp1\WpfApp1\bin\Debug\file.exe", "aaa", true)]
        [DataRow("exe.file", "aaa", true)]
        [DataRow("exe.sdfsfsdfsdfsdf", "aaa", true)]
        [DataRow("file>1.exe", "aaa", false)]
        [DataRow("file|1.ex'", "aaa", false)]
        [DataTestMethod]
        public void WhenIsValidDirectoryPath(string filePath, string defaultValue, bool expected)
        {
            Assert.AreEqual(expected ? defaultValue : filePath, filePath.WhenIsValidDirectoryPath(defaultValue));
        }

        [DataRow(null, "aaa", true)]
        [DataRow("", "aaa", false)]
        [DataRow("f", "aaa", true)]
        [DataRow("file", "aaa", true)]
        [DataRow("file.exe", "aaa", true)]
        [DataRow("exe.file", "aaa", true)]
        [DataRow("exe.sdfsfsdfsdfsdf", "aaa", true)]
        [DataRow("file>1.exe", "aaa", false)]
        [DataRow("file?1.ex'", "aaa", false)]
        [DataTestMethod]
        public void WhenIsValidFileName(string filePath, string defaultValue, bool expected)
        {
            Assert.AreEqual(expected ? defaultValue : filePath, filePath.WhenIsValidFileName(defaultValue));
        }

        [DataRow(null, "aaa", true)]
        [DataRow("", "aaa", false)]
        [DataRow("f", "aaa", true)]
        [DataRow("file", "aaa", true)]
        [DataRow("file.exe", "aaa", true)]
        [DataRow("exe.file", "aaa", true)]
        [DataRow(@"C:\Users\User1\source\repos\WpfApp1\WpfApp1\bin\Debug\file.exe", "aaa", true)]
        [DataRow("exe.sdfsfsdfsdfsdf", "aaa", true)]
        [DataRow("file>1.exe", "aaa", false)]
        [DataRow("file|1.ex'", "aaa", false)]
        [DataTestMethod]
        public void WhenIsValidFilePath(string filePath, string defaultValue, bool expected)
        {
            Assert.AreEqual(expected ? defaultValue : filePath, filePath.WhenIsValidFilePath(defaultValue));
        }

        #endregion Public Methods
    }
}