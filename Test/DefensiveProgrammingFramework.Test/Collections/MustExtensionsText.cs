using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DefensiveProgrammingFramework.Test.Collections
{
    [TestClass]
    public class MustExtensionsText
    {
        #region Public Methods

        [TestMethod]
        public void MustBeEmpty()
        {
            Assert.AreEqual(string.Empty, string.Empty.MustBeEmpty());
            CollectionAssert.AreEqual(new int[] { }.ToList(), new int[] { }.MustBeEmpty().ToList());
        }

        [TestMethod]
        public void MustBeEmptyFail()
        {
            try
            {
                (null as string).MustBeEmpty();

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Value must be empty.", ex.Message);
            }

            try
            {
                "aaa".MustBeEmpty();

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Value must be empty.", ex.Message);
            }

            try
            {
                new char[] { 'x' }.MustBeEmpty();

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Value must be empty.", ex.Message);
            }

            try
            {
                new int[] { 2, 2, 2 }.MustBeEmpty();

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Value must be empty.", ex.Message);
            }

            try
            {
                new int[] { 2, 2, 2 }.MustBeEmpty(() => throw new InvalidOperationException("Test."));

                Assert.Fail();
            }
            catch (InvalidOperationException ex)
            {
                Assert.AreEqual("Test.", ex.Message);
            }
        }

        [TestMethod]
        public void MustBeEqualTo()
        {
            CollectionAssert.AreEqual(new int[] { 1, 2, 3 }.ToList(), new int[] { 1, 2, 3 }.ToList().MustBeEqualTo(new int[] { 1, 2, 3 }).ToList());
            CollectionAssert.AreEqual(new int[] { 'a', 'c', 'd' }.ToList(), new int[] { 'a', 'c', 'd' }.ToList().MustBeEqualTo(new int[] { 'a', 'c', 'd' }).ToList());
        }

        [TestMethod]
        public void MustBeEqualToFail()
        {
            try
            {
                new int[] { 1, 2, 3 }.ToList().MustBeEqualTo(new int[] { 1, 2, 3, 4 });

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual($"Value must be equal to [1, 2, 3, 4].", ex.Message);
            }

            try
            {
                new int[] { 3, 1, 2 }.ToList().MustBeEqualTo(new int[] { 1, 2, 4 }, true);

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual($"Value must be equal to [1, 2, 4].", ex.Message);
            }

            try
            {
                new int[] { 3, 1, 2 }.ToList().MustBeEqualTo(new int[] { 1, 2, 4 }, true, () => throw new InvalidOperationException("Test."));

                Assert.Fail();
            }
            catch (InvalidOperationException ex)
            {
                Assert.AreEqual("Test.", ex.Message);
            }
        }

        [DataRow("")]
        [DataRow(new char[] { })]
        [DataRow(new int[0])]
        [DataTestMethod]
        public void MustBeNullOrEmpty(IEnumerable value)
        {
            Assert.AreSame(value, value.MustBeNullOrEmpty());
        }

        [DataRow("aa")]
        [DataRow(new char[] { 'x' })]
        [DataRow(new int[] { 1 })]
        [DataTestMethod]
        public void MustBeNullOrEmptyFail(IEnumerable value)
        {
            try
            {
                value.MustBeNullOrEmpty();

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Value must be null or empty.", ex.Message);
            }

            try
            {
                value.MustBeNullOrEmpty(() => throw new InvalidOperationException("Test."));

                Assert.Fail();
            }
            catch (InvalidOperationException ex)
            {
                Assert.AreEqual("Test.", ex.Message);
            }
        }

        [TestMethod]
        public void MustBeOneOf()
        {
            Assert.AreEqual(1, 1.MustBeOneOf(new int[] { 1, 2, 3 }.ToList()));
            Assert.AreEqual("aaa", "aaa".MustBeOneOf(new string[] { "a", "aa", "aaa" }.ToList()));
        }

        [TestMethod]
        public void MustBeOneOfFail()
        {
            try
            {
                1.MustBeOneOf(new int[] { 0, 2, 3, 4 }.ToList());

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Value must be one of [0, 2, 3, 4].", ex.Message);
            }

            try
            {
                "a".MustBeOneOf(null as IEnumerable<string>);

                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("Value cannot be null.", ex.Message);
            }

            try
            {
                1.MustBeOneOf(new int[] { 0, 2, 3, 4 }.ToList(), () => throw new InvalidOperationException("Test."));

                Assert.Fail();
            }
            catch (InvalidOperationException ex)
            {
                Assert.AreEqual("Test.", ex.Message);
            }
        }

        [TestMethod]
        public void MustContain()
        {
            CollectionAssert.AreEqual(new int[] { 1, 2, 3 }.ToList(), new int[] { 1, 2, 3 }.ToList().MustContain(x => x == 3).ToList());
            CollectionAssert.AreEqual(new char[] { 'a', 'b', 'c' }.ToList(), new char[] { 'a', 'b', 'c' }.ToList().MustContain(x => x == 'a').ToList());
        }

        [TestMethod]
        public void MustContainDuplicates()
        {
            CollectionAssert.AreEqual(new int[] { 1, 2, 1, 3 }.ToList(), new int[] { 1, 2, 1, 3 }.ToList().MustContainDuplicates().ToList());
            CollectionAssert.AreEqual(new char[] { 'a', 'b', 'c', 'c' }.ToList(), new char[] { 'a', 'b', 'c', 'c' }.ToList().MustContainDuplicates().ToList());
        }

        [TestMethod]
        public void MustContainDuplicatesFail()
        {
            try
            {
                (null as string).MustContainDuplicates();

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual($"Value must contain duplicates.", ex.Message);
            }

            try
            {
                new int[] { 1, 2, 3 }.MustContainDuplicates();

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual($"Value must contain duplicates.", ex.Message);
            }

            try
            {
                new int[] { 1, 11, 111 }.MustContainDuplicates();

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual($"Value must contain duplicates.", ex.Message);
            }

            try
            {
                new int[] { 1, 11, 111 }.MustContainDuplicates(() => throw new InvalidOperationException("Test."));

                Assert.Fail();
            }
            catch (InvalidOperationException ex)
            {
                Assert.AreEqual("Test.", ex.Message);
            }
        }

        [TestMethod]
        public void MustContainFail()
        {
            try
            {
                new int[] { 1, 2, 3 }.MustContain(null);

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual($"Value cannot be null.", ex.Message);
            }

            try
            {
                new int[] { 1, 2, 3 }.MustContain(x => false);

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual($"Value must contain specified expression.", ex.Message);
            }

            try
            {
                new int[] { 1, 2, 3 }.MustContain(x => false, () => throw new InvalidOperationException("Test."));

                Assert.Fail();
            }
            catch (InvalidOperationException ex)
            {
                Assert.AreEqual("Test.", ex.Message);
            }
        }

        [TestMethod]
        public void MustContainNull()
        {
            CollectionAssert.AreEqual(new string[] { null }, new string[] { null }.MustContainNull().ToList());
            CollectionAssert.AreEqual(new string[] { "aaa", "bb", null, "c" }, new string[] { "aaa", "bb", null, "c" }.MustContainNull().ToList());
        }

        [TestMethod]
        public void MustContainNullFail()
        {
            try
            {
                (null as string[]).MustContainNull();

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Value must contain null.", ex.Message);
            }

            try
            {
                new string[] { }.MustContainNull();

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Value must contain null.", ex.Message);
            }

            try
            {
                new string[] { "aaa", "bb", "c" }.MustContainNull();

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Value must contain null.", ex.Message);
            }

            try
            {
                new string[] { "aaa", "bb", "c" }.MustContainNull(() => throw new InvalidOperationException("Test."));

                Assert.Fail();
            }
            catch (InvalidOperationException ex)
            {
                Assert.AreEqual("Test.", ex.Message);
            }
        }

        [TestMethod]
        public void MustContainOnlyNull()
        {
            CollectionAssert.AreEqual(new string[] { null }, new string[] { null }.MustContainOnlyNull().ToList());
            CollectionAssert.AreEqual(new string[] { null, null }, new string[] { null, null }.MustContainOnlyNull().ToList());
            CollectionAssert.AreEqual(new string[] { null, null, null }, new string[] { null, null, null }.MustContainOnlyNull().ToList());
        }

        [TestMethod]
        public void MustContainOnlyNullFail()
        {
            try
            {
                (null as string[]).MustContainOnlyNull();

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Value must contain only null.", ex.Message);
            }

            try
            {
                (new string[0]).MustContainOnlyNull();

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Value must contain only null.", ex.Message);
            }

            try
            {
                new string[] { "a" }.MustContainOnlyNull();

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Value must contain only null.", ex.Message);
            }

            try
            {
                new string[] { null, "a", null }.MustContainOnlyNull();

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Value must contain only null.", ex.Message);
            }

            try
            {
                new string[] { null, "a", null }.MustContainOnlyNull(() => throw new InvalidOperationException("Test."));

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