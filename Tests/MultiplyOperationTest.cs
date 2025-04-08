using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiplyOperationPlugin;

namespace Tests
{
    public class MultiplyOperationTest
    {
        private MultiplyOperation multiplyOperation;

        [SetUp]
        public void Setup()
        {
            multiplyOperation = new MultiplyOperation();
        }
        [Test]
        public void MultiplyOperationUnitTest()
        {
            multiplyOperation = new MultiplyOperation();
            double num1 = 5;
            double num2 = 10;
            double expected = 50;
            double result = multiplyOperation.Calculate(num1, num2);
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void Test1()
        {
           

        }
    }
}
