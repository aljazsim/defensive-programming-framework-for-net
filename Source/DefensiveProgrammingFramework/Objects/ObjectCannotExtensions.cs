using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace DefensiveProgrammingFramework
{
    /// <summary>
    /// The  object cannot extension methods.
    /// </summary>
    [DebuggerNonUserCode]
    [DebuggerStepThrough]
    public static class ObjectCannotExtensions
    {
        #region Public Methods

        /// <summary>
        /// Returns original value if the specified function returns false; otherwise throws a new ArgumentException.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="func">The function.</param>
        /// <returns>The original value if the specified function returns false; otherwise throws a new ArgumentException.</returns>
        public static T CannotBe<T>(this T value, Func<T, bool> func)
        {
            if (value.Is(func))
            {
                throw new ArgumentException("Expression cannot be true.");
            }

            return value;
        }

        /// <summary>
        /// Returns original value if it is not between the specified limits; otherwise throws a new ArgumentException.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="inclusive">If set to <c>true</c> include limits in the range.</param>
        /// <returns>The  original value if it is not between the specified limits; otherwise throws a new ArgumentException.</returns>
        public static T CannotBeBetween<T>(this T value, T minValue, T maxValue, bool inclusive = true) where T : IComparable
        {
            if (value.IsBetween(minValue, maxValue, inclusive))
            {
                throw new ArgumentException($"Value cannot be between {minValue} and {maxValue}.");
            }

            return value;
        }

        /// <summary>
        /// Returns original value if it is not equal to the default value of the specified type; otherwise throws a new ArgumentException.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns>The original value if it is not equal to the default value of the specified type; otherwise throws a new ArgumentException.</returns>
        public static T CannotBeDefault<T>(this T value) where T : struct
        {
            if (value.IsDefault())
            {
                throw new ArgumentException($"Value cannot be equal to {default(T)}.");
            }

            return value;
        }

        /// <summary>
        /// Returns original value if it is not equal to the compared value; otherwise throws a new ArgumentException.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <returns>The original value if it is not equal to the compared value; otherwise throws a new ArgumentException.</returns>
        public static T CannotBeEqualTo<T>(this T value1, T value2) where T : IComparable
        {
            if (value1.IsEqualTo(value2))
            {
                throw new ArgumentException($"Value cannot be of equal to {value2}.");
            }

            return value1;
        }

        /// <summary>
        /// Returns original value if it is not greater than the specified limit; otherwise throws a new ArgumentException.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <returns>The original value if it is not greater than the specified limit; otherwise throws a new ArgumentException.</returns>
        public static T CannotBeGreaterThan<T>(this T value, T minValue) where T : IComparable
        {
            if (value.IsGreaterThan(minValue))
            {
                throw new ArgumentException($"Value cannot be greater than {minValue}.");
            }

            return value;
        }

        /// <summary>
        /// Returns original value if it is not greater than or equal to the specified limit; otherwise throws a new ArgumentException.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <returns>The original value if it is not greater than or equal to the specified limit; otherwise throws a new ArgumentException.</returns>
        public static T CannotBeGreaterThanOrEqualTo<T>(this T value, T minValue) where T : IComparable
        {
            if (value.IsGreaterThanOrEqualTo(minValue))
            {
                throw new ArgumentException($"Value cannot be greater than or equal to {minValue}.");
            }

            return value;
        }

        /// <summary>
        /// Returns original value if it is not less than the specified limit; otherwise throws a new ArgumentException.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <returns>The original value if it is less than the specified limit; otherwise throws a new ArgumentException.</returns>
        public static T CannotBeLessThan<T>(this T value, T maxValue) where T : IComparable
        {
            if (value.IsLessThan(maxValue))
            {
                throw new ArgumentException($"Value cannot be less than {maxValue}.");
            }

            return value;
        }

        /// <summary>
        /// Returns original value if it is not less than or equal to the specified limit; otherwise throws a new ArgumentException.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <returns>The original value if it is less than or equal to the specified limit; otherwise throws a new ArgumentException.</returns>
        public static T CannotBeLessThanOrEqualTo<T>(this T value, T maxValue) where T : IComparable
        {
            if (value.IsLessThanOrEqualTo(maxValue))
            {
                throw new ArgumentException($"Value cannot be less than or equal to {maxValue}.");
            }

            return value;
        }

        /// <summary>
        /// Returns original value if it does not equal null; otherwise throws a new ArgumentException.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns>The  original value if it does not equal null; otherwise throws a new ArgumentException.</returns>
        public static T CannotBeNull<T>(this T value) where T : class
        {
            if (value.IsNull())
            {
                throw new ArgumentNullException(null, "Value cannot be null.");
            }

            return value;
        }

        /// <summary>
        /// Returns original value if it does not belong to the specified set; otherwise throws a new ArgumentException.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="set">The set.</param>
        /// <returns>The original value if it does not belong to the specified set; otherwise throws a new ArgumentException.</returns>
        public static T CannotBeOneOf<T>(this T value, params T[] set) where T : IComparable
        {
            if (value.IsOneOf(set))
            {
                throw new ArgumentException($"Value cannot be one of {set.Format()}.");
            }

            return value;
        }

        /// <summary>
        /// Returns original value if it is not the subtype of the specified type; otherwise throws a new ArgumentException.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="type">The type.</param>
        /// <returns>The original value if it is not the subtype of the specified type; otherwise throws a new ArgumentException.</returns>
        public static T CannotBeSubTypeOf<T>(this T value, Type type)
        {
            if (value.IsSubTypeOf(type))
            {
                throw new ArgumentException($"Value cannot be subtype of {type.Name}.");
            }

            return value;
        }

        /// <summary>
        /// Returns original value if it is not equal to the specified type; otherwise throws a new ArgumentException.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="type">The type.</param>
        /// <returns>The original value if it is not equal to the specified type; otherwise throws a new ArgumentException.</returns>
        public static T CannotBeTypeOf<T>(this T value, Type type)
        {
            if (value.IsTypeOf(type))
            {
                throw new ArgumentException($"Value cannot be of type {type.Name}.");
            }

            return value;
        }

        /// <summary>
        /// Returns original value if it does not match the specified regular expression; otherwise throws a new ArgumentException.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="regex">The regex.</param>
        /// <returns>The original value if it does not match the specified regular expression; otherwise throws a new ArgumentException.</returns>
        public static string CannotMatch(this string value, Regex regex)
        {
            if (value.DoesMatch(regex))
            {
                throw new ArgumentException($"Value cannot match {regex}.");
            }

            return value;
        }

        #endregion Public Methods
    }
}
