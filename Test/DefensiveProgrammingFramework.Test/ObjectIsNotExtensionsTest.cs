using System.Collections;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DefensiveProgrammingFramework.Test;

[TestClass]
public class ObjectIsNotNotExtensionsTest
{
    #region Public Methods

    [DataRow(0, 0, 0, false, true)]
    [DataRow(0, 0, 0, true, false)]
    [DataRow(1, 1, 1, true, false)]
    [DataRow(1, 1, 1, false, true)]
    [DataRow(-1, -1, -1, true, false)]
    [DataRow(0, -1, 1, true, false)]
    [DataRow(0, -1, 1, false, false)]
    [DataRow(98, 95, 99, true, false)]
    [DataRow(-98, -99, -95, false, false)]
    [DataRow(100, 100, 101, true, false)]
    [DataRow(101, 100, 101, false, true)]
    [DataRow(-100, -101, -100, false, true)]
    [DataRow(-101, -101, -100, true, false)]
    [DataRow(1000, 100, 101, false, true)]
    [DataRow(101, -1000, -10, false, true)]
    [DataRow(-100, -101, -100, false, true)]
    [DataRow(100, 1, 10, false, true)]
    [DataTestMethod]
    public void IsNotBetween(int value, int minValue, int maxValue, bool inclusive, bool expected)
    {
        Assert.AreEqual(expected, value.IsNotBetween(minValue, maxValue, inclusive));
    }

    [DataRow("f", "a", "z", true, false)]
    [DataRow("a", "a", "z", false, true)]
    [DataRow("z", "a", "b", true, true)]
    [DataTestMethod]
    public void IsNotBetween2(string value, string valueMin, string valueMax, bool inclusive, bool expected)
    {
        Assert.AreEqual(expected, value.IsNotBetween(valueMin, valueMax, inclusive));
    }

    [DataRow(null, "a", "z", false, false)]
    [DataRow("a", null, "z", false, false)]
    [DataRow("a", "z", null, false, false)]
    [DataRow(null, null, null, false, false)]
    [DataTestMethod]
    public void IsNotBetween3(string value, string valueMin, string valueMax, bool inclusive, bool expected)
    {
        try
        {
            Assert.AreEqual(expected, value.IsNotBetween(valueMin, valueMax, inclusive));

            Assert.Fail();
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Value cannot be null.", ex.Message);
        }
    }

    [TestMethod]
    public void IsNotDefault()
    {
        Assert.AreEqual(false, 0.IsNotDefault());
        Assert.AreEqual(true, 1.IsNotDefault());
        Assert.AreEqual(true, (-1).IsNotDefault());
        Assert.AreEqual(false, '\0'.IsNotDefault());
        Assert.AreEqual(true, 'a'.IsNotDefault());
        Assert.AreEqual(true, 'b'.IsNotDefault());
        Assert.AreEqual(false, StringSplitOptions.None.IsNotDefault());
        Assert.AreEqual(true, StringSplitOptions.RemoveEmptyEntries.IsNotDefault());
    }

    [DataRow(null, null, false)]
    [DataRow(null, "", true)]
    [DataRow("", "", false)]
    [DataRow("a", "a", false)]
    [DataRow("a", "b", true)]
    [DataRow("ab", "ba", true)]
    [DataRow("abc", "abc", false)]
    [DataRow("aaa", "aaa", false)]
    [DataRow("aa_a", "a_aa", true)]
    [DataTestMethod]
    public void IsNotEqualTo5(string value1, string value2, bool expected)
    {
        Assert.AreEqual(expected, value1.IsNotEqualTo(value2));
    }

    [DataRow(null, null, false)]
    [DataRow(null, 1, true)]
    [DataRow(0, 0, false)]
    [DataRow(1, 1, false)]
    [DataRow(-1, -1, false)]
    [DataRow(1, -1, true)]
    [DataRow(-1, 1, true)]
    [DataRow(456456, 456456, false)]
    [DataRow(456456, 654654, true)]
    [DataTestMethod]
    public void IsNotEqualTo6(int value1, int value2, bool expected)
    {
        Assert.AreEqual(expected, value1.IsNotEqualTo(value2));
    }

    [DataRow(0, 0, true)]
    [DataRow(1, 0, false)]
    [DataRow(0, 1, true)]
    [DataRow(0, -1, false)]
    [DataRow(1, -1, false)]
    [DataRow(-10, -11, false)]
    [DataRow(100, 101, true)]
    [DataRow(102, 101, false)]
    [DataTestMethod]
    public void IsNotGreaterThan(int value, int minValue, bool expected)
    {
        Assert.AreEqual(expected, value.IsNotGreaterThan(minValue));
    }

    [DataRow("", "", true)]
    [DataRow("a", "", false)]
    [DataRow("a", "b", true)]
    [DataRow("B", "A", false)]
    [DataRow("A", "a", false)]
    [DataRow("abc", "abcd", true)]
    [DataRow("xyz", "XY", false)]
    [DataRow("tree", "why", true)]
    [DataRow("color", "colour", true)]
    [DataTestMethod]
    public void IsNotGreaterThan2(string value, string minValue, bool expected)
    {
        Assert.AreEqual(expected, value.IsNotGreaterThan(minValue));
    }

    [DataRow("", null)]
    [DataRow(null, "")]
    [DataRow(null, null)]
    [DataTestMethod]
    public void IsNotGreaterThan3(string value1, string value2)
    {
        try
        {
            value1.IsNotGreaterThan(value2);

            Assert.Fail();
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Value cannot be null.", ex.Message);
        }
    }

    [DataRow(0, 0, false)]
    [DataRow(1, 0, false)]
    [DataRow(0, 1, true)]
    [DataRow(0, -1, false)]
    [DataRow(1, -1, false)]
    [DataRow(-10, -11, false)]
    [DataRow(100, 101, true)]
    [DataRow(102, 101, false)]
    [DataTestMethod]
    public void IsNotGreaterThanOrEqualTo(int value1, int value2, bool expected)
    {
        Assert.AreEqual(expected, value1.IsNotGreaterThanOrEqualTo(value2));
    }

    [DataRow("", "", false)]
    [DataRow("a", "", false)]
    [DataRow("a", "b", true)]
    [DataRow("B", "A", false)]
    [DataRow("A", "a", false)]
    [DataRow("abc", "abcd", true)]
    [DataRow("abcd", "abcd", false)]
    [DataRow("xyz", "XY", false)]
    [DataRow("tree", "why", true)]
    [DataRow("color", "colour", true)]
    [DataTestMethod]
    public void IsNotGreaterThanOrEqualTo2(string value, string minValue, bool expected)
    {
        Assert.AreEqual(expected, value.IsNotGreaterThanOrEqualTo(minValue));
    }

    [DataRow("", null)]
    [DataRow(null, "")]
    [DataRow(null, null)]
    [DataTestMethod]
    public void IsNotGreaterThanOrEqualTo3(string value1, string value2)
    {
        try
        {
            value1.IsNotGreaterThanOrEqualTo(value2);

            Assert.Fail();
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Value cannot be null.", ex.Message);
        }
    }

    [DataRow("", new string[] { }, true)]
    [DataRow("", new string[] { "" }, false)]
    [DataRow("a", new string[] { "a" }, false)]
    [DataRow("a", new string[] { "a", "b" }, false)]
    [DataRow("a", new string[] { "ab", "ba" }, true)]
    [DataRow("a", new string[] { "ab", "A" }, true)]
    [DataRow("a", new string[] { "ab", "a" }, false)]
    [DataRow("a", new string[] { "a", "a", "a", "a", "a", "a", "a" }, false)]
    [DataRow("a", new string[] { "b", "b", "b", "b", "b", "b", "b" }, true)]
    [DataRow(null, new string[] { "" }, true)]
    [DataRow(null, new string[] { null }, false)]
    [DataTestMethod]
    public void IsNotInOneOf2(string value, IEnumerable<string> set, bool expected)
    {
        Assert.AreEqual(expected, value.IsNotOneOf(set.ToArray()));
    }

    [DataRow(0, 0, true)]
    [DataRow(1, 0, true)]
    [DataRow(0, 1, false)]
    [DataRow(0, -1, true)]
    [DataRow(1, -1, true)]
    [DataRow(-1, 1, false)]
    [DataRow(-11, -10, false)]
    [DataRow(100, 101, false)]
    [DataRow(101, 102, false)]
    [DataTestMethod]
    public void IsNotLessThan(int value, int maxValue, bool expected)
    {
        Assert.AreEqual(expected, value.IsNotLessThan(maxValue));
    }

    [DataRow("", "", true)]
    [DataRow("a", "", true)]
    [DataRow("a", "b", false)]
    [DataRow("B", "A", true)]
    [DataRow("A", "a", true)]
    [DataRow("abc", "abcd", false)]
    [DataRow("xyz", "XY", true)]
    [DataRow("tree", "why", false)]
    [DataRow("color", "colour", false)]
    [DataTestMethod]
    public void IsNotLessThan2(string value1, string value2, bool expected)
    {
        Assert.AreEqual(expected, value1.IsNotLessThan(value2));
    }

    [DataRow("", null)]
    [DataRow(null, "")]
    [DataRow(null, null)]
    [DataTestMethod]
    public void IsNotLessThan3(string value1, string value2)
    {
        try
        {
            value1.IsNotLessThan(value2);

            Assert.Fail();
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Value cannot be null.", ex.Message);
        }
    }

    [DataRow(0, 0, false)]
    [DataRow(1, 0, true)]
    [DataRow(0, 1, false)]
    [DataRow(0, -1, true)]
    [DataRow(1, -1, true)]
    [DataRow(-1, 1, false)]
    [DataRow(-11, -10, false)]
    [DataRow(100, 101, false)]
    [DataRow(101, 102, false)]
    [DataTestMethod]
    public void IsNotLessThanOrEqualTo(int value1, int value2, bool expected)
    {
        Assert.AreEqual(expected, value1.IsNotLessThanOrEqualTo(value2));
    }

    [DataRow("", "", false)]
    [DataRow("a", "", true)]
    [DataRow("a", "b", false)]
    [DataRow("B", "A", true)]
    [DataRow("A", "a", true)]
    [DataRow("abc", "abcd", false)]
    [DataRow("abcd", "abcd", false)]
    [DataRow("xyz", "XY", true)]
    [DataRow("tree", "why", false)]
    [DataRow("color", "colour", false)]
    [DataTestMethod]
    public void IsNotLessThanOrEqualTo2(string value1, string value2, bool expected)
    {
        Assert.AreEqual(expected, value1.IsNotLessThanOrEqualTo(value2));
    }

    [DataRow("", null)]
    [DataRow(null, "")]
    [DataRow(null, null)]
    [DataTestMethod]
    public void IsNotLessThanOrEqualTo3(string value1, string value2)
    {
        try
        {
            value1.IsNotLessThanOrEqualTo(value2);

            Assert.Fail();
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Value cannot be null.", ex.Message);
        }
    }

    [DataRow(null, "", true)]
    [DataRow("", "", false)]
    [DataRow("a", "a", false)]
    [DataRow("a", "a", false)]
    [DataRow("a", "b", true)]
    [DataRow("b", "a", true)]
    [DataRow("a tree and a rock", @"^[a-z\s]+$", false)]
    [DataRow("d64af57b5bbb5c65", @"^[a-f0-9]+$", false)]
    [DataRow("353644353i345345", @"^[0-9]+$", true)]
    [DataTestMethod]
    public void IsNotMatch(string value, string regex, bool expected)
    {
        Assert.AreEqual(expected, value.DoesNotMatch(new Regex(regex)));
    }

    [TestMethod]
    public void IsNotMatchFail()
    {
        try
        {
            "abc".DoesNotMatch(null);

            Assert.Fail();
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Value cannot be null.", ex.Message);
        }
    }

    [DataRow(null, false)]
    [DataRow("a", true)]
    [DataTestMethod]
    public void IsNotNull(object value, bool expected)
    {
        Assert.AreEqual(expected, value.IsNotNull());
    }

    [TestMethod]
    public void IsNotOfSubType()
    {
        Assert.AreEqual(false, "aaa".IsNotSubTypeOf(typeof(string)));
        Assert.AreEqual(false, "aaa".IsNotSubTypeOf(typeof(IEnumerable)));
        Assert.AreEqual(false, "aaa".IsNotSubTypeOf(typeof(IComparable<string>)));

        Assert.AreEqual(false, 1.IsNotSubTypeOf(typeof(int)));
        Assert.AreEqual(false, 1.IsNotSubTypeOf(typeof(IEquatable<int>)));

        Assert.AreEqual(true, 1.IsNotSubTypeOf(typeof(string)));
        Assert.AreEqual(true, "aaa".IsNotSubTypeOf(typeof(int)));
        Assert.AreEqual(true, (null as string).IsNotSubTypeOf(typeof(int)));
    }

    [TestMethod]
    public void IsNotOfType()
    {
        Assert.AreEqual(false, "aaa".IsNotTypeOf(typeof(string)));
        Assert.AreEqual(true, "aaa".IsNotTypeOf(typeof(IEnumerable)));
        Assert.AreEqual(true, "aaa".IsNotTypeOf(typeof(IComparable<string>)));

        Assert.AreEqual(false, 1.IsNotTypeOf(typeof(int)));
        Assert.AreEqual(true, 1.IsNotTypeOf(typeof(IEquatable<int>)));

        Assert.AreEqual(true, 1.IsNotTypeOf(typeof(string)));
        Assert.AreEqual(true, "aaa".IsNotTypeOf(typeof(int)));
        Assert.AreEqual(true, (null as string).IsNotTypeOf(typeof(int)));
    }

    [DataRow(3, new int[] { }, true)]
    [DataRow(3, new int[] { 3 }, false)]
    [DataRow(3, new int[] { 2 }, true)]
    [DataRow(3, new int[] { 2, 3 }, false)]
    [DataRow(3, new int[] { 1, 2, 3, 4 }, false)]
    [DataRow(3, new int[] { 4, 3, 2, 1 }, false)]
    [DataRow(3, new int[] { 1, 1, 1, 1, 3, 1, 1, 1 }, false)]
    [DataRow(3, new int[] { 3, 3, 3, 3, 3, 3, 3 }, false)]
    [DataRow(3, new int[] { 4, 4, 4, 4, 4, 4, 4, 4 }, true)]
    [DataTestMethod]
    public void IsNotOneOf(int value, IEnumerable<int> set, bool expected)
    {
        Assert.AreEqual(expected, value.IsNotOneOf(set.ToArray()));
    }

    [TestMethod]
    public void IsNotTrue2()
    {
        Assert.AreEqual(false, 5.IsNot(x => x > 1));
        Assert.AreEqual(false, 5.IsNot(x => x >= 5));
        Assert.AreEqual(true, 5.IsNot(x => x < 0));
        Assert.AreEqual(false, "aaa".IsNot(x => x.Length == 3));
        Assert.AreEqual(false, "aaa".IsNot(x => x.IsNotTypeOf(typeof(decimal))));
    }

    #endregion Public Methods
}
