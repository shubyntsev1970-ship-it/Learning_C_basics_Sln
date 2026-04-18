using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace BenchmarkExample
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<InVsValueBenchmark>();
        }
    }

    // Делаем большую структуру, чтобы разница была заметна
    public struct BigStruct
    {
        public long A, B, C, D, E, F, G, H;
        public long I, J, K, L, M, N, O, P;
    }

    [MemoryDiagnoser] // показывает выделение памяти
    public class InVsValueBenchmark
    {
        private BigStruct data;

        [GlobalSetup]
        public void Setup()
        {
            data = new BigStruct
            {
                A = 1,
                B = 2,
                C = 3,
                D = 4,
                E = 5,
                F = 6,
                G = 7,
                H = 8,
                I = 9,
                J = 10,
                K = 11,
                L = 12,
                M = 13,
                N = 14,
                O = 15,
                P = 16
            };
        }

        // Передача по значению (копия)
        [Benchmark]
        public long PassByValue()
        {
            return Foo(data);
        }

        // Передача через in (без копии)
        [Benchmark]
        public long PassByIn()
        {
            return Bar(in data);
        }

        private long Foo(BigStruct value)
        {
            return value.A + value.P;
        }

        private long Bar(in BigStruct value)
        {
            return value.A + value.P;
        }
    }
}