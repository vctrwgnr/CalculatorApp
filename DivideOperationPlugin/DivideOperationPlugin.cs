using PluginInterface;

namespace DivideOperationPlugin
{
    public class DivideOperationPlugin : IPluginInterface
    {
        public string OperatorSymbol => "/";
        public double Calculate(double num1, double num2)
        {

            if (num2 == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }
            return num1 / num2;
        }

    }
}
