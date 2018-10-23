using System;
using System.Diagnostics;

namespace DefensiveProgrammingFramework
{
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
        /// <returns>
        /// The original value if the specified value is not an absolute directory path; otherwise throws a new ArgumentException.
        /// </returns>
        public static string CannotBeAbsoluteDirectoryPath(this string value)
        {
            if (value.IsAbsoluteDirectoryPath())
            {
                throw new ArgumentException("Value cannot be an absolute directory path.");
            }

            return value;
        }

        /// <summary>
        /// Returns original value if the specified value not is an absolute file path; otherwise throws a new ArgumentException.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The original value if the specified value not is an absolute file path; otherwise throws a new ArgumentException.
        /// </returns>
        public static string CannotBeAbsoluteFilePath(this string value)
        {
            if (value.IsAbsoluteFilePath())
            {
                throw new ArgumentException("Value cannot be an absolute file path.");
            }

            return value;
        }

        /// <summary>
        /// Returns original value if the specified value is not an empty directory path; otherwise throws a new ArgumentException.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The original value if the specified value is not an empty directory path; otherwise throws a new ArgumentException.
        /// </returns>
        public static string CannotBeEmptyDirectory(this string value)
        {
            if (value.IsEmptyDirectory())
            {
                throw new ArgumentException("Value cannot be an empty directory.");
            }

            return value;
        }

        /// <summary>
        /// Returns original value if the specified value is not a valid directory path; otherwise throws a new ArgumentException.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The original value if the specified value is not a valid directory path; otherwise throws a new ArgumentException.
        /// </returns>
        public static string CannotBeValidDirectoryPath(this string value)
        {
            if (value.IsValidDirectoryPath())
            {
                throw new ArgumentException("Value cannot be a valid directory path.");
            }

            return value;
        }

        /// <summary>
        /// Returns original value if the specified value is not a valid file name; otherwise throws a new ArgumentException.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The original value if the specified value is not a valid file name; otherwise throws a new ArgumentException.
        /// </returns>
        public static string CannotBeValidFileName(this string value)
        {
            if (value.IsValidFileName())
            {
                throw new ArgumentException("Value cannot be a valid file name.");
            }

            return value;
        }

        /// <summary>
        /// Returns original value if the specified value is not a valid file path; otherwise throws a new ArgumentException.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The original value if the specified value is not a valid file path; otherwise throws a new ArgumentException.
        /// </returns>
        public static string CannotBeValidFilePath(this string value)
        {
            if (value.IsValidFilePath())
            {
                throw new ArgumentException("Value cannot be a valid file path.");
            }

            return value;
        }

        /// <summary>
        /// Returns original value if the specified directory does not exist; otherwise throws a new ArgumentException.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The original value if the specified directory does not exist; otherwise throws a new ArgumentException.
        /// </returns>
        public static string CannotDirectoryExist(this string value)
        {
            if (value.DoesDirectoryExist())
            {
                throw new ArgumentException("Directory cannot exist.");
            }

            return value;
        }

        /// <summary>
        /// Returns original value if the specified file does not exist; otherwise throws a new ArgumentException.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The original value if the specified file does not exist; otherwise throws a new ArgumentException.
        /// </returns>
        public static string CannotFileExist(this string value)
        {
            if (value.DoesFileExist())
            {
                throw new ArgumentException("File cannot exist.");
            }

            return value;
        }

        #endregion Public Methods
    }
}
