using PluginInterface;

namespace ModuloOperationPlugin
{
    public class ModuloOperation : IPluginInterface
    {
        public string OperatorSymbol => "%";
        public double Calculate(double num1, double num2)
        {
            return num1 % num2;

        }

    }
}
