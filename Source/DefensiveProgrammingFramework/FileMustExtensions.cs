using System.Diagnostics;

namespace DefensiveProgrammingFramework;

/// <summary>
/// The object must extension methods.
/// </summary>
[DebuggerNonUserCode]
[DebuggerStepThrough]
public static class FileMustExtensions
{
    #region Public Methods

    /// <summary>
    /// Returns original value if the specified value is an absolute directory path; otherwise throws a new ArgumentException.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="errorHandler">The error handler.</param>
    /// <returns>
    /// The original value if the specified value is an absolute directory path; otherwise throws a new ArgumentException.
    /// </returns>
    public static string MustBeAbsoluteDirectoryPath(this string value, Action errorHandler = null)
    {
        if (value.IsNotAbsoluteDirectoryPath())
        {
            if (errorHandler.IsNull())
            {
                throw new ArgumentException("Value must be an absolute directory path.");
            }
            else
            {
                errorHandler();
            }
        }

        return value;
    }

    /// <summary>
    /// Returns original value if the specified value is an absolute file path; otherwise throws a new ArgumentException.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="errorHandler">The error handler.</param>
    /// <returns>
    /// The original value if the specified value is an absolute file path; otherwise throws a new ArgumentException.
    /// </returns>
    public static string MustBeAbsoluteFilePath(this string value, Action errorHandler = null)
    {
        if (value.IsNotAbsoluteFilePath())
        {
            if (errorHandler.IsNull())
            {
                throw new ArgumentException("Value must be an absolute file path.");
            }
            else
            {
                errorHandler();
            }
        }

        return value;
    }

    /// <summary>
    /// Returns original value if the specified value is an empty directory path; otherwise throws a new ArgumentException.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="errorHandler">The error handler.</param>
    /// <returns>
    /// The original value if the specified value is an empty directory path; otherwise throws a new ArgumentException.
    /// </returns>
    public static string MustBeEmptyDirectory(this string value, Action errorHandler = null)
    {
        if (value.IsNotEmptyDirectory())
        {
            if (errorHandler.IsNull())
            {
                throw new ArgumentException("Value must be an empty directory.");
            }
            else
            {
                errorHandler();
            }
        }

        return value;
    }

    /// <summary>
    /// Returns original value if the specified value is a valid directory path; otherwise throws a new ArgumentException.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="errorHandler">The error handler.</param>
    /// <returns>
    /// The original value if the specified value is a valid directory path; otherwise throws a new ArgumentException.
    /// </returns>
    public static string MustBeValidDirectoryPath(this string value, Action errorHandler = null)
    {
        if (value.IsNotValidFilePath())
        {
            if (errorHandler.IsNull())
            {
                throw new ArgumentException("Value must be a valid directory path.");
            }
            else
            {
                errorHandler();
            }
        }

        return value;
    }

    /// <summary>
    /// Returns original value if the specified value is a valid file name; otherwise throws a new ArgumentException.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="errorHandler">The error handler.</param>
    /// <returns>
    /// The original value if the specified value is a valid file name; otherwise throws a new ArgumentException.
    /// </returns>
    public static string MustBeValidFileName(this string value, Action errorHandler = null)
    {
        if (value.IsNotValidFileName())
        {
            if (errorHandler.IsNull())
            {
                throw new ArgumentException("Value must be a valid file name.");
            }
            else
            {
                errorHandler();
            }
        }

        return value;
    }

    /// <summary>
    /// Returns original value if the specified value is a valid file path; otherwise throws a new ArgumentException.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="errorHandler">The error handler.</param>
    /// <returns>
    /// The original value if the specified value is a valid file path; otherwise throws a new ArgumentException.
    /// </returns>
    public static string MustBeValidFilePath(this string value, Action errorHandler = null)
    {
        if (value.IsNotValidFilePath())
        {
            if (errorHandler.IsNull())
            {
                throw new ArgumentException("Value must be a valid file path.");
            }
            else
            {
                errorHandler();
            }
        }

        return value;
    }

    /// <summary>
    /// Returns original value if the specified directory exists; otherwise throws a new ArgumentException.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="errorHandler">The error handler.</param>
    /// <returns>
    /// The original value if the specified directory exists; otherwise throws a new ArgumentException.
    /// </returns>
    public static string MustDirectoryExist(this string value, Action errorHandler = null)
    {
        if (value.DoesNotDirectoryExist())
        {
            if (errorHandler.IsNull())
            {
                throw new ArgumentException("Directory must exist.");
            }
            else
            {
                errorHandler();
            }
        }

        return value;
    }

    /// <summary>
    /// Returns original value if the specified file exists; otherwise throws a new ArgumentException.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="errorHandler">The error handler.</param>
    /// <returns>
    /// The original value if the specified file exists; otherwise throws a new ArgumentException.
    /// </returns>
    public static string MustFileExist(this string value, Action errorHandler = null)
    {
        if (value.DoesNotFileExist())
        {
            if (errorHandler.IsNull())
            {
                throw new ArgumentException("File must exist.");
            }
            else
            {
                errorHandler();
            }
        }

        return value;
    }

    #endregion Public Methods
}
