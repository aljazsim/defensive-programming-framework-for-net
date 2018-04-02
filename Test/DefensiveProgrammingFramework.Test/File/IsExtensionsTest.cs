using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DefensiveProgrammingFramework.Test.Files
{
    [TestClass]
    public class IsExtensionsTest
    {
        #region Public Methods

        [TestMethod]
        public void DoesDirectoryExist()
        {
            if (!Directory.Exists(@".\Temp"))
            {
                Directory.CreateDirectory(@".\Temp");
            }

            Assert.AreEqual(true, @".\Temp".DoesDirectoryExist());

            if (Directory.Exists(@".\Temp"))
            {
                Directory.Delete(@".\Temp");
            }

            Assert.AreEqual(false, @".\Temp".DoesDirectoryExist());
        }

        [TestMethod]
        public void DoesFileExist()
        {
            if (!File.Exists(@".\Temp.txt"))
            {
                File.WriteAllText(@".\Temp.txt", "tmp");
            }

            Assert.AreEqual(true, @".\Temp.txt".DoesFileExist());

            if (File.Exists(@".\Temp.txt"))
            {
                File.Delete(@".\Temp.txt");
            }

            Assert.AreEqual(false, @".\Temp.txt".DoesFileExist());
        }

        [DataRow(null, true)]
        [DataRow(".", false)]
        [DataRow(@".\bin\Debug", false)]
        [DataRow(@"c:\", true)]
        [DataRow(@"c:", false)]
        [DataRow(@"c:\apps\MyApp\bin\Debug", true)]
        [DataRow(@"d:\apps\MyApp\bin\Debug", true)]
        [DataRow(@"e:\apps\MyApp\bin\Debug", true)]
        [DataTestMethod]
        public void IsAbsoluteDirectoryPath(string filePath, bool expected)
        {
            Assert.AreEqual(expected, filePath.IsAbsoluteDirectoryPath());
        }

        [DataRow("")]
        [DataRow(@"e:\apps\M|yApp\bin\Debug")]
        [DataTestMethod]
        public void IsAbsoluteDirectoryPathFail(string filePath)
        {
            try
            {
                filePath.IsAbsoluteDirectoryPath();

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Value must be a valid directory path.", ex.Message);
            }
        }

        [DataRow(null, true)]
        [DataRow(@".\file.exe", false)]
        [DataRow(@".\bin\Debug\file.exe", false)]
        [DataRow(@"c:\file.exe", true)]
        [DataRow(@"c:\apps\MyApp\bin\Debug\file.exe", true)]
        [DataRow(@"d:\apps\MyApp\bin\Debug\file.exe", true)]
        [DataRow(@"e:\apps\MyApp\bin\Debug\file.exe", true)]
        [DataTestMethod]
        public void IsAbsoluteFilePath(string filePath, bool expected)
        {
            Assert.AreEqual(expected, filePath.IsAbsoluteFilePath());
        }

        [DataRow(@"")]
        [DataRow(@"e:\apps\M|yApp\bin\Debug\file.exe")]
        [DataTestMethod]
        public void IsAbsoluteFilePathFail(string filePath)
        {
            try
            {
                filePath.IsAbsoluteFilePath();

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Value must be a valid file path.", ex.Message);
            }
        }

        [TestMethod]
        public void IsEmptyDirectory()
        {
            string directoryPath = @".\Tmp5";
            string filePath = Path.Combine(directoryPath, "tmp.txt");

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            Assert.IsTrue((null as string).IsEmptyDirectory());
            Assert.IsFalse(string.Empty.IsEmptyDirectory());
            Assert.IsTrue(@".\aaa".IsEmptyDirectory());
            Assert.IsTrue(directoryPath.IsEmptyDirectory());

            File.WriteAllText(filePath, "text");

            Assert.IsFalse(directoryPath.IsEmptyDirectory());

            File.Delete(filePath);
            Directory.Delete(directoryPath);
        }

        [DataRow(null, true)]
        [DataRow("", false)]
        [DataRow("f", true)]
        [DataRow("file", true)]
        [DataRow("file.exe", true)]
        [DataRow(@"C:\Users\User1\source\repos\WpfApp1\WpfApp1\bin\Debug", true)]
        [DataRow(@"C:\Users\User1\source\repos\WpfApp1\WpfApp1\bin\Debug\", true)]
        [DataRow(@"C:\Users\User1\source\repos\WpfApp1\WpfApp1\bin\Debug\file.exe", true)]
        [DataRow("exe.file", true)]
        [DataRow("exe.sdfsfsdfsdfsdf", true)]
        [DataRow("file>1.exe", false)]
        [DataRow("file|1.ex'", false)]
        [DataTestMethod]
        public void IsValidDirectoryPath(string filePath, bool expected)
        {
            Assert.AreEqual(expected, filePath.IsValidDirectoryPath());
        }

        [DataRow(null, true)]
        [DataRow("", false)]
        [DataRow("f", true)]
        [DataRow("file", true)]
        [DataRow("file.exe", true)]
        [DataRow("exe.file", true)]
        [DataRow("exe.sdfsfsdfsdfsdf", true)]
        [DataRow("file>1.exe", false)]
        [DataRow("file?1.ex'", false)]
        [DataTestMethod]
        public void IsValidFileName(string filePath, bool expected)
        {
            Assert.AreEqual(expected, filePath.IsValidFileName());
        }

        [DataRow(null, true)]
        [DataRow("", false)]
        [DataRow("f", true)]
        [DataRow("file", true)]
        [DataRow("file.exe", true)]
        [DataRow("exe.file", true)]
        [DataRow(@"C:\Users\User1\source\repos\WpfApp1\WpfApp1\bin\Debug\file.exe", true)]
        [DataRow("exe.sdfsfsdfsdfsdf", true)]
        [DataRow("file>1.exe", false)]
        [DataRow("file|1.ex'", false)]
        [DataTestMethod]
        public void IsValidFilePath(string filePath, bool expected)
        {
            Assert.AreEqual(expected, filePath.IsValidFilePath());
        }

        #endregion Public Methods
    }
}