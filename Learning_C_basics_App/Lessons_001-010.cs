using System;
using System.IO;

namespace Learning_C_basics_App
{
    public partial class Program
    {
        // Типы данных в C#
        public static void Lesson_001()
        {
            Console.WriteLine("Hello from Lesson_001 Типы данных в C#");

            // {0,8} 0 — номер аргумента(первый), который потом подставится в строку, 8 — выравнивание по ширине 8 символов
            // по умолчанию число положительное, значит выравнивание вправо (-8 - влево)
            // {1,8} — второй аргумент, ширина 8
            // {2} - третий аргумент
            // {3,30} — четвертый аргумент, ширина 30
            // {4} - пятый аргумент
            // \t - это табуляция
            string msg = "Тип {0,-8} |\t.NET {1,8} |\tРазмер = {2} \t| MIN = {3,30}\t| MAX = {4}";

            // Тип      int |  .NET    Int32 | Размер = 4 | MIN = -2147483648 | MAX = 2147483647
            Console.WriteLine(msg, "int", "Int32", 4, int.MinValue, int.MaxValue);


            // =======================
            // ЦЕЛОЧИСЛЕННЫЕ ТИПЫ
            // =======================
            Console.WriteLine("\n=== ЦЕЛОЧИСЛЕННЫЕ ТИПЫ ===");

            Console.WriteLine(msg, "sbyte", typeof(sbyte).Name, sizeof(sbyte), sbyte.MinValue, sbyte.MaxValue);
            Console.WriteLine(msg, "byte", typeof(byte).Name, sizeof(byte), byte.MinValue, byte.MaxValue);
            Console.WriteLine(msg, "short", typeof(short).Name, sizeof(short), short.MinValue, short.MaxValue);
            Console.WriteLine(msg, "ushort", typeof(ushort).Name, sizeof(ushort), ushort.MinValue, ushort.MaxValue);
            Console.WriteLine(msg, "int", typeof(int).Name, sizeof(int), int.MinValue, int.MaxValue);
            Console.WriteLine(msg, "uint", typeof(uint).Name, sizeof(uint), uint.MinValue, uint.MaxValue);
            Console.WriteLine(msg, "long", typeof(long).Name, sizeof(long), long.MinValue, long.MaxValue);
            Console.WriteLine(msg, "ulong", typeof(ulong).Name, sizeof(ulong), ulong.MinValue, ulong.MaxValue);

            // =======================
            // ЧИСЛА С ПЛАВАЮЩЕЙ ТОЧКОЙ
            // =======================
            Console.WriteLine("\n=== ЧИСЛА С ПЛАВАЮЩЕЙ ТОЧКОЙ ===");

            Console.WriteLine(msg, "float", typeof(float).Name, sizeof(float), float.MinValue, float.MaxValue);
            Console.WriteLine(msg, "double", typeof(double).Name, sizeof(double), double.MinValue, double.MaxValue);
            Console.WriteLine(msg, "decimal", typeof(decimal).Name, sizeof(decimal), decimal.MinValue, decimal.MaxValue);

            // =======================
            // СИМВОЛЬНЫЕ ТИПЫ
            // =======================
            Console.WriteLine("\n=== СИМВОЛЬНЫЕ ТИПЫ ===");

            Console.WriteLine(msg, "char", typeof(char).Name, sizeof(char), char.MinValue, char.MaxValue);

            // =======================
            // ЛОГИЧЕСКИЕ ТИПЫ
            // =======================
            Console.WriteLine("\n=== ЛОГИЧЕСКИЕ ТИПЫ ===");

            Console.WriteLine(msg, "bool", typeof(bool).Name, sizeof(bool), "false", "true");

            // =======================
            // ОСОБЫЕ / ССЫЛОЧНЫЕ ТИПЫ
            // =======================
            Console.WriteLine("\n=== ОСОБЫЕ / ССЫЛОЧНЫЕ ТИПЫ ===");

            Console.WriteLine(msg, "string", typeof(string).Name, "N/A", "N/A", "N/A");
            Console.WriteLine(msg, "object", typeof(object).Name, "N/A", "N/A", "N/A");
            Console.WriteLine(msg, "dynamic", typeof(object).Name, "N/A", "N/A", "N/A");

            // =======================
            // ДАТА И ВРЕМЯ
            // =======================
            Console.WriteLine("\n=== ДАТА И ВРЕМЯ ===");

            Console.WriteLine(msg, "DateTime", typeof(DateTime).Name, "N/A", DateTime.MinValue, DateTime.MaxValue);

            Console.WriteLine(new string('-', 120));
        }

        // Переменные в С#. Объявление, инициализация, присвоение значенмй (помещение данных)
        public static void Lesson_002()
        {
            Console.WriteLine("Hello from Lesson_002 Переменные в С#");

            // Объявление:
            // тип_данных имя_переменной;
            int a;

            // Инициализация переменной - данные присваиваются (помещаются в переменную) в первый раз
            // имя_переменной = значение_переменной;
            a = 0;
            Console.WriteLine(a);

            // Присвоение - это последующие помещение данных
            a = 1;
            Console.WriteLine(a);

            // Можно так: объявление с инициализацией
            // тип_данных имя_переменной = значение_переменной;
            int b = 10;
            Console.WriteLine(b);

            // Можно так: 
            int c = 23, d = 55;

            Console.WriteLine(c);
            Console.WriteLine(d);

            bool variable = false;

            // Так нельзя - идентичные имена переменных
            //bool variable = true;

            // Среда разработки регистрозависима - так можно: 
            bool Variable = true;

            bool variable2 = true;

            Console.WriteLine(variable);
            Console.WriteLine(Variable);
            Console.WriteLine(variable2);

            double s = 1.33;
            Console.WriteLine(s);

            char ch = '#';
            Console.WriteLine(ch);

            string str = "abcd";
            Console.WriteLine(str);

            Console.WriteLine(new string('-', 120));
        }

        // Ввод данных в консоль
        public static void Lesson_003()
        {
            Console.WriteLine("Hello from Lesson_003 Ввод данных в консоль");

            string data;

            // Автоматизирует ручной ввод с консоли
            TextReader originalInput = Console.In; // Сохраняет оригинальный ввод
            var input = "Валентин";
            Console.SetIn(new StringReader(input));

            data = Console.ReadLine();
            
            // возвращаем обратно
            Console.SetIn(originalInput);

            Console.WriteLine("Привет " + data);
            Console.WriteLine("Привет " + data + " !!!");
            Console.WriteLine("Привет {0, 10} !!!", data);
            Console.WriteLine($"Привет {data, 15} !!!");

            Console.WriteLine(new string('-', 120));
        }

        // Конвертация строки в число. Класс Convert
        public static void Lesson_004()
        {
            Console.WriteLine("Hello from Lesson_004 Конвертация строки в число. Класс Convert");

            string str1  = "5";
            string str2 = "2";

            Console.WriteLine(str1 + str2); // 52

            Console.WriteLine(Convert.ToInt32(str1) + Convert.ToInt32(str2)); // 7

            string str;
            int a, b;

            // Автоматизирует ручной ввод с консоли
            TextReader originalInput = Console.In; // Сохраняет оригинальный ввод
            var input = "11\n11\n";
            Console.SetIn(new StringReader(input));


            Console.WriteLine("Введите число 1:");
            str = Console.ReadLine();
            a = Convert.ToInt32(str);

            Console.WriteLine("Введите число 2:");
            str = Console.ReadLine();
            b = Convert.ToInt32(str);

            // возвращаем обратно
            Console.SetIn(originalInput);
            
            
            int sum = a + b;

            Console.WriteLine("Сумма: " + sum);

            Console.WriteLine(new string('-', 120));
        }
    }
}
