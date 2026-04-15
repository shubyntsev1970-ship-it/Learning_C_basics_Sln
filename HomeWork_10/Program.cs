using System;

namespace HomeWork_10
{
    internal static class Program
    {
        static void Main()
        {
            Console.WriteLine("Домашнее задание 10 Пример использования ref");
            Utilities.ConsoleUnderRisk('=', 120);
            Console.WriteLine("Домашнее задание 10.1 Написать метод Resize, изменяющий количество элементов массива\n" +
                              "(метод должен иметь возможность увеличить или уменьшить количество элементов массива).");

            int[] MyArray = Utilities.GetRandomArray(10);

            Utilities.ShowArrayOnConsole(MyArray, "Исходный массив");

            Console.Write("Введите на какое количество элементов (не более 9) Вы хотите увеличить или уменшить (со знаком -) исходный массив: ");
            int ResizeValue;
            while (!int.TryParse(Console.ReadLine(), out ResizeValue) || ResizeValue > 9 || ResizeValue < -9)
                Console.Write("Ошибка !!! Пожалуйста, введите целое число от -9 до 9: ");
            Utilities.Resize(ref MyArray, ResizeValue);

            Utilities.ShowArrayOnConsole(MyArray, "Измененный массив");

            Utilities.ConsoleUnderRisk('=', 120);

            Console.WriteLine("Домашнее задание 10.2 Написать методы для добавления элемента в начало массива,\n" +
                              "в конец массива и по указанному индексу.");

            int[] MyArray1 = Utilities.GetRandomArray(15);

            Utilities.ShowArrayOnConsole(MyArray1, "Исходный массив");

            Console.Write("Введите какой элемент добавить в начало исходного массива: ");

            int NewValue;

            while (!int.TryParse(Console.ReadLine(), out NewValue))
                Console.Write("Ошибка !!! Пожалуйста, введите целое число: ");

            Utilities.AddValueToArrayBegin(ref MyArray1, NewValue);

            Utilities.ShowArrayOnConsole(MyArray1, "Измененный массив");

            Utilities.ConsoleUnderRisk('-', 120);

            MyArray1 = Utilities.GetRandomArray(15);

            Utilities.ShowArrayOnConsole(MyArray1, "Исходный массив");

            Console.Write("Введите какой элемент добавить в конец исходного массива: ");

            while (!int.TryParse(Console.ReadLine(), out NewValue))
                Console.Write("Ошибка !!! Пожалуйста, введите целое число: ");

            Utilities.AddValueToArrayEnd(ref MyArray1, NewValue);

            Utilities.ShowArrayOnConsole(MyArray1, "Измененный массив");

            Utilities.ConsoleUnderRisk('-', 120);

            MyArray1 = Utilities.GetRandomArray(15);

            Utilities.ShowArrayOnConsole(MyArray1, "Исходный массив");

            Console.Write("Введите какой элемент добавить в массив: ");

            while (!int.TryParse(Console.ReadLine(), out NewValue))
                Console.Write("Ошибка !!! Пожалуйста, введите целое число: ");

            uint index;
            Console.Write($"Введите индекс, по которому добавить элемент {NewValue} в массив, учитывая размер массива: ");
            while (!uint.TryParse(Console.ReadLine(), out index) || index > MyArray1.Length)
                Console.Write($"Ошибка !!! Пожалуйста, введите целое число от 0 до {MyArray1.Length}: ");

            Utilities.AddValueToArrayIndex(ref MyArray1, NewValue, index);

            Utilities.ShowArrayOnConsole(MyArray1, "Измененный массив");


            Utilities.ConsoleUnderRisk('=', 120);

            Console.WriteLine("Домашнее задание 10.3 Написать методы для удаления первого элемента массива, последнего\n" +
                              "элемента массива и элемента по указанному индексу.");

            int[] MyArray2 = Utilities.GetRandomArray(20);

            Utilities.ShowArrayOnConsole(MyArray2, "Исходный массив");

            Console.WriteLine("Удаление первого элемента массива.");

            Utilities.DelValueFromArrayBegin(ref MyArray2);

            Utilities.ShowArrayOnConsole(MyArray2, "Измененный массив");

            Utilities.ConsoleUnderRisk('-', 120);


            MyArray2 = Utilities.GetRandomArray(20);

            Utilities.ShowArrayOnConsole(MyArray2, "Исходный массив");

            Console.WriteLine("Удаление последнего элемента массива.");

            Utilities.DelValueFromArrayEnd(ref MyArray2);

            Utilities.ShowArrayOnConsole(MyArray2, "Измененный массив");

            Utilities.ConsoleUnderRisk('-', 120);

            MyArray2 = Utilities.GetRandomArray(20);

            Utilities.ShowArrayOnConsole(MyArray2, "Исходный массив");

            Console.Write($"Введите индекс, по которому удалить элемент из массива, учитывая размер массива: ");
            while (!uint.TryParse(Console.ReadLine(), out index) || index > MyArray2.Length - 1)
                Console.Write($"Ошибка !!! Пожалуйста, введите целое число от 0 до {MyArray2.Length - 1}: ");

            Utilities.DelValueFromArrayIndex(ref MyArray2, index);

            Utilities.ShowArrayOnConsole(MyArray2, "Измененный массив");

            Utilities.ConsoleUnderRisk('=', 120);

            Console.ReadLine();
        }

        private class Utilities
        {
            /// <summary>
            /// Метод для отображения массива на консоли
            /// </summary>
            /// <param name="arr">Массив, который нужно отобразить</param>
            /// <param name="str">Строка, которая будет отображаться перед массивом</param>
            /// <remarks>Метод использует метод String.Join для объединения элементов массива в строку с разделителем " "</remarks>
            public static void ShowArrayOnConsole(int[] arr, string str)
            {
                if (arr == null)
                    return;
                Console.WriteLine($"{str} из {arr.Length} элементов: {String.Join(" ", arr)}");
            }

            /// <summary>
            /// Метод для получения массива заданного размера, заполненного случайными числами от 0 до 100
            /// </summary>
            /// <param name="size">Размер массива</param>
            /// <returns>Массив случайных чисел</returns>
            /// <remarks>Метод использует класс Random для генерации случайных чисел</remarks>
            public static int[] GetRandomArray(uint size)
            {

                int[] NewArray = new int[size];
                Random random = new Random();

                // Заполняем массив случайными числами от 0 до 100
                for (int i = 0; i < NewArray.Length; i++)
                    NewArray[i] = random.Next(0, 100);

                return NewArray;
            }

            
            /// <summary>
            /// Resizes the specified array by the given number of elements, increasing its length and preserving
            /// existing values.
            /// </summary>
            /// <remarks>The method creates a new array with a length equal to the original array's
            /// length plus the specified resize value, copies existing elements, and assigns the new array to the
            /// reference. Elements beyond the original length are initialized to their default value (0).</remarks>
            /// <param name="arr">The array to resize. If null, the method returns without making changes.</param>
            /// <param name="resizeValue">The number of elements to add to the array's length.</param>
            public static void Resize(ref int[] arr, int resizeValue)
            {
                if (arr == null || arr.Length + resizeValue < 0)
                    return;

                int[] NewArray = new int[arr.Length + resizeValue];
                for (int i = 0; i < NewArray.Length; i++)
                {
                    if (i > arr.Length - 1)
                        break;
                    NewArray[i] = arr[i];
                }
                arr = NewArray;
            }

            /// <summary>
            ///  Выводит в консоль строку, состоящую из указанного символа, повторённого заданное количество раз.
            /// </summary>
            /// <param name="symbol">Символ, который будет повторяться в выводимой строке.</param>
            /// <param name="size">Количество повторений символа в строке. Должно быть неотрицательным числом.</param>
            public static void ConsoleUnderRisk(char symbol, uint size)
            {
                Console.WriteLine(new String(symbol, (int)size));
            }

            /// <summary>
            ///  Вставляет заданное значение в начало массива целых чисел, сдвигая существующие элементы вправо.
            /// </summary>
            /// <remarks>Исходный массив будет заменён новым массивом, содержащим добавленное
            /// значение. Размер массива увеличивается на единицу.</remarks>
            /// <param name="arr">Ссылка на массив целых чисел, в который будет добавлено новое значение в начало. После выполнения метода
            /// ссылка будет указывать на новый массив с добавленным элементом.</param>
            /// <param name="value">Значение, которое необходимо добавить в начало массива.</param>
            public static void AddValueToArrayBegin(ref int[] arr, int value)
            {
                if (arr == null)
                    return;

                int[] NewArray = new int[arr.Length + 1];

                NewArray[0] = value;

                for (int i = 0; i < arr.Length; i++)
                    NewArray[i + 1] = arr[i];

                arr = NewArray;
            }

            
            /// <summary>
            /// Removes the first element from the specified integer array.
            /// </summary>
            /// <remarks>After the method completes, the referenced array will have one fewer element,
            /// with all remaining elements shifted one position toward the beginning. If the array has zero or one
            /// elements, the resulting array will be empty.</remarks>
            /// <param name="arr">A reference to the array from which the first element will be removed. If the array is null or empty, no
            /// action is taken.</param>
            public static void DelValueFromArrayBegin(ref int[] arr)
            {
                if (arr == null || arr.Length == 0)
                    return;

                int[] NewArray = new int[arr.Length - 1];

                for (int i = 1; i < arr.Length; i++)
                    NewArray[i - 1] = arr[i];

                arr = NewArray;
            }

            /// <summary>
            /// Добавляет указанное значение в конец массива целых чисел.
            /// </summary>
            /// <remarks>Если массив пустой, новый массив будет содержать только указанное значение.
            /// Ссылка на исходный массив будет обновлена на новый массив.</remarks>
            /// <param name="arr">Ссылка на массив целых чисел, к которому будет добавлено новое значение. Массив будет заменён новым
            /// массивом, содержащим добавленное значение.</param>
            /// <param name="value">Значение, которое необходимо добавить в конец массива.</param>
            public static void AddValueToArrayEnd(ref int[] arr, int value)
            {
                if (arr == null)
                    return;

                int[] NewArray = new int[arr.Length + 1];

                for (int i = 0; i < arr.Length; i++)
                    NewArray[i] = arr[i];

                NewArray[arr.Length] = value;

                arr = NewArray;
            }


            /// <summary>
            /// Removes the last element from the specified integer array.
            /// </summary>
            /// <remarks>After the method completes, the referenced array will have one fewer element.
            /// If the array is empty, it remains unchanged.</remarks>
            /// <param name="arr">A reference to the array from which the last element will be removed. If the array is null or empty, no
            /// action is taken.</param>
            public static void DelValueFromArrayEnd(ref int[] arr)
            {
                if (arr == null || arr.Length == 0)
                    return;

                int[] NewArray = new int[arr.Length - 1];

                for (int i = 0; i < arr.Length - 1; i++)
                    NewArray[i] = arr[i];

                arr = NewArray;
            }

            /// <summary>
            ///  Вставляет указанное значение в массив по заданному индексу, сдвигая существующие элементы вправо.
            /// </summary>
            /// <remarks>После выполнения метода исходный массив будет заменён новым массивом,
            /// содержащим вставленное значение. Если индекс равен длине массива, новое значение будет добавлено в
            /// конец.</remarks>
            /// <param name="arr">Ссылка на массив целых чисел, в который будет вставлено новое значение. Массив должен быть
            /// инициализирован.</param>
            /// <param name="value">Значение, которое требуется вставить в массив.</param>
            /// <param name="index">Индекс, по которому будет вставлено новое значение. Должен быть в диапазоне от 0 до длины массива минус
            /// один.</param>
            public static void AddValueToArrayIndex(ref int[] arr, int value, uint index)
            {
                if (arr == null) return;
                if (index > arr.Length) return;
                

                int[] NewArray = new int[arr.Length + 1];

                int shift = 0;

                for (int i = 0; i < arr.Length; i++)
                {
                    if (i == index)
                    {
                        NewArray[i] = value;
                        shift = 1;
                    }
                    NewArray[i + shift] = arr[i];
                }
                if (shift == 0)
                    NewArray[arr.Length] = value;

                arr = NewArray;
            }

            
            /// <summary>
            /// Removes the element at the specified index from the given integer array.
            /// </summary>
            /// <remarks>The method creates a new array with the specified element removed. The
            /// original array reference is updated to point to the new array. If the index is out of range, the method
            /// may throw an exception.</remarks>
            /// <param name="arr">The array from which the element will be removed. If null, the method performs no action.</param>
            /// <param name="index">The zero-based index of the element to remove from the array.</param>
            public static void DelValueFromArrayIndex(ref int[] arr, uint index)
            {
                if (arr == null || arr.Length == 0)
                    return;
                if (index >= arr.Length) return;
                
                int[] NewArray = new int[arr.Length - 1];

                int shift = 0;

                for (int i = 0; i < arr.Length; i++)
                {
                    if (i == index)
                    {
                        shift = 1;
                        continue;
                    }
                    NewArray[i - shift] = arr[i];
                }
                
                arr = NewArray;
            }
        }
    }
}
