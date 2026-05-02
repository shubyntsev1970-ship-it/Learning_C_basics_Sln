using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Collections;
using System.Collections.Generic;


namespace Benchmark1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * Запускает отдельный процесс для выполнения бенчмарка и выводит результаты в консоль.
            BenchmarkRunner.Run<Benchmark_1>();
            BenchmarkRunner.Run<Benchmark_2>();
            BenchmarkRunner.Run<Benchmark_3>();
            */

            // Предоставляет выбор пользователю для запуска конкретного бенчмарка.
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
        }

    }

    [MemoryDiagnoser]
    public class Benchmark_1
    {
        [Benchmark]
        public void StructTest()
        {
            StructPoint point = new StructPoint();
            point.X = 1;
            point.Y = 2;
            var result = point.X = point.Y;
        }

        [Benchmark]
        public void ClassTest()
        {
            ClassPoint point = new ClassPoint();
            point.X = 1;
            point.Y = 2;
            var result = point.X = point.Y;
        }
    }

    [MemoryDiagnoser]
    public class Benchmark_2
    {
        [Benchmark]
        public void StructArrayTest()
        {
            StructPoint[] structPoints = new StructPoint[100];
            for (int i = 0; i < structPoints.Length; i++)
            {
                structPoints[i] = new StructPoint();
            }
        }

        [Benchmark]
        public void ClassArrayTest()
        {
            ClassPoint[] classPoints = new ClassPoint[100];
            for (int i = 0; i < classPoints.Length; i++)
            {
                classPoints[i] = new ClassPoint();
            }
        }
    }

    [MemoryDiagnoser]
    public class Benchmark_3
    {
        struct MyStruct
        {
            public decimal MyProperty1 { get; set; }
            public decimal MyProperty2 { get; set; }
            public decimal MyProperty3 { get; set; }
            public decimal MyProperty4 { get; set; }
            public decimal MyProperty5 { get; set; }
            public decimal MyProperty6 { get; set; }
            public decimal MyProperty7 { get; set; }
            public decimal MyProperty8 { get; set; }
            public decimal MyProperty9 { get; set; }
            public decimal MyProperty10 { get; set; }
        }

        struct MyClass
        {
            public decimal MyProperty1 { get; set; }
            public decimal MyProperty2 { get; set; }
            public decimal MyProperty3 { get; set; }
            public decimal MyProperty4 { get; set; }
            public decimal MyProperty5 { get; set; }
            public decimal MyProperty6 { get; set; }
            public decimal MyProperty7 { get; set; }
            public decimal MyProperty8 { get; set; }
            public decimal MyProperty9 { get; set; }
            public decimal MyProperty10 { get; set; }
        }

        private MyStruct _myStruct = new MyStruct();
        private MyClass _myClass = new MyClass();

        private void Foo(MyClass myClass)
        {
            var t = myClass.MyProperty1 + myClass.MyProperty2;
        }

        private void Bar(MyStruct myStruct)
        {
            var t = myStruct.MyProperty1 + myStruct.MyProperty2;
        }

        private void Bar(in MyStruct myStruct)
        {
            var t = myStruct.MyProperty1 + myStruct.MyProperty2;
        }

        [Benchmark]
        public void StructTestIn()
        {
            Bar(in _myStruct);
        }

        [Benchmark]
        public void StructTest()
        {
            Bar(_myStruct);
        }

        [Benchmark]
        public void ClassTest()
        {
            Foo(_myClass);
        }
    }

    [MemoryDiagnoser]
    public class BoxingTest
    {
        [Benchmark]
        public void NoBoxing()
        {
            int res = 0;
            int a = 1;
            res += a;
        }

        [Benchmark]
        public void Boxing()
        {
            int res = 0;
            object a = 1;
            res += (int)a;
        }
    }

    [MemoryDiagnoser] // ВАЖНО: включает статистику GC
    public class MemoryBenchmark
    {
        // Маленькие объекты -> чаще Gen 0
        [Benchmark]
        public void SmallObjects()
        {
            for (int i = 0; i < 10000; i++)
            {
                var arr = new byte[100];
            }
        }

        // Средние объекты -> могут дожить до Gen 1
        [Benchmark]
        public void MediumObjects()
        {
            for (int i = 0; i < 10000; i++)
            {
                var arr = new byte[10_000];
            }
        }

        // Большие объекты -> сразу LOH (обычно Gen 2)
        [Benchmark]
        public void LargeObjects()
        {
            for (int i = 0; i < 1000; i++)
            {
                var arr = new byte[100_000]; // > 85 KB
            }
        }
    }

    [MemoryDiagnoser]
    public class SwapsBenchmark
    {
        [Benchmark]
        public void GenericSwapBenchmark()
        {
            double a = 1;
            double b = 5.3;
            SwapTestClass.GenericSwap(ref a, ref b);
        }

        [Benchmark]
        public void SwapBenchmark()
        {
            object p1 = 2;
            object p2 = 4;
            SwapTestClass.ObjectSwap(ref p1, ref p2);
        }
    }

    [MemoryDiagnoser]
    public class YieldVsListBenchmark
    {
        private const int N = 1000; // Количество элементов для теста

        [Benchmark]
        public int UseYield()
        {
            int sum = 0;
            foreach (var item in GenerateWithYield())
            {
                sum += item;
            }
            return sum;
        }

        private IEnumerable<int> GenerateWithYield()
        {
            for (int i = 0; i < N; i++)
            {
                yield return i;
            }
        }

        [Benchmark]
        public int UseList()
        {
            int sum = 0;
            foreach (var item in GenerateWithList())
            {
                sum += item;
            }
            return sum;
        }
        private List<int> GenerateWithList()
        {
            var list = new List<int>();
            for (int i = 0; i < N; i++)
            {
                list.Add(i);
            }
            return list;
        }
    }

    [MemoryDiagnoser]
    public class ListsBenchmark
    {
        [Benchmark]
        public void ArrayListBenchmark()
        {
            ArrayList arrayList = new ArrayList();
            for (int i = 0; i < 1000; i++)
            {
                arrayList.Add(i);
            }
        }

        [Benchmark]
        public void ObjectListBenchmark()
        {
            List<object> list = new List<object>();
            for (int i = 0; i < 1000; i++)
            {
                list.Add(i);
            }
        }

        [Benchmark]
        public void ListBenchmark()
        {
            List<int> list = new List<int>();
            for (int i = 0; i < 1000; i++)
            {
                list.Add(i);
            }
        }
    }

    public static class SwapTestClass
    {

        public static void GenericSwap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        public static void ObjectSwap(ref object a, ref object b)
        {
            object temp = a;
            a = b;
            b = temp;
        }
    }

    public class ClassPoint
    {
        public int X { get; set; }
        public int Y { get; set; }

        public void Print()
        {
            Console.WriteLine($"X:{X}\tY:{Y}");
        }
    }

    public struct StructPoint
    {
        public int X { get; set; }
        public int Y { get; set; }

        public void Print()
        {
            Console.WriteLine($"X:{X}\tY:{Y}");
        }
    }
}