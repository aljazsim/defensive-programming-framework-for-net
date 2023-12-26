using System.Diagnostics;
using System.Text.RegularExpressions;

namespace DefensiveProgrammingFramework;

/// <summary>
/// The object is extension methods.
/// </summary>
[DebuggerNonUserCode]
[DebuggerStepThrough]
public static class ObjectIsExtensions
{
    #region Public Methods

    /// <summary>
    /// Determines whether the specified value matches the specified regular expression.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="regex">The regular expression.</param>
    /// <returns>
    ///   <c>true</c> if specified value matches the specified regular expression; otherwise, <c>false</c>.
    /// </returns>
    public static bool DoesMatch(this string value, Regex regex)
    {
        regex.CannotBeNull();

        if (value == null)
        {
            return false;
        }
        else
        {
            return regex.IsMatch(value);
        }
    }

    /// <summary>
    /// Determines whether the specified function returns true.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <param name="value">The value.</param>
    /// <param name="func">The function.</param>
    /// <returns>
    ///   <c>true</c> if the specified function returns true; otherwise, <c>false</c>.
    /// </returns>
    public static bool Is<T>(this T value, Func<T, bool> func)
    {
        func.CannotBeNull();

        return func(value);
    }

    /// <summary>
    /// Determines whether the specified value is between the specified limits.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <param name="value">The value.</param>
    /// <param name="minValue">The minimum value.</param>
    /// <param name="maxValue">The maximum value.</param>
    /// <param name="inclusive">if set to <c>true</c> include the limits in the range.</param>
    /// <returns>
    ///   <c>true</c> if the specified value is between the specified limits; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsBetween<T>(this T value, T minValue, T maxValue, bool inclusive = true) where T : IComparable
    {
        if (!typeof(T).IsValueType)
        {
            ((object)value).CannotBeNull();
            ((object)minValue).CannotBeNull();
            ((object)maxValue).CannotBeNull();
        }

        if (!minValue.IsLessThanOrEqualTo(maxValue))
        {
            throw new ArgumentException($"Min value must be less than or equal to max value (min: {minValue}, max: {maxValue}).");
        }

        if (inclusive)
        {
            return value.IsGreaterThanOrEqualTo(minValue) &&
                   value.IsLessThanOrEqualTo(maxValue);
        }
        else
        {
            return value.IsGreaterThan(minValue) &&
                   value.IsLessThan(maxValue);
        }
    }

    /// <summary>
    /// Determines whether the specified value is the default value for the specified type.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <param name="value">The value.</param>
    /// <returns>
    ///   <c>true</c> if the specified value is the default value for the specified type; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsDefault<T>(this T value) where T : struct
    {
        return default(T).Equals(value);
    }

    /// <summary>
    /// Determines whether the specified value is equal to to the compared value.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <param name="value1">The value1.</param>
    /// <param name="value2">The value2.</param>
    /// <returns>
    ///   <c>true</c> if the specified value is equal to to the compared value; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsEqualTo<T>(this T value1, T value2) where T : IComparable
    {
        if (!typeof(T).IsValueType)
        {
            if (value1 == null &&
                value2 == null)
            {
                return true;
            }
            else if (value1 != null &&
                     value2 != null)
            {
                return value1.CompareTo(value2) == 0;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return value1.CompareTo(value2) == 0;
        }
    }

    /// <summary>
    /// Determines whether the specified value is greater than the specified limit.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <param name="value">The value.</param>
    /// <param name="minValue">The minimum value.</param>
    /// <returns>
    ///   <c>true</c> if the specified value is greater than the specified limit; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsGreaterThan<T>(this T value, T minValue) where T : IComparable
    {
        if (!typeof(T).IsValueType)
        {
            ((object)value).CannotBeNull();
            ((object)minValue).CannotBeNull();
        }

        return value.CompareTo(minValue) > 0;
    }

    /// <summary>
    /// Determines whether the specified value is greater than or equal to the specified limit.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <param name="value">The value.</param>
    /// <param name="minValue">The minimum value.</param>
    /// <returns>
    ///   <c>true</c> if the specified value is greater than or equal to the specified limit; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsGreaterThanOrEqualTo<T>(this T value, T minValue) where T : IComparable
    {
        if (!typeof(T).IsValueType)
        {
            ((object)value).CannotBeNull();
            ((object)minValue).CannotBeNull();
        }

        return value.CompareTo(minValue) >= 0;
    }

    /// <summary>
    /// Determines whether the specified value is less than the specified limit.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <param name="value">The value.</param>
    /// <param name="maxValue">The maximum value.</param>
    /// <returns>
    ///   <c>true</c> if the specified value is less than the specified limit; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsLessThan<T>(this T value, T maxValue) where T : IComparable
    {
        if (!typeof(T).IsValueType)
        {
            ((object)value).CannotBeNull();
            ((object)maxValue).CannotBeNull();
        }

        return value.CompareTo(maxValue) < 0;
    }

    /// <summary>
    /// Determines whether the specified value is less than or equal to the specified limit.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <param name="value">The value.</param>
    /// <param name="maxValue">The maximum value.</param>
    /// <returns>
    ///   <c>true</c> if the specified value is less than or equal to the specified limit; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsLessThanOrEqualTo<T>(this T value, T maxValue) where T : IComparable
    {
        if (!typeof(T).IsValueType)
        {
            ((object)value).CannotBeNull();
            ((object)maxValue).CannotBeNull();
        }

        return value.CompareTo(maxValue) <= 0;
    }

    /// <summary>
    /// Determines whether the specified value is null.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <param name="value">The value.</param>
    /// <returns>
    ///   <c>true</c> if the specified value is null; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsNull<T>(this T value) where T : class
    {
        return value == null;
    }

    /// <summary>
    /// Determines whether the specified value is one of the specified set.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <param name="value">The value.</param>
    /// <param name="set">The set.</param>
    /// <returns>
    ///   <c>true</c> if the specified value is one of the specified set; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsOneOf<T>(this T value, params T[] set) where T : IComparable
    {
        set.CannotBeNull();

        if (!typeof(T).IsValueType)
        {
            return set.Any(x => value != null && value.IsEqualTo(x) ||
                                value == null && x == null);
        }
        else
        {
            return set.Any(x => value.IsEqualTo(x));
        }
    }

    /// <summary>
    /// Determines whether the specified value is subtype of the specified type.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <param name="value">The value.</param>
    /// <param name="type">The type.</param>
    /// <returns>
    ///   <c>true</c> if the specified value is subtype of the specified type; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsSubTypeOf<T>(this T value, Type type)
    {
        type.CannotBeNull();

        if (!typeof(T).IsValueType)
        {
            if (value != null)
            {
                return type.IsAssignableFrom(value.GetType());
            }
            else
            {
                return false;
            }
        }
        else
        {
            return type.IsAssignableFrom(value.GetType());
        }
    }

    /// <summary>
    /// Determines whether the specified value is of the specified type.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <param name="value">The value.</param>
    /// <param name="type">The type.</param>
    /// <returns>
    ///   <c>true</c> if the specified value is of the specified type; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsTypeOf<T>(this T value, Type type)
    {
        type.CannotBeNull();

        if (typeof(T).IsValueType)
        {
            return value.GetType() == type;
        }
        else
        {
            if (value == null)
            {
                return false;
            }
            else
            {
                return value.GetType() == type;
            }
        }
    }

    #endregion Public Methods
}
