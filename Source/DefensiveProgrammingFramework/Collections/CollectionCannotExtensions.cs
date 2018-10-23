using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace DefensiveProgrammingFramework
{
    /// <summary>
    /// The collection cannot extensions methods.
    /// </summary>
    [DebuggerNonUserCode]
    [DebuggerStepThrough]
    public static class CollectionCannotExtensions
    {
        #region Public Methods

        /// <summary>
        /// Returns original value if the specified value is not empty; otherwise throws a new ArgumentException.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns>The original value if the specified value is not empty; otherwise throws a new ArgumentException.</returns>
        public static IEnumerable<T> CannotBeEmpty<T>(this IEnumerable<T> value)
        {
            if (value.IsEmpty())
            {
                throw new ArgumentException("Value cannot be empty.");
            }

            return value;
        }

        /// <summary>
        /// Returns original value if the specified value is not equal to the compared value; otherwise throws a new ArgumentException.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <param name="ignoreOrder">If set to <c>true</c> ignore item order.</param>
        /// <returns>
        /// The original value if the specified value is not equal to the compared value; otherwise throws a new ArgumentException.
        /// </returns>
        public static IEnumerable<T> CannotBeEqualTo<T>(this IEnumerable<T> value1, IEnumerable<T> value2, bool ignoreOrder = false)
            where T : IComparable
        {
            if (value1.IsEqualTo(value2, ignoreOrder))
            {
                throw new ArgumentException($"Value cannot be equal to {value2.Format()}.");
            }

            return value1;
        }

        /// <summary>
        /// Returns original value if the specified value is not null or empty; otherwise throws a new ArgumentException.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The original value if the specified value is not null or empty; otherwise throws a new ArgumentException.
        /// </returns>
        /// <exception cref="ArgumentException">Value cannot be null or empty.</exception>
        public static T CannotBeNullOrEmpty<T>(this T value) where T : IEnumerable
        {
            if (value.IsNullOrEmpty())
            {
                throw new ArgumentException("Value cannot be null or empty.");
            }

            return value;
        }

        /// <summary>
        /// Returns original value if the specified value doesn't belong to the specified set; otherwise throws a new ArgumentException.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="set">The set.</param>
        /// <returns>
        /// The original value if the specified value doesn't belong to the specified set; otherwise throws a new ArgumentException.
        /// </returns>
        public static T CannotBeOneOf<T>(this T value, IEnumerable<T> set)
            where T : IComparable
        {
            if (value.IsOneOf(set))
            {
                throw new ArgumentException($"Value cannot be one of {set.Format()}.");
            }

            return value;
        }

        /// <summary>
        /// Returns original value if the specified value doesn't contain any items coresponding to the selector function; otherwise throws a new ArgumentException.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="func">The selector function.</param>
        /// <returns>
        /// The original value if the specified value doesn't contain any items coresponding to the selector function; otherwise throws a new ArgumentException.
        /// </returns>
        public static IEnumerable<T> CannotContain<T>(this IEnumerable<T> value, Func<T, bool> func)
        {
            if (value.Contains(func))
            {
                throw new ArgumentException("Value cannot contain specified expression.");
            }

            return value;
        }

        /// <summary>
        /// Returns original value if the specified value doesn't contain duplicates; otherwise throws a new ArgumentException.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The original value if the specified value doesn't contain duplicates; otherwise throws a new ArgumentException.
        /// </returns>
        public static IEnumerable<T> CannotContainDuplicates<T>(this IEnumerable<T> value)
            where T : IComparable
        {
            if (value.ContainsDuplicates())
            {
                throw new ArgumentException("Value cannot contain duplicates.");
            }

            return value;
        }

        /// <summary>
        /// Returns original value if the specified value doesn't contain null values; otherwise throws a new ArgumentException.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The original value if the specified value doesn't contain null values; otherwise throws a new ArgumentException.
        /// </returns>
        public static IEnumerable<T> CannotContainNull<T>(this IEnumerable<T> value)
            where T : class
        {
            if (value.ContainsNull())
            {
                throw new ArgumentException("Value cannot contain null.");
            }

            return value;
        }

        /// <summary>
        /// Returns original value if the specified value doesn't contain only null values; otherwise throws a new ArgumentException.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The original value if the specified value doesn't contain only null values; otherwise throws a new ArgumentException.
        /// </returns>
        public static IEnumerable<T> CannotContainOnlyNull<T>(this IEnumerable<T> value)
            where T : class
        {
            if (value.ContainsOnlyNull())
            {
                throw new ArgumentException("Value cannot contain only null.");
            }

            return value;
        }

        #endregion Public Methods
    }
}
