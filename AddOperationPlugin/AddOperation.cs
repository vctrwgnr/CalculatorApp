using PluginInterface;

namespace AddOperationPlugin
{
    public class AddOperation : IPluginInterface
    {
        public string OperatorSymbol => "+";
        public double Calculate(double num1, double num2)
        {
            return num1 + num2;

        }

    }
}
