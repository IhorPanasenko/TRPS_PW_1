using System.ComponentModel.DataAnnotations;
using System;

namespace NumberConverter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            RunMain();
        }

        public static void RunMain()
        {
            Console.WriteLine("Welcome to Number Converter!");

            while (true)
            {
                try
                {
                    string numberInput = null;
                    int fromBase = 0;
                    int toBase = 0;

                    while (true)
                    {
                        Console.Write("Enter the base of the input number (2-16) or 'exit' to quit: ");
                        string baseInput = Console.ReadLine();
                        if (HandleExit(baseInput)) return;
                        if (int.TryParse(baseInput, out fromBase) && Validator.IsValidBase(fromBase))
                        {
                            break;
                        }
                        Console.WriteLine("Please enter a valid base between 2 and 16.");
                    }

                    while (true)
                    {
                        Console.Write($"Enter the number in base {fromBase} or 'back' to change the base: ");
                        numberInput = Console.ReadLine();
                        if (HandleExit(numberInput)) return;
                        if (Validator.IsValidNumber(numberInput, fromBase))
                        {
                            break;
                        }
                        Console.WriteLine($"Invalid number for base {fromBase}. Please try again.");
                    }

                    while (true)
                    {
                        Console.Write("Enter the target base (2-16) or 'back' to re-enter the number: ");
                        string baseInput = Console.ReadLine();
                        if (HandleExit(baseInput)) return;
                        if (int.TryParse(baseInput, out toBase) && Validator.IsValidBase(toBase))
                        {
                            break;
                        }
                        Console.WriteLine("Please enter a valid base between 2 and 16.");
                    }

                    string result = Converter.ConvertBase(numberInput, fromBase, toBase);
                    Console.WriteLine($"The number {numberInput} in base {fromBase} is {result} in base {toBase}.\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        static bool HandleExit(string input)
        {
            if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Exiting application...");
                return true;
            }
            return false;
        }
    }
}
