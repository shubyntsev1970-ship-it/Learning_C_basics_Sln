using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_C_basics_App
{
    public static partial class Program
    {
        // Условный оператор SWITCH. ЧТО ЭТО. ПРИМЕР. СИНТАКСИС. ОПЕРАТОР МНОЖЕСТВЕННОГО ВЫБОРА
        private static void Lesson_011()
        {
            Console.WriteLine("Hello from Lesson_011 Условный оператор SWITCH. ЧТО ЭТО. ПРИМЕР. СИНТАКСИС. ОПЕРАТОР МНОЖЕСТВЕННОГО ВЫБОРА");

            Console.WriteLine("Введите число от 1 до 3:");

            int number;

            /*
            while (!int.TryParse(Console.ReadLine(), out number))
                Console.WriteLine("Ошибка формата. Введите целое число:");
            */

            number = 2;

            switch (number)
            {
                case 1:
                    Console.WriteLine("Вы ввели число 1");
                    break;
                case 2:
                    Console.WriteLine("Вы ввели число 2");
                    break;
                case 3:
                    Console.WriteLine("Вы ввели число 3");
                    break;
                default:
                    Console.WriteLine("Вы ввели число, которое не входит в диапазон от 1 до 3");
                    break;
            }

            Console.WriteLine(new string('-', 120));
        }

        // ЦИКЛ WHILE. ЧТО ЭТО. КАК РАБОТАЕТ
        private static void Lesson_012()
        {
            Console.WriteLine("Hello from Lesson_012 ЦИКЛ WHILE. ЧТО ЭТО. КАК РАБОТАЕТ");

            int counter = 0;
            while (counter < 5)
            {
                Console.WriteLine($"Выполняем действие {++counter}");
            }

            Console.WriteLine(new string('-', 120));
        }

        // ЦИКЛ DO WHILE. ЧТО ЭТО. КАК РАБОТАЕТ
        private static void Lesson_013()
        {
            Console.WriteLine("Hello from Lesson_013 ЦИКЛ DO WHILE. ЧТО ЭТО. КАК РАБОТАЕТ");

            int counter = 1;
            do
            {
                Console.WriteLine($"Выполняем действие {counter++}");
            } while (counter <= 5);

            counter = 5;
            // в отличии от цикла while, цикл do while гарантирует выполнение тела цикла хотя бы один раз,
            // даже если условие изначально ложно
            do
            {
                Console.WriteLine($"Выполняем действие {counter++}");
            } while (counter < 5);

            Console.WriteLine(new string('-', 120));
        }

        // ЦИКЛ FOR. ЧТО ЭТО. КАК РАБОТАЕТ
        private static void Lesson_014()
        {
            Console.WriteLine("Hello from Lesson_014 ЦИКЛ FOR. ЧТО ЭТО. КАК РАБОТАЕТ");

            // лучше чем while, так как все 3 части цикла (инициализация, условие, итерация)
            // находятся в одной строке, что улучшает читаемость и уменьшает вероятность ошибок
            // используют для циклов с известным количеством итераций, например,
            // для перебора элементов массива или списка
            // while лучше использовать для циклов с неизвестным количеством итераций, например,
            // для чтения данных из файла до конца
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"Выполняем действие {i}");
            }
            //i = 4; // переменная i недоступна за пределами цикла for, так как она объявлена внутри цикла

            // пример зацикливания когда for пустой, так как условие всегда истинно
            // или пропущена иттерация переменная  
            /*
            for (;;)
            {
                Console.WriteLine("for is working");
            }
            for (int i = 0; i < 5;)
            {
                Console.WriteLine("for is working");
            }
            */

            Console.WriteLine(new string('-', 120));
        }

        // ЦИКЛ FOR. В ОБРАТНОМ ПОРЯДКЕ. НЕСКОЛЬКО ПЕРЕМЕННЫХ. НЕСКОЛЬКО УСЛОВИЙ 
        private static void Lesson_015()
        {
            Console.WriteLine("Hello from Lesson_015 ЦИКЛ FOR. В ОБРАТНОМ ПОРЯДКЕ. НЕСКОЛЬКО ПЕРЕМЕННЫХ. НЕСКОЛЬКО УСЛОВИЙ");

            // цикл for может работать в обратном порядке, например, для перебора элементов
            // массива или списка в обратном порядке

            int i = 0; // переменная i объявлена вне цикла for, так как она будет использоваться в нескольких циклах

            for (; i < 3; i++)
            {
                Console.WriteLine($"Выполняем действие из цикла # 1 {i}");
            }
            for (; i < 5; i++)
            {
                Console.WriteLine($"Выполняем действие из цикла # 2 {i}");
            }

            // пример цикла for с несколькими переменными и несколькими условиями
            for (int j = 0, k = 5; j < 5 && k > 0; j++, k--)
            {
                Console.WriteLine($"Выполняем действие j = {j}, k = {k}");
            }

            // пример цикла for , который работает в обратном порядке
            for (int k = 5; k >= 0; k--)
            {
                Console.WriteLine($"Выполняем действие к = {k}");
            }

            Console.WriteLine(new string('-', 120));
        }

        // КЛЮЧЕВОЕ СЛОВО BREAK. ОПЕРАТОР BREAK. ПРИМЕР. СИНТАКСИС 
        private static void Lesson_016()
        {
            Console.WriteLine("Hello from Lesson_016 КЛЮЧЕВОЕ СЛОВО BREAK. ОПЕРАТОР BREAK. ПРИМЕР. СИНТАКСИС");

            // оператор break используется для выхода из цикла или оператора switch
            // при выполнении определенного условия, например, для прерывания цикла при достижении определенного значения
            for (int i = 0; i < 10; i++)
            {
                if (i == 5)
                {
                    break; // выход из цикла при достижении i = 5
                }
                Console.WriteLine($"Выполняем действие i = {i}");
            }

            Console.WriteLine(new string('-', 120));
        }

        // КЛЮЧЕВОЕ СЛОВО CONTINUE. ОПЕРАТОР CONTINUE. ПРИМЕР
        private static void Lesson_017()
        {
            Console.WriteLine("Hello from Lesson_017 КЛЮЧЕВОЕ СЛОВО CONTINUE. ОПЕРАТОР CONTINUE. ПРИМЕР");

            // оператор continue используется для пропуска текущей итерации цикла и перехода к следующей
            for (int i = 0; i < 10; i++)
            {
                if (i == 5)
                {
                    continue; // пропуск итерации при достижении i = 5
                }
                Console.WriteLine($"Выполняем действие i = {i}");
            }

            Console.WriteLine(new string('-', 120));
        }

        // ВЛОЖЕННЫЕ ЦИКЛЫ.КАК РАБОТАЮТ.ПРИМЕР
        private static void Lesson_018()
        {
            Console.WriteLine("Hello from Lesson_018 ВЛОЖЕННЫЕ ЦИКЛЫ. КАК РАБОТАЮТ. ПРИМЕР");

            int size = 3;

            // вложенные циклы - это циклы, которые находятся внутри других циклов
            // они используются для перебора многомерных массивов или для выполнения сложных операций,
            // которые требуют нескольких уровней итерации
            for (int i = 1; i <= size; i++)
            {
                Console.WriteLine($"Цикл 1 итерация N: {i}");

                for (int j = 1; j <= size; j++)
                {
                    Console.WriteLine($"\tЦикл 2 итерация N: {j}");

                    for (int k = 1; k <= size; k++)
                    {
                        Console.WriteLine($"\t\tЦикл 3 итерация N: {k}");
                    }
                }
            }

            // как нарисовать в консоли прямоугольник из символов, используя вложенные циклы
            for (int j = 0; j < 10; j++)
            {
                for (int i = 0; i < 20; i++)
                {
                    Console.Write('#');
                }

                Console.WriteLine();
            }

            Console.WriteLine();

            int rows = 5;
            int columns = 10;
            var myArray = GetRandomArray(rows, columns);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{myArray[i, j]}\t");
                }

                Console.WriteLine();
            }

            var gamesInfo = GetGamesInfo();

            for (int i = 0; i < gamesInfo.Count; i++)
            {
                Console.WriteLine($"{gamesInfo[i].TypeOfGame}:");

                for (int j = 0; j < gamesInfo[i].Games.Count; j++)
                {
                    Console.WriteLine($" - {gamesInfo[i].Games[j].Name}");
                }

                Console.WriteLine();
            }

            // пример бесконечного вложенного цикла, который будет работать до тех пор,
            // пока не будет принудительно остановлен
            // здесь 3 вложенных цикла, которые будут работать бесконечно, так как условие всегда истинно
            // можно вкладывать разные типы циклов, например, while внутри for, do while внутри while и т.д. 
            /*
            while (true)
            {
                for (int i = 0; i < length; i++)
                {
                    for (int j = 0; j < length; j++)
                    {
                        do
                        {
                        } while (true);
                    }
                }
            }
            */

            Console.WriteLine(new string('-', 120));
        }

        // ТЕРНАРНЫЙ ОПЕРАТОР. ЧТО ЭТО. ПРИМЕР. КАК ИСПОЛЬЗОВАТЬ
        private static void Lesson_019()
        {
            Console.WriteLine("Hello from Lesson_019 ТЕРНАРНЫЙ ОПЕРАТОР. ЧТО ЭТО. ПРИМЕР. КАК ИСПОЛЬЗОВАТЬ");

            // тернарный оператор - это сокращённая форма условного оператора if else, которая позволяет
            // записать условие и его результат в одной строке
            // синтаксис: [condition] ? [expressionIfTrue] : [expressionIfFalse];
            // тернарный оператор возвращает значение, которое может быть присвоено переменной или использовано в выражении
            int number = 10;
            int number1 = 1;
            string result = number % 2 == 0 ? "Чётное" : "Нечётное";
            Console.WriteLine($"Число {number} является {result}");
            string result1 = number1 % 2 == 0 ? "Чётное" : "Нечётное";
            Console.WriteLine($"Число {number1} является {result1}");

            Console.WriteLine(new string('-', 120));
        }

        // ЧТО ТАКОЕ МАССИВЫ. ОДНОМЕРНЫЙ МАССИВ. ПРИМЕРЫ
        private static void Lesson_020() 
        { 
            Console.WriteLine("Hello from Lesson_020 ЧТО ТАКОЕ МАССИВЫ. ОДНОМЕРНЫЙ МАССИВ. ПРИМЕРЫ");

            // массив - это структура данных, которая позволяет хранить несколько значений одного типа в одной переменной.
            int[] myArray;
            myArray = new int[5];

            myArray[1] = 3;

            foreach (int i in myArray)
                Console.WriteLine(i);
            Console.WriteLine($"Элемент массива с индексом 1: {myArray[1]}");
            Console.WriteLine($"Размер массива: {myArray.Length}");

            Console.WriteLine(new string('-', 120));
        }
    }
}
