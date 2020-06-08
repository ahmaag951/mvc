using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mvc_template.Controllers;

namespace mvc_template.test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCreateRandomPasswordMethod()
        {
            // Arrange
            string password = "Ac@123";
            int length = 6;
            
            // Actual
            var generatedPassword = Helper.CreateRandomPassword(length);

            // Assert
            Assert.AreEqual(length, generatedPassword.Length);
            Assert.AreEqual(generatedPassword.Any(char.IsUpper), true);
            Assert.AreEqual(generatedPassword.Any(char.IsLower), true);
            Assert.AreEqual(password.Any(char.IsNumber), true);
            
        }
    }
}
