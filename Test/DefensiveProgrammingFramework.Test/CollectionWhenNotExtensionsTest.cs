using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DefensiveProgrammingFramework.Test;

[TestClass]
public class CollectionWhenNotExtensionsTest
{
    #region Public Methods

    [TestMethod]
    public void WhenContainsNot()
    {
        CollectionAssert.AreEqual(new string[0], (null as string[]).WhenContainsNot(x => x == null, new string[0]).ToList());
        CollectionAssert.AreEqual(new string[0], new string[] { }.WhenContainsNot(x => x == null, new string[0]).ToList());
        CollectionAssert.AreEqual(new string[] { null }, new string[] { null }.WhenContainsNot(x => x == null, new string[0]).ToList());
        CollectionAssert.AreEqual(new string[0], new string[] { "aaa" }.WhenContainsNot(x => x == null, new string[0]).ToList());
        CollectionAssert.AreEqual(new string[0], new string[] { "aaa", "bb", "c" }.WhenContainsNot(x => x == null, new string[0]).ToList());
        CollectionAssert.AreEqual(new string[] { null, "aaa", "bb", "c" }, new string[] { null, "aaa", "bb", "c" }.WhenContainsNot(x => x == null, new string[0]).ToList());
        CollectionAssert.AreEqual(new string[] { "aaa", null, "bb", "c" }, new string[] { "aaa", null, "bb", "c" }.WhenContainsNot(x => x == null, new string[0]).ToList());
        CollectionAssert.AreEqual(new string[] { "aaa", "bb", null, "c" }, new string[] { "aaa", "bb", null, "c" }.WhenContainsNot(x => x == null, new string[0]).ToList());
        CollectionAssert.AreEqual(new string[] { "aaa", "bb", "c", null }, new string[] { "aaa", "bb", "c", null }.WhenContainsNot(x => x == null, new string[0]).ToList());
        CollectionAssert.AreEqual(new string[] { null, null, null }, new string[] { null, null, null }.WhenContainsNot(x => x == null, new string[0]).ToList());
    }

    [TestMethod]
    public void WhenContainsNotDuplicates()
    {
        CollectionAssert.AreEqual(new string[0], (null as string[]).WhenContainsNotDuplicates(new string[0]).ToList());
        CollectionAssert.AreEqual(new string[0], new string[] { }.WhenContainsNotDuplicates(new string[0]).ToList());
        CollectionAssert.AreEqual(new string[0], new string[] { null }.WhenContainsNotDuplicates(new string[0]).ToList());
        CollectionAssert.AreEqual(new string[] { null, null }, new string[] { null, null }.WhenContainsNotDuplicates(new string[0]).ToList());
        CollectionAssert.AreEqual(new string[0], new string[] { "aaa" }.WhenContainsNotDuplicates(new string[0]).ToList());
        CollectionAssert.AreEqual(new string[0], new string[] { "aaa", "bb", "c" }.WhenContainsNotDuplicates(new string[0]).ToList());
        CollectionAssert.AreEqual(new string[] { "aaa", "bb", "aaa" }, new string[] { "aaa", "bb", "aaa" }.WhenContainsNotDuplicates(new string[0]).ToList());
        CollectionAssert.AreEqual(new string[] { null, "aaa", null, "c" }, new string[] { null, "aaa", null, "c" }.WhenContainsNotDuplicates(new string[0]).ToList());
        CollectionAssert.AreEqual(new string[] { null, null, null }, new string[] { null, null, null }.WhenContainsNotDuplicates(new string[0]).ToList());
    }

    [TestMethod]
    public void WhenContainsNotNull()
    {
        CollectionAssert.AreEqual(new string[] { "a" }, (null as string[]).WhenContainsNotNull(new string[] { "a" }).ToList());
        CollectionAssert.AreEqual(new string[] { "a" }, new string[] { }.WhenContainsNotNull(new string[] { "a" }).ToList());
        CollectionAssert.AreEqual(new string[] { null }, new string[] { null }.WhenContainsNotNull(new string[] { "a" }).ToList());
        CollectionAssert.AreEqual(new string[] { "a" }, new string[] { "aaa" }.WhenContainsNotNull(new string[] { "a" }).ToList());
        CollectionAssert.AreEqual(new string[] { "aaa" }, new string[] { "aaa", "bb", "c" }.WhenContainsNotNull(new string[] { "aaa" }).ToList());
        CollectionAssert.AreEqual(new string[] { null, "aaa", "bb", "c" }, new string[] { null, "aaa", "bb", "c" }.WhenContainsNotNull(new string[] { "aaa" }).ToList());
        CollectionAssert.AreEqual(new string[] { "aaa", null, "bb", "c" }, new string[] { "aaa", null, "bb", "c" }.WhenContainsNotNull(new string[] { "aaa" }).ToList());
        CollectionAssert.AreEqual(new string[] { "aaa", "bb", null, "c" }, new string[] { "aaa", "bb", null, "c" }.WhenContainsNotNull(new string[] { "aaa" }).ToList());
        CollectionAssert.AreEqual(new string[] { "aaa", "bb", "c", null }, new string[] { "aaa", "bb", "c", null }.WhenContainsNotNull(new string[] { "aaa" }).ToList());
        CollectionAssert.AreEqual(new string[] { null, null, null }, new string[] { null, null, null }.WhenContainsNotNull(new string[] { "aaa" }).ToList());
    }

    [TestMethod]
    public void WhenContainsNotOnlyNull()
    {
        CollectionAssert.AreEqual(new string[] { "aaa" }, (null as IEnumerable<string>).WhenContainsNotOnlyNull(new string[] { "aaa" }).ToList());
        CollectionAssert.AreEqual(new string[] { "aaa" }, new string[] { }.WhenContainsNotOnlyNull(new string[] { "aaa" }).ToList());
        CollectionAssert.AreEqual(new string[] { null }, new string[] { null }.WhenContainsNotOnlyNull(new string[] { "aaa" }).ToList());
        CollectionAssert.AreEqual(new string[] { "aaa" }, new string[] { "aaa" }.WhenContainsNotOnlyNull(new string[] { "aaa" }).ToList());
        CollectionAssert.AreEqual(new string[] { "aaa" }, new string[] { "aaa", "bb", "c" }.WhenContainsNotOnlyNull(new string[] { "aaa" }).ToList());
        CollectionAssert.AreEqual(new string[] { "aaa" }, new string[] { null, "aaa", "bb", "c" }.WhenContainsNotOnlyNull(new string[] { "aaa" }).ToList());
        CollectionAssert.AreEqual(new string[] { "aaa" }, new string[] { "aaa", null, "bb", "c" }.WhenContainsNotOnlyNull(new string[] { "aaa" }).ToList());
        CollectionAssert.AreEqual(new string[] { "aaa" }, new string[] { "aaa", "bb", null, "c" }.WhenContainsNotOnlyNull(new string[] { "aaa" }).ToList());
        CollectionAssert.AreEqual(new string[] { "aaa" }, new string[] { "aaa", "bb", "c", null }.WhenContainsNotOnlyNull(new string[] { "aaa" }).ToList());
        CollectionAssert.AreEqual(new string[] { null, null, null }, new string[] { null, null, null }.WhenContainsNotOnlyNull(new string[] { "aaa" }).ToList());
    }

    [TestMethod]
    public void WhenIsNotEmpty()
    {
        Assert.AreEqual("", "".WhenIsNotEmpty("x"));
        Assert.AreEqual("x", "a".WhenIsNotEmpty("x"));
        Assert.AreEqual("x", "ab".WhenIsNotEmpty("x"));
        Assert.AreEqual("x", "abc".WhenIsNotEmpty("x"));
        CollectionAssert.AreEqual(new int[] { }, new int[] { }.WhenIsNotEmpty(new int[] { 1 }).ToList());
        CollectionAssert.AreEqual(new int[] { 2 }, new int[] { 1 }.WhenIsNotEmpty(new int[] { 2 }).ToList());
        CollectionAssert.AreEqual(new string[] { "x" }, (null as IEnumerable<string>).WhenIsNotEmpty(new string[] { "x" }) as ICollection);
    }

    [DataRow("", "", false, "x", "")]
    [DataRow(" ", " ", false, "x", " ")]
    [DataRow(" ", "  ", false, "x", "x")]
    [DataRow(" ", " \\t", false, "x", "x")]
    [DataRow("a", "a", false, "x", "a")]
    [DataRow("aa", "aa", false, "x", "aa")]
    [DataRow("aa", "a", false, "x", "x")]
    [DataRow("ab", "ab", false, "x", "ab")]
    [DataRow("ab", "ba", true, "x", "ab")]
    [DataRow("ab", "ba", false, "x", "x")]
    [DataRow("abc", "abc", true, "x", "abc")]
    [DataRow("abc", "abc", false, "x", "abc")]
    [DataRow("abc", "bac", true, "x", "abc")]
    [DataRow("abc", "acb", true, "x", "abc")]
    [DataRow("abd", "cba", true, "x", "x")]
    [DataRow("abc", "bcad", true, "x", "x")]
    [DataRow("", null, false, "x", "x")]
    [DataRow(null, "", false, "x", "x")]
    [DataRow(null, null, false, "x", null)]
    [DataRow(null, null, true, "x", null)]
    [DataTestMethod]
    public void WhenIsNotEqualTo(IEnumerable<char> value1, IEnumerable<char> value2, bool ignoreOrder, IEnumerable<char> defaultValue, IEnumerable<char> expected)
    {
        Assert.AreEqual(expected, value1.WhenIsNotEqualTo(value2, ignoreOrder, defaultValue));
    }

    [DataRow(new string[] { null }, new string[] { null }, true, new string[0], new string[] { null })]
    [DataRow(new string[] { null }, new string[] { null }, false, new string[0], new string[] { null })]
    [DataRow(new string[] { null, null }, new string[] { null, null }, true, new string[0], new string[] { null, null })]
    [DataRow(new string[] { null, null }, new string[] { null, null }, false, new string[0], new string[] { null, null })]
    [DataRow(new string[] { null, "aaa" }, new string[] { null, "aaa" }, false, new string[0], new string[] { null, "aaa" })]
    [DataRow(new string[] { null, "aaa" }, new string[] { "aaa", null }, true, new string[0], new string[] { null, "aaa" })]
    [DataRow(new string[] { "bbb", "aaa" }, new string[] { "bbb", "aaa" }, true, new string[0], new string[] { "bbb", "aaa" })]
    [DataRow(new string[] { "bbb", "aaa" }, new string[] { "aaa", "bbb" }, true, new string[0], new string[] { "bbb", "aaa" })]
    [DataTestMethod]
    public void WhenIsNotEqualTo3(IEnumerable<string> value1, IEnumerable<string> value2, bool ignoreOrder, IEnumerable<string> defaultValue, IEnumerable<string> expected)
    {
        CollectionAssert.AreEqual(expected.ToList(), value1.WhenIsNotEqualTo(value2, ignoreOrder, defaultValue).ToList());
    }

    [DataRow(new int[0], new int[0], false, new int[0], new int[0])]
    [DataRow(new int[] { 1 }, new int[] { 1 }, true, new int[0], new int[] { 1 })]
    [DataRow(new int[] { 1, 1 }, new int[] { 1, 1 }, false, new int[0], new int[] { 1, 1 })]
    [DataRow(new int[] { 1 }, new int[] { 1, 1 }, true, new int[0], new int[0])]
    [DataRow(new int[] { 0, 9, 8, 7, 6, 5, 4, 3, 2, 1 }, new int[] { 7, 8, 9, 6, 5, 4, 1, 0, 2, 3 }, true, new int[0], new int[] { 0, 9, 8, 7, 6, 5, 4, 3, 2, 1 })]
    [DataTestMethod]
    public void WhenIsNotEqualTo4(IEnumerable<int> value1, IEnumerable<int> value2, bool ignoreOrder, IEnumerable<int> defaultValue, IEnumerable<int> expected)
    {
        CollectionAssert.AreEqual(expected.ToList(), value1.WhenIsNotEqualTo(value2, ignoreOrder, defaultValue).ToList());
    }

    [DataRow(null, null, null)]
    [DataRow("", "aa", "")]
    [DataRow("a", "x", "x")]
    [DataRow(new int[] { }, new int[] { 5 }, new int[] { })]
    [DataRow(new int[] { 1 }, new int[0], new int[] { })]
    [DataRow(new int[] { 1, 2 }, new int[0], new int[] { })]
    [DataRow(new int[] { 1, 2, 3 }, new int[0], new int[] { })]
    [DataTestMethod]
    public void WhenIsNotNullOrEmpty(IEnumerable value, IEnumerable defaultValue, IEnumerable expected)
    {
        CollectionAssert.AreEqual(expected as ICollection, value.WhenIsNotNullOrEmpty(defaultValue) as ICollection);
    }

    [DataRow(3, new int[] { }, 99, 99)]
    [DataRow(3, new int[] { 3 }, 99, 3)]
    [DataRow(3, new int[] { 2 }, 99, 99)]
    [DataRow(3, new int[] { 2, 3 }, 99, 3)]
    [DataRow(3, new int[] { 1, 2, 3, 4 }, 99, 3)]
    [DataRow(3, new int[] { 4, 3, 2, 1 }, 99, 3)]
    [DataRow(3, new int[] { 1, 1, 1, 1, 3, 1, 1, 1 }, 99, 3)]
    [DataRow(3, new int[] { 3, 3, 3, 3, 3, 3, 3 }, 99, 3)]
    [DataRow(3, new int[] { 4, 4, 4, 4, 4, 4, 4, 4 }, 99, 99)]
    [DataTestMethod]
    public void WhenIsNotOneOf(int value, IEnumerable<int> set, int defaultValue, int expected)
    {
        Assert.AreEqual(expected, value.WhenIsNotOneOf(set, defaultValue));
        Assert.AreEqual(expected, value.WhenIsNotOneOf(set.ToArray(), defaultValue));
    }

    [DataRow("", new string[] { }, "x", "x")]
    [DataRow("", new string[] { "" }, "x", "")]
    [DataRow("a", new string[] { "a" }, "x", "a")]
    [DataRow("a", new string[] { "a", "b" }, "x", "a")]
    [DataRow("a", new string[] { "ab", "ba" }, "x", "x")]
    [DataRow("a", new string[] { "ab", "A" }, "x", "x")]
    [DataRow("a", new string[] { "ab", "a" }, "x", "a")]
    [DataRow("a", new string[] { "a", "a", "a", "a", "a", "a", "a" }, "x", "a")]
    [DataRow("a", new string[] { "b", "b", "b", "b", "b", "b", "b" }, "x", "x")]
    [DataRow(null, new string[] { "" }, "x", "x")]
    [DataRow(null, new string[] { null }, "x", null)]
    [DataTestMethod]
    public void WhenIsNotOneOf2(string value, IEnumerable<string> set, string defaultValue, string expected)
    {
        Assert.AreEqual(expected, value.WhenIsNotOneOf(set, defaultValue));
    }

    [DataRow(null, null, null)]
    [DataRow("a", null, null)]
    [DataTestMethod]
    public void WhenIsNotOneOfFail(string value, IEnumerable<string> set, string defaultValue)
    {
        try
        {
            value.WhenIsNotOneOf(set, defaultValue);

            Assert.Fail();
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Value cannot be null.", ex.Message);
        }
    }

    #endregion Public Methods
}
