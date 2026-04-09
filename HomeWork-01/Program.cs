using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_01
{
    internal static class Program
    {
        static void Main()

        {
            Console.WriteLine("Домашнее задание 1 - Напишите программу, вычисляющую среднее арифметическое двух чисел.");
            double res;

            Console.WriteLine("Введите первое число:");
            if (!double.TryParse(Console.ReadLine(), out double firstValue))
            {
                Console.WriteLine("Ошибка формата. По умолчанию firstValue = 11");
                firstValue = 11;
            }

            Console.WriteLine("Введите второе число:");
            if (!double.TryParse(Console.ReadLine(), out double secondValue))
            {
                Console.WriteLine("Ошибка формата. По умолчанию secondValue = 22");
                secondValue = 22;
            }   
            
            res = (firstValue + secondValue) / 2;

            Console.WriteLine($"Среднее арифметическое двух чисел {firstValue} и {secondValue} = {res}");
        }
    }
}
