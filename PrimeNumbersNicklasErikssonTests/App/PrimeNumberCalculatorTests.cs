using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrimeNumbersNicklasEriksson.App.Tests
{
    [TestClass()]
    public class PrimeNumberCalculatorTests
    {
        /// <summary>
        /// These tests should pass since all numbers are prime.
        /// Assert is set to AreEqual.
        /// </summary>
        /// <param name="value">Numbers to be checked.</param>
        [TestMethod()]
        [DataRow(2)]
        [DataRow(3)]
        [DataRow(5)]
        [DataRow(7)]
        [DataRow(11)]
        [DataRow(13)]
        [DataRow(17)]
        [DataRow(19)]
        [DataRow(23)]
        [DataRow(29)]
        public void CheckForPrimeTest(int value)
        {
            var c = new PrimeNumberCalculator();
            var result = c.CheckForPrime(value);

            Assert.AreEqual(value, result);
        }

        /// <summary>
        /// These tests should pass since they are composite numbers.
        /// Assert.AreEqual.
        /// </summary>
        /// <param name="value">Numbers to be checked.</param>
        [TestMethod()]
        [DataRow(-1)]
        [DataRow(-2)]
        [DataRow(-3)]
        [DataRow(-4)]
        [DataRow(1)]
        [DataRow(4)]
        [DataRow(6)]
        [DataRow(12)]
        public void CheckForPrimeTest2(int value)
        {
            var c = new PrimeNumberCalculator();
            var result = c.CheckForPrime(value);

            Assert.AreEqual(-1, result);
        }

        /// <summary>
        /// These tests should pass since they are not numbers.
        /// Assert.AreEqual.
        /// </summary>
        /// <param name="value">Numbers to be checked.</param>
        [TestMethod()]
        [DataRow(null)]
        [DataRow(default)]
        [DataRow(0)]
        public void CheckForPrimeTest3(int value)
        {
            var c = new PrimeNumberCalculator();
            var result = c.CheckForPrime(value);

            Assert.AreEqual(0, result);
        }
    }
}