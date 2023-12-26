using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DefensiveProgrammingFramework.Test;

[TestClass]
public class FileWhenNotExtensionsTest
{
    #region Public Methods

    [DataTestMethod]
    public void WhenDoesNotDirectoryExist()
    {
        if (!Directory.Exists(@".\Temp"))
        {
            Directory.CreateDirectory(@".\Temp");
        }

        Assert.AreEqual(@".\Temp", @".\Temp".WhenDoesNotDirectoryExist("aaa"));

        if (Directory.Exists(@".\Temp"))
        {
            Directory.Delete(@".\Temp");
        }

        Assert.AreEqual("aaa", @".\Temp".WhenDoesNotDirectoryExist("aaa"));
    }

    [TestMethod]
    public void WhenIsNotEmptyDirectory()
    {
        var directoryPath = @".\Tmp5";
        var filePath = Path.Combine(directoryPath, "tmp.txt");

        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        Assert.AreEqual(directoryPath, directoryPath.WhenIsNotEmptyDirectory("aaa"));

        File.WriteAllText(filePath, "text");

        Assert.AreEqual("aaa", directoryPath.WhenIsNotEmptyDirectory("aaa"));

        File.Delete(filePath);
        Directory.Delete(directoryPath);
    }

    [DataTestMethod]
    public void WhenDoesNotFileExist()
    {
        if (!File.Exists(@".\Tmp.txt"))
        {
            File.WriteAllText(@".\Tmp.txt", "tmp");
        }

        Assert.AreEqual(@".\Tmp.txt", @".\Tmp.txt".WhenDoesNotFileExist("aaa"));

        if (File.Exists(@".\Tmp.txt"))
        {
            File.Delete(@".\Tmp.txt");
        }

        Assert.AreEqual("aaa", @".\Tmp.txt".WhenDoesNotFileExist("aaa"));
    }

    [DataRow(null, "aaa", !true)]
    [DataRow(".", "aaa", !false)]
    [DataRow(@".\bin\Debug", "aaa", !false)]
    [DataRow(@"c:\", "aaa", !true)]
    [DataRow(@"c:", "aaa", !false)]
    [DataRow(@"c:\apps\MyApp\bin\Debug", "aaa", !true)]
    [DataRow(@"d:\apps\MyApp\bin\Debug", "aaa", !true)]
    [DataRow(@"e:\apps\MyApp\bin\Debug", "aaa", !true)]
    [DataTestMethod]
    public void WhenIsNotAbsoluteDirectoryPath(string filePath, string defaultValue, bool expected)
    {
        Assert.AreEqual(expected ? defaultValue : filePath, filePath.WhenIsNotAbsoluteDirectoryPath(defaultValue));
    }

    [DataRow("")]
    [DataRow(@"e:\apps\M|yApp\bin\Debug")]
    [DataTestMethod]
    public void WhenIsNotAbsoluteDirectoryPath(string filePath)
    {
        try
        {
            filePath.WhenIsNotAbsoluteDirectoryPath("aaa");

            Assert.Fail();
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Value must be a valid directory path.", ex.Message);
        }
    }

    [DataRow(null, "aaa", !true)]
    [DataRow(@".\file.exe", "aaa", !false)]
    [DataRow(@".\bin\Debug\file.exe", "aaa", !false)]
    [DataRow(@"c:\file.exe", "aaa", !true)]
    [DataRow(@"c:\apps\MyApp\bin\Debug\file.exe", "aaa", !true)]
    [DataRow(@"d:\apps\MyApp\bin\Debug\file.exe", "aaa", !true)]
    [DataRow(@"e:\apps\MyApp\bin\Debug\file.exe", "aaa", !true)]
    [DataTestMethod]
    public void WhenIsNotAbsoluteFilePath(string filePath, string defaultValue, bool expected)
    {
        Assert.AreEqual(expected ? defaultValue : filePath, filePath.WhenIsNotAbsoluteFilePath(defaultValue));
    }

    [DataRow(@"")]
    [DataRow(@"e:\apps\M|yApp\bin\Debug\file.exe")]
    [DataTestMethod]
    public void WhenIsNotAbsoluteFilePathFail(string filePath)
    {
        try
        {
            filePath.WhenIsNotAbsoluteFilePath("aaa");

            Assert.Fail();
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Value must be a valid file path.", ex.Message);
        }
    }

    [DataRow(null, "aaa", !true)]
    [DataRow("", "aaa", !false)]
    [DataRow("f", "aaa", !true)]
    [DataRow("file", "aaa", !true)]
    [DataRow("file.exe", "aaa", !true)]
    [DataRow(@"C:\Users\User1\source\repos\WpfApp1\WpfApp1\bin\Debug", "aaa", !true)]
    [DataRow(@"C:\Users\User1\source\repos\WpfApp1\WpfApp1\bin\Debug\", "aaa", !true)]
    [DataRow(@"C:\Users\User1\source\repos\WpfApp1\WpfApp1\bin\Debug\file.exe", "aaa", !true)]
    [DataRow("exe.file", "aaa", !true)]
    [DataRow("exe.sdfsfsdfsdfsdf", "aaa", !true)]
    [DataRow("file\t1.exe", "aaa", !false)]
    [DataRow("file|1.ex'", "aaa", !false)]
    [DataTestMethod]
    public void WhenIsNotValidDirectoryPath(string filePath, string defaultValue, bool expected)
    {
        Assert.AreEqual(expected ? defaultValue : filePath, filePath.WhenIsNotValidDirectoryPath(defaultValue));
    }

    [DataRow(null, "aaa", !true)]
    [DataRow("", "aaa", !false)]
    [DataRow("f", "aaa", !true)]
    [DataRow("file", "aaa", !true)]
    [DataRow("file.exe", "aaa", !true)]
    [DataRow("exe.file", "aaa", !true)]
    [DataRow("exe.sdfsfsdfsdfsdf", "aaa", !true)]
    [DataRow("file>1.exe", "aaa", !false)]
    [DataRow("file?1.ex'", "aaa", !false)]
    [DataTestMethod]
    public void WhenNotIsValidFileName(string filePath, string defaultValue, bool expected)
    {
        Assert.AreEqual(expected ? defaultValue : filePath, filePath.WhenIsNotValidFileName(defaultValue));
    }

    [DataRow(null, "aaa", !true)]
    [DataRow("", "aaa", !false)]
    [DataRow("f", "aaa", !true)]
    [DataRow("file", "aaa", !true)]
    [DataRow("file.exe", "aaa", !true)]
    [DataRow("exe.file", "aaa", !true)]
    [DataRow(@"C:\Users\User1\source\repos\WpfApp1\WpfApp1\bin\Debug\file.exe", "aaa", !true)]
    [DataRow("exe.sdfsfsdfsdfsdf", "aaa", !true)]
    [DataRow("file\t1.exe", "aaa", !false)]
    [DataRow("file|1.ex'", "aaa", !false)]
    [DataTestMethod]
    public void WhenNotIsValidFilePath(string filePath, string defaultValue, bool expected)
    {
        Assert.AreEqual(expected ? defaultValue : filePath, filePath.WhenIsNotValidFilePath(defaultValue));
    }

    #endregion Public Methods
}