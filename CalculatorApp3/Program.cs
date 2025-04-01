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

            try
            {
                manager.Update(new[] { @"..\..\..\..\Plugins\*.dll" });

                var operators = manager.Extensions.Select(p => p.Value().OperatorSymbol).ToArray();
                var charOperators = operators.SelectMany(op => op.ToCharArray()).ToArray();

                Console.WriteLine("Available operations: " + string.Join(", ", operators));

                while (true)
                {
                    Console.Write("Enter calculation in the format (10+3) or 'q' to quit: ");
                    string input = Console.ReadLine()?.Trim();

                    if (string.IsNullOrEmpty(input) || input.ToLower() == "q")
                    {
                        break;  
                    }

                    if (input.Contains("-"))
                    {
                        string[] inputParts = input.Split('-');

                        if (inputParts.Length == 2)
                        {
                            double num1;
                            double num2;

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
                        var usedOperator = input.FirstOrDefault(c => operators.Contains(c.ToString()));

                        if (usedOperator == default(char))
                        {
                            Console.WriteLine("Invalid operator. Please use one of: " + string.Join(", ", operators));
                            continue;
                        }

                        var parts = input.Split(new[] { usedOperator }, StringSplitOptions.RemoveEmptyEntries);

                        if (parts.Length != 2)
                        {
                            Console.WriteLine("Invalid format. Please ensure the input is in the correct format (e.g., 10+3).");
                            continue;
                        }

                        double num1, num2;

                        if (double.TryParse(parts[0].Trim(), out num1) && double.TryParse(parts[1].Trim(), out num2))
                        {
                            var plugin = manager.Extensions.FirstOrDefault(p => p.Value().OperatorSymbol == usedOperator.ToString())?.Value();

                            if (plugin == null)
                            {
                                Console.WriteLine($"Operator '{usedOperator}' not supported.");
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
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Error: Invalid format. Please ensure you are entering numbers in the correct format.");
                Console.WriteLine($"Details: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Error: A plugin or operation is not properly configured.");
                Console.WriteLine($"Details: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred.");
                Console.WriteLine($"Details: {ex.Message}");
            }
        }
    }
}
