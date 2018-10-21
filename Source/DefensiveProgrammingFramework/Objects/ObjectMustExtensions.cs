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
    public static class ObjectMustExtensions
    {
        #region Public Methods

        /// <summary>
        /// Returns original value if the specified function returns true; otherwise throws a new ArgumentException.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="func">The function.</param>
        /// <returns>The original value if the specified function returns true; otherwise throws a new ArgumentException.</returns>
        public static T MustBe<T>(this T value, Func<T, bool> func)
        {
            if (!value.Is(func))
            {
                throw new ArgumentException("Expression must be true.");
            }

            return value;
        }

        /// <summary>
        /// Returns original value if it is between the specified limits; otherwise throws a new ArgumentException.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="inclusive">If set to <c>true</c> include limits in the range.</param>
        /// <returns>The  original value if it is between the specified limits; otherwise throws a new ArgumentException.</returns>
        public static T MustBeBetween<T>(this T value, T minValue, T maxValue, bool inclusive = true) where T : IComparable
        {
            if (!value.IsBetween(minValue, maxValue, inclusive))
            {
                throw new ArgumentException($"Value must be between {minValue} and {maxValue}.");
            }

            return value;
        }

        /// <summary>
        /// Returns original value if it is equal to the default value of the specified type; otherwise throws a new ArgumentException.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns>The original value if it is equal to the default value of the specified type; otherwise throws a new ArgumentException.</returns>
        public static T MustBeDefault<T>(this T value) where T : struct
        {
            if (!value.IsDefault())
            {
                throw new ArgumentException($"Value must be equal to {default(T)}.");
            }

            return value;
        }

        /// <summary>
        /// Returns original value if it is equal to the compared value; otherwise throws a new ArgumentException.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <returns>The original value if it is equal to the compared value; otherwise throws a new ArgumentException.</returns>
        public static T MustBeEqualTo<T>(this T value1, T value2) where T : IComparable
        {
            if (!value1.IsEqualTo(value2))
            {
                throw new ArgumentException($"Value must be equal to {value2}.");
            }

            return value1;
        }

        /// <summary>
        /// Returns original value if it is greater than the specified limit; otherwise throws a new ArgumentException.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <returns>The original value if it is greater than the specified limit; otherwise throws a new ArgumentException.</returns>
        public static T MustBeGreaterThan<T>(this T value, T minValue) where T : IComparable
        {
            if (!value.IsGreaterThan(minValue))
            {
                throw new ArgumentException($"Value must be greater than {minValue}.");
            }

            return value;
        }

        /// <summary>
        /// Returns original value if it is greater than or equal to the specified limit; otherwise throws a new ArgumentException.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <returns>The original value if it is greater than or equal to the specified limit; otherwise throws a new ArgumentException.</returns>
        public static T MustBeGreaterThanOrEqualTo<T>(this T value, T minValue) where T : IComparable
        {
            if (!value.IsGreaterThanOrEqualTo(minValue))
            {
                throw new ArgumentException($"Value must be greater than or equal to {minValue}.");
            }

            return value;
        }

        /// <summary>
        /// Returns original value if it is less than the specified limit; otherwise throws a new ArgumentException.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <returns>The original value if it is less than the specified limit; otherwise throws a new ArgumentException.</returns>
        public static T MustBeLessThan<T>(this T value, T maxValue) where T : IComparable
        {
            if (!value.IsLessThan(maxValue))
            {
                throw new ArgumentException($"Value must be less than {maxValue}.");
            }

            return value;
        }

        /// <summary>
        /// Returns original value if it is less than or equal to the specified limit; otherwise throws a new ArgumentException.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <returns>The original value if it is less than or equal to the specified limit; otherwise throws a new ArgumentException.</returns>
        public static T MustBeLessThanOrEqualTo<T>(this T value, T maxValue) where T : IComparable
        {
            if (!value.IsLessThanOrEqualTo(maxValue))
            {
                throw new ArgumentException($"Value must be less than or equal to {maxValue}.");
            }

            return value;
        }

        /// <summary>
        /// Returns original value if it equals null; otherwise throws a new ArgumentException.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns>The  original value if it equals null; otherwise throws a new ArgumentException.</returns>
        public static T MustBeNull<T>(this T value) where T : class
        {
            if (!value.IsNull())
            {
                throw new ArgumentException("Value must be null.");
            }

            return value;
        }

        /// <summary>
        /// Returns original value if it belongs to the specified set; otherwise throws a new ArgumentException.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="set">The set.</param>
        /// <returns>The original value if it belongs to the specified set; otherwise throws a new ArgumentException.</returns>
        public static T MustBeOneOf<T>(this T value, params T[] set) where T : IComparable
        {
            if (!value.IsOneOf(set))
            {
                throw new ArgumentException($"Value must be one of {set.Format()}.");
            }

            return value;
        }

        /// <summary>
        /// Returns original value if it is the subtype of the specified type; otherwise throws a new ArgumentException.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="type">The type.</param>
        /// <returns>The original value if it is the subtype of the specified type; otherwise throws a new ArgumentException.</returns>
        public static T MustBeSubTypeOf<T>(this T value, Type type)
        {
            if (value.IsNotSubTypeOf(type))
            {
                throw new ArgumentException($"Value must be subtype of {type.Name}.");
            }

            return value;
        }

        /// <summary>
        /// Returns original value if it is equal to the specified type; otherwise throws a new ArgumentException.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="type">The type.</param>
        /// <returns>The original value if it is equal to the specified type; otherwise throws a new ArgumentException.</returns>
        public static T MustBeTypeOf<T>(this T value, Type type)
        {
            if (!value.IsTypeOf(type))
            {
                throw new ArgumentException($"Value must be of type {type.Name}.");
            }

            return value;
        }

        /// <summary>
        /// Returns original value if it matches the specified regular expression; otherwise throws a new ArgumentException.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="regex">The regular expression.</param>
        /// <returns>The original value if it matches the specified regular expression; otherwise throws a new ArgumentException.</returns>
        public static string MustMatch(this string value, Regex regex)
        {
            if (!value.DoesMatch(regex))
            {
                throw new ArgumentException($"Value must match {regex}.");
            }

            return value;
        }

        #endregion Public Methods
    }
}
