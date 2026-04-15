using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_08
{
    internal static class Program
    {
        static void Main()
        {
            Console.WriteLine("Домашнее задание 8");
            // 8.1 Заполнить массив с клавиатуры
            Console.WriteLine("8.1 Заполнить массив с клавиатуры");
            Console.WriteLine("Введите размер массива (целое число):");
            
            int arraySize;
            while(!int.TryParse(Console.ReadLine(), out arraySize))
                Console.WriteLine("Ошибка ввода. Пожалуйста, введите целое число:");
            int[] array = new int[arraySize];

            Console.WriteLine($"Введите элементы массива (количество {arraySize} элементов):");
            for (int i = 0; i < arraySize; i++)
            {
                Console.WriteLine($"Введите {i + 1}-ый элемент массива:");
                while (!int.TryParse(Console.ReadLine(), out array[i]))
                    Console.WriteLine("Ошибка ввода. Пожалуйста, введите целое число:");
            }
            Console.WriteLine($"Введенные элементы массива: {string.Join(" ", array)}");

            Console.WriteLine(new string('-', 120));

            // 8.2 Вывести массив в обратном порядке
            Console.WriteLine("8.2 Вывести массив в обратном порядке");

            // Вариант 1: Используя цикл for
            for (int i = array.Length - 1; i >= 0; i--)
            {
                Console.Write($"{array[i]} ");
            }
            Console.WriteLine();

            // Вариант 2: Используя метод Reverse() из LINQ
            Console.WriteLine(string.Join(" ", array.Reverse()));
            Console.WriteLine(new string('-', 120));
            

            // 8.3 Найти сумму четных чисел в массиве
            Console.WriteLine("8.3 Найти сумму четных чисел в массиве");
            int sumEven = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                    sumEven += array[i];
            }
            Console.WriteLine($"Сумма четных чисел в массиве: {sumEven}");
            Console.WriteLine(new string('-', 120));

            // 8.4 Найти наименьшее число в массиве
            Console.WriteLine("8.4 Найти наименьшее число в массиве");
            int minValue = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < minValue)
                    minValue = array[i];
            }
            Console.WriteLine($"Наименьшее число в массиве: {minValue}"); 
            Console.WriteLine(new string('-', 120));

            Console.ReadLine();
        }
    }
}
