using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_05
{
    internal static class Program
    {
        static void Main()
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("Домашнее задание 5 Калькулятор + - * / 1 вариант - switch 2 вариант - if else");

            double firstValue, secondValue;

            Console.WriteLine("Введите первое число:");
            while (!double.TryParse(Console.ReadLine(), out firstValue))
                Console.WriteLine("Ошибка формата. Введите первое число:");

            Console.WriteLine("Введите второе число:");
            while (!double.TryParse(Console.ReadLine(), out secondValue))
                Console.WriteLine("Ошибка формата. Введите второе число:");

            Console.WriteLine("Введите требуемую операцию  + - * / ");
            string action = Console.ReadLine();

            switch (action)
            {
                case "+":
                    Console.WriteLine($"Результат сложения: {firstValue + secondValue}");
                    break;
                case "-":
                    Console.WriteLine($"Результат вычитания: {firstValue - secondValue}");
                    break;
                case "*":
                    Console.WriteLine($"Результат умножения: {firstValue * secondValue}");
                    break;
                case "/":
                    if (secondValue != 0)
                        Console.WriteLine($"Результат деления: {firstValue / secondValue}");
                    else
                        Console.WriteLine("Ошибка: деление на ноль.");
                    break;
                default:
                    Console.WriteLine("Неверная операция.");
                    break;
            }

            if (action == "+")
                Console.WriteLine($"Результат сложения: {firstValue + secondValue}");
            else if (action == "-")
                Console.WriteLine($"Результат вычитания: {firstValue - secondValue}");
            else if (action == "*")
                Console.WriteLine($"Результат умножения: {firstValue * secondValue}");
            else if (action == "/")
            {
                if (secondValue != 0)
                    Console.WriteLine($"Результат деления: {firstValue / secondValue}");
                else
                    Console.WriteLine("Ошибка: деление на ноль.");
            }
            else
                Console.WriteLine("Неверная операция.");
        }
    }
}
