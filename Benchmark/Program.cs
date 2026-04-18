using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmark
{
    internal static class Program
    {
        static void Main()
        {
            // Бенчмарк для сравнения производительности передачи структуры по значению (копирование данных)
            // и с помощью in (без копирования данных)

            Point a = new Point();

            Console.WriteLine("Бенчмарк для сравнения производительности передачи структуры по значению (копирование данных)");
            Console.WriteLine("Работаю ...");
            Stopwatch sw = Stopwatch.StartNew();

            for (int i = 0; i < int.MaxValue; i++)
            {
                Foo(a); // Передача структуры по значению (копирование данных)
            }

            sw.Stop();
            Console.WriteLine($"Foo Передача структуры по значению (копирование данных) работала - {sw.ElapsedMilliseconds} мс");

            Console.WriteLine("Работаю ...");
            sw.Restart();

            for (int i = 0; i < int.MaxValue; i++)
            {
                Bar(in a); // Передача структуры с помощью in (без копирования данных)
            }

            sw.Stop();
            Console.WriteLine($"Bar Передача структуры с помощью in (без копирования данных) работала - {sw.ElapsedMilliseconds} мс");
        }

        struct Point
        {
            public decimal a;
            public decimal b;
            public decimal c;
            public decimal d;
            public decimal e;
            public decimal f;
            public decimal g;
            public decimal h;
            public decimal i;
        }

        static void Foo(Point value)
        {
        }

        static void Bar(in Point value)
        {
        }
    }
}
