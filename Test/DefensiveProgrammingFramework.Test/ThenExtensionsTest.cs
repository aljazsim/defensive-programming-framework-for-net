using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DefensiveProgrammingFramework.Test
{
    [TestClass]
    public class ThenExtensionsTest
    {
        #region Public Methods

        [TestMethod]
        public void Then()
        {
            true.Then(() => Assert.AreEqual(true, true));
            false.Then(() => Assert.Fail());
        }

        [TestMethod]
        public void ThenFail()
        {
            try
            {
                true.Then(null);

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
