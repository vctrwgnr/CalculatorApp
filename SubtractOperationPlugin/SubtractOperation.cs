using PluginInterface;

namespace SubtractOperationPlugin
{
    [OperationMetadataAttribute(
        Name = "Subtraction",
        Description = "Subtracts two numbers",
        Aliases = new[] { "sub", "minus", "difference" }
    )]
    public class SubtractOperation : IPluginInterface
    {
        public string OperatorSymbol => "-";
        public double Calculate(double num1, double num2)
        {
            return num1 - num2;
        }

    }
}
