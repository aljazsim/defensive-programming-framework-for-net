using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DefensiveProgrammingFramework.Test.Files
{
    [TestClass]
    public class IsNotExtensionsTest
    {
        #region Public Methods

        [TestMethod]
        public void IsNotEmptyDirectory()
        {
            string directoryPath = @".\Tmp5";
            string filePath = Path.Combine(directoryPath, "tmp.txt");

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            Assert.IsFalse(directoryPath.IsNotEmptyDirectory());

            File.WriteAllText(filePath, "text");

            Assert.IsTrue(directoryPath.IsNotEmptyDirectory());

            File.Delete(filePath);
            Directory.Delete(directoryPath);
        }

        [DataRow(null, !true)]
        [DataRow("", !false)]
        [DataRow("f", !true)]
        [DataRow("file", !true)]
        [DataRow("file.exe", !true)]
        [DataRow("exe.file", !true)]
        [DataRow("exe.sdfsfsdfsdfsdf", !true)]
        [DataRow("file>1.exe", !false)]
        [DataRow("file?1.ex'", !false)]
        [DataTestMethod]
        public void IsNotValidFileName(string filePath, bool expected)
        {
            Assert.AreEqual(expected, filePath.IsNotValidFileName());
        }

        [DataRow(null, !true)]
        [DataRow("", !false)]
        [DataRow("f", !true)]
        [DataRow("file", !true)]
        [DataRow("file.exe", !true)]
        [DataRow("exe.file", !true)]
        [DataRow(@"C:\Users\User1\source\repos\WpfApp1\WpfApp1\bin\Debug\file.exe", !true)]
        [DataRow("exe.sdfsfsdfsdfsdf", !true)]
        [DataRow("file>1.exe", !false)]
        [DataRow("file|1.ex'", !false)]
        [DataTestMethod]
        public void IsNotValidFilePath(string filePath, bool expected)
        {
            Assert.AreEqual(expected, filePath.IsNotValidFilePath());
        }

        [DataRow(null, !true)]
        [DataRow("", !false)]
        [DataRow("f", !true)]
        [DataRow("file", !true)]
        [DataRow("file.exe", !true)]
        [DataRow(@"C:\Users\User1\source\repos\WpfApp1\WpfApp1\bin\Debug", !true)]
        [DataRow(@"C:\Users\User1\source\repos\WpfApp1\WpfApp1\bin\Debug\", !true)]
        [DataRow(@"C:\Users\User1\source\repos\WpfApp1\WpfApp1\bin\Debug\file.exe", !true)]
        [DataRow("exe.file", !true)]
        [DataRow("exe.sdfsfsdfsdfsdf", !true)]
        [DataRow("file>1.exe", !false)]
        [DataRow("file|1.ex'", !false)]
        [DataTestMethod]
        public void IsNotValidDirectoryPath(string filePath, bool expected)
        {
            Assert.AreEqual(expected, filePath.IsNotValidDirectoryPath());
        }

        [DataRow(".", !false)]
        [DataRow(@".\bin\Debug", !false)]
        [DataRow(@"c:\", !true)]
        [DataRow(@"c:", !false)]
        [DataRow(@"c:\apps\MyApp\bin\Debug", !true)]
        [DataRow(@"d:\apps\MyApp\bin\Debug", !true)]
        [DataRow(@"e:\apps\MyApp\bin\Debug", !true)]
        [DataTestMethod]
        public void IsNotAbsoluteDirectoryPath(string filePath, bool expected)
        {
            Assert.AreEqual(expected, filePath.IsNotAbsoluteDirectoryPath());
        }

        [DataRow(@"e:\apps\M|yApp\bin\Debug\file.exe")]
        [DataTestMethod]
        public void IsNotAbsoluteFilePathFail(string filePath)
        {
            try
            {
                filePath.IsNotAbsoluteFilePath();

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Value must be a valid file path.", ex.Message);
            }
        }

        [DataRow(@"e:\apps\M|yApp\bin\Debug")]
        [DataTestMethod]
        public void IsNotAbsoluteDirectoryPathFail(string filePath)
        {
            try
            {
                filePath.IsNotAbsoluteDirectoryPath();

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Value must be a valid directory path.", ex.Message);
            }
        }

        [DataRow(@".\file.exe", !false)]
        [DataRow(@".\bin\Debug\file.exe", !false)]
        [DataRow(@"c:\file.exe", !true)]
        [DataRow(@"c:\apps\MyApp\bin\Debug\file.exe", !true)]
        [DataRow(@"d:\apps\MyApp\bin\Debug\file.exe", !true)]
        [DataRow(@"e:\apps\MyApp\bin\Debug\file.exe", !true)]
        [DataTestMethod]
        public void IsNotAbsoluteFilePath(string filePath, bool expected)
        {
            Assert.AreEqual(expected, filePath.IsNotAbsoluteFilePath());
        }

        [DataTestMethod]
        public void DoesNotDirectoryExist()
        {
            if (!Directory.Exists(@".\Temp"))
            {
                Directory.CreateDirectory(@".\Temp");
            }

            Assert.AreEqual(!true, @".\Temp".DoesNotDirectoryExist());

            if (Directory.Exists(@".\Temp"))
            {
                Directory.Delete(@".\Temp");
            }

            Assert.AreEqual(!false, @".\Temp".DoesNotDirectoryExist());
        }

        [DataTestMethod]
        public void DoesNotFileExist()
        {
            if (!File.Exists(@".\Temp.txt"))
            {
                File.WriteAllText(@".\Temp.txt", "tmp");
            }

            Assert.AreEqual(!true, @".\Temp.txt".DoesNotFileExist());

            if (File.Exists(@".\Temp.txt"))
            {
                File.Delete(@".\Temp.txt");
            }

            Assert.AreEqual(!false, @".\Temp.txt".DoesNotFileExist());
        }

        #endregion Public Methods
    }
}