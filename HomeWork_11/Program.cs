using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_11
{
    internal static class Program
    {
        static void Main()
        {
            Console.WriteLine("Домашнее задание 11 Пример использования рекурсии");
            Console.WriteLine(new string('=', 120));
            Console.WriteLine("Домашнее задание 11.1 Реализовать вывод массива с помощью рекурсии.");

            int[] MyArray = Utilities.GetRandomArray(10);
            Console.WriteLine($"Обычный вывод массива: {String.Join(" ", MyArray)}");
            Console.Write("Вывод массива с помощью рекурсивного метода 1: ");
            Utilities.RecShowArray(MyArray);
            Console.WriteLine();
            Console.Write("Вывод массива с помощью рекурсивного метода 2: ");
            Utilities.RecShowArray1(MyArray);
            Console.WriteLine();

            Console.WriteLine(new string('-', 120));

            Console.WriteLine("Домашнее задание 11.2 Найти сумму элементов массива с помощью рекурсии.");

            MyArray = Utilities.GetRandomArray(5);
            Console.WriteLine($"Массив: {String.Join(" ", MyArray)}");
            Console.Write($"Сумма элементов массива: {Utilities.RecSumArray(MyArray)}");
            Console.WriteLine();

            Console.WriteLine(new string('-', 120));

            Console.WriteLine("Домашнее задание 11.3 Найти сумму цифр числа с помощью рекурсии. Например 561 = 12");

            Console.Write("Введите целое неотрицательное число: ");
            int Value;
            while (!int.TryParse(Console.ReadLine(), out Value) || Value < 0)
                Console.Write("Ошибка !!! Введите целое неотрицательное число: ");
            Console.WriteLine($"Сумма цифр числа {Value} равна {Utilities.SumOfDigits(Value)}");
            Console.WriteLine($"Сумма цифр числа {Value} равна {Utilities.SumOfDigits1(Value)}");

            Console.WriteLine(new string('-', 120));

            Console.ReadLine();
        }

        private static class Utilities
        {
            private static readonly Random random = new Random();

            public static int[] GetRandomArray(int size)
            {
                if (size < 0)
                    throw new ArgumentException("Размер массива не может быть отрицательным");
                int[] NewArray = new int[size];

                // Заполняем массив случайными числами от 0 до 100
                for (int i = 0; i < NewArray.Length; i++)
                    NewArray[i] = random.Next(0, 100);

                return NewArray;
            }

            // Мой вариант
            public static void RecShowArray(int[] arr, int index = 0)
            {
                if (arr == null || index >= arr.Length)
                    return;
                Console.Write($"{arr[index]} ");
                RecShowArray(arr, index + 1);
            }

            // Другой вариант
            public static void RecShowArray1(int[] arr, int index = 0)
            {
                if (arr == null)
                    return;
                if (index < arr.Length)
                {
                    Console.Write($"{arr[index]} ");
                    RecShowArray1(arr, index + 1);
                }
            }

            // Мой вариант
            public static int RecSumArray(int[] arr, int index = 0)
            {
                if (arr == null || index >= arr.Length)
                    return 0;
                return arr[index] + RecSumArray(arr, index + 1);
            }

            // Мой вариант
            public static int SumOfDigits(int Value, int index = 0)
            {
                if (Value < 0 || index < 0 || index >= Value.ToString().Length)
                    return 0;
                int n;
                string s = Value.ToString();
                s = s[index].ToString();
                int.TryParse(s, out n);
                return n + SumOfDigits(Value, index + 1);
            }

            // Мой вариант 2
            public static int SumOfDigits1(int Value)
            {
                if (Value < 10)
                    return Value;
                return Value % 10 + SumOfDigits1(Value / 10);
            }
        }
    }
}
