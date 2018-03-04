using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DefensiveProgrammingFramework.Test.Files
{
    [TestClass]
    public class MustExtensions
    {
        #region Public Methods

        [DataRow(@"c:\")]
        [DataRow(@"c:\apps\MyApp\bin\Debug")]
        [DataRow(@"d:\apps\MyApp\bin\Debug")]
        [DataRow(@"e:\apps\MyApp\bin\Debug")]
        [DataTestMethod]
        public void MustAbsoluteDirectoryPath(string directoryPath)
        {
            Assert.AreEqual(directoryPath, directoryPath.MustBeAbsoluteDirectoryPath());
        }

        [DataRow(".")]
        [DataRow(@".\bin\Debug")]
        [DataTestMethod]
        public void MustAbsoluteDirectoryPathFail(string directoryPath)
        {
            try
            {
                directoryPath.MustBeAbsoluteDirectoryPath();

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Value must be an absolute directory path.", ex.Message);
            }
        }

        [DataRow(@".\Tem|p")]
        [DataTestMethod]
        public void MustAbsoluteDirectoryPathFail2(string directoryPath)
        {
            try
            {
                directoryPath.MustBeAbsoluteDirectoryPath();

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Value must be a valid directory path.", ex.Message);
            }
        }

        [DataRow(@"c:\file.exe")]
        [DataRow(@"c:\apps\MyApp\bin\Debug\file.exe")]
        [DataRow(@"d:\apps\MyApp\bin\Debug\file.exe")]
        [DataRow(@"e:\apps\MyApp\bin\Debug\file.exe")]
        [DataTestMethod]
        public void MustBeAbsoluteFilePath(string filePath)
        {
            Assert.AreEqual(filePath, filePath.MustBeAbsoluteFilePath());
        }

        [DataRow(@".\file.exe")]
        [DataRow(@".\bin\Debug\file.exe")]
        [DataTestMethod]
        public void MustBeAbsoluteFilePathFail(string filePath)
        {
            try
            {
                filePath.MustBeAbsoluteFilePath();

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Value must be an absolute file path.", ex.Message);
            }
        }

        [DataRow(@"c:\fil|e.exe")]
        [DataRow(@"e:\apps\M|yApp\bin\Debug\file.exe")]
        [DataTestMethod]
        public void MustBeAbsoluteFilePathFail2(string filePath)
        {
            try
            {
                filePath.MustBeAbsoluteFilePath();

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Value must be a valid file path.", ex.Message);
            }
        }

        [DataRow(null)]
        [DataRow("file")]
        [DataRow("file.exe")]
        [DataRow(@"C:\Users\User1\source\repos\WpfApp1\WpfApp1\bin\Debug")]
        [DataRow(@"C:\Users\User1\source\repos\WpfApp1\WpfApp1\bin\Debug\")]
        [DataRow(@"C:\Users\User1\source\repos\WpfApp1\WpfApp1\bin\Debug\file.exe")]
        [DataRow("exe.file")]
        [DataRow("exe.sdfsfsdfsdfsdf")]
        [DataTestMethod]
        public void MustBeValidDirectoryPath(string filePath)
        {
            Assert.AreEqual(filePath, filePath.MustBeValidDirectoryPath());
        }

        [DataRow("")]
        [DataRow("file>1.exe")]
        [DataRow("file|1.ex'")]
        [DataTestMethod]
        public void MustBeValidDirectoryPathFail(string filePath)
        {
            try
            {
                filePath.MustBeValidDirectoryPath();

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Value must be a valid directory path.", ex.Message);
            }
        }

        [DataRow(null)]
        [DataRow("f")]
        [DataRow("file")]
        [DataRow("file.exe")]
        [DataRow("exe.file")]
        [DataRow("exe.sdfsfsdfsdfsdf")]
        [DataTestMethod]
        public void MustBeValidFileName(string filePath)
        {
            Assert.AreEqual(filePath, filePath.MustBeValidFileName());
        }

        [DataRow("")]
        [DataRow("file>1.exe")]
        [DataRow("file?1.ex'")]
        [DataTestMethod]
        public void MustBeValidFileNameFail(string filePath)
        {
            try
            {
                filePath.MustBeValidFileName();

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Value must be a valid file name.", ex.Message);
            }
        }

        [DataRow(null)]
        [DataRow("f")]
        [DataRow("file")]
        [DataRow("file.exe")]
        [DataRow("exe.file")]
        [DataRow(@"C:\Users\User1\source\repos\WpfApp1\WpfApp1\bin\Debug\file.exe")]
        [DataRow("exe.sdfsfsdfsdfsdf")]
        [DataTestMethod]
        public void MustBeValidFilePath(string filePath)
        {
            Assert.AreEqual(filePath, filePath.MustBeValidFilePath());
        }

        [DataRow("")]
        [DataRow("file>1.exe")]
        [DataRow("file|1.ex'")]
        public void MustBeValidFilePathFail(string filePath)
        {
            try
            {
                filePath.MustBeValidFileName();

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Value must be a valid file name.", ex.Message);
            }
        }

        [DataTestMethod]
        public void MustDirectoryExist()
        {
            if (!Directory.Exists(@".\Temp"))
            {
                Directory.CreateDirectory(@".\Temp");
            }

            Assert.AreEqual(@".\Temp", @".\Temp".MustDirectoryExist());

            if (Directory.Exists(@".\Temp"))
            {
                Directory.Delete(@".\Temp");
            }

            try
            {
                @".\Temp".MustDirectoryExist();

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Directory must exist.", ex.Message);
            }
        }

        [TestMethod]
        public void MustFileExist()
        {
            if (!File.Exists(@".\Temp.txt"))
            {
                File.WriteAllText(@".\Temp.txt", "tmp");
            }

            Assert.AreEqual(@".\Temp.txt", @".\Temp.txt".MustFileExist());

            if (File.Exists(@".\Temp.txt"))
            {
                File.Delete(@".\Temp.txt");
            }

            try
            {
                @".\Temp.txt".MustFileExist();

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("File must exist.", ex.Message);
            }
        }

        #endregion Public Methods
    }
}