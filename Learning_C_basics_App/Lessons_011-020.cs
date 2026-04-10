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
    }
}
