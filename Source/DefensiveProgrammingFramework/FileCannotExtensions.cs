using System.Diagnostics;

namespace DefensiveProgrammingFramework;

/// <summary>
/// The file cannot extension methods.
/// </summary>
[DebuggerNonUserCode]
[DebuggerStepThrough]
public static class FileCannotExtensions
{
    #region Public Methods

    /// <summary>
    /// Returns original value if the specified value is not an absolute directory path; otherwise throws a new ArgumentException.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="errorHandler">The error handler.</param>
    /// <returns>
    /// The original value if the specified value is not an absolute directory path; otherwise throws a new ArgumentException.
    /// </returns>
    public static string CannotBeAbsoluteDirectoryPath(this string value, Action errorHandler = null)
    {
        if (value.IsAbsoluteDirectoryPath())
        {
            if (errorHandler.IsNull())
            {
                throw new ArgumentException("Value cannot be an absolute directory path.");
            }
            else
            {
                errorHandler();
            }
        }

        return value;
    }

    /// <summary>
    /// Returns original value if the specified value not is an absolute file path; otherwise throws a new ArgumentException.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="errorHandler">The error handler.</param>
    /// <returns>
    /// The original value if the specified value not is an absolute file path; otherwise throws a new ArgumentException.
    /// </returns>
    public static string CannotBeAbsoluteFilePath(this string value, Action errorHandler = null)
    {
        if (value.IsAbsoluteFilePath())
        {
            if (errorHandler.IsNull())
            {
                throw new ArgumentException("Value cannot be an absolute file path.");
            }
            else
            {
                errorHandler();
            }
        }

        return value;
    }

    /// <summary>
    /// Returns original value if the specified value is not an empty directory path; otherwise throws a new ArgumentException.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="errorHandler">The error handler.</param>
    /// <returns>
    /// The original value if the specified value is not an empty directory path; otherwise throws a new ArgumentException.
    /// </returns>
    public static string CannotBeEmptyDirectory(this string value, Action errorHandler = null)
    {
        if (value.IsEmptyDirectory())
        {
            if (errorHandler.IsNull())
            {
                throw new ArgumentException("Value cannot be an empty directory.");
            }
            else
            {
                errorHandler();
            }
        }

        return value;
    }

    /// <summary>
    /// Returns original value if the specified value is not a valid directory path; otherwise throws a new ArgumentException.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="errorHandler">The error handler.</param>
    /// <returns>
    /// The original value if the specified value is not a valid directory path; otherwise throws a new ArgumentException.
    /// </returns>
    public static string CannotBeValidDirectoryPath(this string value, Action errorHandler = null)
    {
        if (value.IsValidDirectoryPath())
        {
            if (errorHandler.IsNull())
            {
                throw new ArgumentException("Value cannot be a valid directory path.");
            }
            else
            {
                errorHandler();
            }
        }

        return value;
    }

    /// <summary>
    /// Returns original value if the specified value is not a valid file name; otherwise throws a new ArgumentException.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="errorHandler">The error handler.</param>
    /// <returns>
    /// The original value if the specified value is not a valid file name; otherwise throws a new ArgumentException.
    /// </returns>
    public static string CannotBeValidFileName(this string value, Action errorHandler = null)
    {
        if (value.IsValidFileName())
        {
            if (errorHandler.IsNull())
            {
                throw new ArgumentException("Value cannot be a valid file name.");
            }
            else
            {
                errorHandler();
            }
        }

        return value;
    }

    /// <summary>
    /// Returns original value if the specified value is not a valid file path; otherwise throws a new ArgumentException.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="errorHandler">The error handler.</param>
    /// <returns>
    /// The original value if the specified value is not a valid file path; otherwise throws a new ArgumentException.
    /// </returns>
    public static string CannotBeValidFilePath(this string value, Action errorHandler = null)
    {
        if (value.IsValidFilePath())
        {
            if (errorHandler.IsNull())
            {
                throw new ArgumentException("Value cannot be a valid file path.");
            }
            else
            {
                errorHandler();
            }
        }

        return value;
    }

    /// <summary>
    /// Returns original value if the specified directory does not exist; otherwise throws a new ArgumentException.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="errorHandler">The error handler.</param>
    /// <returns>
    /// The original value if the specified directory does not exist; otherwise throws a new ArgumentException.
    /// </returns>
    public static string CannotDirectoryExist(this string value, Action errorHandler = null)
    {
        if (value.DoesDirectoryExist())
        {
            if (errorHandler.IsNull())
            {
                throw new ArgumentException("Directory cannot exist.");
            }
            else
            {
                errorHandler();
            }
        }

        return value;
    }

    /// <summary>
    /// Returns original value if the specified file does not exist; otherwise throws a new ArgumentException.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="errorHandler">The error handler.</param>
    /// <returns>
    /// The original value if the specified file does not exist; otherwise throws a new ArgumentException.
    /// </returns>
    public static string CannotFileExist(this string value, Action errorHandler = null)
    {
        if (value.DoesFileExist())
        {
            if (errorHandler.IsNull())
            {
                throw new ArgumentException("File cannot exist.");
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
