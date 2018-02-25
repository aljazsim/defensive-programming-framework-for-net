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
    public class IsExtensionsTest
    {
        #region Public Methods

        [DataRow(0, 0, 0, true, true)]
        [DataRow(0, 0, 0, false, false)]
        [DataRow(1, 1, 1, true, true)]
        [DataRow(-1, -1, -1, true, true)]
        [DataRow(0, -1, 1, true, true)]
        [DataRow(0, -1, 1, false, true)]
        [DataRow(98, 95, 99, true, true)]
        [DataRow(-98, -99, -95, true, true)]
        [DataRow(100, 100, 101, true, true)]
        [DataRow(101, 100, 101, true, true)]
        [DataRow(-100, -101, -100, true, true)]
        [DataRow(-101, -101, -100, true, true)]
        [DataRow(100, 100, 101, false, false)]
        [DataRow(101, 100, 101, false, false)]
        [DataRow(-100, -101, -100, false, false)]
        [DataRow(-101, -101, -100, false, false)]
        [DataTestMethod]
        public void IsBetween(int value, int valueMin, int valueMax, bool inclusive, bool expected)
        {
            Assert.AreEqual(expected, value.IsBetween(valueMin, valueMax, inclusive));
        }

        [DataRow("f", "a", "z", true, true)]
        [DataRow("a", "a", "z", true, true)]
        [DataRow("z", "a", "z", true, true)]
        [DataTestMethod]
        public void IsBetween2(string value, string valueMin, string valueMax, bool inclusive, bool expected)
        {
            Assert.AreEqual(expected, value.IsBetween(valueMin, valueMax, inclusive));
        }

        [DataRow(null, "a", "z", false, false)]
        [DataRow("a", null, "z", false, false)]
        [DataRow("a", "z", null, false, false)]
        [DataRow(null, null, null, false, false)]
        [DataTestMethod]
        public void IsBetweenFail(string value, string valueMin, string valueMax, bool inclusive, bool expected)
        {
            try
            {
                value.IsBetween(valueMin, valueMax, inclusive);

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Value cannot be null.", ex.Message);
            }
        }

        [DataTestMethod]
        public void IsBetweenFail2()
        {
            try
            {
                3.IsBetween(5, 2);

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Min value must be less than or equal to max value (min: 5, max: 2).", ex.Message);
            }
        }

        [TestMethod]
        public void IsDefault()
        {
            Assert.AreEqual(true, 0.IsDefault());
            Assert.AreEqual(false, 1.IsDefault());
            Assert.AreEqual(false, (-1).IsDefault());
            Assert.AreEqual(true, '\0'.IsDefault());
            Assert.AreEqual(false, 'a'.IsDefault());
            Assert.AreEqual(false, 'b'.IsDefault());
            Assert.AreEqual(true, StringSplitOptions.None.IsDefault());
            Assert.AreEqual(false, StringSplitOptions.RemoveEmptyEntries.IsDefault());
        }

        [DataRow(null, null, true)]
        [DataRow(null, "", false)]
        [DataRow("", "", true)]
        [DataRow("a", "a", true)]
        [DataRow("a", "b", false)]
        [DataRow("ab", "ba", false)]
        [DataRow("abc", "abc", true)]
        [DataRow("aaa", "aaa", true)]
        [DataRow("aa_a", "a_aa", false)]
        [DataTestMethod]
        public void IsEqualTo5(string value1, string value2, bool expected)
        {
            Assert.AreEqual(expected, value1.IsEqualTo(value2));
        }

        [DataRow(null, null, true)]
        [DataRow(null, 1, false)]
        [DataRow(0, 0, true)]
        [DataRow(1, 1, true)]
        [DataRow(-1, -1, true)]
        [DataRow(1, -1, false)]
        [DataRow(-1, 1, false)]
        [DataRow(456456, 456456, true)]
        [DataRow(456456, 654654, false)]
        [DataTestMethod]
        public void IsEqualTo6(int value1, int value2, bool expected)
        {
            Assert.AreEqual(expected, value1.IsEqualTo(value2));
        }

        [DataRow(0, 0, false)]
        [DataRow(1, 0, true)]
        [DataRow(0, 1, false)]
        [DataRow(0, -1, true)]
        [DataRow(1, -1, true)]
        [DataRow(-10, -11, true)]
        [DataRow(100, 101, false)]
        [DataRow(102, 101, true)]
        [DataTestMethod]
        public void IsGreaterThan(int value1, int value2, bool expected)
        {
            Assert.AreEqual(expected, value1.IsGreaterThan(value2));
        }

        [DataRow("", "", false)]
        [DataRow("a", "", true)]
        [DataRow("a", "b", false)]
        [DataRow("B", "A", true)]
        [DataRow("A", "a", true)]
        [DataRow("abc", "abcd", false)]
        [DataRow("xyz", "XY", true)]
        [DataRow("tree", "why", false)]
        [DataRow("color", "colour", false)]
        [DataTestMethod]
        public void IsGreaterThan2(string value1, string value2, bool expected)
        {
            Assert.AreEqual(expected, value1.IsGreaterThan(value2));
        }

        [DataRow("", null)]
        [DataRow(null, "")]
        [DataRow(null, null)]
        [DataTestMethod]
        public void IsGreaterThan3(string value1, string value2)
        {
            try
            {
                value1.IsGreaterThan(value2);

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Value cannot be null.", ex.Message);
            }
        }

        [DataRow(0, 0, true)]
        [DataRow(1, 0, true)]
        [DataRow(0, 1, false)]
        [DataRow(0, -1, true)]
        [DataRow(1, -1, true)]
        [DataRow(-10, -11, true)]
        [DataRow(100, 101, false)]
        [DataRow(102, 101, true)]
        [DataTestMethod]
        public void IsGreaterThanOrEqualTo(int value1, int value2, bool expected)
        {
            Assert.AreEqual(expected, value1.IsGreaterThanOrEqualTo(value2));
        }

        [DataRow("", "", true)]
        [DataRow("a", "", true)]
        [DataRow("a", "b", false)]
        [DataRow("B", "A", true)]
        [DataRow("A", "a", true)]
        [DataRow("abc", "abcd", false)]
        [DataRow("abcd", "abcd", true)]
        [DataRow("xyz", "XY", true)]
        [DataRow("tree", "why", false)]
        [DataRow("color", "colour", false)]
        [DataTestMethod]
        public void IsGreaterThanOrEqualTo2(string value1, string value2, bool expected)
        {
            Assert.AreEqual(expected, value1.IsGreaterThanOrEqualTo(value2));
        }

        [DataRow("", null)]
        [DataRow(null, "")]
        [DataRow(null, null)]
        [DataTestMethod]
        public void IsGreaterThanOrEqualTo3(string value1, string value2)
        {
            try
            {
                value1.IsGreaterThanOrEqualTo(value2);

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
        [DataRow(-1, 1, true)]
        [DataRow(-11, -10, true)]
        [DataRow(100, 101, true)]
        [DataRow(101, 102, true)]
        [DataTestMethod]
        public void IsLessThan(int value1, int value2, bool expected)
        {
            Assert.AreEqual(expected, value1.IsLessThan(value2));
        }

        [DataRow("", "", false)]
        [DataRow("a", "", false)]
        [DataRow("a", "b", true)]
        [DataRow("B", "A", false)]
        [DataRow("A", "a", false)]
        [DataRow("abc", "abcd", true)]
        [DataRow("xyz", "XY", false)]
        [DataRow("tree", "why", true)]
        [DataRow("color", "colour", true)]
        [DataTestMethod]
        public void IsLessThan2(string value1, string value2, bool expected)
        {
            Assert.AreEqual(expected, value1.IsLessThan(value2));
        }

        [DataRow("", null)]
        [DataRow(null, "")]
        [DataRow(null, null)]
        [DataTestMethod]
        public void IsLessThan3(string value1, string value2)
        {
            try
            {
                value1.IsLessThan(value2);

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Value cannot be null.", ex.Message);
            }
        }

        [DataRow(0, 0, true)]
        [DataRow(1, 0, false)]
        [DataRow(0, 1, true)]
        [DataRow(0, -1, false)]
        [DataRow(1, -1, false)]
        [DataRow(-1, 1, true)]
        [DataRow(-11, -10, true)]
        [DataRow(100, 101, true)]
        [DataRow(101, 102, true)]
        [DataTestMethod]
        public void IsLessThanOrEqualTo(int value1, int value2, bool expected)
        {
            Assert.AreEqual(expected, value1.IsLessThanOrEqualTo(value2));
        }

        [DataRow("", "", true)]
        [DataRow("a", "", false)]
        [DataRow("a", "b", true)]
        [DataRow("B", "A", false)]
        [DataRow("A", "a", false)]
        [DataRow("abc", "abcd", true)]
        [DataRow("abcd", "abcd", true)]
        [DataRow("xyz", "XY", false)]
        [DataRow("tree", "why", true)]
        [DataRow("color", "colour", true)]
        [DataTestMethod]
        public void IsLessThanOrEqualTo2(string value1, string value2, bool expected)
        {
            Assert.AreEqual(expected, value1.IsLessThanOrEqualTo(value2));
        }

        [DataRow("", null)]
        [DataRow(null, "")]
        [DataRow(null, null)]
        [DataTestMethod]
        public void IsLessThanOrEqualTo3(string value1, string value2)
        {
            try
            {
                value1.IsLessThanOrEqualTo(value2);

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Value cannot be null.", ex.Message);
            }
        }

        [DataRow(null, "", false)]
        [DataRow("", "", true)]
        [DataRow("a", "a", true)]
        [DataRow("a", "a", true)]
        [DataRow("a", "b", false)]
        [DataRow("b", "a", false)]
        [DataRow("a tree and a rock", @"^[a-z\s]+$", true)]
        [DataRow("d64af57b5bbb5c65", @"^[a-f0-9]+$", true)]
        [DataRow("353644353i345345", @"^[0-9]+$", false)]
        [DataTestMethod]
        public void IsMatch(string value, string regex, bool expected)
        {
            Assert.AreEqual(expected, value.DoesMatch(new Regex(regex)));
        }

        [TestMethod]
        public void IsMatchFail()
        {
            try
            {
                "abc".DoesMatch((Regex)null);

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Value cannot be null.", ex.Message);
            }
        }

        [DataRow(null, true)]
        [DataRow("a", false)]
        [DataTestMethod]
        public void IsNull(object value, bool expected)
        {
            Assert.AreEqual(expected, value.IsNull());
        }

        [TestMethod]
        public void IsOfSubType()
        {
            Assert.AreEqual(true, "aaa".IsSubTypeOf(typeof(string)));
            Assert.AreEqual(true, "aaa".IsSubTypeOf(typeof(IEnumerable)));
            Assert.AreEqual(true, "aaa".IsSubTypeOf(typeof(IComparable<string>)));

            Assert.AreEqual(true, 1.IsSubTypeOf(typeof(int)));
            Assert.AreEqual(true, 1.IsSubTypeOf(typeof(IEquatable<int>)));

            Assert.AreEqual(false, 1.IsSubTypeOf(typeof(string)));
            Assert.AreEqual(false, "aaa".IsSubTypeOf(typeof(int)));
            Assert.AreEqual(false, (null as string).IsSubTypeOf(typeof(int)));
        }

        [TestMethod]
        public void IsOfType()
        {
            Assert.AreEqual(true, "aaa".IsTypeOf(typeof(string)));
            Assert.AreEqual(false, "aaa".IsTypeOf(typeof(IEnumerable)));
            Assert.AreEqual(false, "aaa".IsTypeOf(typeof(IComparable<string>)));

            Assert.AreEqual(true, 1.IsTypeOf(typeof(int)));
            Assert.AreEqual(false, 1.IsTypeOf(typeof(IEquatable<int>)));

            Assert.AreEqual(false, 1.IsTypeOf(typeof(string)));
            Assert.AreEqual(false, "aaa".IsTypeOf(typeof(int)));
            Assert.AreEqual(false, (null as string).IsTypeOf(typeof(int)));
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
            Assert.AreEqual(expected, value.IsOneOf(set.ToArray()));
        }

        [TestMethod]
        public void IsTrue2()
        {
            Assert.AreEqual(true, 5.Is(x => x > 1));
            Assert.AreEqual(true, 5.Is(x => x >= 5));
            Assert.AreEqual(false, 5.Is(x => x < 0));
            Assert.AreEqual(true, "aaa".Is(x => x.Length == 3));
            Assert.AreEqual(false, "aaa".Is(x => x.IsTypeOf(typeof(decimal))));
        }

        #endregion Public Methods
    }
}
