using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using test_automated_code_test;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Class1 c = new Class1();
            c.FirstName = "Ahmad";
            c.LastName = "Ezzat";

            string expected = "Ahmad, Ezzat";
            string actual = c.FullName;
            Assert.AreEqual(expected, actual);

        }
    }
}
