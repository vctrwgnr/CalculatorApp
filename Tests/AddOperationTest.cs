using AddOperationPlugin;

namespace Tests
{
    public class AddOperationTest
    {
        private AddOperation addOperation;
        [SetUp]
        public void Setup()
        {
            addOperation = new AddOperation();
        }
        [Test]
        public void AddOperationUnitTest()
        {
            
            double num1 = 5;
            double num2 = 10;
            double expected = 15;
            double result = addOperation.Calculate(num1, num2);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Test1()
        {
           
            
        }
    }
}