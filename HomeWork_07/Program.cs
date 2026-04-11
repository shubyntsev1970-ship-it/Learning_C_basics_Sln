using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_07
{
    internal static class Program
    {
        static void Main()
        {
            Console.WriteLine("Домашнее задание 7 Нарисовать в консоли 4 треугольника");

            int triangleSize = 10;
            
            for (int i = 0; i < triangleSize; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.Write('#');
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();

            for (int i = 0; i < triangleSize; i++)
            {
                for (int j = triangleSize; j > i; j--)
                {
                    Console.Write('#');
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();

            for (int i = 0; i < triangleSize; i++)
            {
                Console.Write(new string(' ', triangleSize - i - 1));

                for (int j = 0; j <= i; j++)
                {
                    Console.Write('#');
                }
                
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();

            for (int i = 0; i < triangleSize; i++)
            {
                Console.Write(new string(' ', i));

                for (int j = triangleSize; j > i; j--)
                {
                    Console.Write('#');
                }

                Console.WriteLine();
            }
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
