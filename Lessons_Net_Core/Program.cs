namespace Lessons_Net_Core
{
    internal static class Program
    {
        static void Main()
        {
            // Lesson_024() ИНДЕКСЫ И ДИАПАЗОНЫ в C# 8.0 и выше

            Console.WriteLine("Hello from Lesson_024 ИНДЕКСЫ И ДИАПАЗОНЫ");

            int[] myArray = { 2, 10, 5, 6, 77, 89 };

            Console.WriteLine("Исходдный массив:");
            Console.WriteLine(string.Join(" ", myArray));

            // Индексы в C# начинаются с 0, поэтому первый элемент массива имеет индекс 0,
            // второй элемент имеет индекс 1 и так далее. Последний элемент массива имеет индекс Length - 1.

            // Получаем первый элемент массива
            Console.WriteLine($"Первый элемент массива: {myArray[0]}");

            // Получаем второй элемент массива
            Console.WriteLine($"Второй элемент массива: {myArray[1]}");

            // Получаем последний элемент массива
            Console.WriteLine($"Последний элемент массива: {myArray[myArray.Length - 1]}");

            // ИНДЕКСЫ И ДИАПАЗОНЫ в C# 8.0 и выше позволяют нам легко работать с массивами и другими коллекциями,
            //предоставляя удобный синтаксис для доступа к элементам и создания подмассивов.
            // Диапазоны в C# позволяют нам легко получать подмассивы из существующего массива.
            // Синтаксис для создания диапазона выглядит следующим образом: array[startIndex..endIndex],
            // где startIndex - это индекс первого элемента диапазона, а endIndex - это индекс элемента,
            // который следует за последним элементом диапазона.

            // Получаем последний элемент массива с помощью индекса ^1 (индекс от конца)
            Console.WriteLine($"Последний элемент массива с помощью индекса ^1 (индекс от конца): {myArray[^1]}");

            // Получаем второй с конца элемент массива с помощью индекса ^2 (индекс от конца)
            Console.WriteLine($"Второй с конца элемент массива с помощью индекса ^2 (индекс от конца): {myArray[^2]}");

            Index index = ^3;
            Console.WriteLine($"Значения index value = {index.Value}, index isFromEnd = {index.IsFromEnd}");
            // Получаем третий с конца элемент массива с помощью индекса ^3 (индекс от конца)
            Console.WriteLine($"Третий с конца элемент массива с помощью индекса ^3 (индекс от конца): {myArray[index]}");

            // Получаем элементы с индекса 1 по индекс 3 (не включая индекс 3)
            int[] subArray = myArray[1..3];
            Console.WriteLine($"Подмассив с индекса 1 по индекс 3 (не включая индекс 3): {string.Join(" ", subArray)}");

            Range range = 1..4;
            Console.WriteLine($"Подмассив с индекса 1 по индекс 4 (не включая индекс 4): {string.Join(" ", myArray[range])}");

            // Получаем элементы с начала массива до индекса 3 (не включая индекс 3)
            subArray = myArray[..3];
            Console.WriteLine($"Подмассив с начала массива до индекса 3 (не включая индекс 3): {string.Join(" ", subArray)}");

            // Получаем элементы с индекса 2 до конца массива
            subArray = myArray[2..];
            Console.WriteLine($"Подмассив с индекса 2 до конца массива: {string.Join(" ", subArray)}");

            Console.WriteLine(new string('-', 120));

            // Lesson_036() ОПЕРАТОР ПРИСВАИВАНИЯ ОБЪЕДИНЕНИЯ СО ЗНАЧЕНИЕМ NULL в C# 8  ??=
            Console.WriteLine("Hello from Lesson_036 ОПЕРАТОР ПРИСВАИВАНИЯ ОБЪЕДИНЕНИЯ СО ЗНАЧЕНИЕМ NULL");

            string str = null;

            // В этом случае str не изменится
            string result = str ?? "Default Value";
            Console.WriteLine(result);

            // В этом случае str будет присвоено значение "Default Value", так как str равно null
            str ??= "Default Value";
            Console.WriteLine(str);

            Console.WriteLine(new string('-', 120));

            // Lesson_076 Реализация интерфейса по умолчанию
            Console.WriteLine("Hello from Lesson_076  Реализация интерфейса по умолчанию");
            Console.WriteLine();

            ILogger consoleLogger = new ConsoleLogger();

            consoleLogger.Log(LogLevel.Debug, "some event");      // "некоторое событие"
            consoleLogger.Log(LogLevel.Error, "some fatal error"); // "некоторая ошибка"
            consoleLogger.Log(LogLevel.Info, "some info");      // "некоторая информация"
            consoleLogger.Log(LogLevel.Warning, "some warning");  // "некоторое предупреждение"
            consoleLogger.Log(LogLevel.Fatal, "some fatal error"); // "некоторая фатальная ошибка"

            Console.WriteLine();

            consoleLogger.Foo();
                        
            Console.WriteLine(new string('-', 120));

            Console.ReadLine();
        }
        public enum LogLevel
        {
            Debug,
            Info,
            Warning,
            Error,
            Fatal
        }
        public interface ILogger
        {
            void Log(LogLevel logLevel, string message);

            // Реализация интерфейса по умолчанию (Default Interface Implementation) в C# 8.0 и выше
            // Эта возможность добавлена с целью облегчения расширяемости интерфейсов без нарушения существующих реализаций.
            // Так как если бы это было добавлено без реализации по умолчанию, то все классы,
            // которые реализуют этот интерфейс, должны были бы реализовать этот метод.
            void Foo()
            {
                Console.WriteLine("Реализация интерфейса по умолчанию");
            }

        }
        class ConsoleLogger : ILogger
        {
            public void Log(LogLevel logLevel, string message)
            {

                switch (logLevel) // переключатель по уровню логирования
                {
                    case LogLevel.Debug:
                        Console.ForegroundColor = ConsoleColor.Green; // цвет текста — зелёный
                        break;

                    case LogLevel.Info:
                        Console.ForegroundColor = ConsoleColor.White; // цвет текста — белый
                        break;

                    case LogLevel.Warning:
                        Console.ForegroundColor = ConsoleColor.Yellow; // цвет текста — жёлтый
                        break;

                    case LogLevel.Error:
                    case LogLevel.Fatal:
                        Console.ForegroundColor = ConsoleColor.Red; // цвет текста — красный
                        break;
                }
                // вывод в консоль: "текущая дата и время уровень логирования: сообщение"
                Console.WriteLine($"{DateTime.Now} {logLevel}: {message}");
                Console.ResetColor();
            }
        }
    }
}

