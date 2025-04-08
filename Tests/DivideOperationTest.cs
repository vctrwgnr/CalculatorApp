using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DivideOperationPlugin;

namespace Tests
{
    public class DivideOperationTest
    {
        private DivideOperation divideOperation;
        [SetUp]
        public void Setup()
        {
            divideOperation = new DivideOperation();
        }
        [Test]
        public void DivideOperationUnitTest()
        {
            double num1 = 10;
            double num2 = 5;
            double expected = 2;
            double result = divideOperation.Calculate(num1, num2);
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void Test1()
        {
        }
    }
}
