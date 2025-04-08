using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubtractOperationPlugin;

namespace Tests
{
    public class SubtractOperationTest
    {
        private SubtractOperation subtractOperation;
        [SetUp]
        public void Setup()
        {
            subtractOperation = new SubtractOperation();
        }
        [Test]
        public void SubtractOperationUnitTest()
        {
            double num1 = 10;
            double num2 = 5;
            double expected = 5;
            double result = subtractOperation.Calculate(num1, num2);
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void Test1()
        {

        }
    }
}
