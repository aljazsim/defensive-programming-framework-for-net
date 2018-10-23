using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DefensiveProgrammingFramework.Test.Collections
{
    [TestClass]
    public class CannotExtensions
    {
        #region Public Methods

        [TestMethod]
        public void CannotBeEmpty()
        {
            Assert.AreEqual("a", "a".CannotBeEmpty());
            Assert.AreEqual("ab", "ab".CannotBeEmpty());
            Assert.AreEqual("abc", "abc".CannotBeEmpty());
            CollectionAssert.AreEqual(new int[] { 1 }.ToList(), new int[] { 1 }.CannotBeEmpty().ToList());
            Assert.AreEqual(null, (null as IEnumerable<string>).CannotBeEmpty());
        }

        [TestMethod]
        public void CannotBeEmptyFail()
        {
            try
            {
                "".CannotBeEmpty();

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Value cannot be empty.", ex.Message);
            }

            try
            {
                new char[] { }.CannotBeEmpty();

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Value cannot be empty.", ex.Message);
            }

            try
            {
                new int[0].CannotBeEmpty();

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Value cannot be empty.", ex.Message);
            }

            try
            {
                new int[0].CannotBeEmpty(() => throw new InvalidOperationException("Test."));

                Assert.Fail();
            }
            catch (InvalidOperationException ex)
            {
                Assert.AreEqual("Test.", ex.Message);
            }
        }

        [TestMethod]
        public void CannotBeEqualTo()
        {
            CollectionAssert.AreEqual(new int[] { 1, 2, 3 }.ToList(), new int[] { 1, 2, 3 }.ToList().CannotBeEqualTo(new int[] { 0, 1, 2, 3 }).ToList());
            CollectionAssert.AreEqual(new int[] { 'a', 'c', 'd' }.ToList(), new int[] { 'a', 'c', 'd' }.ToList().CannotBeEqualTo(new int[] { 'a', 'c', 'b' }).ToList());
        }

        [TestMethod]
        public void CannotBeEqualToFail()
        {
            try
            {
                new int[] { 1, 2, 3 }.ToList().CannotBeEqualTo(new int[] { 1, 2, 3 });

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual($"Value cannot be equal to [1, 2, 3].", ex.Message);
            }

            try
            {
                new int[] { 3, 1, 2 }.ToList().CannotBeEqualTo(new int[] { 1, 2, 3 }, true);

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual($"Value cannot be equal to [1, 2, 3].", ex.Message);
            }

            try
            {
                new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }.ToList().CannotBeEqualTo(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 });

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual($"Value cannot be equal to [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, ...].", ex.Message);
            }

            try
            {
                new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }.ToList().CannotBeEqualTo(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }, false, () => throw new InvalidOperationException("Test."));

                Assert.Fail();
            }
            catch (InvalidOperationException ex)
            {
                Assert.AreEqual("Test.", ex.Message);
            }
        }

        [DataRow("a")]
        [DataRow(new char[] { 'a' })]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
        [DataTestMethod]
        public void CannotBeNullOrEmpty(IEnumerable value)
        {
            Assert.AreSame(value, value.CannotBeNullOrEmpty());
        }

        [DataRow(null)]
        [DataRow("")]
        [DataRow(new char[] { })]
        [DataRow(new int[0])]
        [DataTestMethod]
        public void CannotBeNullOrEmptyFail(IEnumerable value)
        {
            try
            {
                value.CannotBeNullOrEmpty();

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Value cannot be null or empty.", ex.Message);
            }

            try
            {
                value.CannotBeNullOrEmpty(() => throw new InvalidOperationException("Test."));

                Assert.Fail();
            }
            catch (InvalidOperationException ex)
            {
                Assert.AreEqual("Test.", ex.Message);
            }
        }

        [TestMethod]
        public void CannotBeOneOf()
        {
            Assert.AreEqual(1, 1.CannotBeOneOf(new int[] { 0, 2, 3 }.ToList()));
            Assert.AreEqual("aaa", "aaa".CannotBeOneOf(new string[] { "a", "aa", "aaaa" }.ToList()));
        }

        [TestMethod]
        public void CannotBeOneOfFail()
        {
            try
            {
                1.CannotBeOneOf(new int[] { 0, 1, 2, 3, 4 }.ToList());

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Value cannot be one of [0, 1, 2, 3, 4].", ex.Message);
            }

            try
            {
                "a".CannotBeOneOf(null as IEnumerable<string>);

                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("Value cannot be null.", ex.Message);
            }

            try
            {
                1.CannotBeOneOf(new int[] { 0, 1, 2, 3, 4 }.ToList(), () => throw new InvalidOperationException("Test."));

                Assert.Fail();
            }
            catch (InvalidOperationException ex)
            {
                Assert.AreEqual("Test.", ex.Message);
            }
        }

        [TestMethod]
        public void CannotContain()
        {
            CollectionAssert.AreEqual(new int[] { 1, 2, 3 }.ToList(), new int[] { 1, 2, 3 }.ToList().CannotContain(x => x >= 4).ToList());
            CollectionAssert.AreEqual(new char[] { 'a', 'b', 'c' }.ToList(), new char[] { 'a', 'b', 'c' }.ToList().CannotContain(x => x == 'x').ToList());
        }

        [TestMethod]
        public void CannotContainDuplicates()
        {
            Assert.AreEqual(null, (null as List<string>).CannotContainDuplicates());
            CollectionAssert.AreEqual(new int[] { 1, 2, 3 }.ToList(), new int[] { 1, 2, 3 }.ToList().CannotContainDuplicates().ToList());
            CollectionAssert.AreEqual(new char[] { 'a', 'b', 'c' }.ToList(), new char[] { 'a', 'b', 'c' }.ToList().CannotContainDuplicates().ToList());
        }

        [TestMethod]
        public void CannotContainDuplicatesFail()
        {
            try
            {
                new int[] { 1, 2, 3, 2 }.CannotContainDuplicates();

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual($"Value cannot contain duplicates.", ex.Message);
            }

            try
            {
                new int[] { 1, 2, 3, 1, 2, 3 }.CannotContainDuplicates();

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual($"Value cannot contain duplicates.", ex.Message);
            }

            try
            {
                new int[] { 1, 2, 3, 1, 2, 3 }.CannotContainDuplicates(() => throw new InvalidOperationException("Test."));

                Assert.Fail();
            }
            catch (InvalidOperationException ex)
            {
                Assert.AreEqual("Test.", ex.Message);
            }
        }

        [TestMethod]
        public void CannotContainFail()
        {
            try
            {
                new int[] { 1, 2, 3 }.CannotContain(null);

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual($"Value cannot be null.", ex.Message);
            }

            try
            {
                new int[] { 1, 2, 3 }.CannotContain(x => true);

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual($"Value cannot contain specified expression.", ex.Message);
            }

            try
            {
                new int[] { 1, 2, 3 }.CannotContain(x => true, () => throw new InvalidOperationException("Test."));

                Assert.Fail();
            }
            catch (InvalidOperationException ex)
            {
                Assert.AreEqual("Test.", ex.Message);
            }
        }

        [TestMethod]
        public void CannotContainNull()
        {
            Assert.AreEqual(null, (null as string[]).CannotContainNull());
            CollectionAssert.AreEqual(new string[] { }, new string[] { }.CannotContainNull().ToList());
            CollectionAssert.AreEqual(new string[] { "aaa", "bb", "c" }, new string[] { "aaa", "bb", "c" }.CannotContainNull().ToList());
        }

        [TestMethod]
        public void CannotContainNullFail()
        {
            try
            {
                new string[] { null }.CannotContainNull();

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Value cannot contain null.", ex.Message);
            }

            try
            {
                new string[] { "aaa", "bb", "c", null }.CannotContainNull();

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Value cannot contain null.", ex.Message);
            }

            try
            {
                new string[] { "aaa", "bb", "c", null }.CannotContainNull(() => throw new InvalidOperationException("Test."));

                Assert.Fail();
            }
            catch (InvalidOperationException ex)
            {
                Assert.AreEqual("Test.", ex.Message);
            }
        }

        [TestMethod]
        public void CannotContainOnlyNull()
        {
            Assert.AreEqual(null, (null as string[]).CannotContainOnlyNull());
            CollectionAssert.AreEqual(new string[] { }, new string[] { }.CannotContainOnlyNull().ToList());
            CollectionAssert.AreEqual(new string[] { "aaa", "bb", "c" }, new string[] { "aaa", "bb", "c" }.CannotContainOnlyNull().ToList());
            CollectionAssert.AreEqual(new string[] { "aaa", "bb", null, "c" }, new string[] { "aaa", "bb", null, "c" }.CannotContainOnlyNull().ToList());
            CollectionAssert.AreEqual(new string[] { "aaa", null, null, null }, new string[] { "aaa", null, null, null }.CannotContainOnlyNull().ToList());
        }

        [TestMethod]
        public void CannotContainOnlyNullFail()
        {
            try
            {
                new string[] { null }.CannotContainOnlyNull();

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Value cannot contain only null.", ex.Message);
            }

            try
            {
                new string[] { null, null, null }.CannotContainOnlyNull();

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Value cannot contain only null.", ex.Message);
            }

            try
            {
                new string[] { null }.CannotContainOnlyNull(() => throw new InvalidOperationException("Test."));

                Assert.Fail();
            }
            catch (InvalidOperationException ex)
            {
                Assert.AreEqual("Test.", ex.Message);
            }
        }

        #endregion Public Methods
    }
}