using System.Diagnostics;
using System.Text.RegularExpressions;

namespace DefensiveProgrammingFramework;

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
    /// <param name="errorHandler">The error handler.</param>
    /// <returns>
    /// The original value if the specified function returns true; otherwise throws a new ArgumentException.
    /// </returns>
    public static T MustBe<T>(this T value, Func<T, bool> func, Action errorHandler = null)
    {
        if (!value.Is(func))
        {
            if (errorHandler.IsNull())
            {
                throw new ArgumentException("Expression must be true.");
            }
            else
            {
                errorHandler();
            }
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
    /// <param name="errorHandler">The error handler.</param>
    /// <returns>
    /// The  original value if it is between the specified limits; otherwise throws a new ArgumentException.
    /// </returns>
    public static T MustBeBetween<T>(this T value, T minValue, T maxValue, bool inclusive = true, Action errorHandler = null) where T : IComparable
    {
        if (!value.IsBetween(minValue, maxValue, inclusive))
        {
            if (errorHandler.IsNull())
            {
                throw new ArgumentException($"Value must be between {minValue} and {maxValue}.");
            }
            else
            {
                errorHandler();
            }
        }

        return value;
    }

    /// <summary>
    /// Returns original value if it is equal to the default value of the specified type; otherwise throws a new ArgumentException.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <param name="value">The value.</param>
    /// <param name="errorHandler">The error handler.</param>
    /// <returns>
    /// The original value if it is equal to the default value of the specified type; otherwise throws a new ArgumentException.
    /// </returns>
    public static T MustBeDefault<T>(this T value, Action errorHandler = null) where T : struct
    {
        if (!value.IsDefault())
        {
            if (errorHandler.IsNull())
            {
                throw new ArgumentException($"Value must be equal to {default(T)}.");
            }
            else
            {
                errorHandler();
            }
        }

        return value;
    }

    /// <summary>
    /// Returns original value if it is equal to the compared value; otherwise throws a new ArgumentException.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <param name="value1">The value1.</param>
    /// <param name="value2">The value2.</param>
    /// <param name="errorHandler">The error handler.</param>
    /// <returns>
    /// The original value if it is equal to the compared value; otherwise throws a new ArgumentException.
    /// </returns>
    public static T MustBeEqualTo<T>(this T value1, T value2, Action errorHandler = null) where T : IComparable
    {
        if (!value1.IsEqualTo(value2))
        {
            if (errorHandler.IsNull())
            {
                throw new ArgumentException($"Value must be equal to {value2}.");
            }
            else
            {
                errorHandler();
            }
        }

        return value1;
    }

    /// <summary>
    /// Returns original value if it is greater than the specified limit; otherwise throws a new ArgumentException.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <param name="value">The value.</param>
    /// <param name="minValue">The minimum value.</param>
    /// <param name="errorHandler">The error handler.</param>
    /// <returns>
    /// The original value if it is greater than the specified limit; otherwise throws a new ArgumentException.
    /// </returns>
    public static T MustBeGreaterThan<T>(this T value, T minValue, Action errorHandler = null) where T : IComparable
    {
        if (!value.IsGreaterThan(minValue))
        {
            if (errorHandler.IsNull())
            {
                throw new ArgumentException($"Value must be greater than {minValue}.");
            }
            else
            {
                errorHandler();
            }
        }

        return value;
    }

    /// <summary>
    /// Returns original value if it is greater than or equal to the specified limit; otherwise throws a new ArgumentException.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <param name="value">The value.</param>
    /// <param name="minValue">The minimum value.</param>
    /// <param name="errorHandler">The error handler.</param>
    /// <returns>
    /// The original value if it is greater than or equal to the specified limit; otherwise throws a new ArgumentException.
    /// </returns>
    public static T MustBeGreaterThanOrEqualTo<T>(this T value, T minValue, Action errorHandler = null) where T : IComparable
    {
        if (!value.IsGreaterThanOrEqualTo(minValue))
        {
            if (errorHandler.IsNull())
            {
                throw new ArgumentException($"Value must be greater than or equal to {minValue}.");
            }
            else
            {
                errorHandler();
            }
        }

        return value;
    }

    /// <summary>
    /// Returns original value if it is less than the specified limit; otherwise throws a new ArgumentException.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <param name="value">The value.</param>
    /// <param name="maxValue">The maximum value.</param>
    /// <param name="errorHandler">The error handler.</param>
    /// <returns>
    /// The original value if it is less than the specified limit; otherwise throws a new ArgumentException.
    /// </returns>
    public static T MustBeLessThan<T>(this T value, T maxValue, Action errorHandler = null) where T : IComparable
    {
        if (!value.IsLessThan(maxValue))
        {
            if (errorHandler.IsNull())
            {
                throw new ArgumentException($"Value must be less than {maxValue}.");
            }
            else
            {
                errorHandler();
            }
        }

        return value;
    }

    /// <summary>
    /// Returns original value if it is less than or equal to the specified limit; otherwise throws a new ArgumentException.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <param name="value">The value.</param>
    /// <param name="maxValue">The maximum value.</param>
    /// <param name="errorHandler">The error handler.</param>
    /// <returns>
    /// The original value if it is less than or equal to the specified limit; otherwise throws a new ArgumentException.
    /// </returns>
    public static T MustBeLessThanOrEqualTo<T>(this T value, T maxValue, Action errorHandler = null) where T : IComparable
    {
        if (!value.IsLessThanOrEqualTo(maxValue))
        {
            if (errorHandler.IsNull())
            {
                throw new ArgumentException($"Value must be less than or equal to {maxValue}.");
            }
            else
            {
                errorHandler();
            }
        }

        return value;
    }

    /// <summary>
    /// Returns original value if it equals null; otherwise throws a new ArgumentException.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <param name="value">The value.</param>
    /// <param name="errorHandler">The error handler.</param>
    /// <returns>
    /// The  original value if it equals null; otherwise throws a new ArgumentException.
    /// </returns>
    public static T MustBeNull<T>(this T value, Action errorHandler = null) where T : class
    {
        if (!value.IsNull())
        {
            if (errorHandler.IsNull())
            {
                throw new ArgumentException("Value must be null.");
            }
            else
            {
                errorHandler();
            }
        }

        return value;
    }

    /// <summary>
    /// Returns original value if it belongs to the specified set; otherwise throws a new ArgumentException.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <param name="value">The value.</param>
    /// <param name="set">The set.</param>
    /// <returns>
    /// The original value if it belongs to the specified set; otherwise throws a new ArgumentException.
    /// </returns>
    public static T MustBeOneOf<T>(this T value, params T[] set)
        where T : IComparable
    {
        return value.MustBeOneOf(set, null);
    }

    /// <summary>
    /// Returns original value if it is the subtype of the specified type; otherwise throws a new ArgumentException.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <param name="value">The value.</param>
    /// <param name="type">The type.</param>
    /// <param name="errorHandler">The error handler.</param>
    /// <returns>
    /// The original value if it is the subtype of the specified type; otherwise throws a new ArgumentException.
    /// </returns>
    public static T MustBeSubTypeOf<T>(this T value, Type type, Action errorHandler = null)
    {
        if (value.IsNotSubTypeOf(type))
        {
            if (errorHandler.IsNull())
            {
                throw new ArgumentException($"Value must be subtype of {type.Name}.");
            }
            else
            {
                errorHandler();
            }
        }

        return value;
    }

    /// <summary>
    /// Returns original value if it is equal to the specified type; otherwise throws a new ArgumentException.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <param name="value">The value.</param>
    /// <param name="type">The type.</param>
    /// <param name="errorHandler">The error handler.</param>
    /// <returns>
    /// The original value if it is equal to the specified type; otherwise throws a new ArgumentException.
    /// </returns>
    public static T MustBeTypeOf<T>(this T value, Type type, Action errorHandler = null)
    {
        if (!value.IsTypeOf(type))
        {
            if (errorHandler.IsNull())
            {
                throw new ArgumentException($"Value must be of type {type.Name}.");
            }
            else
            {
                errorHandler();
            }
        }

        return value;
    }

    /// <summary>
    /// Returns original value if it matches the specified regular expression; otherwise throws a new ArgumentException.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="regex">The regular expression.</param>
    /// <param name="errorHandler">The error handler.</param>
    /// <returns>
    /// The original value if it matches the specified regular expression; otherwise throws a new ArgumentException.
    /// </returns>
    public static string MustMatch(this string value, Regex regex, Action errorHandler = null)
    {
        if (!value.DoesMatch(regex))
        {
            if (errorHandler.IsNull())
            {
                throw new ArgumentException($"Value must match {regex}.");
            }
            else
            {
                errorHandler();
            }
        }

        return value;
    }

    #endregion Public Methods
}
