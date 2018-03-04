using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace DefensiveProgrammingFramework
{
    /// <summary>
    /// The file when extension methods.
    /// </summary>
    [DebuggerNonUserCode]
    [DebuggerStepThrough]
    public static class FileWhenExtensions
    {
        #region Public Methods

        /// <summary>
        /// Returns default value when the specified directory exist; otherwise returns the original value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>
        /// The default value when the directory exist; otherwise returns the original value.
        /// </returns>
        public static string WhenDoesDirectoryExist(this string value, string defaultValue)
        {
            if (value.DoesDirectoryExist())
            {
                return defaultValue;
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// Returns default value when the specified file exist; otherwise returns the original value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>
        /// The default value when the file exist; otherwise returns the original value.
        /// </returns>
        public static string WhenDoesFileExist(this string value, string defaultValue)
        {
            if (value.DoesFileExist())
            {
                return defaultValue;
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// Returns default value when the specified directory path is an absolute directory path; otherwise returns the original value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>
        /// The default value when the directory path is an absolute directory path; otherwise returns the original value.
        /// </returns>
        public static string WhenIsAbsoluteDirectoryPath(this string value, string defaultValue)
        {
            if (value.IsAbsoluteDirectoryPath())
            {
                return defaultValue;
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// Returns default value when the specified file path is an absolute file path; otherwise returns the original value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>
        /// The default value when the file path is an absolute file path; otherwise returns the original value.
        /// </returns>
        public static string WhenIsAbsoluteFilePath(this string value, string defaultValue)
        {
            if (value.IsAbsoluteFilePath())
            {
                return defaultValue;
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// Returns default value when the original value is a valid directory path; otherwise returns the original value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>
        /// The default value when the original value is a valid directory path; otherwise returns the original value.
        /// </returns>
        public static string WhenIsValidDirectoryPath(this string value, string defaultValue)
        {
            if (value.IsValidDirectoryPath())
            {
                return defaultValue;
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// Returns default value when the original value is a valid file name; otherwise returns the original value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>
        /// The default value when the original value is a valid file name; otherwise returns the original value.
        /// </returns>
        public static string WhenIsValidFileName(this string value, string defaultValue)
        {
            if (value.IsValidFileName())
            {
                return defaultValue;
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// Returns default value when the original value is a valid file path; otherwise returns the original value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>
        /// The default value when the original value is a valid file path; otherwise returns the original value.
        /// </returns>
        public static string WhenIsValidFilePath(this string value, string defaultValue)
        {
            if (value.IsValidFilePath())
            {
                return defaultValue;
            }
            else
            {
                return value;
            }
        }

        #endregion Public Methods
    }
}
