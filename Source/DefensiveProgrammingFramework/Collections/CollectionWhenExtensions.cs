using System;
using System.Collections;
using System.Collections.Generic;

namespace DefensiveProgrammingFramework
{
    /// <summary>
    /// The collection when extension methods.
    /// </summary>
    public static class CollectionWhenExtensions
    {
        #region Public Methods

        /// <summary>
        /// Returns original value if the specified value contains any items coresponding to the selector function; otherwise throws a new ArgumentException; otherwise returns the original value.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="func">The function.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>
        /// The original value if the specified value contains any items coresponding to the selector function; otherwise returns the original value.
        /// </returns>
        public static IEnumerable<T> WhenContains<T>(this IEnumerable<T> value, Func<T, bool> func, IEnumerable<T> defaultValue) where T : class
        {
            if (value.Contains(func))
            {
                return defaultValue;
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// Returns original value if the specified value contains duplicates; otherwise returns the original value.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>
        /// The original value if the specified value contains duplicates; otherwise returns the original value.
        /// </returns>
        public static IEnumerable<T> WhenContainsDuplicates<T>(this IEnumerable<T> value, IEnumerable<T> defaultValue) where T : IComparable
        {
            if (value.ContainsDuplicates())
            {
                return defaultValue;
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// Returns original value if the specified value contains null values; otherwise returns the original value.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>
        /// The original value if the specified value contains null values; otherwise returns the original value.
        /// </returns>
        public static IEnumerable<T> WhenContainsNull<T>(this IEnumerable<T> value, IEnumerable<T> defaultValue) where T : class
        {
            if (value.ContainsNull())
            {
                return defaultValue;
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// Returns original value if the specified value contains only null values; otherwise returns the original value.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>
        /// The original value if the specified value contains only null values; otherwise returns the original value.
        /// </returns>
        public static IEnumerable<T> WhenContainsOnlyNull<T>(this IEnumerable<T> value, IEnumerable<T> defaultValue) where T : class
        {
            if (value.ContainsOnlyNull())
            {
                return defaultValue;
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// Returns original value if the specified value is empty; otherwise returns the original value.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>
        /// The original value if the specified value is empty; otherwise returns the original value.
        /// </returns>
        public static IEnumerable<T> WhenIsEmpty<T>(this IEnumerable<T> value, IEnumerable<T> defaultValue)
        {
            if (value.IsEmpty())
            {
                return defaultValue;
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// Returns original value if the specified value is equal to the compared value; otherwise returns the original value.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <param name="ignoreOrder">If set to <c>true</c> ignore item order.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>
        /// The original value if the specified value is equal to the compared value; otherwise returns the original value.
        /// </returns>
        public static IEnumerable<T> WhenIsEqualTo<T>(this IEnumerable<T> value1, IEnumerable<T> value2, bool ignoreOrder, IEnumerable<T> defaultValue) where T : IComparable
        {
            if (value1.IsEqualTo(value2, ignoreOrder))
            {
                return defaultValue;
            }
            else
            {
                return value1;
            }
        }

        /// <summary>
        /// Returns original value if the specified value is null or empty; otherwise returns the original value.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>
        /// The original value if the specified value is null or empty; otherwise returns the original value.
        /// </returns>
        public static T WhenIsNullOrEmpty<T>(this T value, T defaultValue) where T : IEnumerable
        {
            if (value.IsNullOrEmpty())
            {
                return defaultValue;
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// Returns original value if the specified value belongs to the specified set; otherwise returns the original value.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="set">The set.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>
        /// The original value if the specified value belongs to the specified set; otherwise returns the original value.
        /// </returns>
        public static T WhenIsOneOf<T>(this T value, IEnumerable<T> set, T defaultValue) where T : IComparable
        {
            if (value.IsOneOf(set))
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
