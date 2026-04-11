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
    }
}
