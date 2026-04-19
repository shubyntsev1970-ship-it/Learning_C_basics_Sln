using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_C_basics_App
{
    public static partial class Program
    {
        // МОДИФИКАТОР IN и бенчмарк(Stopwatch). РАЗНИЦА между IN REF и OUT
        private static void Lesson_041()
        {
            Console.WriteLine("Hello from Lesson_041  МОДИФИКАТОР IN и бенчмарк(Stopwatch). РАЗНИЦА между IN REF и OUT");
            Console.WriteLine();

            // Модификатор in был добавлен в C# 7.2 и используется для передачи аргументов по ссылке, но с гарантией того,
            // что значение не будет изменено внутри метода. Это позволяет оптимизировать производительность при передаче
            // больших структур данных, таких как структуры или большие объекты, без необходимости создавать копию данных.
            // Разница между in, ref и out заключается в следующем:
            // - in: Аргумент передается по ссылке, но не может быть изменен внутри метода. Это обеспечивает безопасность
            // и оптимизацию производительности.
            // - ref: Аргумент передается по ссылке и может быть изменен внутри метода. Это позволяет методу изменять
            // значение аргумента.
            // - out: Аргумент передается по ссылке и должен быть обязательно присвоен внутри метода до его использования.
            // Это используется для возвращения нескольких значений из метода.
            // Бенчмарк (benchmark) - это процесс измерения производительности кода, обычно с целью сравнения различных
            // реализаций или оптимизаций. В данном случае, использование модификатора in может улучшить производительность
            // при работе с большими структурами данных, так как избегает создания копий данных.
            Console.WriteLine("Пример использования модификатора in:");
            int number = 10;
            PrintNumber(in number); // Передача аргумента с помощью in
            Console.WriteLine();

            Console.WriteLine("Пример использования модификатора ref:");
            int refNumber = 20;
            Console.WriteLine($"Значение до изменения: {refNumber}");
            ModifyNumber(ref refNumber); // Передача аргумента с помощью ref
            Console.WriteLine($"Значение после изменения: {refNumber}");
            Console.WriteLine();

            Console.WriteLine("Пример использования модификатора out:");
            int outNumber;
            InitializeNumber(out outNumber); // Передача аргумента с помощью out
            Console.WriteLine($"Значение после инициализации: {outNumber}");

            Console.WriteLine(new string('-', 120));
        }

        private static void InitializeNumber(out int outNumber)
        {
            //outNumber++; // Ошибка компиляции: переменная outNumber должна быть обязательно присвоена до использования
            outNumber = 100;
        }

        private static void ModifyNumber(ref int refNumber)
        {
            refNumber++;
        }

        private static void PrintNumber(in int number)
        {
            //number++; // Ошибка компиляции: нельзя изменить значение аргумента, переданного с помощью in
            Console.WriteLine($"Значение числа: {number}");
        }

        // КЛЮЧЕВОЕ СЛОВО PARAMS
        private static void Lesson_042()
        {
            Console.WriteLine("Hello from Lesson_042  КЛЮЧЕВОЕ СЛОВО PARAMS");
            Console.WriteLine();

            // Ключевое слово params используется для указания, что метод может принимать переменное количество
            // аргументов одного типа. 
            // Это позволяет вызывать метод с разным количеством аргументов без необходимости создавать массив вручную.

            // Пример использования ключевого слова params:
            Console.WriteLine("Пример использования ключевого слова params:");

            Console.WriteLine("Вызываем PrintNumbersSum(1, 2, 3, 4, 5)");
            PrintNumbersSum(1, 2, 3, 4, 5); // Передача нескольких аргументов

            Console.WriteLine("Вызываем PrintNumbersSum(10, 20)");
            PrintNumbersSum(10, 20); // Передача другого количества аргументов

            Console.WriteLine("Вызываем PrintNumbersSum()");
            PrintNumbersSum(); // Вызов метода без аргументов

            Foo("test", 5, 'q', 5.89, true);

            Console.WriteLine(new string('-', 120));
        }

        // Пример использования params
        private static void PrintNumbersSum(params int[] numbers)
        {
            int sum = 0;

            foreach (var number in numbers)
                sum += number;

            Console.WriteLine($"Сумма чисел: {sum}");
        }
        static void Foo(params object[] parameters)
        {
            string message = "Тип данных {0}, значение {1}";

            foreach (var item in parameters)
                Console.WriteLine(message, item.GetType(), item);

        }

        // НЕОБЯЗАТЕЛЬНЫЕ ПАРАМЕТРЫ МЕТОДА (параметры по умолчанию)
        private static void Lesson_043()
        {
            Console.WriteLine("Hello from Lesson_043  НЕОБЯЗАТЕЛЬНЫЕ ПАРАМЕТРЫ МЕТОДА (параметры по умолчанию)");
            Console.WriteLine();

            // Необязательные параметры метода, также известные как параметры по умолчанию, позволяют
            // задавать значения по умолчанию для параметров метода. Это означает, что при вызове метода
            // можно не указывать эти параметры, и они будут автоматически принимать заданные значения.

            // Пример использования параметров по умолчанию:

            Console.WriteLine("Пример использования параметров по умолчанию:");

            PrintMessage("Hello, World!"); // Использует значение по умолчанию для параметра times

            PrintMessage("Hello, C#!", 3); // Указывает значение для параметра times

            Console.WriteLine(Sum1(11, 9));

            Console.WriteLine(Sum1(11, 9, true));

            Console.WriteLine(new string('-', 120));
        }

        private static void PrintMessage(string message, int times = 1)
        {
            for (int i = 0; i < times; i++)
            {
                Console.WriteLine(message);
            }
        }
        static int Sum1(int a, int b, bool enableLogging = false)
        {
            int result = a + b;

            if (enableLogging)
            {
                Console.WriteLine("Значение переменной a = " + a);
                Console.WriteLine("Значение переменной b = " + b);
                Console.WriteLine("Результат сложения = " + result);
            }

            return result;
        }

        // ИМЕНОВАННЫЕ ПАРАМЕТРЫ
        private static void Lesson_044()
        {
            Console.WriteLine("Hello from Lesson_044  ИМЕНОВАННЫЕ ПАРАМЕТРЫ");
            Console.WriteLine();

            // Именованные параметры позволяют указывать аргументы метода по имени, а не по позиции. Это улучшает
            // читаемость кода и позволяет передавать аргументы в любом порядке.

            // Пример использования именованных параметров:
            Console.WriteLine("Пример использования именованных параметров:");

            PrintPersonInfo(name: "Alice", age: 30); // Указываем аргументы по имени

            PrintPersonInfo(age: 25, name: "Bob"); // Указываем аргументы в другом порядке

            Console.WriteLine(new string('-', 120));
        }

        private static void PrintPersonInfo(string name, int age)
        {
            Console.WriteLine($"Имя: {name}, Возраст: {age}");
        }

        // ЧТО ТАКОЕ РЕКУРСИЯ. ПЕРЕПОЛНЕНИЕ СТЕКА. СТЕК ВЫЗОВОВ
        private static void Lesson_045()
        {
            Console.WriteLine("Hello from Lesson_045  ЧТО ТАКОЕ РЕКУРСИЯ. ПЕРЕПОЛНЕНИЕ СТЕКА. СТЕК ВЫЗОВОВ");
            Console.WriteLine();

            // Рекурсия - это техника программирования, при которой функция вызывает сама себя для решения задачи.
            // Рекурсия может быть полезной для решения задач, которые могут быть разбиты на подобные подзадачи.
            // Однако, если рекурсивные вызовы не имеют базового случая или условие выхода, это может привести к
            // переполнению стека (stack overflow), когда стек вызовов превышает свою максимальную глубину.
            // Также если передается большой объем данных или слишком много рекурсивных вызовов,
            // это может привести к переполнению стека.

            // Пример рекурсии:
            Console.WriteLine("Пример рекурсии: вычисление факториала числа:");

            int number = 5;

            int result = Factorial(number);

            Console.WriteLine($"Факториал числа {number} равен {result}");

            // Пример рекурсии:
            Item item = InitItem();
            Print(item);

            // Можно с помощью for цикла сделать то же самое, что и с помощью рекурсии, только без рекурсии,
            // но это будет менее элегантно и более громоздко:
            for (Item i = item; i != null; i = i.Child)
            {
                Console.WriteLine(i.Value);
            }

            Console.WriteLine(new string('-', 120));
        }

        private static int Factorial(int n)
        {
            if (n <= 1) // Базовый случай: факториал 0 или 1 равен 1
                return 1;
            return n * Factorial(n - 1); // Рекурсивный вызов
        }

        class Item
        {
            public int Value { get; set; }
            public Item Child { get; set; }
        }

        static Item InitItem()
        {
            return new Item()
            {
                Value = 5,
                Child = new Item()
                {
                    Value = 10,
                    Child = new Item()
                    {
                        Value = 2
                    }
                }
            };
        }

        static void Print(Item item)
        {
            if (item == null)
                return;

            Console.WriteLine($"Value: {item.Value}");
            Print(item.Child);
        }

        // ПРЕОБРАЗОВАНИЕ И ПРИВЕДЕНИЕ ТИПОВ. Явное. Неявное
        private static void Lesson_046()
        {
            Console.WriteLine("Hello from Lesson_046  ПРЕОБРАЗОВАНИЕ И ПРИВЕДЕНИЕ ТИПОВ. Явное. Неявное");
            Console.WriteLine();

            // Преобразование типов - это процесс изменения типа данных переменной или значения. В C# существует
            // два основных вида преобразования типов: неявное и явное.
            // - Неявное преобразование (implicit conversion) происходит автоматически, когда компилятор может гарантировать,
            // что преобразование не приведет к потере данных или ошибкам. Например, преобразование int в double.
            // - Явное преобразование (explicit conversion) требует использования оператора приведения (cast), когда
            // компилятор не может гарантировать безопасность преобразования. Например, преобразование double в int
            // может привести к потере данных, поэтому требуется явное приведение.

            Console.WriteLine("Пример неявного преобразования:");
            int intValue = 42;
            double doubleValue = intValue; // Неявное преобразование int в double
            Console.WriteLine($"intValue: {intValue}, doubleValue: {doubleValue}");
            Console.WriteLine();

            Console.WriteLine("Пример явного преобразования:");
            double anotherDoubleValue = 3.14;
            int anotherIntValue = (int)anotherDoubleValue; // Явное преобразование double в int
            Console.WriteLine($"anotherDoubleValue: {anotherDoubleValue}, anotherIntValue: {anotherIntValue}");

            Console.WriteLine(new string('-', 120));
        }

        // Арифметическое переполнение. checked unchecked
        private static void Lesson_047()
        {
            Console.WriteLine("Hello from Lesson_047  Арифметическое переполнение. checked unchecked");
            Console.WriteLine();

            // Арифметическое переполнение происходит, когда результат арифметической операции превышает максимально
            // допустимое значение для данного типа данных. В C#, по умолчанию, арифметические операции не проверяют
            // на переполнение, и если оно происходит, результат может быть неожиданным.
            // Ключевые слова checked и unchecked используются для управления поведением при переполнении:
            // - checked: Включает проверку на переполнение. Если происходит переполнение,
            // генерируется исключение OverflowException.
            // - unchecked: Отключает проверку на переполнение. Если происходит переполнение,
            // результат оборачивается вокруг допустимых значений типа.

            Console.WriteLine("Пример unchecked (без проверки на переполнение):");
            int maxIntValue = int.MaxValue; // Максимальное значение для типа int = 2147483647
            int resultUnchecked = maxIntValue + 1; // Происходит переполнение, результат оборачивается

            // Результат будет -2147483648 из-за переполнения
            Console.WriteLine($"Максимальное значение int: {maxIntValue}, результат unchecked: {resultUnchecked}");
            Console.WriteLine();

            int minIntValue = int.MinValue; // Минимальное значение для типа int = -2147483648
            int resultUnchecked1 = minIntValue - 1; // Происходит переполнение, результат оборачивается

            // Результат будет 2147483647 из-за переполнения
            Console.WriteLine($"Минимальное значение int: {minIntValue}, результат unchecked: {resultUnchecked1}");
            Console.WriteLine();

            Console.WriteLine("Пример checked (с проверкой на переполнение):");
            try
            {
                // Эту проверку можно также включить глобально для всего проекта в файле .csproj,
                // добавив элемент <CheckForOverflowUnderflow>true</CheckForOverflowUnderflow>
                int resultChecked = checked(maxIntValue + 1); // Происходит переполнение, генерируется исключение
                Console.WriteLine($"Результат checked: {resultChecked}");
            }
            catch (OverflowException ex)
            {
                Console.WriteLine($"Переполнение произошло: {ex.Message}");
            }


            // Пример ядерного Ганди из игры Civilization, который был багом в оригинальной игре и стал легендарным
            // мемом в геймерском сообществе. Ганди был представлен как очень мирный лидер с низким уровнем агрессии (1),
            // но из-за бага, когда он получал ядерное оружие, его агрессия внезапно становилась максимальной (255),
            // что делало его крайне опасным противником.

            Console.WriteLine();
            Console.WriteLine("Пример ядерного Ганди из игры Civilization");
            string name = "Ганди";
            byte aggression = 1;     // 1 = очень мирный
            byte democracy = 2;
            bool hasNukes = true;   // есть ядерка

            Console.WriteLine("Начало игры:");
            Console.WriteLine($"{name}, агрессия: {aggression}");

            if (aggression <= 2)
            {
                Console.WriteLine("Ганди предлагает мир ☮️");
            }

            Console.WriteLine("\nПроизошёл баг...");

            // Хотели снизить уровень агрессии Ганди, но из-за бага он стал максимально агрессивным
            aggression = (byte)(aggression - democracy);


            Console.WriteLine($"\nТеперь агрессия: {aggression}");

            if (hasNukes && aggression >= 10)
            {
                Console.WriteLine("Ганди запускает ЯДЕРКУ 💥 ");
            }

            // Также стоит отметить, что в C# есть специальные методы для проверки на переполнение
            // и некорректные операции с числами, такие как деление на ноль. Например, при делении на ноль
            // или при операциях,которые приводят к бесконечности или NaN (Not a Number), можно использовать методы
            // double.IsInfinity() и double.IsNaN() для проверки результатов.
            double a = 1.0 / 0.0;

            Console.WriteLine(double.IsInfinity(a)); // output: True

            double b = 0.0 / 0.0;
            Console.WriteLine(double.IsNaN(b)); // output: True

            double c = double.MaxValue + double.MaxValue;
            Console.WriteLine(double.IsInfinity(c)); // output: True

            // При работе с типом decimal, который используется для финансовых расчетов,
            // также может произойти переполнение, но в отличие от типов int и double,
            // при переполнении decimal будет выбрасывать исключение OverflowException,
            // а не оборачиваться вокруг допустимых значений. Это связано с тем, что decimal имеет
            // более строгие правила для обработки переполнения, чтобы обеспечить точность в финансовых расчетах.
            decimal a1 = decimal.MaxValue;
            decimal b1 = decimal.MaxValue;
            try
            {
                decimal c1 = unchecked(a1 + b1);// Даже при использовании unchecked, при переполнении decimal
                                                // будет выбрасывать исключение
                Console.WriteLine(c1);
            }
            catch (Exception)
            {
                Console.WriteLine("Переполнение произошло при работе с decimal");
            }

            Console.WriteLine(new string('-', 120));
        }

        // Что такое Nullable. Null совместимые значимые типы Nullable
        private static void Lesson_048()
        {
            Console.WriteLine("Hello from Lesson_048  Что такое Nullable. Null совместимые значимые типы Nullable");
            Console.WriteLine();

            // Nullable (null-совместимые) типы - это обертки над значимыми типами, которые позволяют им принимать
            // значение null.
            // Это полезно для случаев, когда нужно указать отсутствие значения для типов, которые по умолчанию
            // не могут быть null, таких как int, double, bool и т.д.
            // В C#, nullable типы представлены через обобщенный тип Nullable<T> или синтаксисом T?.

            // Пример использования nullable типов:
            Console.WriteLine("Пример использования nullable типов:");
            int? nullableInt = null; // Объявление nullable типа int
            Console.WriteLine($"Значение nullableInt: {nullableInt}"); // Выводит: Значение nullableInt:
            nullableInt = 42; // Присвоение значения

            // Выводит: Значение nullableInt после присвоения: 42
            Console.WriteLine($"Значение nullableInt после присвоения: {nullableInt}");

            // Выводит: Значение nullableInt через свойство HasValue: 42
            if (nullableInt.HasValue)
                Console.WriteLine($"Значение nullableInt через свойство HasValue: {nullableInt.Value}");

            // Также можно использовать оператор null-коалесцирования (??) для предоставления значения по умолчанию,
            // если переменная null:
            Nullable<int> nullableInt1 = 42;
            int defaultValue = 100;
            int result = nullableInt1 ?? defaultValue; // Если nullableInt1 не имеет значения, используется defaultValue

            // Выводит: Результат с использованием оператора null-коалесцирования: 42
            Console.WriteLine($"Результат с использованием оператора null-коалесцирования: {result}");

            int? i = null;

            Console.WriteLine(i == null); // True

            Console.WriteLine(i.HasValue); // False

            Console.WriteLine(i.GetValueOrDefault()); // 0;

            Console.WriteLine(i.GetValueOrDefault(3)); // 3;

            Console.WriteLine(i ?? 55); // 55;

            // При попытке доступа к свойству Value у nullable типа, который не имеет значения (null),
            // будет выброшено исключение InvalidOperationException.
            try
            {
                Console.WriteLine(i.Value); // InvalidOperationException
            }
            catch (Exception)
            {

                Console.WriteLine("Попытка доступа к свойству Value у nullable типа, который не имеет значения (null), вызвала исключение.");
            }

            i = 2;

            Console.WriteLine(i); // 2

            Console.WriteLine(i == null); // False

            Console.WriteLine(i.HasValue); // True

            Console.WriteLine(i.GetValueOrDefault()); // 2;

            Console.WriteLine(i.GetValueOrDefault(3)); // 2;

            Console.WriteLine(i ?? 55); // 2;

            Console.WriteLine(i.Value); // 2

            Console.WriteLine(new string('-', 120));
        }

        // var что это. VAR ЭТО НЕ ТИП ДАННЫХ. неявно типизированные переменные
        private static void Lesson_049()
        {
            Console.WriteLine("Hello from Lesson_049  var что это. VAR ЭТО НЕ ТИП ДАННЫХ. неявно типизированные переменные");
            Console.WriteLine();

            // Ключевое слово var используется для объявления неявно типизированных переменных.
            // Это означает, что компилятор автоматически определяет тип переменной на основе присвоенного значения.
            // Важно отметить, что var - это не тип данных, а просто синтаксический сахар для удобства написания кода.

            // Пример использования var:
            Console.WriteLine("Пример использования var:");
            var number = 42; // Компилятор определяет тип как int
            var message = "Hello, World!"; // Компилятор определяет тип как string
            var isActive = true; // Компилятор определяет тип как bool
            Console.WriteLine($"number: {number}, type: {number.GetType()}");
            Console.WriteLine($"message: {message}, type: {message.GetType()}");
            Console.WriteLine($"isActive: {isActive}, type: {isActive.GetType()}");

            // Также стоит отметить, что при использовании var, переменная должна быть инициализирована
            // в момент объявления, так как компилятор должен иметь возможность определить ее тип.
            // Если попытаться объявить var без инициализации, будет ошибка компиляции.

            // Например, следующий код вызовет ошибку компиляции:
            // var uninitializedVar; // Ошибка: переменная должна быть инициализирована

            Console.WriteLine(new string('-', 120));
        }

        // enum ЧТО ЭТО И ДЛЯ ЧЕГО НУЖНО. перечисления enum
        private static void Lesson_050()
        {
            Console.WriteLine("Hello from Lesson_050  enum ЧТО ЭТО И ДЛЯ ЧЕГО НУЖНО. перечисления enum");
            Console.WriteLine();

            // Перечисления (enum) позволяют создавать именованные константы, которые представляют собой набор связанных
            // значений. Это улучшает читаемость кода и делает его более понятным.

            DaysOfWeek today = DaysOfWeek.Saturday;
            Console.Write($"Сегодня: {today}  ");
            Console.WriteLine($"{(int)today}-й день недели"); // Выводит: 7-й день недели
            Console.WriteLine($"Следующий за {today} идет {GetNextDay(today)}");
            Console.WriteLine($"3-ему дню недели соответствует {(DaysOfWeek)3}"); // Выводит: 3-ему дню недели соответствует Wednesday

            int value = 55;

            // При попытке привести значение 55 к типу DaysOfWeek, который не имеет такого значения в своем определении,
            // можем столкнуться с проблемой, так как 55 не соответствует ни одному из определенных дней недели.
            // В этом случае, можем использовать метод Enum.IsDefined для проверки, существует ли такое значение
            // в перечислении, прежде чем пытаться его привести. Если значение не определено, мы можем обработать
            // эту ситуацию, например, вывести сообщение об ошибке или использовать значение по умолчанию.

            try
            {
                Enum.IsDefined(typeof(DaysOfWeek), value);
                today = (DaysOfWeek)value; // приводим int к DayOfWeek
                Console.WriteLine(today);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid DayOfWeek value.");
            }

            var values = Enum.GetValues(typeof(DaysOfWeek));

            foreach (var item in values)
                Console.WriteLine($"{item} - {(byte)item}");

            string str = "wednesday";
            today = (DaysOfWeek)Enum.Parse(typeof(DaysOfWeek), str, ignoreCase: true);
            Console.WriteLine(today); // Выводит: Wednesday


            // Автоматически генерируется switch в коде для каждого элемента перечисления,
            // что позволяет обрабатывать все возможные значения перечисления в одном месте.
            // Для этого необходимо кликнуть левой кнопкой мыши на свободном месте внутри метода
            // Автоматически, при использовании switch с enum,
            // компилятор может выдавать предупреждение, если не все возможные значения перечисления
            switch (today)
            {
                case DaysOfWeek.Monday:
                    break;
                case DaysOfWeek.Tuesday:
                    break;
                case DaysOfWeek.Wednesday:
                    break;
                case DaysOfWeek.Thursday:
                    break;
                case DaysOfWeek.Friday:
                    break;
                case DaysOfWeek.Saturday:
                    break;
                case DaysOfWeek.Sunday:
                    break;
                default:
                    break;
            }

            // По умолчанию, underlying type для enum - это int,
            // и каждому элементу перечисления присваивается целочисленное значение,
            // начиная с 0 для первого элемента и увеличиваясь на 1 для каждого последующего элемента. В данном примере,
            // Monday будет иметь значение 1, Tuesday - 2, и так далее. Также можно явно указать underlying type для enum,
            // например, byte, и тогда значения будут занимать меньше памяти.
            // В нашем примере, мы указали underlying type byte,
            // поэтому Monday будет иметь значение 1, Tuesday - 2, и так далее, но все они будут занимать всего 1 байт памяти.
            Console.WriteLine(Enum.GetUnderlyingType(typeof(DaysOfWeek)));

            while (true)
            {
                ConsoleKey key = Console.ReadKey().Key;

                int keyCode = (int)key;

                Console.WriteLine($"\tEnum {key}\tKey Code {keyCode}");

                if (key == ConsoleKey.Enter)
                {
                    Console.WriteLine("Вы нажали enter!");
                    break;
                }
            }

            Console.WriteLine(new string('-', 120));
        }

        private static DaysOfWeek GetNextDay(DaysOfWeek today)
        {
            if (today < DaysOfWeek.Sunday)
                return today + 1;
            return DaysOfWeek.Monday;
        }

        // Пример использования enum:
        enum DaysOfWeek : byte
        {
            Monday = 1,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday
        }
    }
}


