using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace DefensiveProgrammingFramework
{
    /// <summary>
    /// The file when not extension methods.
    /// </summary>
    [DebuggerNonUserCode]
    [DebuggerStepThrough]
    public static class FileWhenNotExtensions
    {
        #region Public Methods

        /// <summary>
        /// Returns default value when the specified directory does exist; otherwise returns the original value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>
        /// The default value when the directory does exist; otherwise returns the original value.
        /// </returns>
        public static string WhenDoesNotDirectoryExist(this string value, string defaultValue)
        {
            if (value.DoesNotDirectoryExist())
            {
                return defaultValue;
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// Returns default value when the specified directory path is not empty; otherwise returns the original value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>
        /// The default value when the directory path is not empty; otherwise returns the original value.
        /// </returns>
        public static string WhenIsNotEmptyDirectory(this string value, string defaultValue)
        {
            if (value.IsNotEmptyDirectory())
            {
                return defaultValue;
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// Returns default value when the specified file does not exist; otherwise returns the original value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>
        /// The default value when the file does not exist; otherwise returns the original value.
        /// </returns>
        public static string WhenDoesNotFileExist(this string value, string defaultValue)
        {
            if (value.DoesNotFileExist())
            {
                return defaultValue;
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// Returns default value when the specified directory path is not an absolute directory path; otherwise returns the original value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>
        /// The default value when the directory path is not an absolute directory path; otherwise returns the original value.
        /// </returns>
        public static string WhenIsNotAbsoluteDirectoryPath(this string value, string defaultValue)
        {
            if (value.IsNotAbsoluteDirectoryPath())
            {
                return defaultValue;
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// Returns default value when the specified file path is not an absolute file path; otherwise returns the original value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>
        /// The default value when the file path is not an absolute file path; otherwise returns the original value.
        /// </returns>
        public static string WhenIsNotAbsoluteFilePath(this string value, string defaultValue)
        {
            if (value.IsNotAbsoluteFilePath())
            {
                return defaultValue;
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// Returns default value when the original value is not a valid directory path; otherwise returns the original value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>
        /// The default value when the original value is not a valid directory path; otherwise returns the original value.
        /// </returns>
        public static string WhenIsNotValidDirectoryPath(this string value, string defaultValue)
        {
            if (value.IsNotValidDirectoryPath())
            {
                return defaultValue;
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// Returns default value when the original value is not a valid file name; otherwise returns the original value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>
        /// The default value when the original value is not a valid file name; otherwise returns the original value.
        /// </returns>
        public static string WhenIsNotValidFileName(this string value, string defaultValue)
        {
            if (value.IsNotValidFileName())
            {
                return defaultValue;
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// Returns default value when the original value is not a valid file path; otherwise returns the original value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>
        /// The default value when the original value is not a valid file path; otherwise returns the original value.
        /// </returns>
        public static string WhenIsNotValidFilePath(this string value, string defaultValue)
        {
            if (value.IsNotValidFilePath())
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
