using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace DefensiveProgrammingFramework
{
    /// <summary>
    /// The collection must extensions methods.
    /// </summary>
    [DebuggerNonUserCode]
    [DebuggerStepThrough]
    public static class CollectionMustExtensions
    {
        #region Public Methods

        /// <summary>
        /// Returns original value if the specified value is empty; otherwise throws a new ArgumentException.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns>The original value if the specified value is empty; otherwise throws a new ArgumentException.</returns>
        public static IEnumerable<T> MustBeEmpty<T>(this IEnumerable<T> value)
        {
            if (value.IsNotEmpty())
            {
                throw new ArgumentException("Value must be empty.");
            }

            return value;
        }

        /// <summary>
        /// Returns original value if the specified value is equal to the compared value; otherwise throws a new ArgumentException.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <param name="ignoreOrder">If set to <c>true</c> ignore item order.</param>
        /// <returns>
        /// The original value if the specified value is equal to the compared value; otherwise throws a new ArgumentException.
        /// </returns>
        public static IEnumerable<T> MustBeEqualTo<T>(this IEnumerable<T> value1, IEnumerable<T> value2, bool ignoreOrder = false) where T : IComparable
        {
            if (value1.IsNotEqualTo(value2, ignoreOrder))
            {
                throw new ArgumentException($"Value must be equal to { value2.Format() }.");
            }

            return value1;
        }

        /// <summary>
        /// Returns original value if the specified value is null or empty; otherwise throws a new ArgumentException.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The original value if the specified value is null or empty; otherwise throws a new ArgumentException.
        /// </returns>
        /// <exception cref="ArgumentException">Value must be null or empty.</exception>
        public static T MustBeNullOrEmpty<T>(this T value) where T : IEnumerable
        {
            if (value.IsNotNullOrEmpty())
            {
                throw new ArgumentException("Value must be null or empty.");
            }

            return value;
        }

        /// <summary>
        /// Returns original value if the specified value belongs to the specified set; otherwise throws a new ArgumentException.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="set">The set.</param>
        /// <returns>
        /// The original value if the specified value belongs to the specified set; otherwise throws a new ArgumentException.
        /// </returns>
        public static T MustBeOneOf<T>(this T value, IEnumerable<T> set) where T : IComparable
        {
            if (value.IsNotOneOf(set))
            {
                throw new ArgumentException($"Value must be one of {set.Format()}.");
            }

            return value;
        }

        /// <summary>
        /// Returns original value if the specified value contains any items coresponding to the selector function; otherwise throws a new ArgumentException.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="func">The selector function.</param>
        /// <returns>
        /// The original value if the specified value contains any items coresponding to the selector function; otherwise throws a new ArgumentException.
        /// </returns>
        public static IEnumerable<T> MustContain<T>(this IEnumerable<T> value, Func<T, bool> func)
        {
            if (value.ContainsNot(func))
            {
                throw new ArgumentException("Value must contain specified expression.");
            }

            return value;
        }

        /// <summary>
        /// Returns original value if the specified value contains duplicates; otherwise throws a new ArgumentException.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The original value if the specified value contains duplicates; otherwise throws a new ArgumentException.
        /// </returns>
        public static IEnumerable<T> MustContainDuplicates<T>(this IEnumerable<T> value) where T : IComparable
        {
            if (value.ContainsNotDuplicates())
            {
                throw new ArgumentException("Value must contain duplicates.");
            }

            return value;
        }

        /// <summary>
        /// Returns original value if the specified value contains null values; otherwise throws a new ArgumentException.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The original value if the specified value contains null values; otherwise throws a new ArgumentException.
        /// </returns>
        public static IEnumerable<T> MustContainNull<T>(this IEnumerable<T> value) where T : class
        {
            if (value.ContainsNotNull())
            {
                throw new ArgumentException("Value must contain null.");
            }

            return value;
        }

        /// <summary>
        /// Returns original value if the specified value contains only null values; otherwise throws a new ArgumentException.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The original value if the specified value contains only null values; otherwise throws a new ArgumentException.
        /// </returns>
        public static IEnumerable<T> MustContainOnlyNull<T>(this IEnumerable<T> value) where T : class
        {
            if (value.ContainsNotOnlyNull())
            {
                throw new ArgumentException("Value must contain only null.");
            }

            return value;
        }

        #endregion Public Methods
    }
}
