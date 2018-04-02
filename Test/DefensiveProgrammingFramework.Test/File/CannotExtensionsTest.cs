using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DefensiveProgrammingFramework.Test.Files
{
    [TestClass]
    public class CannotExtensions
    {
        #region Public Methods

        [DataRow(".")]
        [DataRow(@".\bin\Debug")]
        [DataTestMethod]
        public void CannotAbsoluteDirectoryPath(string filePath)
        {
            Assert.AreEqual(filePath, filePath.CannotBeAbsoluteDirectoryPath());
        }

        [DataRow(@"c:\")]
        [DataRow(@"c:\apps\MyApp\bin\Debug")]
        [DataRow(@"d:\apps\MyApp\bin\Debug")]
        [DataRow(@"e:\apps\MyApp\bin\Debug")]
        [DataTestMethod]
        public void CannotAbsoluteDirectoryPathFail(string directoryPath)
        {
            try
            {
                directoryPath.CannotBeAbsoluteDirectoryPath();

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Value cannot be an absolute directory path.", ex.Message);
            }
        }

        [DataRow(@".\Tem|p")]
        [DataTestMethod]
        public void CannotAbsoluteDirectoryPathFail2(string directoryPath)
        {
            try
            {
                directoryPath.CannotBeAbsoluteDirectoryPath();

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Value must be a valid directory path.", ex.Message);
            }
        }

        [DataRow(@".\file.exe")]
        [DataRow(@".\bin\Debug\file.exe")]
        [DataTestMethod]
        public void CannotBeAbsoluteFilePath(string filePath)
        {
            Assert.AreEqual(filePath, filePath.CannotBeAbsoluteFilePath());
        }

        [DataRow(@"c:\file.exe")]
        [DataRow(@"c:\apps\MyApp\bin\Debug\file.exe")]
        [DataRow(@"d:\apps\MyApp\bin\Debug\file.exe")]
        [DataRow(@"e:\apps\MyApp\bin\Debug\file.exe")]
        [DataTestMethod]
        public void CannotBeAbsoluteFilePathFail(string filePath)
        {
            try
            {
                filePath.CannotBeAbsoluteFilePath();

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Value cannot be an absolute file path.", ex.Message);
            }
        }

        [DataRow(@"c:\fil|e.exe")]
        [DataRow(@"e:\apps\M|yApp\bin\Debug\file.exe")]
        [DataTestMethod]
        public void CannotBeAbsoluteFilePathFail2(string filePath)
        {
            try
            {
                filePath.CannotBeAbsoluteFilePath();

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Value must be a valid file path.", ex.Message);
            }
        }

        [TestMethod]
        public void CannotBeEmptyDirectory()
        {
            string directoryPath = @".\Tmp5";
            string filePath = Path.Combine(directoryPath, "tmp.txt");

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
                File.WriteAllText(filePath, "text");
            }

            Assert.AreEqual(directoryPath, directoryPath.CannotBeEmptyDirectory());

            File.Delete(filePath);
            Directory.Delete(directoryPath);
        }

        [TestMethod]
        public void CannotBeEmptyDirectoryFail()
        {
            string directoryPath = @".\Tmp5";

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            try
            {
                directoryPath.CannotBeEmptyDirectory();

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Value cannot be an empty directory.", ex.Message);
            }

            Directory.Delete(directoryPath);
        }

        [TestMethod]
        public void CannotBeEmptyDirectoryFail2()
        {
            string directoryPath = @".\Tmp5<";

            try
            {
                directoryPath.CannotBeEmptyDirectory();

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Value must be a valid directory path.", ex.Message);
            }
        }

        [DataRow("")]
        [DataRow("file>1.exe")]
        [DataRow("file|1.ex'")]
        [DataTestMethod]
        public void CannotBeValidDirectoryPath(string filePath)
        {
            Assert.AreEqual(filePath, filePath.CannotBeValidDirectoryPath());
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
        public void CannotBeValidDirectoryPathFail(string filePath)
        {
            try
            {
                filePath.CannotBeValidDirectoryPath();

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Value cannot be a valid directory path.", ex.Message);
            }
        }

        [DataRow("")]
        [DataRow("file>1.exe")]
        [DataRow("file?1.ex'")]
        [DataTestMethod]
        public void CannotBeValidFileName(string filePath)
        {
            Assert.AreEqual(filePath, filePath.CannotBeValidFileName());
        }

        [DataRow(null)]
        [DataRow("f")]
        [DataRow("file")]
        [DataRow("file.exe")]
        [DataRow("exe.file")]
        [DataRow("exe.sdfsfsdfsdfsdf")]
        [DataTestMethod]
        public void CannotBeValidFileNameFail(string filePath)
        {
            try
            {
                filePath.CannotBeValidFileName();

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Value cannot be a valid file name.", ex.Message);
            }
        }

        [DataRow("")]
        [DataRow("file>1.exe")]
        [DataRow("file|1.ex'")]
        [DataTestMethod]
        public void CannotBeValidFilePath(string filePath)
        {
            Assert.AreEqual(filePath, filePath.CannotBeValidFilePath());
        }

        [DataRow(null)]
        [DataRow("f")]
        [DataRow("file")]
        [DataRow("file.exe")]
        [DataRow("exe.file")]
        [DataRow("exe.sdfsfsdfsdfsdf")]
        [DataTestMethod]
        public void CannotBeValidFilePathFail(string filePath)
        {
            try
            {
                filePath.CannotBeValidFilePath();

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Value cannot be a valid file path.", ex.Message);
            }
        }

        [DataTestMethod]
        public void CannotDirectoryExist()
        {
            if (!Directory.Exists(@".\Temp"))
            {
                Directory.CreateDirectory(@".\Temp");
            }

            try
            {
                @".\Temp".CannotDirectoryExist();

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Directory cannot exist.", ex.Message);
            }

            if (Directory.Exists(@".\Temp"))
            {
                Directory.Delete(@".\Temp");
            }

            Assert.AreEqual(@".\Temp", @".\Temp".CannotDirectoryExist());
        }

        [TestMethod]
        public void CannotFileExist()
        {
            if (!File.Exists(@".\Temp.txt"))
            {
                File.WriteAllText(@".\Temp.txt", "tmp");
            }

            try
            {
                @".\Temp.txt".CannotFileExist();

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("File cannot exist.", ex.Message);
            }

            if (File.Exists(@".\Temp.txt"))
            {
                File.Delete(@".\Temp.txt");
            }

            Assert.AreEqual(@".\Temp.txt", @".\Temp.txt".CannotFileExist());
        }

        #endregion Public Methods
    }
}