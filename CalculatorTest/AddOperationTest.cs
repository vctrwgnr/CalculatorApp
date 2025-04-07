using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AddOperationPlugin;

namespace CalculatorTest
{
    [TestClass]
    public class AddOperationTest
    {
        [TestMethod]
        public void AddOperationUnitTest()
        {
            var addOperation = new AddOperation();
            double num1 = 5;
            double num2 = 5;
            double expected = 10;

            double result = addOperation.Calculate(num1, num2);

            Assert.AreEqual(expected, result);
        }
    }
}
