using PluginInterface;

namespace MultiplyOperationPlugin
{
    [OperationMetadataAttribute(
        Name = "Multiplication",
        Description = "Multiplies two numbers",
        Aliases = new[] { "mult", "times" }
    )]
    public class MultiplyOperation : IPluginInterface
    {
        public string OperatorSymbol => "*";
        public double Calculate(double num1, double num2)
        {
            return num1 * num2;
        }

    }
}
