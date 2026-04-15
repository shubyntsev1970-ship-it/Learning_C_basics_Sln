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

            Console.ReadLine();
        }
    }
}
