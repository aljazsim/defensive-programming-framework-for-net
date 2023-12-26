using System.Collections;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DefensiveProgrammingFramework.Test;

[TestClass]
public class ObjectWhenExtensionsTest
{
    #region Public Methods

    [TestMethod]
    public void WhenIs()
    {
        Assert.AreEqual(99, 5.WhenIs(x => x > 1, 99));
        Assert.AreEqual(99, 5.WhenIs(x => x >= 5, 99));
        Assert.AreEqual(5, 5.WhenIs(x => x > 5, 99));
        Assert.AreEqual(5, 5.WhenIs(x => x < 0, 99));
        Assert.AreEqual("xxx", "aaa".WhenIs(x => x.Length == 3, "xxx"));
        Assert.AreEqual("aaa", "aaa".WhenIs(x => x.IsTypeOf(typeof(decimal)), "xxx"));
    }

    [DataRow(0, 0, 0, true, 99, 99)]
    [DataRow(0, 0, 0, false, 99, 0)]
    [DataRow(0, 10, 100, true, 99, 0)]
    [DataRow(0, 50, 100, true, 99, 0)]
    [DataTestMethod]
    public void WhenIsBetween(int value, int minValue, int maxValue, bool inclusive, int defaultValue, int expected)
    {
        Assert.AreEqual(expected, value.WhenIsBetween(minValue, maxValue, inclusive, defaultValue));
    }

    [DataRow("f", "a", "z", true, "xxx", "xxx")]
    [DataRow("a", "a", "z", true, "xxx", "xxx")]
    [DataRow("a", "a", "z", false, "xxx", "a")]
    [DataRow("z", "a", "z", true, "xxx", "xxx")]
    [DataRow("z", "a", "z", false, "xxx", "z")]
    [DataTestMethod]
    public void WhenIsBetween2(string value, string valueMin, string valueMax, bool inclusive, string defaultValue, string expected)
    {
        Assert.AreEqual(expected, value.WhenIsBetween(valueMin, valueMax, inclusive, defaultValue));
    }

    [DataRow(null, "a", "z", false, "xxx", "xxx")]
    [DataRow("a", null, "z", false, "xxx", "xxx")]
    [DataRow("a", "z", null, false, "xxx", "xxx")]
    [DataRow(null, null, null, false, "xxx", "xxx")]
    [DataTestMethod]
    public void WhenIsBetweenFail(string value, string valueMin, string valueMax, bool inclusive, string defaultValue, string expected)
    {
        try
        {
            value.WhenIsBetween(valueMin, valueMax, inclusive, defaultValue);

            Assert.Fail();
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Value cannot be null.", ex.Message);
        }
    }

    [DataTestMethod]
    public void WhenIsBetweenFail2()
    {
        try
        {
            3.WhenIsBetween(5, 2, false, 99);

            Assert.Fail();
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Min value must be less than or equal to max value (min: 5, max: 2).", ex.Message);
        }
    }

    [TestMethod]
    public void WhenIsDefault()
    {
        Assert.AreEqual(99, 0.WhenIsDefault(99));
        Assert.AreEqual(1, 1.WhenIsDefault(99));
        Assert.AreEqual(-1, (-1).WhenIsDefault(99));
        Assert.AreEqual('x', '\0'.WhenIsDefault('x'));
        Assert.AreEqual('a', 'a'.WhenIsDefault('x'));
        Assert.AreEqual('b', 'b'.WhenIsDefault('x'));
        Assert.AreEqual(StringSplitOptions.RemoveEmptyEntries, StringSplitOptions.None.WhenIsDefault(StringSplitOptions.RemoveEmptyEntries));
        Assert.AreEqual(StringSplitOptions.RemoveEmptyEntries, StringSplitOptions.RemoveEmptyEntries.WhenIsDefault(StringSplitOptions.None));
    }

    [DataRow(null, null, "x", "x")]
    [DataRow(null, "", "x", null)]
    [DataRow("", "", "x", "x")]
    [DataRow("a", "a", "x", "x")]
    [DataRow("a", "b", "x", "a")]
    [DataRow("ab", "ba", "x", "ab")]
    [DataRow("abc", "abc", "x", "x")]
    [DataRow("aaa", "aaa", "x", "x")]
    [DataRow("aa_a", "a_aa", "x", "aa_a")]
    [DataTestMethod]
    public void WhenIsEqualTo5(string value1, string value2, string defaultValue, string expected)
    {
        Assert.AreEqual(expected, value1.WhenIsEqualTo(value2, defaultValue));
    }

    [DataRow(null, null, 99, 99)]
    [DataRow(null, 1, 99, null)]
    [DataRow(0, 0, 99, 99)]
    [DataRow(1, 1, 99, 99)]
    [DataRow(-1, -1, 99, 99)]
    [DataRow(1, -1, 99, 1)]
    [DataRow(-1, 1, 99, -1)]
    [DataRow(456456, 456456, 99, 99)]
    [DataRow(456456, 654654, 99, 456456)]
    [DataTestMethod]
    public void WhenIsEqualTo6(int value1, int value2, int defaultValue, int expected)
    {
        Assert.AreEqual(expected, value1.WhenIsEqualTo(value2, defaultValue));
    }

    [DataRow(0, 0, 99, 0)]
    [DataRow(1, 0, 99, 99)]
    [DataRow(0, 1, 99, 0)]
    [DataRow(0, -1, 99, 99)]
    [DataRow(1, -1, 99, 99)]
    [DataRow(-10, -11, 99, 99)]
    [DataRow(100, 101, 99, 100)]
    [DataRow(102, 101, 99, 99)]
    [DataTestMethod]
    public void WhenIsGreaterThan(int value1, int value2, int defaultValue, int expected)
    {
        Assert.AreEqual(expected, value1.WhenIsGreaterThan(value2, defaultValue));
    }

    [DataRow("", "", "xxx", "")]
    [DataRow("a", "", "xxx", "xxx")]
    [DataRow("a", "b", "xxx", "a")]
    [DataRow("B", "A", "xxx", "xxx")]
    [DataRow("A", "a", "xxx", "xxx")]
    [DataRow("abc", "abcd", "xxx", "abc")]
    [DataRow("xyz", "XY", "xxx", "xxx")]
    [DataRow("tree", "why", "xxx", "tree")]
    [DataRow("color", "colour", "xxx", "color")]
    [DataTestMethod]
    public void WhenIsGreaterThan2(string value1, string value2, string defaultValue, string expected)
    {
        Assert.AreEqual(expected, value1.WhenIsGreaterThan(value2, defaultValue));
    }

    [DataRow("", null, "x")]
    [DataRow(null, "", "x")]
    [DataRow(null, null, null)]
    [DataTestMethod]
    public void WhenIsGreaterThanFail(string value1, string value2, string defaultValue)
    {
        try
        {
            value1.WhenIsNotGreaterThan(value2, defaultValue);

            Assert.Fail();
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Value cannot be null.", ex.Message);
        }
    }

    [DataRow(0, 0, 99, 99)]
    [DataRow(1, 0, 99, 99)]
    [DataRow(0, 1, 99, 0)]
    [DataRow(0, -1, 99, 99)]
    [DataRow(1, -1, 99, 99)]
    [DataRow(-10, -11, 99, 99)]
    [DataRow(100, 101, 99, 100)]
    [DataRow(102, 101, 99, 99)]
    [DataTestMethod]
    public void WhenIsGreaterThanOrEqualTo(int value1, int value2, int defaultValue, int expected)
    {
        Assert.AreEqual(expected, value1.WhenIsGreaterThanOrEqualTo(value2, defaultValue));
    }

    [DataRow("", "", "x", "x")]
    [DataRow("a", "", "x", "x")]
    [DataRow("a", "b", "x", "a")]
    [DataRow("B", "A", "x", "x")]
    [DataRow("A", "a", "x", "x")]
    [DataRow("abc", "abcd", "x", "abc")]
    [DataRow("abcd", "abcd", "x", "x")]
    [DataRow("xyz", "XY", "x", "x")]
    [DataRow("tree", "why", "x", "tree")]
    [DataRow("color", "colour", "x", "color")]
    [DataTestMethod]
    public void WhenIsGreaterThanOrEqualTo2(string value1, string value2, string defaultValue, string expected)
    {
        Assert.AreEqual(expected, value1.WhenIsGreaterThanOrEqualTo(value2, expected));
    }

    [DataRow("", null, "a")]
    [DataRow(null, "", "b")]
    [DataRow(null, null, "c")]
    [DataTestMethod]
    public void WhenIsGreaterThanOrEqualToFail(string value1, string value2, string defaultValue)
    {
        try
        {
            value1.WhenIsGreaterThanOrEqualTo(value2, defaultValue);

            Assert.Fail();
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Value cannot be null.", ex.Message);
        }
    }

    [DataRow(0, 0, 99, 0)]
    [DataRow(1, 0, 99, 1)]
    [DataRow(0, 1, 99, 99)]
    [DataRow(0, -1, 99, 0)]
    [DataRow(1, -1, 99, 1)]
    [DataRow(-1, 1, 99, 99)]
    [DataRow(-11, -10, 99, 99)]
    [DataRow(100, 101, 99, 99)]
    [DataRow(101, 102, 99, 99)]
    [DataTestMethod]
    public void WhenIsLessThan(int value1, int value2, int defaultValue, int expected)
    {
        Assert.AreEqual(expected, value1.WhenIsLessThan(value2, defaultValue));
    }

    [DataRow("", "", "x", "")]
    [DataRow("a", "", "x", "a")]
    [DataRow("a", "b", "x", "x")]
    [DataRow("B", "A", "x", "B")]
    [DataRow("A", "a", "x", "A")]
    [DataRow("abc", "abcd", "x", "x")]
    [DataRow("xyz", "XY", "x", "xyz")]
    [DataRow("tree", "why", "x", "x")]
    [DataRow("color", "colour", "x", "x")]
    [DataTestMethod]
    public void WhenIsLessThan2(string value1, string value2, string defaultValue, string expected)
    {
        Assert.AreEqual(expected, value1.WhenIsLessThan(value2, defaultValue));
    }

    [DataRow("", null, "x")]
    [DataRow(null, "", "x")]
    [DataRow(null, null, "x")]
    [DataTestMethod]
    public void WhenIsLessThanFail(string value1, string value2, string defaultValue)
    {
        try
        {
            value1.WhenIsLessThan(value2, defaultValue);

            Assert.Fail();
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Value cannot be null.", ex.Message);
        }
    }

    [DataRow(0, 0, 99, 99)]
    [DataRow(1, 0, 99, 1)]
    [DataRow(0, 1, 99, 99)]
    [DataRow(0, -1, 99, 0)]
    [DataRow(1, -1, 99, 1)]
    [DataRow(-1, 1, 99, 99)]
    [DataRow(-11, -10, 99, 99)]
    [DataRow(100, 101, 99, 99)]
    [DataRow(101, 102, 99, 99)]
    [DataTestMethod]
    public void WhenIsLessThanOrEqualTo(int value1, int value2, int defaultValue, int expected)
    {
        Assert.AreEqual(expected, value1.WhenIsLessThanOrEqualTo(value2, defaultValue));
    }

    [DataRow("", "", "x", "x")]
    [DataRow("a", "", "x", "a")]
    [DataRow("a", "b", "x", "x")]
    [DataRow("B", "A", "x", "B")]
    [DataRow("A", "a", "x", "A")]
    [DataRow("abc", "abcd", "x", "x")]
    [DataRow("abcd", "abcd", "x", "x")]
    [DataRow("xyz", "XY", "x", "xyz")]
    [DataRow("tree", "why", "x", "x")]
    [DataRow("color", "colour", "x", "x")]
    [DataTestMethod]
    public void WhenIsLessThanOrEqualTo2(string value1, string value2, string defaultValue, string expected)
    {
        Assert.AreEqual(expected, value1.WhenIsLessThanOrEqualTo(value2, defaultValue));
    }

    [DataRow("", null, "x")]
    [DataRow(null, "", "x")]
    [DataRow(null, null, "x")]
    [DataTestMethod]
    public void WhenIsLessThanOrEqualToFail(string value1, string value2, string defaultValue)
    {
        try
        {
            value1.WhenIsLessThanOrEqualTo(value2, defaultValue);

            Assert.Fail();
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Value cannot be null.", ex.Message);
        }
    }

    [DataRow(null, "", "x", null)]
    [DataRow("", "", "x", "x")]
    [DataRow("a", "a", "x", "x")]
    [DataRow("a", "a", "x", "x")]
    [DataRow("a", "b", "x", "a")]
    [DataRow("b", "a", "x", "b")]
    [DataRow("a tree and a rock", @"^[a-z\s]+$", "x", "x")]
    [DataRow("d64af57b5bbb5c65", @"^[a-f0-9]+$", "x", "x")]
    [DataRow("353644353i345345", @"^[0-9]+$", "x", "353644353i345345")]
    [DataTestMethod]
    public void WhenIsMatch(string value, string regex, string defaultValue, string expected)
    {
        Assert.AreEqual(expected, value.WhenDoesMatch(new Regex(regex), defaultValue));
    }

    [TestMethod]
    public void WhenIsMatchFail()
    {
        try
        {
            "abc".WhenDoesMatch(null, "xyz");

            Assert.Fail();
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Value cannot be null.", ex.Message);
        }
    }

    [DataRow(null, false, false)]
    [DataRow("a", "x", "a")]
    [DataTestMethod]
    public void WhenIsNull(object value, object defaultValue, object expected)
    {
        Assert.AreEqual(expected, value.WhenIsNull(defaultValue));
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
        Assert.AreEqual(expected, value.WhenIsOneOf(set.ToArray(), defaultValue));
    }

    [DataRow("", new string[] { }, "x", "")]
    [DataRow("", new string[] { "" }, null, null)]
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
        Assert.AreEqual(expected, value.WhenIsOneOf(set.ToArray(), defaultValue));
    }

    [TestMethod]
    public void WhenIsSubTypeOf()
    {
        Assert.AreEqual("x", "aaa".WhenIsSubTypeOf(typeof(string), "x"));
        Assert.AreEqual("x", "aaa".WhenIsSubTypeOf(typeof(IEnumerable), "x"));
        Assert.AreEqual("x", "aaa".WhenIsSubTypeOf(typeof(IComparable<string>), "x"));

        Assert.AreEqual(99, 1.WhenIsSubTypeOf(typeof(int), 99));
        Assert.AreEqual(99, 1.WhenIsSubTypeOf(typeof(IEquatable<int>), 99));

        Assert.AreEqual(1, 1.WhenIsSubTypeOf(typeof(string), 99));
        Assert.AreEqual("aaa", "aaa".WhenIsSubTypeOf(typeof(int), "x"));
        Assert.AreEqual(null, (null as string).WhenIsSubTypeOf(typeof(int), "x"));
    }

    [TestMethod]
    public void WhenTypeOf()
    {
        Assert.AreEqual(null, "aaa".WhenIsTypeOf(typeof(string), null));
        Assert.AreEqual("aaa", "aaa".WhenIsTypeOf(typeof(int), null));
        Assert.AreEqual("aaa", "aaa".WhenIsTypeOf(typeof(IEnumerable), "xxx"));
        Assert.AreEqual("aaa", "aaa".WhenIsTypeOf(typeof(IComparable<string>), null));

        Assert.AreEqual(99, 1.WhenIsTypeOf(typeof(int), 99));
        Assert.AreEqual(1, 1.WhenIsTypeOf(typeof(IEquatable<int>), 99));

        Assert.AreEqual(1, 1.WhenIsTypeOf(typeof(string), 99));
        Assert.AreEqual("aaa", "aaa".WhenIsTypeOf(typeof(int), "xxx"));
        Assert.AreEqual(null, (null as string).WhenIsTypeOf(typeof(int), "xxx"));
    }

    #endregion Public Methods
}
