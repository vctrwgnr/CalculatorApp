using BYTES.NET.Primitives;
using BYTES.NET.Extensibility;
using PluginInterface;
using System;
using System.Linq;

namespace CalculatorApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var manager = new ExtensionsManager<IPluginInterface>();

            
            manager.Update(new[] { @"..\..\..\..\Plugins\*.dll" });

            Console.Write("Enter calculation (e.g. 5+3): ");
            var operators = manager.Extensions.Select(p => p.Value().OperatorSymbol).ToArray();

            Console.WriteLine("Available operations: " + string.Join(", ", operators));
            Console.Write("Enter calculation (e.g., 5+3): ");
            string input = Console.ReadLine()?.Trim();

            var parts = input.ParseKeyValue(new[] { '+', '-', '*', '/' });
            var num1 = double.Parse(parts.Key);
            var num2 = double.Parse(parts.Value);
            var usedOperator = input.FirstOrDefault(c => operators.Contains(c.ToString()));

            if (usedOperator == default(char))
            {
                Console.WriteLine("Invalid operator. Please use one of: " + string.Join(", ", operators));
                return;
            }

            
            var plugin = manager.Extensions.FirstOrDefault(p => p.Value().OperatorSymbol == usedOperator.ToString())?.Value();

            if (plugin == null)
            {
                Console.WriteLine($"Operator '{usedOperator}' not supported.");
                return;
            }

            double result = plugin.Calculate(num1, num2);
            Console.WriteLine($"= {result}\n");
            Console.ReadLine();
        }
    }
}
