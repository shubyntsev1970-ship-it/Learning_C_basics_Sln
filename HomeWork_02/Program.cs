using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_02
{
    internal static class Program
    {
        static void Main()
        {
            Console.WriteLine("Домашнее задание 2 - Введите три числа и выведите на экран значение суммы и произведения этих чисел.");
            double sum, prod;

            Console.WriteLine("Введите первое число:");
            if (!double.TryParse(Console.ReadLine(), out double firstValue))
            { 
                Console.WriteLine("Ошибка формата. По умолчанию firstValue = 11");
                firstValue = 11;
            }
            Console.WriteLine("Введите второе число:");
            if (!double.TryParse(Console.ReadLine(), out double secondValue))
            {
                Console.WriteLine("Ошибка формата. По умолчанию secondValue = 12");
                secondValue = 12;
            }
            Console.WriteLine("Введите третье число:");
            if (!double.TryParse(Console.ReadLine(), out double thirdValue))
            {
                Console.WriteLine("Ошибка формата. По умолчанию thirdValue = 13");
                thirdValue = 13;
            }

            sum = firstValue + secondValue + thirdValue;
            prod = firstValue * secondValue * thirdValue;

            Console.WriteLine($"{firstValue} + {secondValue} + {thirdValue} = {sum}");
            Console.WriteLine($"{firstValue} * {secondValue} * {thirdValue} = {prod}");
        }
    }
}
