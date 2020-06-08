using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp1;

namespace NewUnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        /*
             ^(?=(.*\d){2})(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z\d]).{8,}$
        
            two digits anywhere
            an upper-lower case letter
            theres anything except letter or digit
            8 or more characters
            like this: P@sw0rd2
             */
        [TestMethod]
        public void TestCheckPasswordMethodOneDigitOnlyInMiddle()
        {
            // arrange
            string password = "P@ssw0rd";

            // act
            bool result = Program.CheckPassword(password);

            // assert
            Assert.AreEqual(result, false);
        }

        [TestMethod]
        public void TestCheckPasswordMethodOneDigitOnlyInStart()
        {
            // arrange
            string password = "0P@sswrd";

            // act
            bool result = Program.CheckPassword(password);

            // assert
            Assert.AreEqual(result, false);
        }

        [TestMethod]
        public void TestCheckPasswordMethodOneDigitOnlyInEnd()
        {
            // arrange
            string password = "P@sswrd0";

            // act
            bool result = Program.CheckPassword(password);

            // assert
            Assert.AreEqual(result, false);
        }

        [TestMethod]
        public void TestCheckPasswordMethodNoUpperCases()
        {
            // arrange
            string password = "p@ssw0rd2";

            // act
            bool result = Program.CheckPassword(password);

            // assert
            Assert.AreEqual(result, false);
        }

        [TestMethod]
        public void TestCheckPasswordMethodNoAnythingNotLetterOrDigits()
        {
            // In other words, sympols
            // arrange
            string password = "Pssw0rd2";

            // act
            bool result = Program.CheckPassword(password);

            // assert
            Assert.AreEqual(result, false);
        }

        [TestMethod]
        public void TestCheckPasswordMethodEightOrMoreCharacters()
        {
            // In other words, sympols
            // arrange
            string password = "P@s0rd2";

            // act
            bool result = Program.CheckPassword(password);

            // assert
            Assert.AreEqual(result, false);
        }
    }
}
