using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_06
{
    internal static class Program
    {
        static void Main()
        {
            Console.WriteLine("Домашнее задание 6    Подсчет количества четных и нечетных чисел в диапазоне");

            int firstValue = 0, secondValue = 0;
            bool checker = true;
            int evencount = 0, oddcount = 0;

            while (checker)
            {
                int fV, sV;

                Console.WriteLine("Введите начальное целое число диапазона:");
                while (!int.TryParse(Console.ReadLine(), out fV))
                    Console.WriteLine("Ошибка формата числа. Введите начальное целое число диапазона:");

                Console.WriteLine("Введите конечное целое число диапазона:");
                while (!int.TryParse(Console.ReadLine(), out sV))
                    Console.WriteLine("Ошибка формата числа. Введите конечное целое число диапазона:");
                if (sV >= fV)
                {
                    firstValue = fV;
                    secondValue = sV;
                    checker = false;    
                }
                else 
                {
                    Console.WriteLine("Второе число должно быть больше или равно первому. Попробуйте снова.");
                    Console.ReadKey();
                    Console.Clear();
                }
            }

            int current = firstValue;
            while (current <= secondValue)      
            {
                if (current % 2 == 0)
                    evencount++;
                else
                    oddcount++;
                current++;
            }

            Console.WriteLine($"В диапазоне чисел от {firstValue} до {secondValue}");
            Console.WriteLine($"Количество четных чисел: {evencount}");
            Console.WriteLine($"Количество нечетных чисел: {oddcount}");
            Console.ReadLine();
        }
    }
}
