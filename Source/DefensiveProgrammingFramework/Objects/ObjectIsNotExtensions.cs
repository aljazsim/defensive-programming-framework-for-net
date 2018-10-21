using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace DefensiveProgrammingFramework
{
    /// <summary>
    /// The object is not extension methods.
    /// </summary>
    [DebuggerNonUserCode]
    [DebuggerStepThrough]
    public static class ObjectIsNotExtensions
    {
        #region Public Methods

        /// <summary>
        /// Determines whether the specified value does not match the specified regular expression.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="regex">The regular expression.</param>
        /// <returns>
        ///   <c>true</c> if specified value does not match the specified regular expression; otherwise, <c>false</c>.
        /// </returns>
        public static bool DoesNotMatch(this string value, Regex regex)
        {
            return !value.DoesMatch(regex);
        }

        /// <summary>
        /// Determines whether the specified function does not return true.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="func">The function.</param>
        /// <returns>
        ///   <c>true</c> if the specified function does not return true; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNot<T>(this T value, Func<T, bool> func)
        {
            return !value.Is(func);
        }

        /// <summary>
        /// Determines whether the specified value is not between the specified limits.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="inclusive">if set to <c>true</c> include the limits in the range.</param>
        /// <returns>
        ///   <c>true</c> if the specified value is not between the specified limits; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNotBetween<T>(this T value, T minValue, T maxValue, bool inclusive = true)
            where T : IComparable
        {
            return !value.IsBetween(minValue, maxValue, inclusive);
        }

        /// <summary>
        /// Determines whether the specified value is not the default value for the specified type.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns>
        ///   <c>true</c> if the specified value is not the default value for the specified type; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNotDefault<T>(this T value)
            where T : struct
        {
            return !value.IsDefault();
        }

        /// <summary>
        /// Determines whether the specified value is not equal to to the compared value.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <returns>
        ///   <c>true</c> if the specified value is not equal to to the compared value; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNotEqualTo<T>(this T value1, T value2)
            where T : IComparable
        {
            return !value1.IsEqualTo(value2);
        }

        /// <summary>
        /// Determines whether the specified value is not greater than the specified limit.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <returns>
        ///   <c>true</c> if the specified value is not greater than the specified limit; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNotGreaterThan<T>(this T value, T minValue)

            where T : IComparable
        {
            return !value.IsGreaterThan(minValue);
        }

        /// <summary>
        /// Determines whether the specified value is not greater than or equal to the specified limit.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <returns>
        ///   <c>true</c> if the specified value is not greater than or equal to the specified limit; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNotGreaterThanOrEqualTo<T>(this T value, T minValue)
            where T : IComparable
        {
            return !value.IsGreaterThanOrEqualTo(minValue);
        }

        /// <summary>
        /// Determines whether the specified value is not less than the specified limit.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <returns>
        ///   <c>true</c> if the specified value is not less than the specified limit; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNotLessThan<T>(this T value, T maxValue)
            where T : IComparable
        {
            return !value.IsLessThan(maxValue);
        }

        /// <summary>
        /// Determines whether the specified value is not less than or equal to the specified limit.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <returns>
        ///   <c>true</c> if the specified value is not less than or equal to the specified limit; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNotLessThanOrEqualTo<T>(this T value, T maxValue)
            where T : IComparable
        {
            return !value.IsLessThanOrEqualTo(maxValue);
        }

        /// <summary>
        /// Determines whether the specified value is not null.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns>
        ///   <c>true</c> if the specified value is not null; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNotNull<T>(this T value)
            where T : class
        {
            return !value.IsNull();
        }

        /// <summary>
        /// Determines whether the specified value is not one of the specified set.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="set">The set.</param>
        /// <returns>
        ///   <c>true</c> if the specified value is not one of the specified set; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNotOneOf<T>(this T value, params T[] set)
            where T : IComparable
        {
            return !value.IsOneOf(set);
        }

        /// <summary>
        /// Determines whether the specified value is not subtype of the specified type.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="type">The type.</param>
        /// <returns>
        ///   <c>true</c> if the specified value is not subtype of the specified type; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNotSubTypeOf<T>(this T value, Type type)
        {
            return !value.IsSubTypeOf(type);
        }

        /// <summary>
        /// Determines whether the specified value is not of the specified type.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="type">The type.</param>
        /// <returns>
        ///   <c>true</c> if the specified value is not of the specified type; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNotTypeOf<T>(this T value, Type type)
        {
            return !value.IsTypeOf(type);
        }

        #endregion Public Methods
    }
}
