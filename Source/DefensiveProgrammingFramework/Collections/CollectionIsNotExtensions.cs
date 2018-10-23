using System;
using System.Collections;
using System.Collections.Generic;

namespace DefensiveProgrammingFramework
{
    /// <summary>
    /// The collection is not extension methods.
    /// </summary>
    public static class CollectionIsNotExtensions
    {
        #region Public Methods

        /// <summary>
        /// Determines whether the specified collection doesn't contain any items coresponding to the selector function.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="func">The function.</param>
        /// <returns>
        ///   <c>true</c> if the specified collection doesn't contain any items coresponding to the selector function; otherwise, <c>false</c>.
        /// </returns>
        public static bool ContainsNot<T>(this IEnumerable<T> value, Func<T, bool> func)
        {
            return !value.Contains(func);
        }

        /// <summary>
        /// Determines whether the specified collection doesn't contain duplicates.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns>
        ///   <c>true</c> if the specified collection doesn't contain duplicates; otherwise, <c>false</c>.
        /// </returns>
        public static bool ContainsNotDuplicates<T>(this IEnumerable<T> value) where T : IComparable
        {
            return !value.ContainsDuplicates();
        }

        /// <summary>
        /// Determines whether the specified collection doesn't contain a null value.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns>
        ///   <c>true</c> if the specified collection doesn't contain a null value; otherwise, <c>false</c>.
        /// </returns>
        public static bool ContainsNotNull<T>(this IEnumerable<T> value) where T : class
        {
            return !value.ContainsNull();
        }

        /// <summary>
        /// Determines whether the specified collection doesn't contain only null values.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns>
        ///   <c>true</c> if the specified collection doesn't contain only null values; otherwise, <c>false</c>.
        /// </returns>
        public static bool ContainsNotOnlyNull<T>(this IEnumerable<T> value) where T : class
        {
            return !value.ContainsOnlyNull();
        }

        /// <summary>
        /// Determines whether the specified collection is not empty.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns>
        ///   <c>true</c> if the specified collection is not empty; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNotEmpty<T>(this IEnumerable<T> value)
        {
            return !value.IsEmpty();
        }

        /// <summary>
        /// Determines whether the specified collection is not equal to compared collection.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <param name="ignoreOrder">If set to <c>true</c> ignore order of the items.</param>
        /// <returns>
        ///   <c>true</c> if the specified collection is not equal to compared collection; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNotEqualTo<T>(this IEnumerable<T> value1, IEnumerable<T> value2, bool ignoreOrder = false) where T : IComparable
        {
            return !value1.IsEqualTo(value2, ignoreOrder);
        }

        /// <summary>
        /// Determines whether the specified collection is not null or empty.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns>
        ///   <c>true</c> if the specified collection is not null or empty; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNotNullOrEmpty<T>(this T value) where T : IEnumerable
        {
            return !value.IsNullOrEmpty();
        }

        /// <summary>
        /// Determines whether the specified value doesn't belong to the specified set.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="set">The set.</param>
        /// <returns>
        ///   <c>true</c> if the specified value doesn't belong to the specified set; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNotOneOf<T>(this T value, IEnumerable<T> set) where T : IComparable
        {
            return !value.IsOneOf(set);
        }

        #endregion Public Methods
    }
}
