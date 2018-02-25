using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DefensiveProgrammingFramework.Test.Objects
{
    [TestClass]
    public class MustExtensionsTest

    {
        #region Public Methods

        [DataRow("aaa")]
        [DataRow(1)]
        [DataRow(Math.PI)]
        [DataTestMethod]
        public void MustBeBe(object value)
        {
            Assert.AreSame(value, value.MustBe(x => true));
        }

        [DataRow(1, 1, 1, true)]
        [DataRow(0, 0, 1, true)]
        [DataRow(1, 1, 3, true)]
        [DataRow(1, 1, 3, true)]
        [DataRow(2, 1, 3, false)]
        [DataRow(3, 1, 3, true)]
        [DataRow(4, 1, 4, true)]
        [DataRow("a", "a", "a", true)]
        [DataRow("b", "a", "b", true)]
        [DataRow("a", "a", "b", true)]
        [DataRow("b", "a", "c", true)]
        [DataRow("b", "a", "c", false)]
        [DataRow("c", "a", "c", true)]
        [DataRow("d", "a", "d", true)]
        [DataRow("d", "a", "f", false)]
        [DataRow("b", "a", "c", false)]
        [DataTestMethod]
        public void MustBeBetween(IComparable value, IComparable min, IComparable max, bool inclusive)
        {
            Assert.AreSame(value, value.MustBeBetween(min, max, inclusive));
        }

        [DataRow(1, 1, 1, false)]
        [DataRow(1, 1, 3, false)]
        [DataRow(3, 1, 3, false)]
        [DataRow(0, 1, 3, true)]
        [DataRow(4, 1, 3, true)]
        [DataRow("", "a", "a", true)]
        [DataRow("d", "a", "c", true)]
        [DataRow("d", "a", "c", true)]
        [DataRow("", "a", "c", true)]
        [DataTestMethod]
        public void MustBeBetweenFail(IComparable value, IComparable min, IComparable max, bool inclusive)
        {
            try
            {
                value.MustBeBetween(min, max, inclusive);

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual($"Value must be between {min} and {max}.", ex.Message);
            }
        }

        [TestMethod]
        public void MustBeDefault()
        {
            Assert.AreEqual(0, 0.MustBeDefault());
            Assert.AreEqual('\0', '\0'.MustBeDefault());
            Assert.AreEqual(StringSplitOptions.None, StringSplitOptions.None.MustBeDefault());
        }

        [TestMethod]
        public void MustBeDefaultFail()
        {
            try
            {
                1.MustBeDefault();

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Value must be equal to 0.", ex.Message);
            }

            try
            {
                'x'.MustBeDefault();

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Value must be equal to \0.", ex.Message);
            }

            try
            {
                StringSplitOptions.RemoveEmptyEntries.MustBeDefault();

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Value must be equal to None.", ex.Message);
            }
        }

        [DataRow(null, null)]
        [DataRow("a", "a")]
        [DataRow(1, 1)]
        [DataTestMethod]
        public void MustBeEqualTo(IComparable value1, IComparable value2)
        {
            Assert.AreSame(value1, value1.MustBeEqualTo(value2));
        }

        [DataRow(null, "a")]
        [DataRow("a", "b")]
        [DataRow(1, 2)]
        [DataTestMethod]
        public void MustBeEqualToFail(IComparable value1, IComparable value2)
        {
            try
            {
                value1.MustBeEqualTo(value2);

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual($"Value must be equal to {value2}.", ex.Message);
            }
        }

        [DataRow("aaa")]
        [DataRow(1)]
        [DataRow(Math.PI)]
        [DataTestMethod]
        public void MustBeFail(object value)
        {
            try
            {
                value.MustBe(x => false);

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Expression must be true.", ex.Message);
            }
        }

        [DataRow("c", "a")]
        [DataRow("b", "a")]
        [DataRow(1, -11)]
        [DataRow(2, 1)]
        [TestMethod]
        public void MustBeGreaterThan(IComparable value, IComparable minValue)
        {
            Assert.AreSame(value, value.MustBeGreaterThan(minValue));
        }

        [DataRow(null, "a")]
        [DataRow("b", null)]
        [DataRow("a", "b")]
        [DataRow("", "x")]
        [DataRow(0, 1)]
        [DataRow(-1, 1)]
        [DataTestMethod]
        public void MustBeGreaterThanFail(IComparable value, IComparable minValue)
        {
            try
            {
                value.MustBeGreaterThan(minValue);

                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("Value cannot be null.", ex.Message);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual($"Value must be greater than {minValue}.", ex.Message);
            }
        }

        [DataRow("b", "a")]
        [DataRow("a", "a")]
        [DataRow(3, 1)]
        [DataRow(2, 1)]
        [DataRow(1, 1)]
        [TestMethod]
        public void MustBeGreaterThanOrEqualTo(IComparable value, IComparable minValue)
        {
            Assert.AreSame(value, value.MustBeGreaterThanOrEqualTo(minValue));
        }

        [DataRow(null, "a")]
        [DataRow("b", null)]
        [DataRow("a", "b")]
        [DataRow("b", "c")]
        [DataRow(0, 1)]
        [DataRow(-1, 1)]
        [DataTestMethod]
        public void MustBeGreaterThanOrEqualToFail(IComparable value, IComparable minValue)
        {
            try
            {
                value.MustBeGreaterThanOrEqualTo(minValue);

                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("Value cannot be null.", ex.Message);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual($"Value must be greater than or equal to {minValue}.", ex.Message);
            }
        }

        [DataRow("", "a")]
        [DataRow("a", "b")]
        [DataRow(1, 2)]
        [DataRow(-1, 1)]
        [TestMethod]
        public void MustBeLessThan(IComparable value, IComparable maxValue)
        {
            Assert.AreSame(value, value.MustBeLessThan(maxValue));
        }

        [DataRow(null, "a")]
        [DataRow("b", null)]
        [DataRow("b", "b")]
        [DataRow("x", "a")]
        [DataRow(1, 0)]
        [DataRow(1, 1)]
        [DataRow(1, -1)]
        [DataTestMethod]
        public void MustBeLessThanFail(IComparable value, IComparable maxValue)
        {
            try
            {
                value.MustBeLessThan(maxValue);

                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("Value cannot be null.", ex.Message);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual($"Value must be less than {maxValue}.", ex.Message);
            }
        }

        [DataRow("a", "a")]
        [DataRow("a", "b")]
        [DataRow("a", "c")]
        [DataRow(1, 1)]
        [DataRow(0, 1)]
        [DataRow(-1, 1)]
        [TestMethod]
        public void MustBeLessThanOrEqualTo(IComparable value, IComparable minValue)
        {
            Assert.AreSame(value, value.MustBeLessThanOrEqualTo(minValue));
        }

        [DataRow(null, "a")]
        [DataRow("b", null)]
        [DataRow("b", "a")]
        [DataRow("c", "b")]
        [DataRow(1, 0)]
        [DataRow(1, -1)]
        [DataTestMethod]
        public void MustBeLessThanOrEqualToFail(IComparable value, IComparable maxValue)
        {
            try
            {
                value.MustBeLessThanOrEqualTo(maxValue);

                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("Value cannot be null.", ex.Message);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual($"Value must be less than or equal to {maxValue}.", ex.Message);
            }
        }

        [DataRow(null)]
        [DataTestMethod]
        public void MustBeNull(object value)
        {
            Assert.AreSame(value, value.MustBeNull());
        }

        [DataRow("a")]
        [DataRow(1)]
        [DataTestMethod]
        public void MustBeNullFail(object value)
        {
            try
            {
                value.MustBeNull();

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual($"Value must be null.", ex.Message);
            }
        }

        [DataRow("a", typeof(string))]
        [DataRow(1, typeof(int))]
        [DataRow(Math.PI, typeof(double))]
        [TestMethod]
        public void MustBeOfType(object value, Type type)
        {
            Assert.AreSame(value, value.MustBeTypeOf(type));
        }

        [DataRow(null, typeof(string))]
        [DataRow("a", null)]
        [DataRow("a", typeof(int))]
        [DataRow(1, typeof(double))]
        [DataRow(Math.PI, typeof(IEnumerable))]
        [DataTestMethod]
        public void MustBeOfTypeFail(object value, Type type)
        {
            try
            {
                value.MustBeTypeOf(type);

                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("Value cannot be null.", ex.Message);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual($"Value must be of type {type.Name}.", ex.Message);
            }
        }

        [TestMethod]
        public void MustBeOneOf()
        {
            Assert.AreEqual(1, 1.MustBeOneOf(1, 2, 3, 4));
            Assert.AreEqual(2, 2.MustBeOneOf(1, 2, 3, 4));
            Assert.AreEqual(3, 3.MustBeOneOf(1, 2, 3, 4));
            Assert.AreEqual(4, 4.MustBeOneOf(1, 2, 3, 4));
            Assert.AreEqual("aa", "aa".MustBeOneOf("a", "aa", "aaa"));
        }

        [TestMethod]
        public void MustBeOneOfFail()
        {
            try
            {
                5.MustBeOneOf(0, 1, 2, 3, 4);

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Value must be one of [0, 1, 2, 3, 4].", ex.Message);
            }

            try
            {
                "a".MustBeOneOf(null);

                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("Value cannot be null.", ex.Message);
            }
        }

        [DataRow("a", typeof(string))]
        [DataRow(Math.PI, typeof(double))]
        [TestMethod]
        public void MustBeSubTypeOf(object value, Type type)
        {
            Assert.AreSame(value, value.MustBeSubTypeOf(type));
        }

        [DataRow(null, typeof(string))]
        [DataRow("a", null)]
        [DataRow("a", typeof(int))]
        [DataRow(5, typeof(IEnumerable))]
        [DataRow(1, typeof(double))]
        [DataRow(1, typeof(IEnumerable<char>))]
        [DataTestMethod]
        public void MustBeSubTypeOfFail(object value, Type type)
        {
            try
            {
                value.MustBeSubTypeOf(type);

                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("Value cannot be null.", ex.Message);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual($"Value must be subtype of {type.Name}.", ex.Message);
            }
        }

        [DataRow("a", "a")]
        [DataRow("b", "b")]
        [DataRow("b", "[ab]")]
        [DataRow("a tree and a rock", @"^[a-z\s]+$")]
        [DataRow("d64af57b5bbb5c65", @"^[a-z0-9]+$")]
        [DataTestMethod]
        public void MustMatch(string value, string regex)
        {
            Assert.AreSame(value, value.MustMatch(new Regex(regex)));
        }

        [TestMethod]
        public void MustMatchFail()
        {
            try
            {
                (null as string).MustMatch(new Regex(@"^[a-z]+$"));

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual($"Value must match ^[a-z]+$.", ex.Message);
            }

            try
            {
                "123".MustMatch(new Regex(@"^[a-z]+$"));

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual($"Value must match ^[a-z]+$.", ex.Message);
            }

            try
            {
                "123".MustMatch(null);

                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("Value cannot be null.", ex.Message);
            }
        }

        #endregion Public Methods
    }
}
