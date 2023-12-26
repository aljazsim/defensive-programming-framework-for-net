using System.Collections;
using System.Diagnostics;

namespace DefensiveProgrammingFramework;

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
    /// <param name="errorHandler">The error handler.</param>
    /// <returns>
    /// The original value if the specified value is empty; otherwise throws a new ArgumentException.
    /// </returns>
    public static IEnumerable<T> MustBeEmpty<T>(this IEnumerable<T> value, Action errorHandler = null)
    {
        if (value.IsNotEmpty())
        {
            if (errorHandler.IsNull())
            {
                throw new ArgumentException("Value must be empty.");
            }
            else
            {
                errorHandler();
            }
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
    /// <param name="errorHandler">The error handler.</param>
    /// <returns>
    /// The original value if the specified value is equal to the compared value; otherwise throws a new ArgumentException.
    /// </returns>
    public static IEnumerable<T> MustBeEqualTo<T>(this IEnumerable<T> value1, IEnumerable<T> value2, bool ignoreOrder = false, Action errorHandler = null)
        where T : IComparable
    {
        if (value1.IsNotEqualTo(value2, ignoreOrder))
        {
            if (errorHandler.IsNull())
            {
                throw new ArgumentException($"Value must be equal to {value2.Format()}.");
            }
            else
            {
                errorHandler();
            }
        }

        return value1;
    }

    /// <summary>
    /// Returns original value if the specified value is null or empty; otherwise throws a new ArgumentException.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <param name="value">The value.</param>
    /// <param name="errorHandler">The error handler.</param>
    /// <returns>
    /// The original value if the specified value is null or empty; otherwise throws a new ArgumentException.
    /// </returns>
    public static T MustBeNullOrEmpty<T>(this T value, Action errorHandler = null)
        where T : IEnumerable
    {
        if (value.IsNotNullOrEmpty())
        {
            if (errorHandler.IsNull())
            {
                throw new ArgumentException("Value must be null or empty.");
            }
            else
            {
                errorHandler();
            }
        }

        return value;
    }

    /// <summary>
    /// Returns original value if the specified value belongs to the specified set; otherwise throws a new ArgumentException.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <param name="value">The value.</param>
    /// <param name="set">The set.</param>
    /// <param name="errorHandler">The error handler.</param>
    /// <returns>
    /// The original value if the specified value belongs to the specified set; otherwise throws a new ArgumentException.
    /// </returns>
    public static T MustBeOneOf<T>(this T value, IEnumerable<T> set, Action errorHandler = null)
        where T : IComparable
    {
        if (value.IsNotOneOf(set))
        {
            if (errorHandler.IsNull())
            {
                throw new ArgumentException($"Value must be one of {set.Format()}.");
            }
            else
            {
                errorHandler();
            }
        }

        return value;
    }

    /// <summary>
    /// Returns original value if the specified value contains any items coresponding to the selector function; otherwise throws a new ArgumentException.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <param name="value">The value.</param>
    /// <param name="func">The selector function.</param>
    /// <param name="errorHandler">The error handler.</param>
    /// <returns>
    /// The original value if the specified value contains any items coresponding to the selector function; otherwise throws a new ArgumentException.
    /// </returns>
    public static IEnumerable<T> MustContain<T>(this IEnumerable<T> value, Func<T, bool> func, Action errorHandler = null)
    {
        if (value.ContainsNot(func))
        {
            if (errorHandler.IsNull())
            {
                throw new ArgumentException("Value must contain specified expression.");
            }
            else
            {
                errorHandler();
            }
        }

        return value;
    }

    /// <summary>
    /// Returns original value if the specified value contains duplicates; otherwise throws a new ArgumentException.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <param name="value">The value.</param>
    /// <param name="errorHandler">The error handler.</param>
    /// <returns>
    /// The original value if the specified value contains duplicates; otherwise throws a new ArgumentException.
    /// </returns>
    public static IEnumerable<T> MustContainDuplicates<T>(this IEnumerable<T> value, Action errorHandler = null)
        where T : IComparable
    {
        if (value.ContainsNotDuplicates())
        {
            if (errorHandler.IsNull())
            {
                throw new ArgumentException("Value must contain duplicates.");
            }
            else
            {
                errorHandler();
            }
        }

        return value;
    }

    /// <summary>
    /// Returns original value if the specified value contains null values; otherwise throws a new ArgumentException.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <param name="value">The value.</param>
    /// <param name="errorHandler">The error handler.</param>
    /// <returns>
    /// The original value if the specified value contains null values; otherwise throws a new ArgumentException.
    /// </returns>
    public static IEnumerable<T> MustContainNull<T>(this IEnumerable<T> value, Action errorHandler = null)
        where T : class
    {
        if (value.ContainsNotNull())
        {
            if (errorHandler.IsNull())
            {
                throw new ArgumentException("Value must contain null.");
            }
            else
            {
                errorHandler();
            }
        }

        return value;
    }

    /// <summary>
    /// Returns original value if the specified value contains only null values; otherwise throws a new ArgumentException.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <param name="value">The value.</param>
    /// <param name="errorHandler">The error handler.</param>
    /// <returns>
    /// The original value if the specified value contains only null values; otherwise throws a new ArgumentException.
    /// </returns>
    public static IEnumerable<T> MustContainOnlyNull<T>(this IEnumerable<T> value, Action errorHandler = null)
        where T : class
    {
        if (value.ContainsNotOnlyNull())
        {
            if (errorHandler.IsNull())
            {
                throw new ArgumentException("Value must contain only null.");
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
