using System.Diagnostics;
using System.Text.RegularExpressions;

namespace DefensiveProgrammingFramework;

/// <summary>
/// The object when extension methods.
/// </summary>
[DebuggerNonUserCode]
[DebuggerStepThrough]
public static class ObjectWhenExtensions
{
    #region Public Methods

    /// <summary>
    /// Returns default value when the original value does match the specified regular expression; otherwise returns the original value.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="regex">The regular expression.</param>
    /// <param name="defaultValue">The default value.</param>
    /// <returns>The default value when the original value does match the specified regular expression; otherwise returns the original value.</returns>
    public static string WhenDoesMatch(this string value, Regex regex, string defaultValue)
    {
        if (value.DoesMatch(regex))
        {
            return defaultValue;
        }
        else
        {
            return value;
        }
    }

    /// <summary>
    /// Returns default value when the specified function returns true; otherwise returns the original value.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <param name="value">The value.</param>
    /// <param name="func">The function.</param>
    /// <param name="defaultValue">The default value.</param>
    /// <returns>The default value when the specified function returns true; otherwise returns the original value.</returns>
    public static T WhenIs<T>(this T value, Func<T, bool> func, T defaultValue)
    {
        if (value.Is(func))
        {
            return defaultValue;
        }
        else
        {
            return value;
        }
    }

    /// <summary>
    /// Returns default value when the original value is between the specified limits; otherwise returns the original value.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <param name="value">The value.</param>
    /// <param name="minValue">The minimum value.</param>
    /// <param name="maxValue">The maximum value.</param>
    /// <param name="inclusive">If set to <c>true</c> include limits in the range.</param>
    /// <param name="defaultValue">The default value.</param>
    /// <returns>The default value when the original value is between the specified limits; otherwise returns the original value.</returns>
    public static T WhenIsBetween<T>(this T value, T minValue, T maxValue, bool inclusive, T defaultValue) where T : IComparable
    {
        if (value.IsBetween(minValue, maxValue, inclusive))
        {
            return defaultValue;
        }
        else
        {
            return value;
        }
    }

    /// <summary>
    /// Returns default value when the original value is default value for the specified type; otherwise returns the original value.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <param name="value">The value.</param>
    /// <param name="defaultValue">The default value.</param>
    /// <returns>The default value when the original value is default value for the specified type; otherwise returns the original value.</returns>
    public static T WhenIsDefault<T>(this T value, T defaultValue) where T : struct
    {
        if (value.IsDefault())
        {
            return defaultValue;
        }
        else
        {
            return value;
        }
    }

    /// <summary>
    /// Returns default value when the original value is equal to the compared value; otherwise returns the original value.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <param name="value1">The value1.</param>
    /// <param name="value2">The value2.</param>
    /// <param name="defaultValue">The default value.</param>
    /// <returns>The default value when the original value is equal to the compared value; otherwise returns the original value.</returns>
    public static T WhenIsEqualTo<T>(this T value1, T value2, T defaultValue) where T : IComparable
    {
        if (value1.IsEqualTo(value2))
        {
            return defaultValue;
        }
        else
        {
            return value1;
        }
    }

    /// <summary>
    /// Returns default value when the original value is greater than the specified limit; otherwise returns the original value.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <param name="value">The value.</param>
    /// <param name="minValue">The minimum value.</param>
    /// <param name="defaultValue">The default value.</param>
    /// <returns>The default value when the original value is greater than the specified limit; otherwise returns the original value.</returns>
    public static T WhenIsGreaterThan<T>(this T value, T minValue, T defaultValue) where T : IComparable
    {
        if (value.IsGreaterThan(minValue))
        {
            return defaultValue;
        }
        else
        {
            return value;
        }
    }

    /// <summary>
    /// Returns default value when the original value is greater than or equal to the specified limit; otherwise returns the original value.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <param name="value">The value.</param>
    /// <param name="minValue">The minimum value.</param>
    /// <param name="defaultValue">The default value.</param>
    /// <returns>The default value when the original value is greater than or equal to the specified limit; otherwise returns the original value.</returns>
    public static T WhenIsGreaterThanOrEqualTo<T>(this T value, T minValue, T defaultValue) where T : IComparable
    {
        if (value.IsGreaterThanOrEqualTo(minValue))
        {
            return defaultValue;
        }
        else
        {
            return value;
        }
    }

    /// <summary>
    /// Returns default value when the original value is less than the specified limit; otherwise returns the original value.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <param name="value">The value.</param>
    /// <param name="maxValue">The maximum value.</param>
    /// <param name="defaultValue">The default value.</param>
    /// <returns>the default value when the original value is less than the specified limit; otherwise returns the original value.</returns>
    public static T WhenIsLessThan<T>(this T value, T maxValue, T defaultValue) where T : IComparable
    {
        if (value.IsLessThan(maxValue))
        {
            return defaultValue;
        }
        else
        {
            return value;
        }
    }

    /// <summary>
    /// Returns default value when the original value is less than or equal to the specified limit; otherwise returns the original value.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <param name="value">The value.</param>
    /// <param name="maxValue">The maximum value.</param>
    /// <param name="defaultValue">The default value.</param>
    /// <returns>The default value when the original value is less than or equal to the specified limit; otherwise returns the original value.</returns>
    public static T WhenIsLessThanOrEqualTo<T>(this T value, T maxValue, T defaultValue) where T : IComparable
    {
        if (value.IsLessThanOrEqualTo(maxValue))
        {
            return defaultValue;
        }
        else
        {
            return value;
        }
    }

    /// <summary>
    /// Returns default value when the original value is null; otherwise returns the original value.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <param name="value">The value.</param>
    /// <param name="defaultValue">The default value.</param>
    /// <returns>The default value when the original value is null; otherwise returns the original value.</returns>
    public static T WhenIsNull<T>(this T value, T defaultValue) where T : class
    {
        if (value.IsNull())
        {
            return defaultValue;
        }
        else
        {
            return value;
        }
    }

    /// <summary>
    /// Returns default value when the original value does belong to the specified set; otherwise returns the original value.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <param name="value">The value.</param>
    /// <param name="set">The set.</param>
    /// <param name="defaultValue">The default value.</param>
    /// <returns>
    /// The default value when the original value does belong to the specified set; otherwise returns the original value.
    /// </returns>
    public static T WhenIsOneOf<T>(this T value, T[] set, T defaultValue) where T : IComparable
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

    /// <summary>
    /// Returns default value when the original value is subtype of the specified type; otherwise returns the original value.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <param name="value">The value.</param>
    /// <param name="type">The type.</param>
    /// <param name="defaultValue">The default value.</param>
    /// <returns>The default value when the original value is subtype of the specified type; otherwise returns the original value.</returns>
    public static T WhenIsSubTypeOf<T>(this T value, Type type, T defaultValue)
    {
        if (value.IsSubTypeOf(type))
        {
            return defaultValue;
        }
        else
        {
            return value;
        }
    }

    /// <summary>
    /// Returns default value when the original value is of the specified type; otherwise returns the original value.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <param name="value">The value.</param>
    /// <param name="type">The type.</param>
    /// <param name="defaultValue">The default value.</param>
    /// <returns>The default value when the original value is of the specified type; otherwise returns the original value.</returns>
    public static T WhenIsTypeOf<T>(this T value, Type type, T defaultValue)
    {
        if (value.IsTypeOf(type))
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
