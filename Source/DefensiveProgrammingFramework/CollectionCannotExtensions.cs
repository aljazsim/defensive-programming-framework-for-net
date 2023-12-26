using System.Collections;
using System.Diagnostics;

namespace DefensiveProgrammingFramework;

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
    /// <param name="errorHandler">The error handler.</param>
    /// <returns>
    /// The original value if the specified value is not empty; otherwise throws a new ArgumentException.
    /// </returns>
    public static IEnumerable<T> CannotBeEmpty<T>(this IEnumerable<T> value, Action errorHandler = null)
    {
        if (value.IsEmpty())
        {
            if (errorHandler.IsNull())
            {
                throw new ArgumentException("Value cannot be empty.");
            }
            else
            {
                errorHandler();
            }
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
    /// <param name="errorHandler">The error handler.</param>
    /// <returns>
    /// The original value if the specified value is not equal to the compared value; otherwise throws a new ArgumentException.
    /// </returns>
    public static IEnumerable<T> CannotBeEqualTo<T>(this IEnumerable<T> value1, IEnumerable<T> value2, bool ignoreOrder = false, Action errorHandler = null)
        where T : IComparable
    {
        if (value1.IsEqualTo(value2, ignoreOrder))
        {
            if (errorHandler.IsNull())
            {
                throw new ArgumentException($"Value cannot be equal to {value2.Format()}.");
            }
            else
            {
                errorHandler();
            }
        }

        return value1;
    }

    /// <summary>
    /// Returns original value if the specified value is not null or empty; otherwise throws a new ArgumentException.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <param name="value">The value.</param>
    /// <param name="errorHandler">The error handler.</param>
    /// <returns>
    /// The original value if the specified value is not null or empty; otherwise throws a new ArgumentException.
    /// </returns>
    public static T CannotBeNullOrEmpty<T>(this T value, Action errorHandler = null)
        where T : IEnumerable
    {
        if (value.IsNullOrEmpty())
        {
            if (errorHandler.IsNull())
            {
                throw new ArgumentException("Value cannot be null or empty.");
            }
            else
            {
                errorHandler();
            }
        }

        return value;
    }

    /// <summary>
    /// Returns original value if the specified value doesn't belong to the specified set; otherwise throws a new ArgumentException.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <param name="value">The value.</param>
    /// <param name="set">The set.</param>
    /// <param name="errorHandler">The error handler.</param>
    /// <returns>
    /// The original value if the specified value doesn't belong to the specified set; otherwise throws a new ArgumentException.
    /// </returns>
    public static T CannotBeOneOf<T>(this T value, IEnumerable<T> set, Action errorHandler = null)
        where T : IComparable
    {
        if (value.IsOneOf(set))
        {
            if (errorHandler.IsNull())
            {
                throw new ArgumentException($"Value cannot be one of {set.Format()}.");
            }
            else
            {
                errorHandler();
            }
        }

        return value;
    }

    /// <summary>
    /// Returns original value if the specified value doesn't contain any items coresponding to the selector function; otherwise throws a new ArgumentException.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <param name="value">The value.</param>
    /// <param name="func">The selector function.</param>
    /// <param name="errorHandler">The error handler.</param>
    /// <returns>
    /// The original value if the specified value doesn't contain any items coresponding to the selector function; otherwise throws a new ArgumentException.
    /// </returns>
    public static IEnumerable<T> CannotContain<T>(this IEnumerable<T> value, Func<T, bool> func, Action errorHandler = null)
    {
        if (value.Contains(func))
        {
            if (errorHandler.IsNull())
            {
                throw new ArgumentException("Value cannot contain specified expression.");
            }
            else
            {
                errorHandler();
            }
        }

        return value;
    }

    /// <summary>
    /// Returns original value if the specified value doesn't contain duplicates; otherwise throws a new ArgumentException.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <param name="value">The value.</param>
    /// <param name="errorHandler">The error handler.</param>
    /// <returns>
    /// The original value if the specified value doesn't contain duplicates; otherwise throws a new ArgumentException.
    /// </returns>
    public static IEnumerable<T> CannotContainDuplicates<T>(this IEnumerable<T> value, Action errorHandler = null)
        where T : IComparable
    {
        if (value.ContainsDuplicates())
        {
            if (errorHandler.IsNull())
            {
                throw new ArgumentException("Value cannot contain duplicates.");
            }
            else
            {
                errorHandler();
            }
        }

        return value;
    }

    /// <summary>
    /// Returns original value if the specified value doesn't contain null values; otherwise throws a new ArgumentException.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <param name="value">The value.</param>
    /// <param name="errorHandler">The error handler.</param>
    /// <returns>
    /// The original value if the specified value doesn't contain null values; otherwise throws a new ArgumentException.
    /// </returns>
    public static IEnumerable<T> CannotContainNull<T>(this IEnumerable<T> value, Action errorHandler = null)
        where T : class
    {
        if (value.ContainsNull())
        {
            if (errorHandler.IsNull())
            {
                throw new ArgumentException("Value cannot contain null.");
            }
            else
            {
                errorHandler();
            }
        }

        return value;
    }

    /// <summary>
    /// Returns original value if the specified value doesn't contain only null values; otherwise throws a new ArgumentException.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <param name="value">The value.</param>
    /// <param name="errorHandler">The error handler.</param>
    /// <returns>
    /// The original value if the specified value doesn't contain only null values; otherwise throws a new ArgumentException.
    /// </returns>
    public static IEnumerable<T> CannotContainOnlyNull<T>(this IEnumerable<T> value, Action errorHandler = null)
        where T : class
    {
        if (value.ContainsOnlyNull())
        {
            if (errorHandler.IsNull())
            {
                throw new ArgumentException("Value cannot contain only null.");
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
