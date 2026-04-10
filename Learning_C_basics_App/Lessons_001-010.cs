using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Learning_C_basics_App
{
    public static partial class Program
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
            Console.WriteLine($"Привет {data,15} !!!");

            Console.WriteLine(new string('-', 120));
        }

        // Конвертация строки в число. Класс Convert
        public static void Lesson_004()
        {
            Console.WriteLine("Hello from Lesson_004 Конвертация строки в число. Класс Convert");

            string str1 = "5";
            string str2 = "2";

            Console.WriteLine(str1 + str2); // 52

            Console.WriteLine(Convert.ToInt32(str1) + Convert.ToInt32(str2)); // 7

            string str;
            int a, b;

            // Автоматизирует ручной ввод с консоли
            TextReader originalInput = Console.In; // Сохраняет оригинальный ввод
            var input = "11\n12\n";
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

            str = "1,9";
            double d = Convert.ToDouble(str);
            Console.WriteLine(d);

            // Так будет исключение FormatException (зависит от региональных настроек - что используется для десятичного разделителя)
            str = "1.9";
            try
            {
                d = Convert.ToDouble(str);
                Console.WriteLine(d);
            }
            catch (FormatException e)
            {
                Console.WriteLine("Ошибка формата: " + e.Message);
            }

            // Для решения вопроса подключаем протранство имен System.Globalization 
            NumberFormatInfo info = new NumberFormatInfo()
            {
                NumberDecimalSeparator = ".",
            };
            // По умолчанию Convert.ToDouble(str) использует текущую культуру системы.
            // И так тоже будет исключение
            // d = Convert.ToDouble(str);

            // необходимо
            d = Convert.ToDouble(str, info);
            Console.WriteLine(d);


            Console.WriteLine(new string('-', 120));
        }

        // Преобразование строк. Parse string. TryParse string.
        public static void Lesson_005()
        {
            Console.WriteLine("Hello from Lesson_005 Преобразование строк. Parse string. TryParse string.");

            string str = "5";
            Console.WriteLine(int.TryParse(str, out int i)); // True
            Console.WriteLine(i); // 5
            Console.WriteLine(int.Parse(str)); // 5

            str = "6,7";
            Console.WriteLine(double.TryParse(str, out double dbl)); // True
            Console.WriteLine(dbl); // 6,7
            Console.WriteLine(double.Parse(str)); // 6,7

            str = "7.7";
            if (double.TryParse(str, out dbl)) // false
                Console.WriteLine(dbl);

            NumberFormatInfo info = new NumberFormatInfo()
            {
                NumberDecimalSeparator = ".",
            };
            dbl = double.Parse(str, info);
            Console.WriteLine(dbl); // 7,7

            str = "8,8";
            if (double.TryParse(str, out dbl)) // True
                Console.WriteLine(dbl); // 8,8

            str = "8,8dsgfgaa";
            Console.WriteLine(double.TryParse(str, out dbl)); // False
            Console.WriteLine(dbl);

            str = "dhakjsh";

            try
            {
                int a = int.Parse(str);
                Console.WriteLine($"Успешная конвертация {a}");
            }
            catch (Exception)
            {
                Console.WriteLine($"Ошибка при конвертации {str} в int");
            }

            str = "12345";

            try
            {
                int a = int.Parse(str);
                Console.WriteLine($"Успешная конвертация {a}");
            }
            catch (Exception)
            {
                Console.WriteLine($"Ошибка при конвертации {str} в int");
            }

            if (int.TryParse(str, out int n))
                Console.WriteLine(n);

            str = "dhakjsh";
            if (int.TryParse(str, out n)) // Исключения не будет в отличие от Parse
                Console.WriteLine(n); // но в то же время ничего не отправит на консоль 
            else
                Console.WriteLine($"Ошибка конвертации {str} в int");

            str = "223344";
            if (int.TryParse(str, out n)) // Исключения не будет в отличие от Parse
                Console.WriteLine(n); // 223344
            else
                Console.WriteLine($"Ошибка конвертации {str} в int");

            Console.WriteLine(new string('-', 120));
        }

        // ОПЕРАТОРЫ.
        public static void Lesson_006()
        {
            Console.WriteLine("Hello from Lesson_006 ОПЕРАТОРЫ.");
            /*
             * Приоритет операторов (сверху — сильнее)
            Основные группы (упрощённо)
            ()
            ++ -- (префикс)
            * / %
            + -
            < > <= >=
            == !=
            &&
            ||
            ?:
            = += -= и тому подобное
            */

            // 1.Арифметические операторы
            // + сложение
            // - вычитание
            // * умножение
            // / деление
            // % деление по модулю 2
            int a = 10;
            int b = 3;

            Console.WriteLine("1.Арифметические операторы");
            Console.WriteLine($"10 + 3 = {a + b}"); // 13
            Console.WriteLine($"10 - 3 = {a - b}"); // 7
            Console.WriteLine($"10 * 3 = {a * b}"); // 30
            Console.WriteLine($"10 / 3 = {a / b}"); // 3 (целочисленное деление!)
            Console.WriteLine($"10 % 3 = {a % b}"); // 1 (остаток)

            // 2.Операторы присваивания
            int x = 5;

            Console.WriteLine("2.Операторы присваивания");

            x += 3;
            Console.WriteLine($"x += 3 → {x}"); // 8

            x -= 2;
            Console.WriteLine($"x -= 2 → {x}"); // 6

            x *= 2;
            Console.WriteLine($"x *= 2 → {x}"); // 12

            x /= 3;
            Console.WriteLine($"x /= 3 → {x}"); // 4

            x %= 3;
            Console.WriteLine($"x %= 3 → {x}"); // 1

            // 3.Операторы сравнения
            a = 5;
            b = 10;

            Console.WriteLine("3.Операторы сравнения");
            Console.WriteLine($"5 == 10 → {a == b}"); // false
            Console.WriteLine($"5 != 10 → {a != b}"); // true
            Console.WriteLine($"5 > 10 → {a > b}");  // false
            Console.WriteLine($"5 < 10 → {a < b}");  // true
            Console.WriteLine($"5 >= 10 → {a >= b}"); // false
            Console.WriteLine($"5 <= 10 → {a <= b}"); // true

            // 4.Логические операторы
            bool aa = true;
            bool bb = false;

            Console.WriteLine("4.Операторы сравнения");
            Console.WriteLine($"true && false → {aa && bb}"); // false (И)
            Console.WriteLine($"true || false → {aa || bb}"); // true  (ИЛИ)
            Console.WriteLine($"!true → {!aa}");              // false (НЕ)

            // 5.Побитовые
            a = 5; // 0101
            b = 3; // 0011

            Console.WriteLine("5.Побитовые");
            Console.WriteLine($"5 & 3 → {a & b}");   // 1  (0001)
            Console.WriteLine($"5 | 3 → {a | b}");   // 7  (0111)
            Console.WriteLine($"5 ^ 3 → {a ^ b}");   // 6  (0110)
            Console.WriteLine($"5 << 1 → {a << 1}"); // 10 (сдвиг влево)
            Console.WriteLine($"5 >> 1 → {a >> 1}"); // 2  (сдвиг вправо)

            // 6.Тернарный оператор
            int age = 18;

            Console.WriteLine("6.Тернарный оператор");
            string result = age >= 18 ? "Взрослый" : "Ребёнок";
            Console.WriteLine($"Возраст 18 → {result}"); // Взрослый

            // 7.Инкремент / декремент
            a = 5;
            b = a++;

            Console.WriteLine("7.Инкремент / декремент");
            Console.WriteLine($"b = a++ → b = {b}, a = {a}"); // b = 5, a = 6

            int c = 5;
            int d = ++c;
            Console.WriteLine($"d = ++c → d = {d}, c = {c}"); // d = 6, c = 6

            // 8.Проверка типа
            object obj = "hello";

            Console.WriteLine("8.Проверка типа");
            Console.WriteLine($"obj is string → {obj is string}"); // true
            Console.WriteLine($"obj is int → {obj is int}");       // false

            // 9.Приведение типов
            double dd = 10.5;
            int i = (int)dd;

            Console.WriteLine("9.Приведение типов");
            Console.WriteLine($"(int)10.5 → {i}"); // 10 (обрезает)

            object obj1 = "text";
            string s = obj1 as string;

            Console.WriteLine($"obj1 as string → {s}"); // text

            // 10.Null - операторы
            string name = null;

            Console.WriteLine("10.Null - операторы");
            Console.WriteLine($"name?.Length → {name?.Length}"); // null

            string result1 = name ?? "default";
            Console.WriteLine($"name ?? \"default\" → {result1}"); // default

            string text1 = "Привет";
            string text2 = null;

            Console.WriteLine($"text1?.Length = {text1?.Length}"); // 6
            Console.WriteLine($"text2?.Length = {text2?.Length}"); // null
            Console.WriteLine($"text1?.ToLower() = {text1?.ToLower()}"); // привет

            //name ??= "new value";
            //Console.WriteLine($"name ??= \"new value\" → {name}"); // new value

            // 11.Доступ к членам
            string text = "hello";

            Console.WriteLine("11.Доступ к членам");
            Console.WriteLine($"\"hello\".Length → {text.Length}"); // 5

            // 12. new
            var list = new List<int>();

            Console.WriteLine("12. new");
            Console.WriteLine($"Создали List<int> → Count = {list.Count}"); // 0

            // 13.Лямбда
            Func<int, int> square = y => y * y;

            Console.WriteLine("13.Лямбда");
            Console.WriteLine($"y => y * y, y = 5 → {square(5)}"); // 25

            // 14.nameof
            Console.WriteLine("14.nameof");
            Console.WriteLine($"nameof(Console) → {nameof(Console)}"); // Console

            // 15. typeof
            Console.WriteLine("15. typeof");
            Console.WriteLine($"typeof(string) → {typeof(string)}"); // System.String

            Console.WriteLine(new string('-', 120));
        }

        // ИНКРЕМЕНТ И ДЕКРЕМЕНТ. ПОСТФИКСНЫЙ И ПРЕФИКСНЫЙ
        public static void Lesson_007()
        {
            Console.WriteLine("Hello from Lesson_007 ИНКРЕМЕНТ И ДЕКРЕМЕНТ. ПОСТФИКСНЫЙ И ПРЕФИКСНЫЙ");

            int a = 0;
            Console.WriteLine($"a = {a}");
            a++;
            Console.WriteLine($"a++ = {a}"); // 1
            a = 0;
            a--;
            Console.WriteLine($"a-- = {a}"); // -1

            int b = 3, c = 3;
            Console.WriteLine($"b = {b}");
            Console.WriteLine($"b++ = {b++} - ПОСТФИКСНЫЙ увеличение на 1 после вывода на консоль"); // 3
            Console.WriteLine($"c = {c}");
            Console.WriteLine($"++c = {++c} - ПРЕФИКСНЫЙ  увеличение на 1 до вывода на консоль"); // 4
            Console.WriteLine($"b + c = {b + c} - b уже тоже увеличилось на  1"); // 8

            Console.WriteLine(new string('-', 120));
        }

        // ОПЕРАЦИИ СРАВНЕНИЯ. ОПЕРАТОРЫ ОТНОШЕНИЯ
        public static void Lesson_008()
        {
            Console.WriteLine("Hello from Lesson_008 ОПЕРАЦИИ СРАВНЕНИЯ. ОПЕРАТОРЫ ОТНОШЕНИЯ");

            int a = 5;
            int b = 10;

            Console.WriteLine($"5 == 10 → {a == b}"); // false
            Console.WriteLine($"5 != 10 → {a != b}"); // true
            Console.WriteLine($"5 > 10 → {a > b}");  // false
            Console.WriteLine($"5 < 10 → {a < b}");  // true
            Console.WriteLine($"5 >= 10 → {a >= b}"); // false
            Console.WriteLine($"5 <= 10 → {a <= b}"); // true

            bool res = a == b;
            Console.WriteLine(res); // false

            Console.WriteLine(new string('-', 120));
        }
        // IF ELSE. КОНСТРУКЦИЯ ЛОГИЧЕСКОГО ВЫБОРА. ВЕТВЛЕНИЕ
        public static void Lesson_009()
        {
            Console.WriteLine("Hello from Lesson_009 IF ELSE. КОНСТРУКЦИЯ ЛОГИЧЕСКОГО ВЫБОРА. ВЕТВЛЕНИЕ");

            bool isInfected  = true;
            bool isDied = false;

            if (isInfected)
            {
                Console.WriteLine("Infected"); // Infected 
            }

            if (isDied)
            {
                Console.WriteLine("Died"); // Ничего не выведет
            }

            isInfected = false;

            if (isInfected)
            {
                Console.WriteLine("Infected"); // Ничего не выведет
            }
            else
            {
                Console.WriteLine("Not infected"); // Not infected
            }

            int a = 5; 
            
            if (a == 5)
            {
                Console.WriteLine("a равно 5");
            }
            else
            {
                Console.WriteLine("a не равно 5");
            }

            Console.WriteLine(new string('-', 120));
        }
        
        //ЛОГИЧЕСКИЕ ОПЕРАТОРЫ. СОКРАЩЁННЫЕ ЛОГИЧЕСКИЕ ОПЕРАЦИИ
        public static void Lesson_010()
        {
            // &&  Сокращенное И сокращенное потому что, если первое условие false,
            // то второе уже не проверяется, так как результат будет false

            // ||  Сокращенное ИЛИ потому что , если первое условие true,
            // то второе уже не проверяется, так как результат будет true

            // &   И (логическое И, не сокращённое, проверяет оба условия всегда)

            // |   ИЛИ (логическое ИЛИ, не сокращённое, проверяет оба условия всегда)

            // !   НЕ (унарный)

            Console.WriteLine("Hello from Lesson_010 ЛОГИЧЕСКИЕ ОПЕРАТОРЫ. СОКРАЩЁННЫЕ ЛОГИЧЕСКИЕ ОПЕРАЦИИ");

            bool isInfected = true;

            if (isInfected)
            {
                Console.WriteLine("Infected"); // Infected
            }
            else
            {
                Console.WriteLine("Not infected"); // Ничего не выведет
            }

            if (!isInfected)  // !   НЕ (унарный)
            { 
                Console.WriteLine("Not infected"); // Ничего не выведет
            }
            else 
            { 
                Console.WriteLine("Infected"); // Infected
            }

            bool isHighTemperature = true;

            bool hasNoCooling = true;

            if (isHighTemperature && hasNoCooling) // &&  Сокращенное И
            {
                Console.WriteLine("Угроза повреждения процессора!!!"); // Угроза повреждения процессора!!!
            }

            hasNoCooling = false;

            if (isHighTemperature && hasNoCooling) // &&  Сокращенное И
            {
                Console.WriteLine("Угроза повреждения процессора!!!"); // Ничего не выведет, так как hasNoCooling = false
            }

            if (isHighTemperature || hasNoCooling) // ||  Сокращенное ИЛИ
            {
                Console.WriteLine("Угроза повреждения процессора!!!"); // Угроза повреждения процессора!!!
            }

            isHighTemperature = false;

            if (isHighTemperature || hasNoCooling) // ||  Сокращенное ИЛИ
            {
                Console.WriteLine("Угроза повреждения процессора!!!"); // Ничего не выведет, так как оба условия false
            }

            Console.WriteLine(new string('-', 120));
        }

    }
}
