using System.Diagnostics;
using System.Text.RegularExpressions;

namespace DefensiveProgrammingFramework;

/// <summary>
/// The object when not extension methods.
/// </summary>
[DebuggerNonUserCode]
[DebuggerStepThrough]
public static class ObjectWhenNotExtensions
{
    #region Public Methods

    /// <summary>
    /// Returns default value when the original value does not match the specified regular expression; otherwise returns the original value.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="regex">The regular expression.</param>
    /// <param name="defaultValue">The default value.</param>
    /// <returns>The default value when the original value does not match the specified regular expression; otherwise returns the original value.</returns>
    public static string WhenDoesNotMatch(this string value, Regex regex, string defaultValue)
    {
        if (value.DoesNotMatch(regex))
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
    /// <returns>The default value when the specified function returns true; otherwise returns the original value</returns>
    public static T WhenIsNot<T>(this T value, Func<T, bool> func, T defaultValue)
    {
        if (value.IsNot(func))
        {
            return defaultValue;
        }
        else
        {
            return value;
        }
    }

    /// <summary>
    /// Returns default value when the original value is not between the specified limits; otherwise returns the original value.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <param name="value">The value.</param>
    /// <param name="minValue">The minimum value.</param>
    /// <param name="maxValue">The maximum value.</param>
    /// <param name="inclusive">If set to <c>true</c> include limits in the range.</param>
    /// <param name="defaultValue">The default value.</param>
    /// <returns>The default value when the original value is not between the specified limits; otherwise returns the original value.</returns>
    public static T WhenIsNotBetween<T>(this T value, T minValue, T maxValue, bool inclusive, T defaultValue) where T : IComparable
    {
        if (value.IsNotBetween(minValue, maxValue, inclusive))
        {
            return defaultValue;
        }
        else
        {
            return value;
        }
    }

    /// <summary>
    /// Returns default value when the original value is not default value for the specified type; otherwise returns the original value.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <param name="value">The value.</param>
    /// <param name="defaultValue">The default value.</param>
    /// <returns>The default value when the original value is not default value for the specified type; otherwise returns the original value.</returns>
    public static T WhenIsNotDefault<T>(this T value, T defaultValue) where T : struct
    {
        if (value.IsNotDefault())
        {
            return defaultValue;
        }
        else
        {
            return value;
        }
    }

    /// <summary>
    /// Returns default value when the original value is not equal to the compared value; otherwise returns the original value.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <param name="value1">The value1.</param>
    /// <param name="value2">The value2.</param>
    /// <param name="defaultValue">The default value.</param>
    /// <returns>The default value when the original value is not equal to the compared value; otherwise returns the original value.</returns>
    public static T WhenIsNotEqualTo<T>(this T value1, T value2, T defaultValue) where T : IComparable
    {
        if (value1.IsNotEqualTo(value2))
        {
            return defaultValue;
        }
        else
        {
            return value1;
        }
    }

    /// <summary>
    /// Returns default value when the original value is not greater than the specified limit; otherwise returns the original value.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <param name="value">The value.</param>
    /// <param name="minValue">The minimum value.</param>
    /// <param name="defaultValue">The default value.</param>
    /// <returns>The default value when the original value is not greater than the specified limit; otherwise returns the original value.</returns>
    public static T WhenIsNotGreaterThan<T>(this T value, T minValue, T defaultValue) where T : IComparable
    {
        if (value.IsNotGreaterThan(minValue))
        {
            return defaultValue;
        }
        else
        {
            return value;
        }
    }

    /// <summary>
    /// Returns default value when the original value is not greater than or equal to the specified limit; otherwise returns the original value.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <param name="value">The value.</param>
    /// <param name="minValue">The minimum value.</param>
    /// <param name="defaultValue">The default value.</param>
    /// <returns>The default value when the original value is not greater than or equal to the specified limit; otherwise returns the original value.</returns>
    public static T WhenIsNotGreaterThanOrEqualTo<T>(this T value, T minValue, T defaultValue) where T : IComparable
    {
        if (value.IsNotGreaterThanOrEqualTo(minValue))
        {
            return defaultValue;
        }
        else
        {
            return value;
        }
    }

    /// <summary>
    /// Returns default value when the original value is not less than the specified limit; otherwise returns the original value.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <param name="value">The value.</param>
    /// <param name="maxValue">The maximum value.</param>
    /// <param name="defaultValue">The default value.</param>
    /// <returns>the default value when the original value is not less than the specified limit; otherwise returns the original value.</returns>
    public static T WhenIsNotLessThan<T>(this T value, T maxValue, T defaultValue) where T : IComparable
    {
        if (value.IsNotLessThan(maxValue))
        {
            return defaultValue;
        }
        else
        {
            return value;
        }
    }

    /// <summary>
    /// Returns default value when the original value is not less than or equal to the specified limit; otherwise returns the original value.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <param name="value">The value.</param>
    /// <param name="maxValue">The maximum value.</param>
    /// <param name="defaultValue">The default value.</param>
    /// <returns>The default value when the original value is not less than or equal to the specified limit; otherwise returns the original value.</returns>
    public static T WhenIsNotLessThanOrEqualTo<T>(this T value, T maxValue, T defaultValue) where T : IComparable
    {
        if (value.IsNotLessThanOrEqualTo(maxValue))
        {
            return defaultValue;
        }
        else
        {
            return value;
        }
    }

    /// <summary>
    /// Returns default value when the original value is not null; otherwise returns the original value.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <param name="value">The value.</param>
    /// <param name="defaultValue">The default value.</param>
    /// <returns>The default value when the original value is not null; otherwise returns the original value.</returns>
    public static T WhenIsNotNull<T>(this T value, T defaultValue) where T : class
    {
        if (value.IsNotNull())
        {
            return defaultValue;
        }
        else
        {
            return value;
        }
    }

    /// <summary>
    /// Returns default value when the original value does not belong to the specified set; otherwise returns the original value.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <param name="value">The value.</param>
    /// <param name="set">The set.</param>
    /// <param name="defaultValue">The default value.</param>
    /// <returns>
    /// The default value when the original value does not belong to the specified set; otherwise returns the original value.
    /// </returns>
    public static T WhenIsNotOneOf<T>(this T value, T[] set, T defaultValue) where T : IComparable
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

    /// <summary>
    /// Returns default value when the original value is not subtype of the specified type; otherwise returns the original value.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <param name="value">The value.</param>
    /// <param name="type">The type.</param>
    /// <param name="defaultValue">The default value.</param>
    /// <returns>The default value when the original value is not subtype of the specified type; otherwise returns the original value.</returns>
    public static T WhenIsNotSubTypeOf<T>(this T value, Type type, T defaultValue)
    {
        if (value.IsNotSubTypeOf(type))
        {
            return defaultValue;
        }
        else
        {
            return value;
        }
    }

    /// <summary>
    /// Returns default value when the original value is not of the specified type; otherwise returns the original value.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <param name="value">The value.</param>
    /// <param name="type">The type.</param>
    /// <param name="defaultValue">The default value.</param>
    /// <returns>The default value when the original value is not of the specified type; otherwise returns the original value.</returns>
    public static T WhenIsNotTypeOf<T>(this T value, Type type, T defaultValue)
    {
        if (value.IsNotTypeOf(type))
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
