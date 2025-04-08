using PluginInterface;

namespace DivideOperationPlugin
{
    [OperationMetadataAttribute(
        Name = "Division",
        Description = "Divides two numbers",
        Aliases = new[] { "div", "divide" }
    )]
    public class DivideOperation : IPluginInterface
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
