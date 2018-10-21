using System;
using System.Collections;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DefensiveProgrammingFramework.Test.Objects
{
    [TestClass]
    public class CannotExtensions
    {
        #region Public Methods

        [DataRow("aaa")]
        [DataRow(1)]
        [DataRow(Math.PI)]
        [DataTestMethod]
        public void CannotBe(object value)
        {
            Assert.AreSame(value, value.CannotBe(x => false));
        }

        [DataRow(0, 1, 1, true)]
        [DataRow(2, 1, 1, true)]
        [DataRow(1, 1, 1, false)]
        [DataRow(0, 1, 3, true)]
        [DataRow(1, 1, 3, false)]
        [DataRow(3, 1, 3, false)]
        [DataRow(4, 1, 3, true)]
        [DataRow(4, 1, 3, false)]
        [DataRow("", "a", "a", true)]
        [DataRow("b", "a", "a", true)]
        [DataRow("a", "a", "a", false)]
        [DataRow("a", "b", "c", true)]
        [DataRow("a", "a", "c", false)]
        [DataRow("c", "a", "c", false)]
        [DataRow("d", "a", "c", true)]
        [DataRow("d", "a", "c", false)]
        [DataTestMethod]
        public void CannotBeBetween(IComparable value, IComparable min, IComparable max, bool inclusive)
        {
            Assert.AreSame(value, value.CannotBeBetween(min, max, inclusive));
        }

        [DataRow(1, 1, 1, true)]
        [DataRow(1, 1, 3, true)]
        [DataRow(2, 1, 3, true)]
        [DataRow(3, 1, 3, true)]
        [DataRow(2, 1, 3, false)]
        [DataRow("a", "a", "a", true)]
        [DataRow("a", "a", "c", true)]
        [DataRow("b", "a", "c", true)]
        [DataRow("c", "a", "c", true)]
        [DataRow("b", "a", "c", false)]
        [DataTestMethod]
        public void CannotBeBetweenFail(IComparable value, IComparable min, IComparable max, bool inclusive)
        {
            try
            {
                value.CannotBeBetween(min, max, inclusive);

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual($"Value cannot be between {min} and {max}.", ex.Message);
            }
        }

        [TestMethod]
        public void CannotBeDefault()
        {
            Assert.AreEqual(1, 1.CannotBeDefault());
            Assert.AreEqual('x', 'x'.CannotBeDefault());
            Assert.AreEqual(StringSplitOptions.RemoveEmptyEntries, StringSplitOptions.RemoveEmptyEntries.CannotBeDefault());
        }

        [TestMethod]
        public void CannotBeDefaultFail()
        {
            try
            {
                0.CannotBeDefault();

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Value cannot be equal to 0.", ex.Message);
            }

            try
            {
                '\0'.CannotBeDefault();

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Value cannot be equal to \0.", ex.Message);
            }

            try
            {
                StringSplitOptions.None.CannotBeDefault();

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Value cannot be equal to None.", ex.Message);
            }
        }

        [DataRow("a", "b")]
        [DataRow(1, 2)]
        [DataTestMethod]
        public void CannotBeEqualTo(IComparable value1, IComparable value2)
        {
            Assert.AreSame(value1, value1.CannotBeEqualTo(value2));
        }

        [DataRow(null, null)]
        [DataRow("a", "a")]
        [DataRow(1, 1)]
        [DataTestMethod]
        public void CannotBeEqualToFail(IComparable value1, IComparable value2)
        {
            try
            {
                value1.CannotBeEqualTo(value2);

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual($"Value cannot be equal to {value2}.", ex.Message);
            }
        }

        [DataRow("aaa")]
        [DataRow(1)]
        [DataRow(Math.PI)]
        [DataTestMethod]
        public void CannotBeFail(object value)
        {
            try
            {
                value.CannotBe(x => true);

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Expression cannot be true.", ex.Message);
            }
        }

        [DataRow("a", "a")]
        [DataRow("a", "b")]
        [DataRow(1, 1)]
        [DataRow(1, 2)]
        [TestMethod]
        public void CannotBeGreaterThan(IComparable value, IComparable max)
        {
            Assert.AreSame(value, value.CannotBeGreaterThan(max));
        }

        [DataRow(null, "a")]
        [DataRow("b", null)]
        [DataRow("b", "a")]
        [DataRow("x", "a")]
        [DataRow(1, 0)]
        [DataRow(1, -1)]
        [DataTestMethod]
        public void CannotBeGreaterThanFail(IComparable value, IComparable maxValue)
        {
            try
            {
                value.CannotBeGreaterThan(maxValue);

                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("Value cannot be null.", ex.Message);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual($"Value cannot be greater than {maxValue}.", ex.Message);
            }
        }

        [DataRow("a", "b")]
        [DataRow("a", "c")]
        [DataRow(1, 2)]
        [DataRow(1, 3)]
        [TestMethod]
        public void CannotBeGreaterThanOrEqualTo(IComparable value, IComparable max)
        {
            Assert.AreSame(value, value.CannotBeGreaterThanOrEqualTo(max));
        }

        [DataRow(null, "a")]
        [DataRow("b", null)]
        [DataRow("a", "a")]
        [DataRow("b", "a")]
        [DataRow(0, 0)]
        [DataRow(1, 0)]
        [DataTestMethod]
        public void CannotBeGreaterThanOrEqualToFail(IComparable value, IComparable maxValue)
        {
            try
            {
                value.CannotBeGreaterThanOrEqualTo(maxValue);

                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("Value cannot be null.", ex.Message);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual($"Value cannot be greater than or equal to {maxValue}.", ex.Message);
            }
        }

        [DataRow("a", "a")]
        [DataRow("b", "a")]
        [DataRow(1, 1)]
        [DataRow(2, 1)]
        [TestMethod]
        public void CannotBeLessThan(IComparable value, IComparable max)
        {
            Assert.AreSame(value, value.CannotBeLessThan(max));
        }

        [DataRow(null, "a")]
        [DataRow("b", null)]
        [DataRow("a", "b")]
        [DataRow("a", "x")]
        [DataRow(0, 1)]
        [DataRow(-1, 1)]
        [DataTestMethod]
        public void CannotBeLessThanFail(IComparable value, IComparable minValue)
        {
            try
            {
                value.CannotBeLessThan(minValue);

                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("Value cannot be null.", ex.Message);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual($"Value cannot be less than {minValue}.", ex.Message);
            }
        }

        [DataRow("b", "a")]
        [DataRow("c", "a")]
        [DataRow(2, 1)]
        [DataRow(3, 1)]
        [TestMethod]
        public void CannotBeLessThanOrEqualTo(IComparable value, IComparable minValue)
        {
            Assert.AreSame(value, value.CannotBeLessThanOrEqualTo(minValue));
        }

        [DataRow(null, "a")]
        [DataRow("b", null)]
        [DataRow("a", "a")]
        [DataRow("a", "b")]
        [DataRow(0, 0)]
        [DataRow(0, 1)]
        [DataTestMethod]
        public void CannotBeLessThanOrEqualToFail(IComparable value, IComparable minValue)
        {
            try
            {
                value.CannotBeLessThanOrEqualTo(minValue);

                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("Value cannot be null.", ex.Message);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual($"Value cannot be less than or equal to {minValue}.", ex.Message);
            }
        }

        [DataRow("aaa")]
        [DataRow(5)]
        [DataRow(new int[0])]
        [DataTestMethod]
        public void CannotBeNull(object value)
        {
            Assert.AreSame(value, value.CannotBeNull());
        }

        [DataRow("a", typeof(int))]
        [DataRow(null, typeof(int))]
        [DataRow(Math.PI, typeof(string))]
        [TestMethod]
        public void CannotBeOfType(object value, Type type)
        {
            Assert.AreSame(value, value.CannotBeTypeOf(type));
        }

        [DataRow("a", null)]
        [DataRow("a", typeof(string))]
        [DataRow(1, typeof(int))]
        [DataRow(Math.PI, typeof(double))]
        [DataTestMethod]
        public void CannotBeOfTypeFail(object value, Type type)
        {
            try
            {
                value.CannotBeTypeOf(type);

                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("Value cannot be null.", ex.Message);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual($"Value cannot be of type {type.Name}.", ex.Message);
            }
        }

        [TestMethod]
        public void CannotBeOneOf()
        {
            Assert.AreEqual(1, 1.CannotBeOneOf(0, 2, 3, 4));
            Assert.AreEqual("aa", "aa".CannotBeOneOf("a", "aaa", "ab"));
        }

        [TestMethod]
        public void CannotBeOneOfFail()
        {
            try
            {
                1.CannotBeOneOf(0, 1, 2, 3, 4);

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Value cannot be one of [0, 1, 2, 3, 4].", ex.Message);
            }

            try
            {
                "a".CannotBeOneOf(null);

                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("Value cannot be null.", ex.Message);
            }
        }

        [DataRow(null, typeof(string))]
        [DataRow("a", typeof(int))]
        [DataRow(Math.PI, typeof(string))]
        [TestMethod]
        public void CannotBeSubTypeOf(object value, Type type)
        {
            Assert.AreSame(value, value.CannotBeSubTypeOf(type));
        }

        [DataRow("a", null)]
        [DataRow("a", typeof(string))]
        [DataRow("a", typeof(IEnumerable))]
        [DataRow(1, typeof(int))]
        [DataRow(1, typeof(IComparable))]
        [DataTestMethod]
        public void CannotBeSubTypeOfFail(object value, Type type)
        {
            try
            {
                value.CannotBeSubTypeOf(type);

                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("Value cannot be null.", ex.Message);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual($"Value cannot be subtype of {type.Name}.", ex.Message);
            }
        }

        [DataRow(null, "a")]
        [DataRow("a", "\\.")]
        [DataRow("a", "b")]
        [DataRow("b", "a")]
        [DataRow("a tree and a rock", @"^[a-z]+$")]
        [DataRow("d64af57b5bbb5c65", @"^[0-9]+$")]
        [DataRow("353644353i345345", @"^[0-9]+$")]
        [DataTestMethod]
        public void CannotMatch(string value, string regex)
        {
            Assert.AreSame(value, value.CannotMatch(new Regex(regex)));
        }

        [TestMethod]
        public void CannotMatchFail()
        {
            try
            {
                "123".CannotMatch(new Regex(@"^[0-9]+$"));

                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual($"Value cannot match ^[0-9]+$.", ex.Message);
            }

            try
            {
                "123".CannotMatch(null);

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