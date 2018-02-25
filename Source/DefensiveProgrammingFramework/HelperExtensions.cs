using System.Collections.Generic;
using System.Linq;

namespace DefensiveProgrammingFramework
{
    /// <summary>
    /// The helper extension methods.
    /// </summary>
    internal static class HelperExtensions
    {
        #region Internal Methods

        /// <summary>
        /// Formats the specified list.
        /// </summary>
        /// <typeparam name="T">The list item type.</typeparam>
        /// <param name="list">The list.</param>
        /// <returns>The formatted list.</returns>
        internal static string Format<T>(this IEnumerable<T> list)
        {
            var max = 10;

            if (list.Count() > max)
            {
                return $"[{ string.Join(", ", list.Take(max).Select(x => x.ToString())) }, ...]";
            }
            else
            {
                return $"[{ string.Join(", ", list.Select(x => x.ToString())) }]";
            }
        }

        #endregion Internal Methods
    }
}
