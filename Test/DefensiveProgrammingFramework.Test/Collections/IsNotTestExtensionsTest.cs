using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DefensiveProgrammingFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DefensiveProgrammingFramework.Test.Collections
{
    [TestClass]
    public class IsNotNotTestExtensionsTest
    {
        #region Public Methods

        [TestMethod]
        public void ContainsNot()
        {
            Assert.AreEqual(true, (null as string[]).ContainsNot(x => x == null));
            Assert.AreEqual(true, new string[] { }.ContainsNot(x => x == null));
            Assert.AreEqual(false, new string[] { null }.ContainsNot(x => x == null));
            Assert.AreEqual(true, new string[] { "aaa" }.ContainsNot(x => x == null));
            Assert.AreEqual(true, new string[] { "aaa", "bb", "c" }.ContainsNot(x => x == null));
            Assert.AreEqual(false, new string[] { null, "aaa", "bb", "c" }.ContainsNot(x => x == null));
            Assert.AreEqual(false, new string[] { "aaa", null, "bb", "c" }.ContainsNot(x => x == null));
            Assert.AreEqual(false, new string[] { "aaa", "bb", null, "c" }.ContainsNot(x => x == null));
            Assert.AreEqual(false, new string[] { "aaa", "bb", "c", null }.ContainsNot(x => x == null));
            Assert.AreEqual(false, new string[] { null, null, null }.ContainsNot(x => x == null));
        }

        [TestMethod]
        public void ContainsNotDuplicates()
        {
            Assert.AreEqual(true, (null as string[]).ContainsNotDuplicates());
            Assert.AreEqual(true, new string[] { }.ContainsNotDuplicates());
            Assert.AreEqual(true, new string[] { null }.ContainsNotDuplicates());
            Assert.AreEqual(false, new string[] { null, null }.ContainsNotDuplicates());
            Assert.AreEqual(true, new string[] { "aaa" }.ContainsNotDuplicates());
            Assert.AreEqual(true, new string[] { "aaa", "bb", "c" }.ContainsNotDuplicates());
            Assert.AreEqual(false, new string[] { "aaa", "bb", "aaa" }.ContainsNotDuplicates());
            Assert.AreEqual(false, new string[] { null, "aaa", null, "c" }.ContainsNotDuplicates());
            Assert.AreEqual(false, new string[] { null, null, null }.ContainsNotDuplicates());
        }

        [TestMethod]
        public void ContainsNotNull()
        {
            Assert.AreEqual(true, (null as string[]).ContainsNotNull());
            Assert.AreEqual(true, new string[] { }.ContainsNotNull());
            Assert.AreEqual(false, new string[] { null }.ContainsNotNull());
            Assert.AreEqual(true, new string[] { "aaa" }.ContainsNotNull());
            Assert.AreEqual(true, new string[] { "aaa", "bb", "c" }.ContainsNotNull());
            Assert.AreEqual(false, new string[] { null, "aaa", "bb", "c" }.ContainsNotNull());
            Assert.AreEqual(false, new string[] { "aaa", null, "bb", "c" }.ContainsNotNull());
            Assert.AreEqual(false, new string[] { "aaa", "bb", null, "c" }.ContainsNotNull());
            Assert.AreEqual(false, new string[] { "aaa", "bb", "c", null }.ContainsNotNull());
            Assert.AreEqual(false, new string[] { null, null, null }.ContainsNotNull());
        }

        [TestMethod]
        public void ContainsNotOnlyNull()
        {
            Assert.AreEqual(true, (null as IEnumerable<string>).ContainsNotOnlyNull());
            Assert.AreEqual(true, new string[] { }.ContainsNotOnlyNull());
            Assert.AreEqual(false, new string[] { null }.ContainsNotOnlyNull());
            Assert.AreEqual(true, new string[] { "aaa" }.ContainsNotOnlyNull());
            Assert.AreEqual(true, new string[] { "aaa", "bb", "c" }.ContainsNotOnlyNull());
            Assert.AreEqual(true, new string[] { null, "aaa", "bb", "c" }.ContainsNotOnlyNull());
            Assert.AreEqual(true, new string[] { "aaa", null, "bb", "c" }.ContainsNotOnlyNull());
            Assert.AreEqual(true, new string[] { "aaa", "bb", null, "c" }.ContainsNotOnlyNull());
            Assert.AreEqual(true, new string[] { "aaa", "bb", "c", null }.ContainsNotOnlyNull());
            Assert.AreEqual(false, new string[] { null, null, null }.ContainsNotOnlyNull());
        }

        [TestMethod]
        public void IsNotEmpty()
        {
            Assert.AreEqual(false, "".IsNotEmpty());
            Assert.AreEqual(true, "a".IsNotEmpty());
            Assert.AreEqual(true, "ab".IsNotEmpty());
            Assert.AreEqual(true, "abc".IsNotEmpty());
            Assert.AreEqual(false, new int[] { }.IsNotEmpty());
            Assert.AreEqual(true, new int[] { 1 }.IsNotEmpty());
            Assert.AreEqual(true, (null as IEnumerable<string>).IsNotEmpty());
        }

        [DataRow("", "", false, false)]
        [DataRow(" ", " ", false, false)]
        [DataRow(" ", "  ", false, true)]
        [DataRow(" ", " \\t", false, true)]
        [DataRow("a", "a", false, false)]
        [DataRow("aa", "aa", false, false)]
        [DataRow("aa", "a", false, true)]
        [DataRow("ab", "ab", false, false)]
        [DataRow("ab", "ba", true, false)]
        [DataRow("ab", "ba", false, true)]
        [DataRow("abc", "abc", true, false)]
        [DataRow("abc", "abc", false, false)]
        [DataRow("abc", "bac", true, false)]
        [DataRow("abc", "acb", true, false)]
        [DataRow("abd", "cba", true, true)]
        [DataRow("abc", "bcad", true, true)]
        [DataRow("", null, false, true)]
        [DataRow(null, "", false, true)]
        [DataRow(null, null, false, false)]
        [DataRow(null, null, true, false)]
        [DataTestMethod]
        public void IsNotEqualTo(IEnumerable<char> value1, IEnumerable<char> value2, bool ignoreOrder, bool expected)
        {
            Assert.AreEqual(expected, value1.IsNotEqualTo(value2, ignoreOrder));
        }

        [DataRow(new string[] { null }, new string[] { null }, true, false)]
        [DataRow(new string[] { null }, new string[] { null }, false, false)]
        [DataRow(new string[] { null, null }, new string[] { null, null }, true, false)]
        [DataRow(new string[] { null, null }, new string[] { null, null }, false, false)]
        [DataRow(new string[] { null, "aaa" }, new string[] { null, "aaa" }, false, false)]
        [DataRow(new string[] { null, "aaa" }, new string[] { "aaa", null }, true, false)]
        [DataRow(new string[] { "bbb", "aaa" }, new string[] { "bbb", "aaa" }, true, false)]
        [DataRow(new string[] { "bbb", "aaa" }, new string[] { "aaa", "bbb" }, true, false)]
        [DataTestMethod]
        public void IsNotEqualTo3(IEnumerable<string> value1, IEnumerable<string> value2, bool ignoreOrder, bool expected)
        {
            Assert.AreEqual(expected, value1.IsNotEqualTo(value2, ignoreOrder));
        }

        [DataRow(new int[0], new int[0], false, false)]
        [DataRow(new int[] { 1 }, new int[] { 1 }, true, false)]
        [DataRow(new int[] { 1, 1 }, new int[] { 1, 1 }, false, false)]
        [DataRow(new int[] { 1 }, new int[] { 1, 1 }, true, true)]
        [DataRow(new int[] { 0, 9, 8, 7, 6, 5, 4, 3, 2, 1 }, new int[] { 7, 8, 9, 6, 5, 4, 1, 0, 2, 3 }, true, false)]
        [DataTestMethod]
        public void IsNotEqualTo4(IEnumerable<int> value1, IEnumerable<int> value2, bool ignoreOrder, bool expected)
        {
            Assert.AreEqual(expected, value1.IsNotEqualTo(value2, ignoreOrder));
        }

        [DataRow(null, false)]
        [DataRow("", false)]
        [DataRow("a", true)]
        [DataRow(new int[] { }, false)]
        [DataRow(new int[] { 1 }, true)]
        [DataRow(new int[] { 1, 2 }, true)]
        [DataRow(new int[] { 1, 2, 3 }, true)]
        [DataTestMethod]
        public void IsNotNullOrEmpty(IEnumerable value, bool expected)
        {
            Assert.AreEqual(expected, value.IsNotNullOrEmpty());
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
            Assert.AreEqual(expected, value.IsNotOneOf(set));
            Assert.AreEqual(expected, value.IsNotOneOf(set.ToArray()));
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
        public void IsNotOneOf2(string value, IEnumerable<string> set, bool expected)
        {
            Assert.AreEqual(expected, value.IsNotOneOf(set));
        }

        [DataRow(null, null)]
        [DataRow("a", null)]
        [DataTestMethod]
        public void IsNotOneOfFail(string value, IEnumerable<string> set)
        {
            try
            {
                value.IsNotOneOf(set);

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Value cannot be null.", ex.Message);
            }
        }

        #endregion Public Methods
    }
}
