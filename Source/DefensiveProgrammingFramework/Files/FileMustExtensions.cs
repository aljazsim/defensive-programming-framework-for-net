using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace DefensiveProgrammingFramework
{
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
        /// <returns>
        /// The original value if the specified value is an absolute directory path; otherwise throws a new ArgumentException.
        /// </returns>
        public static string MustBeAbsoluteDirectoryPath(this string value)
        {
            if (value.IsNotAbsoluteDirectoryPath())
            {
                throw new ArgumentException("Value must be an absolute directory path.");
            }

            return value;
        }

        /// <summary>
        /// Returns original value if the specified value is an absolute file path; otherwise throws a new ArgumentException.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The original value if the specified value is an absolute file path; otherwise throws a new ArgumentException.
        /// </returns>
        public static string MustBeAbsoluteFilePath(this string value)
        {
            if (value.IsNotAbsoluteFilePath())
            {
                throw new ArgumentException("Value must be an absolute file path.");
            }

            return value;
        }

        /// <summary>
        /// Returns original value if the specified value is an empty directory path; otherwise throws a new ArgumentException.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The original value if the specified value is an empty directory path; otherwise throws a new ArgumentException.
        /// </returns>
        public static string MustBeEmptyDirectory(this string value)
        {
            if (value.IsNotEmptyDirectory())
            {
                throw new ArgumentException("Value must be an empty directory.");
            }

            return value;
        }

        /// <summary>
        /// Returns original value if the specified value is a valid directory path; otherwise throws a new ArgumentException.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The original value if the specified value is a valid directory path; otherwise throws a new ArgumentException.
        /// </returns>
        public static string MustBeValidDirectoryPath(this string value)
        {
            if (value.IsNotValidFilePath())
            {
                throw new ArgumentException("Value must be a valid directory path.");
            }

            return value;
        }

        /// <summary>
        /// Returns original value if the specified value is a valid file name; otherwise throws a new ArgumentException.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The original value if the specified value is a valid file name; otherwise throws a new ArgumentException.
        /// </returns>
        public static string MustBeValidFileName(this string value)
        {
            if (value.IsNotValidFileName())
            {
                throw new ArgumentException("Value must be a valid file name.");
            }

            return value;
        }

        /// <summary>
        /// Returns original value if the specified value is a valid file path; otherwise throws a new ArgumentException.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The original value if the specified value is a valid file path; otherwise throws a new ArgumentException.
        /// </returns>
        public static string MustBeValidFilePath(this string value)
        {
            if (value.IsNotValidFilePath())
            {
                throw new ArgumentException("Value must be a valid file path.");
            }

            return value;
        }

        /// <summary>
        /// Returns original value if the specified directory exists; otherwise throws a new ArgumentException.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The original value if the specified directory exists; otherwise throws a new ArgumentException.
        /// </returns>
        public static string MustDirectoryExist(this string value)
        {
            if (value.DoesNotDirectoryExist())
            {
                throw new ArgumentException("Directory must exist.");
            }

            return value;
        }

        /// <summary>
        /// Returns original value if the specified file exists; otherwise throws a new ArgumentException.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The original value if the specified file exists; otherwise throws a new ArgumentException.
        /// </returns>
        public static string MustFileExist(this string value)
        {
            if (value.DoesNotFileExist())
            {
                throw new ArgumentException("File must exist.");
            }

            return value;
        }

        #endregion Public Methods
    }
}
