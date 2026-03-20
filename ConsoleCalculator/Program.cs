using System;
using vizgalova_library1;

namespace ConsoleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Консольный калькулятор");
            Console.WriteLine("Введите выражение (например 2+2*2) или 'exit' для выхода");
            Console.WriteLine("Поддерживаются: + - * / ^ и скобки");
            Console.WriteLine();
            while (true)
            {
                Console.Write("> ");
                string input = Console.ReadLine();

                if (input.ToLower() == "exit")
                    break;

                try
                {
                    double res = Calc.Calculate(input);
                    Console.WriteLine($"= {res}");
                }
                catch (DivideByZeroException)
                {
                    Console.WriteLine("Ошибка: деление на ноль");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
                Console.WriteLine();
            }
        }
    }
}