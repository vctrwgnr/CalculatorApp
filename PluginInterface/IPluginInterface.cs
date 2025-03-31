namespace PluginInterface
{
    public interface IPluginInterface
    {
        string OperatorSymbol { get; } 
        double Calculate(double num1, double num2);

    }
}
