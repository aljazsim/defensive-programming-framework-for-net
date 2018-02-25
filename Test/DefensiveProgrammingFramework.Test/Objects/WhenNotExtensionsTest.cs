using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using DefensiveProgrammingFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DefensiveProgrammingFramework.Test.Objects
{
    [TestClass]
    public class WhenNotExtensionsTest
    {
        #region Public Methods

        [TestMethod]
        public void WhenIsNot()
        {
            Assert.AreEqual(5, 5.WhenIsNot(x => x > 1, 99));
            Assert.AreEqual(5, 5.WhenIsNot(x => x >= 5, 99));
            Assert.AreEqual(99, 5.WhenIsNot(x => x > 5, 99));
            Assert.AreEqual(99, 5.WhenIsNot(x => x < 0, 99));
            Assert.AreEqual("aaa", "aaa".WhenIsNot(x => x.Length == 3, "xxx"));
            Assert.AreEqual("xxx", "aaa".WhenIsNot(x => x.IsTypeOf(typeof(decimal)), "xxx"));
        }

        [DataRow(0, 0, 0, true, 99, 0)]
        [DataRow(0, 0, 0, false, 99, 99)]
        [DataRow(0, 10, 100, true, 99, 99)]
        [DataRow(0, 50, 100, true, 99, 99)]
        [DataTestMethod]
        public void WhenIsNotBetween(int value, int minValue, int maxValue, bool inclusive, int defaultValue, int expected)
        {
            Assert.AreEqual(expected, value.WhenIsNotBetween(minValue, maxValue, inclusive, defaultValue));
        }

        [DataRow("f", "a", "z", true, "xxx", "f")]
        [DataRow("a", "a", "z", true, "xxx", "a")]
        [DataRow("a", "a", "z", false, "xxx", "xxx")]
        [DataRow("z", "a", "z", true, "xxx", "z")]
        [DataRow("z", "a", "z", false, "xxx", "xxx")]
        [DataTestMethod]
        public void WhenIsNotBetween2(string value, string valueMin, string valueMax, bool inclusive, string defaultValue, string expected)
        {
            Assert.AreEqual(expected, value.WhenIsNotBetween(valueMin, valueMax, inclusive, defaultValue));
        }

        [DataRow(null, "a", "z", false, "xxx", "xxx")]
        [DataRow("a", null, "z", false, "xxx", "xxx")]
        [DataRow("a", "z", null, false, "xxx", "xxx")]
        [DataRow(null, null, null, false, "xxx", "xxx")]
        [DataTestMethod]
        public void WhenIsNotBetweenFail(string value, string valueMin, string valueMax, bool inclusive, string defaultValue, string expected)
        {
            try
            {
                value.WhenIsNotBetween(valueMin, valueMax, inclusive, defaultValue);

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Value cannot be null.", ex.Message);
            }
        }

        [DataTestMethod]
        public void WhenIsNotBetweenFail2()
        {
            try
            {
                3.WhenIsNotBetween(5, 2, false, 99);

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Min value must be less than or equal to max value (min: 5, max: 2).", ex.Message);
            }
        }

        [TestMethod]
        public void WhenIsNotDefault()
        {
            Assert.AreEqual(0, 0.WhenIsNotDefault(99));
            Assert.AreEqual(99, 1.WhenIsNotDefault(99));
            Assert.AreEqual(99, (-1).WhenIsNotDefault(99));
            Assert.AreEqual('\0', '\0'.WhenIsNotDefault('x'));
            Assert.AreEqual('x', 'a'.WhenIsNotDefault('x'));
            Assert.AreEqual('x', 'b'.WhenIsNotDefault('x'));
            Assert.AreEqual(StringSplitOptions.None, StringSplitOptions.None.WhenIsNotDefault(StringSplitOptions.RemoveEmptyEntries));
            Assert.AreEqual(StringSplitOptions.None, StringSplitOptions.RemoveEmptyEntries.WhenIsNotDefault(StringSplitOptions.None));
        }

        [DataRow(null, null, "x", null)]
        [DataRow(null, "", "x", "x")]
        [DataRow("", "", "x", "")]
        [DataRow("a", "a", "x", "a")]
        [DataRow("a", "b", "x", "x")]
        [DataRow("ab", "ba", "x", "x")]
        [DataRow("abc", "abc", "x", "abc")]
        [DataRow("aaa", "aaa", "x", "aaa")]
        [DataRow("aa_a", "a_aa", "x", "x")]
        [DataTestMethod]
        public void WhenIsNotEqualTo5(string value1, string value2, string defaultValue, string expected)
        {
            Assert.AreEqual(expected, value1.WhenIsNotEqualTo(value2, defaultValue));
        }

        [DataRow(null, null, 99, null)]
        [DataRow(null, 1, 99, 99)]
        [DataRow(0, 0, 99, 0)]
        [DataRow(1, 1, 99, 1)]
        [DataRow(-1, -1, 99, -1)]
        [DataRow(1, -1, 99, 99)]
        [DataRow(-1, 1, 99, 99)]
        [DataRow(456456, 456456, 99, 456456)]
        [DataRow(456456, 654654, 99, 99)]
        [DataTestMethod]
        public void WhenIsNotEqualTo6(int value1, int value2, int defaultValue, int expected)
        {
            Assert.AreEqual(expected, value1.WhenIsNotEqualTo(value2, defaultValue));
        }

        [DataRow(0, 0, 99, 99)]
        [DataRow(1, 0, 99, 1)]
        [DataRow(0, 1, 99, 99)]
        [DataRow(0, -1, 99, 0)]
        [DataRow(1, -1, 99, 1)]
        [DataRow(-10, -11, 99, -10)]
        [DataRow(100, 101, 99, 99)]
        [DataRow(102, 101, 99, 102)]
        [DataTestMethod]
        public void WhenIsNotGreaterThan(int value1, int value2, int defaultValue, int expected)
        {
            Assert.AreEqual(expected, value1.WhenIsNotGreaterThan(value2, defaultValue));
        }

        [DataRow("", "", "xxx", "xxx")]
        [DataRow("a", "", "xxx", "a")]
        [DataRow("a", "b", "xxx", "xxx")]
        [DataRow("B", "A", "xxx", "B")]
        [DataRow("A", "a", "xxx", "A")]
        [DataRow("abc", "abcd", "xxx", "xxx")]
        [DataRow("xyz", "XY", "xxx", "xyz")]
        [DataRow("tree", "why", "xxx", "xxx")]
        [DataRow("color", "colour", "xxx", "xxx")]
        [DataTestMethod]
        public void WhenIsNotGreaterThan2(string value1, string value2, string defaultValue, string expected)
        {
            Assert.AreEqual(expected, value1.WhenIsNotGreaterThan(value2, defaultValue));
        }

        [DataRow("", null, "x")]
        [DataRow(null, "", "x")]
        [DataRow(null, null, null)]
        [DataTestMethod]
        public void WhenIsNotGreaterThanFail(string value1, string value2, string defaultValue)
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

        [DataRow(0, 0, 99, 0)]
        [DataRow(1, 0, 99, 1)]
        [DataRow(0, 1, 99, 99)]
        [DataRow(0, -1, 99, 0)]
        [DataRow(1, -1, 99, 1)]
        [DataRow(-10, -11, 99, -10)]
        [DataRow(100, 101, 99, 99)]
        [DataRow(102, 101, 99, 102)]
        [DataTestMethod]
        public void WhenIsNotGreaterThanOrEqualTo(int value1, int value2, int defaultValue, int expected)
        {
            Assert.AreEqual(expected, value1.WhenIsNotGreaterThanOrEqualTo(value2, defaultValue));
        }

        [DataRow("", "", "x", "")]
        [DataRow("a", "", "x", "a")]
        [DataRow("a", "b", "x", "a")]
        [DataRow("B", "A", "x", "B")]
        [DataRow("A", "a", "x", "A")]
        [DataRow("abc", "abcd", "x", "x")]
        [DataRow("abcd", "abcd", "x", "abcd")]
        [DataRow("xyz", "XY", "x", "xyz")]
        [DataRow("tree", "why", "x", "tree")]
        [DataRow("color", "colour", "x", "color")]
        [DataTestMethod]
        public void WhenIsNotGreaterThanOrEqualTo2(string value1, string value2, string defaultValue, string expected)
        {
            Assert.AreEqual(expected, value1.WhenIsNotGreaterThanOrEqualTo(value2, expected));
        }

        [DataRow("", null, "a")]
        [DataRow(null, "", "b")]
        [DataRow(null, null, "c")]
        [DataTestMethod]
        public void WhenIsNotGreaterThanOrEqualToFail(string value1, string value2, string defaultValue)
        {
            try
            {
                value1.WhenIsNotGreaterThanOrEqualTo(value2, defaultValue);

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
        [DataRow(-1, 1, 99, -1)]
        [DataRow(-11, -10, 99, -11)]
        [DataRow(100, 101, 99, 100)]
        [DataRow(101, 102, 99, 101)]
        [DataTestMethod]
        public void WhenIsNotLessThan(int value1, int value2, int defaultValue, int expected)
        {
            Assert.AreEqual(expected, value1.WhenIsNotLessThan(value2, defaultValue));
        }

        [DataRow("", "", "x", "x")]
        [DataRow("a", "", "x", "x")]
        [DataRow("a", "b", "x", "a")]
        [DataRow("B", "A", "x", "x")]
        [DataRow("A", "a", "x", "x")]
        [DataRow("abc", "abcd", "x", "abc")]
        [DataRow("xyz", "XY", "x", "x")]
        [DataRow("tree", "why", "x", "tree")]
        [DataRow("color", "colour", "x", "color")]
        [DataTestMethod]
        public void WhenIsNotLessThan2(string value1, string value2, string defaultValue, string expected)
        {
            Assert.AreEqual(expected, value1.WhenIsNotLessThan(value2, defaultValue));
        }

        [DataRow("", null, "x")]
        [DataRow(null, "", "x")]
        [DataRow(null, null, "x")]
        [DataTestMethod]
        public void WhenIsNotLessThanFail(string value1, string value2, string defaultValue)
        {
            try
            {
                value1.WhenIsNotLessThan(value2, defaultValue);

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Value cannot be null.", ex.Message);
            }
        }

        [DataRow(0, 0, 99, 0)]
        [DataRow(1, 0, 99, 99)]
        [DataRow(0, 1, 99, 0)]
        [DataRow(0, -1, 99, 99)]
        [DataRow(1, -1, 99, 99)]
        [DataRow(-1, 1, 99, -1)]
        [DataRow(-11, -10, 99, -11)]
        [DataRow(100, 101, 99, 100)]
        [DataRow(101, 102, 99, 101)]
        [DataTestMethod]
        public void WhenIsNotLessThanOrEqualTo(int value1, int value2, int defaultValue, int expected)
        {
            Assert.AreEqual(expected, value1.WhenIsNotLessThanOrEqualTo(value2, defaultValue));
        }

        [DataRow("", "", "x", "")]
        [DataRow("a", "", "x", "x")]
        [DataRow("a", "b", "x", "a")]
        [DataRow("B", "A", "x", "x")]
        [DataRow("A", "a", "x", "x")]
        [DataRow("abc", "abcd", "x", "abc")]
        [DataRow("abcd", "abcd", "x", "abcd")]
        [DataRow("xyz", "XY", "x", "x")]
        [DataRow("tree", "why", "x", "tree")]
        [DataRow("color", "colour", "x", "color")]
        [DataTestMethod]
        public void WhenIsNotLessThanOrEqualTo2(string value1, string value2, string defaultValue, string expected)
        {
            Assert.AreEqual(expected, value1.WhenIsNotLessThanOrEqualTo(value2, defaultValue));
        }

        [DataRow("", null, "x")]
        [DataRow(null, "", "x")]
        [DataRow(null, null, "x")]
        [DataTestMethod]
        public void WhenIsNotLessThanOrEqualToFail(string value1, string value2, string defaultValue)
        {
            try
            {
                value1.WhenIsNotLessThanOrEqualTo(value2, defaultValue);

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Value cannot be null.", ex.Message);
            }
        }

        [DataRow(null, "", "x", "x")]
        [DataRow("", "", "x", "")]
        [DataRow("a", "a", "x", "a")]
        [DataRow("a", "a", "x", "a")]
        [DataRow("a", "b", "x", "x")]
        [DataRow("b", "a", "x", "x")]
        [DataRow("a tree and a rock", @"^[a-z\s]+$", "x", "a tree and a rock")]
        [DataRow("d64af57b5bbb5c65", @"^[a-f0-9]+$", "x", "d64af57b5bbb5c65")]
        [DataRow("353644353i345345", @"^[0-9]+$", "x", "x")]
        [DataTestMethod]
        public void WhenIsNotMatch(string value, string regex, string defaultValue, string expected)
        {
            Assert.AreEqual(expected, value.WhenDoesNotMatch(new Regex(regex), defaultValue));
        }

        [TestMethod]
        public void WhenIsNotMatchFail()
        {
            try
            {
                "abc".WhenDoesNotMatch((Regex)null, "xyz");

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Value cannot be null.", ex.Message);
            }
        }

        [DataRow(null, false, null)]
        [DataRow("a", "x", "x")]
        [DataTestMethod]
        public void WhenIsNotNull(object value, object defaultValue, object expected)
        {
            Assert.AreEqual(expected, value.WhenIsNotNull(defaultValue));
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
            Assert.AreEqual(expected, value.WhenIsNotOneOf(set.ToArray(), defaultValue));
        }

        [DataRow("", new string[] { }, "x", "x")]
        [DataRow("", new string[] { "" }, null, "")]
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
            Assert.AreEqual(expected, value.WhenIsNotOneOf(set.ToArray(), defaultValue));
        }

        [TestMethod]
        public void WhenIsNotSubTypeOf()
        {
            Assert.AreEqual("aaa", "aaa".WhenIsNotSubTypeOf(typeof(string), "x"));
            Assert.AreEqual("aaa", "aaa".WhenIsNotSubTypeOf(typeof(IEnumerable), "x"));
            Assert.AreEqual("aaa", "aaa".WhenIsNotSubTypeOf(typeof(IComparable<string>), "x"));

            Assert.AreEqual(1, 1.WhenIsNotSubTypeOf(typeof(int), 99));
            Assert.AreEqual(1, 1.WhenIsNotSubTypeOf(typeof(IEquatable<int>), 99));

            Assert.AreEqual(99, 1.WhenIsNotSubTypeOf(typeof(string), 99));
            Assert.AreEqual("x", "aaa".WhenIsNotSubTypeOf(typeof(int), "x"));
            Assert.AreEqual("x", (null as string).WhenIsNotSubTypeOf(typeof(int), "x"));
        }

        [TestMethod]
        public void WhenTypeOf()
        {
            Assert.AreEqual("aaa", "aaa".WhenIsNotTypeOf(typeof(string), null));
            Assert.AreEqual(null, "aaa".WhenIsNotTypeOf(typeof(int), null));
            Assert.AreEqual("xxx", "aaa".WhenIsNotTypeOf(typeof(IEnumerable), "xxx"));
            Assert.AreEqual(null, "aaa".WhenIsNotTypeOf(typeof(IComparable<string>), null));

            Assert.AreEqual(1, 1.WhenIsNotTypeOf(typeof(int), 99));
            Assert.AreEqual(99, 1.WhenIsNotTypeOf(typeof(IEquatable<int>), 99));

            Assert.AreEqual(99, 1.WhenIsNotTypeOf(typeof(string), 99));
            Assert.AreEqual("xxx", "aaa".WhenIsNotTypeOf(typeof(int), "xxx"));
            Assert.AreEqual("xxx", (null as string).WhenIsNotTypeOf(typeof(int), "xxx"));
        }

        #endregion Public Methods
    }
}
