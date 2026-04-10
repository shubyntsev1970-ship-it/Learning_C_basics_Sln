using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_04
{
    internal static class Program
    {
        static void Main()
        {
            Console.WriteLine("Домашнее задание 4 - Напишите программу, проверяющую число, введенное с клавиатуры на четность.");

            int n;

            Console.WriteLine("Введите целое число:");
            while (!int.TryParse(Console.ReadLine(), out n))
                Console.WriteLine("Ошибка формата. Введите целое число:");

            if (n % 2 == 0)
                Console.WriteLine($"Число {n} является четным.");
            else
                Console.WriteLine($"Число {n} является нечетным.");
        }
    }
}
