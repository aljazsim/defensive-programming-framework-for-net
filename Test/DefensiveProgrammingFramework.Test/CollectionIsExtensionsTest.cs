using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DefensiveProgrammingFramework.Test;

[TestClass]
public class CollectionIsExtensionsTest
{
    #region Public Methods

    [TestMethod]
    public void Contains()
    {
        Assert.AreEqual(false, (null as string[]).Contains(x => x == null));
        Assert.AreEqual(false, new string[] { }.Contains(x => x == null));
        Assert.AreEqual(true, new string[] { null }.Contains(x => x == null));
        Assert.AreEqual(false, new string[] { "aaa" }.Contains(x => x == null));
        Assert.AreEqual(false, new string[] { "aaa", "bb", "c" }.Contains(x => x == null));
        Assert.AreEqual(true, new string[] { null, "aaa", "bb", "c" }.Contains(x => x == null));
        Assert.AreEqual(true, new string[] { "aaa", null, "bb", "c" }.Contains(x => x == null));
        Assert.AreEqual(true, new string[] { "aaa", "bb", null, "c" }.Contains(x => x == null));
        Assert.AreEqual(true, new string[] { "aaa", "bb", "c", null }.Contains(x => x == null));
        Assert.AreEqual(true, new string[] { null, null, null }.Contains(x => x == null));
    }

    [TestMethod]
    public void ContainsDuplicates()
    {
        Assert.AreEqual(false, (null as string[]).ContainsDuplicates());
        Assert.AreEqual(false, new string[] { }.ContainsDuplicates());
        Assert.AreEqual(false, new string[] { null }.ContainsDuplicates());
        Assert.AreEqual(true, new string[] { null, null }.ContainsDuplicates());
        Assert.AreEqual(false, new string[] { "aaa" }.ContainsDuplicates());
        Assert.AreEqual(false, new string[] { "aaa", "bb", "c" }.ContainsDuplicates());
        Assert.AreEqual(true, new string[] { "aaa", "bb", "aaa" }.ContainsDuplicates());
        Assert.AreEqual(true, new string[] { null, "aaa", null, "c" }.ContainsDuplicates());
        Assert.AreEqual(true, new string[] { null, null, null }.ContainsDuplicates());
    }

    [TestMethod]
    public void ContainsNull()
    {
        Assert.AreEqual(false, (null as string[]).ContainsNull());
        Assert.AreEqual(false, new string[] { }.ContainsNull());
        Assert.AreEqual(true, new string[] { null }.ContainsNull());
        Assert.AreEqual(false, new string[] { "aaa" }.ContainsNull());
        Assert.AreEqual(false, new string[] { "aaa", "bb", "c" }.ContainsNull());
        Assert.AreEqual(true, new string[] { null, "aaa", "bb", "c" }.ContainsNull());
        Assert.AreEqual(true, new string[] { "aaa", null, "bb", "c" }.ContainsNull());
        Assert.AreEqual(true, new string[] { "aaa", "bb", null, "c" }.ContainsNull());
        Assert.AreEqual(true, new string[] { "aaa", "bb", "c", null }.ContainsNull());
        Assert.AreEqual(true, new string[] { null, null, null }.ContainsNull());
    }

    [TestMethod]
    public void ContainsOnlyNull()
    {
        Assert.AreEqual(false, (null as IEnumerable<string>).ContainsOnlyNull());
        Assert.AreEqual(false, new string[] { }.ContainsOnlyNull());
        Assert.AreEqual(true, new string[] { null }.ContainsOnlyNull());
        Assert.AreEqual(false, new string[] { "aaa" }.ContainsOnlyNull());
        Assert.AreEqual(false, new string[] { "aaa", "bb", "c" }.ContainsOnlyNull());
        Assert.AreEqual(false, new string[] { null, "aaa", "bb", "c" }.ContainsOnlyNull());
        Assert.AreEqual(false, new string[] { "aaa", null, "bb", "c" }.ContainsOnlyNull());
        Assert.AreEqual(false, new string[] { "aaa", "bb", null, "c" }.ContainsOnlyNull());
        Assert.AreEqual(false, new string[] { "aaa", "bb", "c", null }.ContainsOnlyNull());
        Assert.AreEqual(true, new string[] { null, null, null }.ContainsOnlyNull());
    }

    [TestMethod]
    public void IsEmpty()
    {
        Assert.AreEqual(true, "".IsEmpty());
        Assert.AreEqual(false, "a".IsEmpty());
        Assert.AreEqual(false, "ab".IsEmpty());
        Assert.AreEqual(false, "abc".IsEmpty());
        Assert.AreEqual(true, new int[] { }.IsEmpty());
        Assert.AreEqual(false, new int[] { 1 }.IsEmpty());
        Assert.AreEqual(false, (null as IEnumerable<string>).IsEmpty());
    }

    [DataRow("", "", false, true)]
    [DataRow(" ", " ", false, true)]
    [DataRow(" ", "  ", false, false)]
    [DataRow(" ", " \\t", false, false)]
    [DataRow("a", "a", false, true)]
    [DataRow("aa", "aa", false, true)]
    [DataRow("aa", "a", false, false)]
    [DataRow("ab", "ab", false, true)]
    [DataRow("ab", "ba", true, true)]
    [DataRow("ab", "ba", false, false)]
    [DataRow("abc", "abc", true, true)]
    [DataRow("abc", "abc", false, true)]
    [DataRow("abc", "bac", true, true)]
    [DataRow("abc", "acb", true, true)]
    [DataRow("abd", "cba", true, false)]
    [DataRow("abc", "bcad", true, false)]
    [DataRow("", null, false, false)]
    [DataRow(null, "", false, false)]
    [DataRow(null, null, false, true)]
    [DataRow(null, null, true, true)]
    [DataTestMethod]
    public void IsEqualTo(IEnumerable<char> value1, IEnumerable<char> value2, bool ignoreOrder, bool expected)
    {
        Assert.AreEqual(expected, value1.IsEqualTo(value2, ignoreOrder));
    }

    [DataRow(new string[] { null }, new string[] { null }, true, true)]
    [DataRow(new string[] { null }, new string[] { null }, false, true)]
    [DataRow(new string[] { null, null }, new string[] { null, null }, true, true)]
    [DataRow(new string[] { null, null }, new string[] { null, null }, false, true)]
    [DataRow(new string[] { null, "aaa" }, new string[] { null, "aaa" }, false, true)]
    [DataRow(new string[] { null, "aaa" }, new string[] { "aaa", null }, true, true)]
    [DataRow(new string[] { "bbb", "aaa" }, new string[] { "bbb", "aaa" }, true, true)]
    [DataRow(new string[] { "bbb", "aaa" }, new string[] { "aaa", "bbb" }, true, true)]
    [DataTestMethod]
    public void IsEqualTo3(IEnumerable<string> value1, IEnumerable<string> value2, bool ignoreOrder, bool expected)
    {
        Assert.AreEqual(expected, value1.IsEqualTo(value2, ignoreOrder));
    }

    [DataRow(new int[0], new int[0], false, true)]
    [DataRow(new int[] { 1 }, new int[] { 1 }, true, true)]
    [DataRow(new int[] { 1, 1 }, new int[] { 1, 1 }, false, true)]
    [DataRow(new int[] { 1 }, new int[] { 1, 1 }, true, false)]
    [DataRow(new int[] { 0, 9, 8, 7, 6, 5, 4, 3, 2, 1 }, new int[] { 7, 8, 9, 6, 5, 4, 1, 0, 2, 3 }, true, true)]
    [DataTestMethod]
    public void IsEqualTo4(IEnumerable<int> value1, IEnumerable<int> value2, bool ignoreOrder, bool expected)
    {
        Assert.AreEqual(expected, value1.IsEqualTo(value2, ignoreOrder));
    }

    [DataRow(null, true)]
    [DataRow("", true)]
    [DataRow("a", false)]
    [DataRow(new int[] { }, true)]
    [DataRow(new int[] { 1 }, false)]
    [DataRow(new int[] { 1, 2 }, false)]
    [DataRow(new int[] { 1, 2, 3 }, false)]
    [DataTestMethod]
    public void IsNullOrEmpty(IEnumerable value, bool expected)
    {
        Assert.AreEqual(expected, value.IsNullOrEmpty());
    }

    [DataRow(3, new int[] { }, false)]
    [DataRow(3, new int[] { 3 }, true)]
    [DataRow(3, new int[] { 2 }, false)]
    [DataRow(3, new int[] { 2, 3 }, true)]
    [DataRow(3, new int[] { 1, 2, 3, 4 }, true)]
    [DataRow(3, new int[] { 4, 3, 2, 1 }, true)]
    [DataRow(3, new int[] { 1, 1, 1, 1, 3, 1, 1, 1 }, true)]
    [DataRow(3, new int[] { 3, 3, 3, 3, 3, 3, 3 }, true)]
    [DataRow(3, new int[] { 4, 4, 4, 4, 4, 4, 4, 4 }, false)]
    [DataTestMethod]
    public void IsOneOf(int value, IEnumerable<int> set, bool expected)
    {
        Assert.AreEqual(expected, value.IsOneOf(set));
        Assert.AreEqual(expected, value.IsOneOf(set.ToArray()));
    }

    [DataRow("", new string[] { }, false)]
    [DataRow("", new string[] { "" }, true)]
    [DataRow("a", new string[] { "a" }, true)]
    [DataRow("a", new string[] { "a", "b" }, true)]
    [DataRow("a", new string[] { "ab", "ba" }, false)]
    [DataRow("a", new string[] { "ab", "A" }, false)]
    [DataRow("a", new string[] { "ab", "a" }, true)]
    [DataRow("a", new string[] { "a", "a", "a", "a", "a", "a", "a" }, true)]
    [DataRow("a", new string[] { "b", "b", "b", "b", "b", "b", "b" }, false)]
    [DataRow(null, new string[] { "" }, false)]
    [DataRow(null, new string[] { null }, true)]
    [DataTestMethod]
    public void IsOneOf2(string value, IEnumerable<string> set, bool expected)
    {
        Assert.AreEqual(expected, value.IsOneOf(set));
    }

    [DataRow(null, null)]
    [DataRow("a", null)]
    [DataTestMethod]
    public void IsOneOfFail(string value, IEnumerable<string> set)
    {
        try
        {
            value.IsOneOf(set);

            Assert.Fail();
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Value cannot be null.", ex.Message);
        }
    }

    #endregion Public Methods
}
