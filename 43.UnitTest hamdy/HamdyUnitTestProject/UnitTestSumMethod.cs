using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestSample;

namespace HamdyUnitTestProject
{
    [TestClass]
    public class UnitTestSumMethod
    {
        [TestMethod]
        public void TestNormalInputs()
        {
            // arrange
            int firstNumber = 3;
            int secondNumber = 4;
            int expected = 7;

            // act
            int actual = Program.Sum(firstNumber, secondNumber);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestNegativeFirstNumber()
        {
            // arrange
            int firstNumber = -3;
            int secondNumber = 4;
            int expected = 1;

            // act
            int actual = Program.Sum(firstNumber, secondNumber);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestNegativeSecondNumber()
        {
            // arrange
            int firstNumber = 3;
            int secondNumber = -4;
            int expected = -1;

            // act
            int actual = Program.Sum(firstNumber, secondNumber);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestZeroParameter()
        {
            // arrange
            int firstNumber = 0;
            int secondNumber = 4;
            int expected = 4;

            // act
            int actual = Program.Sum(firstNumber, secondNumber);

            // assert
            Assert.AreEqual(expected, actual);
        }

    }
}
