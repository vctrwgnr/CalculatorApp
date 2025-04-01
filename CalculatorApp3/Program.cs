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

            while (true)
            {
                manager.Update(new[] { @"..\..\..\..\Plugins\*.dll" });

                
                var operators = manager.Extensions.Select(p => p.Value().OperatorSymbol).ToArray();

                Console.WriteLine("Available operations: " + string.Join(", ", operators));
                Console.Write("Enter calculation (e.g., 10-5): ");
                string input = Console.ReadLine()?.Trim();

                
                if (input.Contains("-")) 
                {
                    
                    string[] inputParts = input.Split("-");

                    
                    if (inputParts.Length == 2)
                    {
                        double num1, num2;

                       
                        if (double.TryParse(inputParts[0].Trim(), out num1) && double.TryParse(inputParts[1].Trim(), out num2))
                        {
                            
                            var plugin = manager.Extensions.FirstOrDefault(p => p.Value().OperatorSymbol == "-")?.Value();

                            if (plugin == null)
                            {
                                Console.WriteLine("Subtraction plugin not found.");
                                continue; 
                            }

                          
                            double result = plugin.Calculate(num1, num2);
                            Console.WriteLine($"= {result}\n");
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter valid numbers.");
                        }
                    }
           
                }
                else
                {
                   
                    var parts = input.ParseKeyValue(new[] { '+', '-', '*', '/' });
                    var num1 = double.Parse(parts.Key);
                    var num2 = double.Parse(parts.Value);
                    var usedOperator = input.FirstOrDefault(c => operators.Contains(c.ToString()));

                    if (usedOperator == default(char))
                    {
                        Console.WriteLine("Invalid operator. Please use one of: " + string.Join(", ", operators));
                        continue; 
                    }

                    
                    var plugin = manager.Extensions.FirstOrDefault(p => p.Value().OperatorSymbol == usedOperator.ToString())?.Value();

                    if (plugin == null)
                    {
                        Console.WriteLine($"Operator '{usedOperator}' not supported.");
                        continue; 
                    }

                    
                    double result = plugin.Calculate(num1, num2);
                    Console.WriteLine($"= {result}\n");
                }
            }
        }
    }
}
