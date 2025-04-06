using PluginInterface;

namespace AddOperationPlugin
{
    [OperationMetadataAttribute(
    Name = "Addition",
    Description = "Adds two numbers",
    Aliases = new[] { "add", "sum" } 
)]
    public class AddOperation : IPluginInterface
    {
        public string OperatorSymbol => "+";
        public double Calculate(double num1, double num2)
        {
            return num1 + num2;

        }

    }
}
