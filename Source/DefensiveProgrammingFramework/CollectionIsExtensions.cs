using System.Collections;

namespace DefensiveProgrammingFramework;

/// <summary>
/// The collection is extension method.
/// </summary>
public static class CollectionIsExtensions
{
    #region Public Methods

    /// <summary>
    /// Determines whether the specified collection contains any items coresponding to the selector function.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <param name="value">The value.</param>
    /// <param name="func">The function.</param>
    /// <returns>
    ///   <c>true</c> if the specified collection contains any items coresponding to the selector function; otherwise, <c>false</c>.
    /// </returns>
    public static bool Contains<T>(this IEnumerable<T> value, Func<T, bool> func)
    {
        func.CannotBeNull();

        if (value != null)
        {
            foreach (var item in value)
            {
                if (func(item))
                {
                    return true;
                }
            }
        }

        return false;
    }

    /// <summary>
    /// Determines whether the specified collection contains duplicates.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <param name="value">The value.</param>
    /// <returns>
    ///   <c>true</c> if the specified collection contains duplicates; otherwise, <c>false</c>.
    /// </returns>
    public static bool ContainsDuplicates<T>(this IEnumerable<T> value) where T : IComparable
    {
        if (value != null)
        {
            return value.GroupBy(x => x).Any(x => x.Count() > 1);
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Determines whether the specified collection contains a null value.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <param name="value">The value.</param>
    /// <returns>
    ///   <c>true</c> if the specified collection contains a null value; otherwise, <c>false</c>.
    /// </returns>
    public static bool ContainsNull<T>(this IEnumerable<T> value) where T : class
    {
        if (value != null)
        {
            foreach (var item in value)
            {
                if (item == null)
                {
                    return true;
                }
            }
        }

        return false;
    }

    /// <summary>
    /// Determines whether the specified collection contains only null values.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <param name="value">The value.</param>
    /// <returns>
    ///   <c>true</c> if the specified collection contains only null values; otherwise, <c>false</c>.
    /// </returns>
    public static bool ContainsOnlyNull<T>(this IEnumerable<T> value) where T : class
    {
        if (value != null)
        {
            if (value.IsEmpty())
            {
                return false;
            }
            else
            {
                foreach (var item in value)
                {
                    if (item != null)
                    {
                        return false;
                    }
                }

                return true;
            }
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Determines whether the specified collection is empty.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <param name="value">The value.</param>
    /// <returns>
    ///   <c>true</c> if the specified collection is empty; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsEmpty<T>(this IEnumerable<T> value)
    {
        if (value == null)
        {
            return false;
        }
        else
        {
            return !value.GetEnumerator().MoveNext();
        }
    }

    /// <summary>
    /// Determines whether the specified collection is equal to compared collection.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <param name="value1">The value1.</param>
    /// <param name="value2">The value2.</param>
    /// <param name="ignoreOrder">If set to <c>true</c> ignore order of the items.</param>
    /// <returns>
    ///   <c>true</c> if the specified collection is equal to compared collection; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsEqualTo<T>(this IEnumerable<T> value1, IEnumerable<T> value2, bool ignoreOrder = false) where T : IComparable
    {
        if (value1 == null &&
            value2 == null)
        {
            return true;
        }
        else if (value1 != null &&
                 value2 != null)
        {
            if (ignoreOrder)
            {
                value1 = value1.OrderBy(x => x).ToList();
                value2 = value2.OrderBy(x => x).ToList();
            }

            return value1.SequenceEqual(value2);
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Determines whether the specified collection is null or empty.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <param name="value">The value.</param>
    /// <returns>
    ///   <c>true</c> if the specified collection is null or empty; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsNullOrEmpty<T>(this T value) where T : IEnumerable
    {
        if (value == null)
        {
            return true;
        }
        else
        {
            return !value.GetEnumerator().MoveNext();
        }
    }

    /// <summary>
    /// Determines whether the specified value belongs to the specified set.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <param name="value">The value.</param>
    /// <param name="set">The set.</param>
    /// <returns>
    ///   <c>true</c> if the specified value belongs to the specified set; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsOneOf<T>(this T value, IEnumerable<T> set) where T : IComparable
    {
        set.CannotBeNull();

        if (typeof(T).IsValueType)
        {
            return set.Any(x => value.IsEqualTo(x));
        }
        else
        {
            if (value == null)
            {
                return set.Any(x => x == null);
            }
            else
            {
                return set.Any(x => value.IsEqualTo(x));
            }
        }
    }

    #endregion Public Methods
}
