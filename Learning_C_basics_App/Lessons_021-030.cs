using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_C_basics_App
{
    public static partial class Program
    {
        // ИНИЦИАЛИЗАЦИЯ МАССИВА. СПОСОБЫ. ПРИМЕРЫ
        private static void Lesson_021()
        {
            Console.WriteLine("Hello from Lesson_021 ИНИЦИАЛИЗАЦИЯ МАССИВА. СПОСОБЫ. ПРИМЕРЫ");

            // инициализация массива - это процесс присвоения начальных значений элементам массива.
            // В C# существует несколько способов инициализации массивов. Вот некоторые из них:

            int[] myArray = new int[5]; // Инициализация массива с помощью оператора new. Все элементы
                                        // будут инициализированы значением по умолчанию (0 для int).

            int[] myArray1 = new int[5] { 1, 2, 3, 4, 5 }; // Инициализация массива с помощью инициализатора массива.
                                                           // Здесь мы задаем размер массива (5) и сразу же присваиваем
                                                           // значения для !!!всех!!! элементов массива.


            int[] myArray2 = { 1, 2, 3, 4, 5 }; // Инициализация массива с помощью инициализатора массива. 
                                                // Здесь мы сразу задаем значения для всех элементов массива.

            foreach (var item in myArray2)
            {
                Console.WriteLine(item);
            }

            // Если не хотим чтобы по умолчанию все элементы были инициализированы нулём,то можно
            int[] myArray3 = Enumerable.Repeat(1, 5).ToArray();  // Инициализация массива с помощью метода Enumerable.Repeat. 
                                                                 // Здесь мы создаем массив из 5 элементов,
                                                                 // все из которых будут иметь значение 1.

            foreach (var item in myArray3)
            {
                Console.WriteLine(item);
            }

            //или
            int[] myArray4 = Enumerable.Range(1, 5).ToArray(); // Инициализация массива с помощью метода Enumerable.Range. 
                                                               // Здесь мы создаем массив из 5 элементов, 
                                                               // которые будут иметь значения от 1 до 5.

            foreach (var item in myArray4)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(new string('-', 120));
        }

        // ВЫВОД МАССИВА. ПЕРЕБОР МАССИВА. МАССИВЫ И ЦИКЛЫ
        private static void Lesson_022()
        {
            Console.WriteLine("Hello from Lesson_022 ВЫВОД МАССИВА. ПЕРЕБОР МАССИВА. МАССИВЫ И ЦИКЛЫ");

            // Вывод массива - это процесс отображения элементов массива на консоли или в другом месте.
            // Перебор массива - это процесс прохода по каждому элементу массива для выполнения определенных действий с ними.
            // Массивы и циклы - это часто используемые конструкции в программировании,
            // которые позволяют эффективно работать с коллекциями данных.

            int[] myArray = { 1, 2, 3, 4, 5 };

            // Вывод массива с помощью цикла for
            for (int i = 0; i < myArray.Length; i++)
            {
                Console.WriteLine(myArray[i]);
            }

            // Вывод массива с помощью цикла foreach
            foreach (var item in myArray)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(new string('-', 120));
        }

        // КАК РАБОТАТЬ С МАССИВАМИ В C# НА САМОМ ДЕЛЕ
        private static void Lesson_023()
        {
            Console.WriteLine("Hello from Lesson_023 КАК РАБОТАТЬ С МАССИВАМИ В C# НА САМОМ ДЕЛЕ");

            int[] myArray = { 111, 10, 4, 10, 49, 64, 77, 4, 42, 5 };

            Console.WriteLine("Исходдный массив:");
            Console.WriteLine(string.Join(" ", myArray));
            // Получаем максимальное значение в массиве
            Console.WriteLine($"Максимальное значение  массива: {myArray.Max()}");
            // Получаем минимальное значение в массиве
            Console.WriteLine($"Минимальное значение  массива: {myArray.Min()}");
            // Получаем сумму всех элементов массива
            Console.WriteLine($"Сумма всех элементов массива: {myArray.Sum()}");
            // Получаем сумму всех четных элементов массива
            Console.WriteLine($"Сумма всех четных элементов массива: {myArray.Where(x => x % 2 == 0).Sum()}");
            // Получаем среднее значение элементов массива
            Console.WriteLine($"Среднее значение элементов массива: {myArray.Average()}");
            // Переворачиваем массив
            Console.WriteLine("Перевернутый массив:");
            Console.WriteLine(string.Join(" ", myArray.Reverse()));
            // Убираем дубликаты из массива
            Console.WriteLine("Массив без дубликатов:");
            Console.WriteLine(string.Join(" ", myArray.Distinct()));
            // Сортируем массив по возрастанию
            Console.WriteLine("Массив, отсортированный по возрастанию:");
            Console.WriteLine(string.Join(" ", myArray.OrderBy(x => x)));
            // Сортируем массив по убыванию
            Console.WriteLine("Массив, отсортированный по убыванию:");
            Console.WriteLine(string.Join(" ", myArray.OrderByDescending(x => x)));

            // Абстрактный класс Array в C# предоставляет множество методов для работы с массивами,
            // таких как Sort, Reverse, IndexOf, LastIndexOf и многие другие.
            // Статические методы класса Array позволяют выполнять операции над массивами, не создавая экземпляр класса Array,
            // так как он является абстрактным классом и не может быть инстанцирован.

            // Так нельзя
            // myArray.Sort();
            // Надо так
            // Array.Sort(myArray);

            // В данном случае мы ищем первый элемент, который меньше 70.
            int result = Array.Find(myArray, x => x < 70);
            Console.WriteLine($"Первый элемент массива, который меньше 70: {result}");

            // В данном случае мы ищем последний элемент, который меньше 70.
            result = Array.FindLast(myArray, x => x < 70);
            Console.WriteLine($"Последний элемент массива, который меньше 70: {result}");

            // В данном случае мы ищем все элементы массива, которые меньше 70.
            int[] results = Array.FindAll(myArray, x => x < 70);
            Console.WriteLine($"Все элементы массива, которые меньше 70: {string.Join(" ", results)}");

            // В данном случае мы ищем индекс первого элемента, который меньше 70.
            result = Array.FindIndex(myArray, x => x < 70);
            Console.WriteLine($"Индекс первого элемента массива, который меньше 70: {result}");

            // Переворачиваем массив 
            // В отличие от метода Reverse() из LINQ, который возвращает новый перевернутый массив,
            // метод Array.Reverse() изменяет порядок элементов в существующем массиве.
            Array.Reverse(myArray);
            Console.WriteLine($"Переворачиваем массив: {string.Join(" ", myArray)}");

            result = myArray.Where(x => x < 70).First();
            Console.WriteLine($"Первый элемент массива, который меньше 70: {result}");
            result = myArray.Where(x => x < 0).FirstOrDefault();
            Console.WriteLine($"Первый элемент массива, который меньше 0: {result}");
            result = myArray.Where(x => x < 70).Last();
            Console.WriteLine($"Последний элемент массива, который меньше 70: {result}");
            results = myArray.Where(x => x < 70).ToArray();
            Console.WriteLine($"Все элементы массива, которые меньше 70: {string.Join(" ", results)}");

            Console.WriteLine(new string('-', 120));
        }

        // ДВУМЕРНЫЙ МАССИВ. ОБЪЯВЛЕНИЕ. ИНИЦИАЛИЗАЦИЯ. ИНДЕКСЫ
        private static void Lesson_025()
        {
            Console.WriteLine("Hello from Lesson_025 ДВУМЕРНЫЙ МАССИВ. ОБЪЯВЛЕНИЕ. ИНИЦИАЛИЗАЦИЯ. ИНДЕКСЫ");

            // Двумерный массив - это массив, который содержит строки и столбцы. Он может быть представлен в виде таблицы.
            // Объявление двумерного массива в C# выглядит следующим образом:
            // тип_данных[,] имя_массива = new тип_данных[количество_строк, количество_столбцов];

            int[,] myArray = new int[3, 5]; // Объявление двумерного массива с 3 строками и 5 столбцами.

            myArray[2, 4] = 10;
            Console.WriteLine($"myArray[2,4] = {myArray[2, 4]}");

            // Инициализация двумерного массива с помощью инициализатора массива. 
            // Здесь мы задаем значения для всех элементов массива.
            int[,] myArray1 =
            {
                { 2, 4, 66, 53, 35 },
                { 6, 8, 7, 9, 10 },
                { 11, 12, 13, 14, 15 }
            };

            Console.WriteLine(new string('-', 120));
        }

        // ВЫВОД ДВУМЕРНОГО МАССИВА
        private static void Lesson_026()
        {
            Console.WriteLine("Hello from Lesson_026 ВЫВОД ДВУМЕРНОГО МАССИВА");

            int[,] myArray =
            {
                { 2, 4, 66, 53, 35 },
                { 6, 8, 7, 9, 10 },
                { 11, 12, 13, 14, 15 }
            };

            // Метод GetLength() используется у многомерных массивов.
            // Он принимает один параметр - номер измерения (0 для строк, 1 для столбцов)
            // - и возвращает количество элементов в этом измерении.
            Console.WriteLine($"Массив размерностью {myArray.Rank} {myArray.GetLength(0)}x{myArray.GetLength(1)}");
            Console.WriteLine($"Строк: {myArray.GetLength(0)}");
            Console.WriteLine($"Столбцов: {myArray.GetLength(1)}");
            for (int i = 0; i < myArray.GetLength(0); i++)
            {
                for (int j = 0; j < myArray.GetLength(1); j++)
                {
                    Console.Write($"{myArray[i, j]}\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine(new string('-', 120));
        }

        // ЗАПОЛНЕНИЕ ДВУМЕРНОГО МАССИВА С КЛАВИАТУРЫ. СЛУЧАЙНЫМИ ЧИСЛАМИ
        private static void Lesson_027()
        {
            Console.WriteLine("Hello from Lesson_027 ЗАПОЛНЕНИЕ ДВУМЕРНОГО МАССИВА С КЛАВИАТУРЫ. СЛУЧАЙНЫМИ ЧИСЛАМИ");

            // Заполнение двумерного массива с клавиатуры - это процесс ввода
            // значений для каждого элемента массива с помощью консоли.
            // Заполнение двумерного массива случайными числами - это процесс присвоения
            // случайных значений для каждого элемента массива с помощью генератора случайных чисел.

            int[,] myArray = new int[3, 5];
            Random random = new Random();

            // Заполнение двумерного массива случайными числами
            for (int i = 0; i < myArray.GetLength(0); i++)
            {
                for (int j = 0; j < myArray.GetLength(1); j++)
                {
                    myArray[i, j] = random.Next(1, 100); // Заполняем массив случайными числами от 1 до 99
                }
            }

            // Вывод заполненного массива
            Console.WriteLine("Случайные числа в массиве:");
            for (int i = 0; i < myArray.GetLength(0); i++)
            {
                for (int j = 0; j < myArray.GetLength(1); j++)
                {
                    Console.Write($"{myArray[i, j]}\t");
                }
                Console.WriteLine();
            }

            // Заполнение двумерного массива с клавиатуры
            /*
            for (int i = 0; i < myArray.GetLength(0); i++)
            {
                for (int j = 0; j < myArray.GetLength(1); j++)
                {
                    Console.Write($"Введите элемент массива [{i}, {j}] (целое число): ");
                    while (!int.TryParse(Console.ReadLine(), out myArray[i, j]))
                        Console.Write(  $"Некорректный ввод. " +
                                        $"Пожалуйста, введите целое число для элемента массива [{i}, {j}]: ");
                }
            }

            // Вывод заполненного массива
            Console.WriteLine("Массив, введенный вручную:");
            for (int i = 0; i < myArray.GetLength(0); i++)
            {
                for (int j = 0; j < myArray.GetLength(1); j++)
                {
                    Console.Write($"{myArray[i, j]}\t");
                }
                Console.WriteLine();
            }
            */

            Console.WriteLine(new string('-', 120));
        }

        // СТУПЕНЧАТЫЕ(ЗУБЧАТЫЕ) МАССИВЫ
        private static void Lesson_028()
        {
            Console.WriteLine("Hello from Lesson_028 СТУПЕНЧАТЫЕ(ЗУБЧАТЫЕ) МАССИВЫ");

            // Ступенчатые (зубчатые) массивы - это массивы массивов, где каждая строка может иметь
            // разное количество столбцов.
            // Они объявляются с помощью двойного массива, но каждая строка инициализируется отдельно.

            int[][] jaggedArray = new int[3][]; // Объявление ступенчатого массива с 3 строками
            jaggedArray[0] = new int[] { 1, 2, 3 }; // Инициализация первой строки с 3 элементами
            jaggedArray[1] = new int[] { 4, 5 };    // Инициализация второй строки с 2 элементами
            jaggedArray[2] = new int[] { 6, 7, 8, 9 }; // Инициализация третьей строки с 4 элементами

            // Вывод ступенчатого массива
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.Write($"{jaggedArray[i][j]}\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            int[][] jaggedArray1 =
            {
                new int[] { 1, 2, 3, 47, 47, 347, 736, 367,3  },
                new int[] { 4, 5, 66, 77, 78 },
                new int[] { 6, 7 }
            };

            // Вывод ступенчатого массива
            for (int i = 0; i < jaggedArray1.Length; i++)
            {
                for (int j = 0; j < jaggedArray1[i].Length; j++)
                {
                    Console.Write($"{jaggedArray1[i][j]}\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine(new string('-', 120));
        }

        // ТРЁХМЕРНЫЕ МАССИВЫ. МНОГОМЕРНЫЕ МАССИВЫ ЛЮБОЙ МЕРНОСТИ
        private static void Lesson_029()
        {
            Console.WriteLine("Hello from Lesson_029 ТРЁХМЕРНЫЕ МАССИВЫ. МНОГОМЕРНЫЕ МАССИВЫ ЛЮБОЙ МЕРНОСТИ");

            // Трёхмерные массивы - это массивы, которые содержат строки, столбцы и глубину (или слои).
            // Они объявляются с помощью тройного массива.
            // Объявление трёхмерного массива с 2 слоями, 3 строками и 4 столбцами
            
            int[,,] threeDimensionalArray = new int[2, 3, 4];

            // Инициализация трёхмерного массива слуайными числами
            Random random = new Random();
            for (int i = 0; i < threeDimensionalArray.GetLength(0); i++)
            {
                for (int j = 0; j < threeDimensionalArray.GetLength(1); j++)
                {
                    for (int k = 0; k < threeDimensionalArray.GetLength(2); k++)
                    {
                        // Заполняем массив случайными числами от 1 до 99
                        threeDimensionalArray[i, j, k] = random.Next(1, 100);
                    }
                }
            }

            // Вывод трёхмерного массива
            for (int i = 0; i < threeDimensionalArray.GetLength(0); i++)
            {
                for (int j = 0; j < threeDimensionalArray.GetLength(1); j++)
                {
                    for (int k = 0; k < threeDimensionalArray.GetLength(2); k++)
                    {
                        Console.Write($"{threeDimensionalArray[i, j, k]}\t");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }

            // Пример заполнения случайными числами и вывода четырёхмерного массива
            int[,,,] fourDimensionalArray = new int[3, 5, 5, 10];
            for (int i = 0; i < fourDimensionalArray.GetLength(0); i++)
            {
                for (int j = 0; j < fourDimensionalArray.GetLength(1); j++)
                {
                    for (int k = 0; k < fourDimensionalArray.GetLength(2); k++)
                    {
                        for (int l = 0; l < fourDimensionalArray.GetLength(3); l++)
                        {
                            fourDimensionalArray[i, j, k, l] = random.Next(1, 100);
                        }
                    }
                }
            }

            // Вывод четырёхмерного массива
            for (int i = 0; i < fourDimensionalArray.GetLength(0); i++)
            {
                Console.WriteLine($"== Книга N: {i + 1} ==");
                for (int j = 0; j < fourDimensionalArray.GetLength(1); j++)
                {
                    Console.WriteLine($"== Страница N: {j + 1} ==");
                    for (int k = 0; k < fourDimensionalArray.GetLength(2); k++)
                    {
                        for (int l = 0; l < fourDimensionalArray.GetLength(3); l++)
                        {
                            Console.Write($"{fourDimensionalArray[i, j, k, l]}\t");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }

            // Пример заполнения случайными числами зубчатого 3 мерного массива с случайным размером
            int[][][] myArray = new int[random.Next(3, 6)][][];

            for (int i = 0; i < myArray.Length; i++)
            {
                myArray[i] = new int[random.Next(2, 6)][];

                for (int j = 0; j < myArray[i].Length; j++)
                {
                    myArray[i][j] = new int[random.Next(2, 6)];

                    for (int k = 0; k < myArray[i][j].Length; k++)
                    {
                        myArray[i][j][k] = random.Next(100);
                    }
                }
            }

            // Вывод на консоль зубчатого  3 мерного массива
            for (int i = 0; i < myArray.Length; i++)
            {
                Console.WriteLine($"--- Уровень i = {i} ---");

                for (int j = 0; j < myArray[i].Length; j++)
                {
                    Console.Write($"i={i}, j={j} -> [ ");

                    for (int k = 0; k < myArray[i][j].Length; k++)
                    {
                        Console.Write($"{myArray[i][j][k]} ");

                        // разделитель (чтобы не было лишнего пробела в конце)
                        if (k < myArray[i][j].Length - 1)
                            Console.Write("| ");
                    }

                    Console.WriteLine("]");
                }

                Console.WriteLine(); // пустая строка между уровнями
            }

            Console.WriteLine(new string('-', 120));
        }

        // ФУНКЦИИ И МЕТОДЫ. МЕТОД ЧТО ЭТО. ФУНКЦИИ ПРИМЕР
        private static void Lesson_030()
        {
            Console.WriteLine("Hello from Lesson_030 ФУНКЦИИ И МЕТОДЫ. МЕТОД ЧТО ЭТО. ФУНКЦИИ ПРИМЕР");

            // Метод - это блок кода, который выполняет определенную задачу и может быть вызван из других частей программы.
            // Функция - это термин, который часто используется в других языках программирования, но в C# мы обычно
            // говорим "метод".
            // Методы могут принимать параметры и возвращать значения.

            // Синтаксис метода в C# выглядит следующим образом:
            // модификаторы тип_возвращаемого_значения название_метода(параметры)
            // {
            //     тело метода
            // }

            // Пример метода, который принимает два числа и возвращает их сумму
            int Sum(int a, int b)
            {
                return a + b;
            }
            
            // Вызов метода
            int result = Sum(5, 10);
            Console.WriteLine($"Сумма 5 и 10 равна: {result}");

            // Пример метода, который не возвращает значение (void) и не принимает параметры
            void PrintMessage()
            {
                Console.WriteLine("Вызван метод PrintMessage");
            }

            // Вызов метода
            PrintMessage();

            // Пример метода, который не возвращает значение (void) и принимает параметры
            void PrintResult(int a, int b)
            {
                Console.WriteLine($"Сумма {a} и {b} равна: {a + b}");
            }

            // Вызов метода
            PrintResult(5, 10);

            Console.WriteLine(new string('-', 120));
        }
    }
}
