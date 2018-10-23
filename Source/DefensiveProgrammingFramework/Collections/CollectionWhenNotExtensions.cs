using System;
using System.Collections;
using System.Collections.Generic;

namespace DefensiveProgrammingFramework
{
    /// <summary>
    /// The collection when not extension method.
    /// </summary>
    public static class CollectionWhenNotExtensions
    {
        #region Public Methods

        /// <summary>
        /// Returns original value if the specified value doesn't contain any items coresponding to the selector function; otherwise throws a new ArgumentException; otherwise returns the original value.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="func">The function.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>
        /// The original value if the specified value doesn't contain any items coresponding to the selector function; otherwise returns the original value.
        /// </returns>
        public static IEnumerable<T> WhenContainsNot<T>(this IEnumerable<T> value, Func<T, bool> func, IEnumerable<T> defaultValue)
        {
            if (value.ContainsNot(func))
            {
                return defaultValue;
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// Returns original value if the specified value doesn't contain duplicates; otherwise returns the original value.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>
        /// The original value if the specified value doesn't contain; otherwise returns the original value.
        /// </returns>
        public static IEnumerable<T> WhenContainsNotDuplicates<T>(this IEnumerable<T> value, IEnumerable<T> defaultValue)
            where T : IComparable
        {
            if (value.ContainsNotDuplicates())
            {
                return defaultValue;
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// Returns original value if the specified value doesn't contain null values; otherwise returns the original value.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>
        /// The original value if the specified value doesn't contain null values; otherwise returns the original value.
        /// </returns>
        public static IEnumerable<T> WhenContainsNotNull<T>(this IEnumerable<T> value, IEnumerable<T> defaultValue)
            where T : class
        {
            if (value.ContainsNotNull())
            {
                return defaultValue;
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// Returns original value if the specified value doesn't contain only null values; otherwise returns the original value.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>
        /// The original value if the specified value doesn't contain only null values; otherwise returns the original value.
        /// </returns>
        public static IEnumerable<T> WhenContainsNotOnlyNull<T>(this IEnumerable<T> value, IEnumerable<T> defaultValue)
            where T : class
        {
            if (value.ContainsNotOnlyNull())
            {
                return defaultValue;
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// Returns original value if the specified value is not empty; otherwise returns the original value.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>
        /// The original value if the specified value is not empty; otherwise returns the original value.
        /// </returns>
        public static IEnumerable<T> WhenIsNotEmpty<T>(this IEnumerable<T> value, IEnumerable<T> defaultValue)
        {
            if (value.IsNotEmpty())
            {
                return defaultValue;
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// Returns original value if the specified value is not equal to the compared value; otherwise returns the original value.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <param name="ignoreOrder">If set to <c>true</c> ignore item order.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>
        /// The original value if the specified value is not equal to the compared value; otherwise returns the original value.
        /// </returns>
        public static IEnumerable<T> WhenIsNotEqualTo<T>(this IEnumerable<T> value1, IEnumerable<T> value2, bool ignoreOrder, IEnumerable<T> defaultValue)
            where T : IComparable
        {
            if (value1.IsNotEqualTo(value2, ignoreOrder))
            {
                return defaultValue;
            }
            else
            {
                return value1;
            }
        }

        /// <summary>
        /// Returns original value if the specified value is not null or empty; otherwise returns the original value.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>
        /// The original value if the specified value is not null or empty; otherwise returns the original value.
        /// </returns>
        public static T WhenIsNotNullOrEmpty<T>(this T value, T defaultValue) where T : IEnumerable
        {
            if (value.IsNotNullOrEmpty())
            {
                return defaultValue;
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// Returns original value if the specified value doesn't belong to the specified set; otherwise returns the original value.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="set">The set.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>
        /// The original value if the specified value doesn't belong to the specified set; otherwise returns the original value.
        /// </returns>
        public static T WhenIsNotOneOf<T>(this T value, IEnumerable<T> set, T defaultValue)
            where T : IComparable
        {
            if (value.IsNotOneOf(set))
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
