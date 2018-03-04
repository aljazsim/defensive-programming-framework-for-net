using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace DefensiveProgrammingFramework
{
    /// <summary>
    /// The file is extension methods.
    /// </summary>
    ////[DebuggerNonUserCode]
    ////[DebuggerStepThrough]
    public static class FileIsExtensions
    {
        #region Public Methods

        /// <summary>
        /// Determines whether the specified directory exists.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        ///   <c>true</c> if the specified directory exists; otherwise, <c>false</c>.
        /// </returns>
        public static bool DoesDirectoryExist(this string value)
        {
            value.MustBeValidDirectoryPath();

            return Directory.Exists(value);
        }

        /// <summary>
        /// Determines whether the specified file exists.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        ///   <c>true</c> if the specified file exists; otherwise, <c>false</c>.
        /// </returns>
        public static bool DoesFileExist(this string value)
        {
            value.MustBeValidFilePath();

            return File.Exists(value);
        }

        /// <summary>
        /// Determines whether the specified value is an absolute directory path.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        ///   <c>true</c> if the specified value is an absolute directory path; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsAbsoluteDirectoryPath(this string value)
        {
            if (value == null)
            {
                return true;
            }
            else
            {
                value.MustBeValidDirectoryPath();

                return value == Path.GetFullPath(value);
            }
        }

        /// <summary>
        /// Determines whether the specified value is an absolute file path.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        ///   <c>true</c> if the specified value is an absolute file path; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsAbsoluteFilePath(this string value)
        {
            if (value == null)
            {
                return true;
            }
            else
            {
                value.MustBeValidFilePath();

                return value == Path.GetFullPath(value);
            }
        }

        /// <summary>
        /// Determines whether the specified value is a valid directory path.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        ///   <c>true</c> if the specified value is a valid directory path; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidDirectoryPath(this string value)
        {
            if (value == null)
            {
                return true;
            }
            else if (string.IsNullOrWhiteSpace(value))
            {
                return false;
            }
            else
            {
                return !value.ToCharArray().Intersect(Path.GetInvalidPathChars()).Any();
            }
        }

        /// <summary>
        /// Determines whether the specified value is a valid file name.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        ///   <c>true</c> if the specified value is a valid file name; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidFileName(this string value)
        {
            if (value == null)
            {
                return true;
            }
            else if (string.IsNullOrWhiteSpace(value))
            {
                return false;
            }
            else
            {
                return !value.ToCharArray().Intersect(Path.GetInvalidFileNameChars()).Any();
            }
        }

        /// <summary>
        /// Determines whether the specified value is a valid file path.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        ///   <c>true</c> if the specified value is a valid file path; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidFilePath(this string value)
        {
            if (value == null)
            {
                return true;
            }
            else if (string.IsNullOrWhiteSpace(value))
            {
                return false;
            }
            else
            {
                return !value.ToCharArray().Intersect(Path.GetInvalidPathChars()).Any();
            }
        }

        #endregion Public Methods
    }
}
