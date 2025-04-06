using PluginInterface;

namespace ModuloOperationPlugin
{
    [OperationMetadataAttribute(
        Name = "Modulo",
        Description = "Returns the remainder after division",
        Aliases = new[] { "mod", "remainder" }
    )]
    public class ModuloOperation : IPluginInterface
    {
        public string OperatorSymbol => "%";
        public double Calculate(double num1, double num2)
        {
            return num1 % num2;

        }

    }
}
