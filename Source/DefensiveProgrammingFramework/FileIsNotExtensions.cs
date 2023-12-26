using System.Diagnostics;

namespace DefensiveProgrammingFramework;

/// <summary>
/// The file is not extension methods.
/// </summary>
[DebuggerNonUserCode]
[DebuggerStepThrough]
public static class FileIsNotExtensions
{
    #region Public Methods

    /// <summary>
    /// Determines whether the specified directory does not exist.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>
    ///   <c>true</c> if the specified directory does not exist; otherwise, <c>false</c>.
    /// </returns>
    public static bool DoesNotDirectoryExist(this string value)
    {
        value.MustBeValidDirectoryPath();

        return !value.DoesDirectoryExist();
    }

    /// <summary>
    /// Determines whether the specified file does not exist.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>
    ///   <c>true</c> if the specified file does not exist; otherwise, <c>false</c>.
    /// </returns>
    public static bool DoesNotFileExist(this string value)
    {
        value.MustBeValidFilePath();

        return !value.DoesFileExist();
    }

    /// <summary>
    /// Determines whether specified direcory is not empty.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>
    ///   <c>true</c> if specified direcory is not empty; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsNotEmptyDirectory(this string value)
    {
        return !value.IsEmptyDirectory();
    }

    /// <summary>
    /// Determines whether the specified value is an absolute directory path.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>
    ///   <c>true</c> if the specified value is an absolute directory path; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsNotAbsoluteDirectoryPath(this string value)
    {
        return !value.IsAbsoluteDirectoryPath();
    }

    /// <summary>
    /// Determines whether the specified value is an absolute file path.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>
    ///   <c>true</c> if the specified value is an absolute file path; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsNotAbsoluteFilePath(this string value)
    {
        return !value.IsAbsoluteFilePath();
    }

    /// <summary>
    /// Determines whether the specified value is not a valid directory path.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>
    ///   <c>true</c> if the specified value is not a valid directory path; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsNotValidDirectoryPath(this string value)
    {
        return !value.IsValidDirectoryPath();
    }

    /// <summary>
    /// Determines whether the specified value is not a valid file name.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>
    ///   <c>true</c> if the specified value is not a valid file name; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsNotValidFileName(this string value)
    {
        return !value.IsValidFileName();
    }

    /// <summary>
    /// Determines whether the specified value is not a valid file path.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>
    ///   <c>true</c> if the specified value is not a valid file path; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsNotValidFilePath(this string value)
    {
        return !value.IsValidFilePath();
    }

    #endregion Public Methods
}
