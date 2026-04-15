using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_09
{
    internal static class Program
    {
        static void Main()
        {
            Console.WriteLine("Домашнее задание 9");
            Console.WriteLine("Домашнее задание 9.1 Написать метод, который выводит на экран строку.\n" +
                              "Символ, из которого состоит строка, и их количество вводятся пользователем.");

            void PrintSymbol(char ch, int cnt)
            {

                // С использованием цикла for
                for (int i = 0; i < cnt; i++)
                    Console.Write(ch);
                Console.WriteLine();

                // или так
                // Console.WriteLine(new string(ch, cnt));

            }

            Console.Write("Введите символ: ");
            char chrRead = Console.ReadKey().KeyChar; 
            Console.WriteLine();

            Console.Write($"Сколько раз нужно вывести символ '{chrRead}': ");
            int count;
            while (!int.TryParse(Console.ReadLine(), out count) || count < 0)
                Console.Write("Ошибка. Введите целое неотрицательное число: ");
            PrintSymbol(chrRead, count);

            Console.WriteLine("Домашнее задание 9.2 Написать метод для поиска индекса элемента массива (тип элементов в массиве — int).\n" +
                              "Метод должен вернуть индекс первого найденного элемента(если он будет найден)");

            int FindIndex(int[] arr, int value)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] == value)
                        return i;
                }
                return -1;
            }

            int[] myArray = new int[20];
            Random random = new Random();
            int valueToFind, index;

            for (int i = 0; i < myArray.Length; i++)
                myArray[i] = random.Next(1, 10);
            Console.WriteLine("Исходный массив:");
            Console.WriteLine(string.Join(" ", myArray));
            Console.Write("Введите значение элемента, индекс которого нужно найти: ");
            while (!int.TryParse(Console.ReadLine(), out valueToFind))
                Console.Write("Ошибка формата. Введите целое число: ");
            index = FindIndex(myArray, valueToFind);
            if (index >= 0)
                Console.WriteLine($"Индекс первого элемента {valueToFind} в массиве - [{index}]");
            else
                Console.WriteLine($"Элемент {valueToFind} отсутствует в массиве");


            Console.ReadLine();
        }
    }
}
