using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DefensiveProgrammingFramework.Test;

[TestClass]
public class CollectionWhenExtensionsTest
{
    #region Public Methods

    [TestMethod]
    public void WhenContains()
    {
        Assert.AreEqual(null, (null as string[]).WhenContains(x => x == null, new string[0]));
        CollectionAssert.AreEqual(new string[0], new string[] { }.WhenContains(x => x == null, new string[0]).ToList());
        CollectionAssert.AreEqual(new string[0], new string[] { null }.WhenContains(x => x == null, new string[0]).ToList());
        CollectionAssert.AreEqual(new string[] { "aaa" }, new string[] { "aaa" }.WhenContains(x => x == null, new string[0]).ToList());
        CollectionAssert.AreEqual(new string[] { "aaa", "bb", "c" }, new string[] { "aaa", "bb", "c" }.WhenContains(x => x == null, new string[0]).ToList());
        CollectionAssert.AreEqual(new string[0], new string[] { null, "aaa", "bb", "c" }.WhenContains(x => x == null, new string[0]).ToList());
        CollectionAssert.AreEqual(new string[0], new string[] { "aaa", null, "bb", "c" }.WhenContains(x => x == null, new string[0]).ToList());
        CollectionAssert.AreEqual(new string[0], new string[] { "aaa", "bb", null, "c" }.WhenContains(x => x == null, new string[0]).ToList());
        CollectionAssert.AreEqual(new string[0], new string[] { "aaa", "bb", "c", null }.WhenContains(x => x == null, new string[0]).ToList());
        CollectionAssert.AreEqual(new string[0], new string[] { null, null, null }.WhenContains(x => x == null, new string[0]).ToList());
    }

    [TestMethod]
    public void WhenContainsDuplicates()
    {
        Assert.AreEqual(null, (null as string[]).WhenContainsDuplicates(new string[0]));
        CollectionAssert.AreEqual(new string[0], new string[] { }.WhenContainsDuplicates(new string[0]).ToList());
        CollectionAssert.AreEqual(new string[] { null }, new string[] { null }.WhenContainsDuplicates(new string[0]).ToList());
        CollectionAssert.AreEqual(new string[0], new string[] { null, null }.WhenContainsDuplicates(new string[0]).ToList());
        CollectionAssert.AreEqual(new string[] { "aaa" }, new string[] { "aaa" }.WhenContainsDuplicates(new string[0]).ToList());
        CollectionAssert.AreEqual(new string[] { "aaa", "bb", "c" }, new string[] { "aaa", "bb", "c" }.WhenContainsDuplicates(new string[0]).ToList());
        CollectionAssert.AreEqual(new string[0], new string[] { "aaa", "bb", "aaa" }.WhenContainsDuplicates(new string[0]).ToList());
        CollectionAssert.AreEqual(new string[0], new string[] { null, "aaa", null, "c" }.WhenContainsDuplicates(new string[0]).ToList());
        CollectionAssert.AreEqual(new string[0], new string[] { null, null, null }.WhenContainsDuplicates(new string[0]).ToList());
    }

    [TestMethod]
    public void WhenContainsNull()
    {
        Assert.AreEqual(null, (null as string[]).WhenContainsNull(new string[] { "a" }));
        CollectionAssert.AreEqual(new string[] { }.ToList(), new string[] { }.WhenContainsNull(new string[] { "a" }).ToList());
        CollectionAssert.AreEqual(new string[] { "a" }.ToList(), new string[] { null }.WhenContainsNull(new string[] { "a" }).ToList());
        CollectionAssert.AreEqual(new string[] { "aaa" }.ToList(), new string[] { "aaa" }.WhenContainsNull(new string[] { "a" }).ToList());
        CollectionAssert.AreEqual(new string[] { "aaa", "bb", "c" }, new string[] { "aaa", "bb", "c" }.WhenContainsNull(new string[] { "aaa" }).ToList());
        CollectionAssert.AreEqual(new string[] { "aaa" }, new string[] { null, "aaa", "bb", "c" }.WhenContainsNull(new string[] { "aaa" }).ToList());
        CollectionAssert.AreEqual(new string[] { "aaa" }, new string[] { "aaa", null, "bb", "c" }.WhenContainsNull(new string[] { "aaa" }).ToList());
        CollectionAssert.AreEqual(new string[] { "aaa" }, new string[] { "aaa", "bb", null, "c" }.WhenContainsNull(new string[] { "aaa" }).ToList());
        CollectionAssert.AreEqual(new string[] { "aaa" }, new string[] { "aaa", "bb", "c", null }.WhenContainsNull(new string[] { "aaa" }).ToList());
        CollectionAssert.AreEqual(new string[] { "aaa" }, new string[] { null, null, null }.WhenContainsNull(new string[] { "aaa" }).ToList());
    }

    [TestMethod]
    public void WhenContainsOnlyNull()
    {
        Assert.AreEqual(null, (null as IEnumerable<string>).WhenContainsOnlyNull(new string[] { "aaa" }));
        CollectionAssert.AreEqual(new string[0], new string[] { }.WhenContainsOnlyNull(new string[] { "aaa" }).ToList());
        CollectionAssert.AreEqual(new string[] { "aaa" }, new string[] { null }.WhenContainsOnlyNull(new string[] { "aaa" }).ToList());
        CollectionAssert.AreEqual(new string[] { "aaa" }, new string[] { "aaa" }.WhenContainsOnlyNull(new string[] { "aaa" }).ToList());
        CollectionAssert.AreEqual(new string[] { "aaa", "bb", "c" }, new string[] { "aaa", "bb", "c" }.WhenContainsOnlyNull(new string[] { "aaa" }).ToList());
        CollectionAssert.AreEqual(new string[] { null, "aaa", "bb", "c" }, new string[] { null, "aaa", "bb", "c" }.WhenContainsOnlyNull(new string[] { "aaa" }).ToList());
        CollectionAssert.AreEqual(new string[] { "aaa", null, "bb", "c" }, new string[] { "aaa", null, "bb", "c" }.WhenContainsOnlyNull(new string[] { "aaa" }).ToList());
        CollectionAssert.AreEqual(new string[] { "aaa", "bb", null, "c" }, new string[] { "aaa", "bb", null, "c" }.WhenContainsOnlyNull(new string[] { "aaa" }).ToList());
        CollectionAssert.AreEqual(new string[] { "aaa", "bb", "c", null }, new string[] { "aaa", "bb", "c", null }.WhenContainsOnlyNull(new string[] { "aaa" }).ToList());
        CollectionAssert.AreEqual(new string[] { "aaa" }, new string[] { null, null, null }.WhenContainsOnlyNull(new string[] { "aaa" }).ToList());
    }

    [TestMethod]
    public void WhenIsEmpty()
    {
        Assert.AreEqual("x", "".WhenIsEmpty("x"));
        Assert.AreEqual("a", "a".WhenIsEmpty("x"));
        Assert.AreEqual("ab", "ab".WhenIsEmpty("x"));
        Assert.AreEqual("abc", "abc".WhenIsEmpty("x"));
        CollectionAssert.AreEqual(new int[] { 1 }, new int[] { }.WhenIsEmpty(new int[] { 1 }).ToList());
        CollectionAssert.AreEqual(new int[] { 1 }, new int[] { 1 }.WhenIsEmpty(new int[] { 2 }).ToList());
        CollectionAssert.AreEqual(null, (null as IEnumerable<string>).WhenIsEmpty(new string[] { "x" }) as ICollection);
    }

    [DataRow("", "", false, "x", "x")]
    [DataRow(" ", " ", false, "x", "x")]
    [DataRow(" ", "  ", false, "x", " ")]
    [DataRow(" ", " \\t", false, "x", " ")]
    [DataRow("a", "a", false, "x", "x")]
    [DataRow("aa", "aa", false, "x", "x")]
    [DataRow("aa", "a", false, "x", "aa")]
    [DataRow("ab", "ab", false, "x", "x")]
    [DataRow("ab", "ba", true, "x", "x")]
    [DataRow("ab", "ba", false, "x", "ab")]
    [DataRow("abc", "abc", true, "x", "x")]
    [DataRow("abc", "abc", false, "x", "x")]
    [DataRow("abc", "bac", true, "x", "x")]
    [DataRow("abc", "acb", true, "x", "x")]
    [DataRow("abd", "cba", true, "x", "abd")]
    [DataRow("abc", "bcad", true, "x", "abc")]
    [DataRow("", null, false, "x", "")]
    [DataRow(null, "", false, "x", null)]
    [DataRow(null, null, false, "x", "x")]
    [DataRow(null, null, true, "x", "x")]
    [DataTestMethod]
    public void WhenIsEqualTo(IEnumerable<char> value1, IEnumerable<char> value2, bool ignoreOrder, IEnumerable<char> defaultValue, IEnumerable<char> expected)
    {
        Assert.AreEqual(expected, value1.WhenIsEqualTo(value2, ignoreOrder, defaultValue));
    }

    [DataRow(new string[] { null }, new string[] { null }, true, new string[0], new string[0])]
    [DataRow(new string[] { null }, new string[] { null }, false, new string[0], new string[0])]
    [DataRow(new string[] { null, null }, new string[] { null, null }, true, new string[0], new string[0])]
    [DataRow(new string[] { null, null }, new string[] { null, null }, false, new string[0], new string[0])]
    [DataRow(new string[] { null, "aaa" }, new string[] { null, "aaa" }, false, new string[0], new string[0])]
    [DataRow(new string[] { null, "aaa" }, new string[] { "aaa", null }, true, new string[0], new string[0])]
    [DataRow(new string[] { "bbb", "aaa" }, new string[] { "bbb", "aaa" }, true, new string[0], new string[0])]
    [DataRow(new string[] { "bbb", "aaa" }, new string[] { "aaa", "bbb" }, true, new string[0], new string[0])]
    [DataTestMethod]
    public void WhenIsEqualTo3(IEnumerable<string> value1, IEnumerable<string> value2, bool ignoreOrder, IEnumerable<string> defaultValue, IEnumerable<string> expected)
    {
        CollectionAssert.AreEqual(expected.ToList(), value1.WhenIsEqualTo(value2, ignoreOrder, defaultValue).ToList());
    }

    [DataRow(new int[0], new int[0], false, new int[0], new int[0])]
    [DataRow(new int[] { 1 }, new int[] { 1 }, true, new int[0], new int[0])]
    [DataRow(new int[] { 1, 1 }, new int[] { 1, 1 }, false, new int[0], new int[0])]
    [DataRow(new int[] { 1 }, new int[] { 1, 1 }, true, new int[0], new int[] { 1 })]
    [DataRow(new int[] { 0, 9, 8, 7, 6, 5, 4, 3, 2, 1 }, new int[] { 7, 8, 9, 6, 5, 4, 1, 0, 2, 3 }, true, new int[0], new int[0])]
    [DataTestMethod]
    public void WhenIsEqualTo4(IEnumerable<int> value1, IEnumerable<int> value2, bool ignoreOrder, IEnumerable<int> defaultValue, IEnumerable<int> expected)
    {
        CollectionAssert.AreEqual(expected.ToList(), value1.WhenIsEqualTo(value2, ignoreOrder, defaultValue).ToList());
    }

    [DataRow(null, null, null)]
    [DataRow("", "aa", "aa")]
    [DataRow("a", "x", "a")]
    [DataRow(new int[] { }, new int[] { 5 }, new int[] { 5 })]
    [DataRow(new int[] { 1 }, new int[0], new int[] { 1 })]
    [DataRow(new int[] { 1, 2 }, new int[0], new int[] { 1, 2 })]
    [DataRow(new int[] { 1, 2, 3 }, new int[0], new int[] { 1, 2, 3 })]
    [DataTestMethod]
    public void WhenIsNullOrEmpty(IEnumerable value, IEnumerable defaultValue, IEnumerable expected)
    {
        CollectionAssert.AreEqual(expected as ICollection, value.WhenIsNullOrEmpty(defaultValue) as ICollection);
    }

    [DataRow(3, new int[] { }, 99, 3)]
    [DataRow(3, new int[] { 3 }, 99, 99)]
    [DataRow(3, new int[] { 2 }, 99, 3)]
    [DataRow(3, new int[] { 2, 3 }, 99, 99)]
    [DataRow(3, new int[] { 1, 2, 3, 4 }, 99, 99)]
    [DataRow(3, new int[] { 4, 3, 2, 1 }, 99, 99)]
    [DataRow(3, new int[] { 1, 1, 1, 1, 3, 1, 1, 1 }, 99, 99)]
    [DataRow(3, new int[] { 3, 3, 3, 3, 3, 3, 3 }, 99, 99)]
    [DataRow(3, new int[] { 4, 4, 4, 4, 4, 4, 4, 4 }, 99, 3)]
    [DataTestMethod]
    public void WhenIsOneOf(int value, IEnumerable<int> set, int defaultValue, int expected)
    {
        Assert.AreEqual(expected, value.WhenIsOneOf(set, defaultValue));
        Assert.AreEqual(expected, value.WhenIsOneOf(set.ToArray(), defaultValue));
    }

    [DataRow("", new string[] { }, "x", "")]
    [DataRow("", new string[] { "" }, "x", "x")]
    [DataRow("a", new string[] { "a" }, "x", "x")]
    [DataRow("a", new string[] { "a", "b" }, "x", "x")]
    [DataRow("a", new string[] { "ab", "ba" }, "x", "a")]
    [DataRow("a", new string[] { "ab", "A" }, "x", "a")]
    [DataRow("a", new string[] { "ab", "a" }, "x", "x")]
    [DataRow("a", new string[] { "a", "a", "a", "a", "a", "a", "a" }, "x", "x")]
    [DataRow("a", new string[] { "b", "b", "b", "b", "b", "b", "b" }, "x", "a")]
    [DataRow(null, new string[] { "" }, "x", null)]
    [DataRow(null, new string[] { null }, "x", "x")]
    [DataTestMethod]
    public void WhenIsOneOf2(string value, IEnumerable<string> set, string defaultValue, string expected)
    {
        Assert.AreEqual(expected, value.WhenIsOneOf(set, defaultValue));
    }

    [DataRow(null, null, null)]
    [DataRow("a", null, null)]
    [DataTestMethod]
    public void WhenIsOneOfFail(string value, IEnumerable<string> set, string defaultValue)
    {
        try
        {
            value.WhenIsOneOf(set, defaultValue);

            Assert.Fail();
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Value cannot be null.", ex.Message);
        }
    }

    #endregion Public Methods
}
