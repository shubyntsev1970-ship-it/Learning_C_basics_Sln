using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Lessons_WinForms;

namespace Learning_C_basics_App
{
    public static partial class Program
    {
        // ПЕРЕГРУЗКА МЕТОДОВ
        private static void Lesson_031()
        {
            Console.WriteLine("Hello from Lesson_031  ПЕРЕГРУЗКА МЕТОДОВ");
            Console.WriteLine();

            // ПЕРЕГРУЗКА МЕТОДОВ - это возможность создавать несколько методов с одинаковым именем, но разными параметрами. 
            // Это позволяет использовать одно и то же имя метода для разных типов данных или разных количеств параметров.

            // ВЫЗОВ ПЕРЕГРУЖЕННЫХ МЕТОДОВ:
            Console.WriteLine(Sum(2, 3)); // Вызов метода для сложения двух целых чисел
            Console.WriteLine(Sum(1, 2, 3)); // Вызов метода для сложения трех целых чисел
            Console.WriteLine(Sum(2.5, 3.5)); // Вызов метода для сложения двух чисел с плавающей запятой

            Console.WriteLine(new string('-', 120));
        }

        // Так добавляем описание метода, который будет перегружен. В данном случае это метод для сложения чисел.
        /// <summary>
        /// Метод для сложения двух целых чисел
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static int Sum(int a, int b)
        {
            return a + b;
        }

        // Метод для сложения трех целых чисел 
        static int Sum(int a, int b, int c)
        {
            return a + b + c;
        }

        // Метод для сложения двух чисел с плавающей запятой
        static double Sum(double a, double b)
        {
            return a + b;
        }

        // ОБЛАСТЬ ВИДИМОСТИ. КОНТЕКСТ ПЕРЕМЕННОЙ. КОНФЛИКТЫ ОБЛАСТЕЙ ВИДИМОСТИ
        // - это концепция, которая определяет, где в коде переменные и методы доступны для использования.
        private static void Lesson_032()
        {
            Console.WriteLine("Hello from Lesson_032  ОБЛАСТЬ ВИДИМОСТИ. КОНТЕКСТ ПЕРЕМЕННОЙ. КОНФЛИКТЫ ОБЛАСТЕЙ ВИДИМОСТИ");
            Console.WriteLine();

            // ОБЛАСТЬ ВИДИМОСТИ. КОНТЕКСТ ПЕРЕМЕННОЙ. КОНФЛИКТЫ ОБЛАСТЕЙ ВИДИМОСТИ
            // - это концепция, которая определяет, где в коде переменные и методы доступны для использования.

            // В C# существуют следующие области видимости:
            // 1. Локальная область видимости - переменные, объявленные внутри метода, доступны только внутри этого метода.
            // 2. Область видимости класса - переменные, объявленные внутри класса, доступны для всех методов этого класса.
            // 3. Глобальная область видимости - переменные, объявленные вне всех классов и методов,
            // доступны для всего кода в проекте.
            // КОНФЛИКТЫ ОБЛАСТЕЙ ВИДИМОСТИ - это ситуация, когда две или более переменных с
            // одинаковым именем объявлены в разных областях видимости.


            // Циклы имеют свою собственную область видимости,
            // и переменные, объявленные внутри цикла, доступны только внутри этого цикла.
            for (int n = 0; n < 3; n++)
            {
                int j = n * 2; // Переменная j объявлена внутри цикла for, она доступна только внутри этого цикла
                // int i; // Конфликт!
                Console.WriteLine(j);
            }
            // j = 10; // Ошибка! Переменная j недоступна вне цикла for

            int i; // Переменная i объявлена в области видимости метода Lesson_032, она доступна внутри этого метода
                   // Но теперь будет конфликт, если мы попытаемся использовать переменную i внутри цикла for,
                   // так как она уже объявлена в цикле for. меняем в цикле i на n, чтобы избежать конфликта
            i = 8; // Теперь переменная i доступна и может быть изменена внутри метода Lesson_032
            Console.WriteLine(i);

            Console.WriteLine(new string('-', 120));
        }

        // ССЫЛОЧНЫЕ И ЗНАЧИМЫЕ ТИПЫ. СТЕК И КУЧА. REFERENCE AND VALUE TYPES
        private static void Lesson_033()
        {
            Console.WriteLine("Hello from Lesson_033  ССЫЛОЧНЫЕ И ЗНАЧИМЫЕ ТИПЫ. СТЕК И КУЧА. REFERENCE AND VALUE TYPES");
            Console.WriteLine();

            // В C# существуют два типа данных: значимые (value types) и ссылочные (reference types).
            // Значимые типы хранятся в стеке и включают примитивные типы, такие как int, double, char, bool и struct.
            // Ссылочные типы хранятся в куче и включают объекты, массивы и строки.
            // При присвоении значимого типа создается копия данных, тогда как при присвоении ссылочного типа создается
            // ссылка на объект в куче. Это означает, что изменения в одном экземпляре ссылочного типа будут отражаться
            // на всех ссылках, указывающих на этот объект,
            // тогда как изменения в одном экземпляре значимого типа не будут влиять на другие экземпляры. 

            // при наведении курсора на тип данных в Visual Studio, можно увидеть,
            // является ли он значимым или ссылочным типом.
            // Примеры значимых типов:
            // - int, double, char, bool, struct, enum, decimal, DateTime, TimeSpan и другие.
            // при наведении на int, , double, char, bool мы видим, что это struct,
            // а struct - это значимый тип данных, который хранится в стеке.
            int f = 5; // Значимый тип, хранится в стеке
            bool isTrue = true; // Значимый тип, хранится в стеке
            char letter = 'A'; // Значимый тип, хранится в стеке
            double pi = 3.14; // Значимый тип, хранится в стеке

            Console.WriteLine(MyEnum.One);
            Console.WriteLine((int)MyEnum.One);

            // Примеры ссылочных типов: 
            // - string, object, dynamic, class, interface, delegate и другие.
            string name = "Hello"; // Ссылочный тип, хранится в куче
            object obj = new object(); // Ссылочный тип, хранится в куче
            dynamic dynamicObj = new { Name = "Dynamic Object" }; // Ссылочный тип, хранится в куче

            Console.WriteLine(new string('-', 120));
        }

        enum MyEnum
        {
            One = 1,
            Two = 2
        } // Значимый тип, хранится в стеке

        // ЧТО ТАКОЕ NULL
        private static void Lesson_034()
        {
            Console.WriteLine("Hello from Lesson_034  ЧТО ТАКОЕ NULL");
            Console.WriteLine();

            // NULL - это специальное значение, которое указывает на отсутствие данных или ссылку на несуществующий объект.
            // В C# NULL может быть присвоен только ссылочным типам и nullable типам.
            // При попытке доступа к члену объекта, который имеет значение NULL, возникает исключение NullReferenceException
            // .
            string str = null; // Ссылочный тип, может быть присвоено значение null
            object obj = null; // Ссылочный тип, может быть присвоено значение null
            // int number = null; // Ошибка! Значимый тип не может быть присвоено значение null
            int? nullableNumber = null; // Nullable тип, может быть присвоено значение null

            int[] a = new int[10];
            Console.WriteLine(a[0]);
            a = null; // Теперь переменная a указывает на null,
                      // и попытка доступа к элементу массива вызовет NullReferenceException
            try
            {
                Console.WriteLine(a.Length); // Ошибка! NullReferenceException, так как переменная a указывает на null
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }

            Console.WriteLine(new string('-', 120));
        }

        // ОПЕРАТОР NULL-COALESCING. ОПЕРАТОР ОБЪЕДИНЕНИЯ С NULL - ?? . ПРИМЕР
        private static void Lesson_035()
        {
            Console.WriteLine("Hello from Lesson_035  ОПЕРАТОР NULL-COALESCING. ОПЕРАТОР ОБЪЕДИНЕНИЯ С NULL - ?? . ПРИМЕР");
            Console.WriteLine();


            // ОПЕРАТОР NULL-COALESCING (??) - это оператор, который возвращает левый операнд, если он не равен null,
            // или правый операнд, если левый операнд равен null.
            // Это позволяет легко задавать значение по умолчанию для переменных, которые могут быть null.

            string str, result;

            str = null;

            if (str == null)
            {
                result = "Default Value";
            }
            else
            {
                result = str;
            }
            Console.WriteLine(result); // Вывод: "Default Value"

            // С помощью оператора null-coalescing (??) можно упростить код,
            // который проверяет на null и присваивает значение по умолчанию.

            result = str ?? "Default Value"; // Если str равно null, используется "Default Value"
            Console.WriteLine(result); // Вывод: "Default Value"

            str = "Hello";
            result = str ?? "Default Value"; // Если str не равно null, используется значение str
            Console.WriteLine(result); // Вывод: "Hello"

            // также работает с nullable типами:
            int? nullableNumber = null;
            int resultNumber = nullableNumber ?? 0; // Если nullableNumber равно null, используется 0
            Console.WriteLine(resultNumber); // Вывод: 0

            Console.WriteLine(new string('-', 120));
        }

        // ОПЕРАТОР УСЛОВНОГО NULL ?. ПРИМЕР ИСПОЛЬЗОВАНИЯ
        private static void Lesson_037()
        {
            Console.WriteLine("Hello from Lesson_037  ОПЕРАТОР УСЛОВНОГО NULL ?. ПРИМЕР ИСПОЛЬЗОВАНИЯ");
            Console.WriteLine();

            // ОПЕРАТОР УСЛОВНОГО NULL (?.) - это оператор, который позволяет безопасно
            // обращаться к членам объекта, который может быть null.
            // Если объект равен null, то результат всего выражения будет null,
            // вместо того чтобы выбрасывать исключение NullReferenceException.

            int[] myArray = GetArray();

            // Будет NullReferenceException, если myArray будет null 
            Console.WriteLine($"Сумма элементов массива: {myArray.Sum()}");
            // С помощью оператора условного null (?.) можно безопасно обращаться к членам объекта, который может быть null.
            Console.WriteLine($"Сумма элементов массива: {myArray?.Sum() ?? 0}");

            Person1 person1 = GetPerson();

            // string fullName = person.GetFullName(); // Будет NullReferenceException, если person будет null
            // надо использовать оператор условного null (?.) для безопасного вызова метода GetFullName(),
            // который может быть null
            string fullName = person1?.FirstName ?? "Person is null";
            Console.WriteLine(fullName);


            Console.WriteLine(new string('-', 120));
        }

        static int[] GetArray()
        {
            int[] myArray = { 1, 2, 3 };
            return myArray;
        }

        static Person1 GetPerson()
        {
            Person1 person = null;
            return person;
        }

        internal class Person1
        {
            public string FirstName { get; set; }
        }

        // КЛЮЧЕВОЕ СЛОВО ref. Что это и для чего нужно. Передача аргументов по ссылке.
        private static void Lesson_038()
        {
            Console.WriteLine("Hello from Lesson_038  КЛЮЧЕВОЕ СЛОВО ref. Что это и для чего нужно. Передача аргументов по ссылке.");
            Console.WriteLine();

            // КЛЮЧЕВОЕ СЛОВО ref - это ключевое слово в C#, которое используется для передачи аргумента по ссылке в метод. 
            // Это позволяет методу изменять значение аргумента, переданного в него, и эти изменения будут видны
            // за пределами метода.

            int number = 5;
            Console.WriteLine($"До вызова метода Increment number={number}"); // Вывод: 5
            Increment(number);
            Console.WriteLine($"После вызова метода Increment без ref number={number}"); // Вывод: 5
            Increment(ref number);
            Console.WriteLine($"После вызова метода Increment с ref number={number}"); // Вывод: 6

            // string — ссылочный тип, но неизменяемый (immutable),
            // поэтому без ref изменения не влияют на исходную переменную
            string myString = "Hello";
            Console.WriteLine($"Моя строка до вызова метода - {myString}");
            ChangeString(myString);
            Console.WriteLine($"Моя строка после вызова метода без ref - {myString}");
            ChangeString(ref myString);
            Console.WriteLine($"Моя строка после вызова метода с ref - {myString}");

            // ref удобно когда много параметров, и нужно изменить их значения внутри метода,
            // чтобы не возвращать их через return, а просто передать по ссылке и изменить внутри метода.
            int a = 10, b = 20, c = 30;
            Console.WriteLine($"До вызова метода Increment с ref a={a}, b={b}, c={c}");
            Increment(ref a, ref b, ref c);
            Console.WriteLine($"После вызова метода Increment с ref a={a}, b={b}, c={c}");

            MyStruct myStruct = new MyStruct { a = 1, b = 2.5, c = 3.5f };
            Console.WriteLine($"До вызова метода Increment с ref для структуры a={myStruct.a}, b={myStruct.b}, c={myStruct.c}");
            Increment(ref myStruct);
            Console.WriteLine($"После вызова метода Increment с ref для структуры a={myStruct.a}, b={myStruct.b}, c={myStruct.c}");

            // для ссылочных типов, таких как классы, передача по ссылке(ref) не требуется,
            // так как они уже передаются по ссылке.
            MyClass myClass = new MyClass { a = 1, b = 2.5, c = 3.5f };
            Console.WriteLine($"До вызова метода Increment для класса a={myClass.a}, b={myClass.b}, c={myClass.c}");
            Increment(myClass);
            Console.WriteLine($"После вызова метода Increment для класса a={myClass.a}, b={myClass.b}, c={myClass.c}");

            // Массивы в C# являются ссылочными типами, поэтому при передаче массива в метод, мы передаем ссылку на массив,
            // ref не требуется, так как изменения в массиве внутри метода будут видны за пределами метода.
            int[] ints = { 1, 2, 3, 4, 5 };
            Console.WriteLine($"До вызова метода Bar для массива ints[0]={ints[0]}");
            Bar(ints);
            Console.WriteLine($"После вызова метода Bar для массива ints[0]={ints[0]}");

            // Однако, если мы хотим изменить саму ссылку на массив, то нам нужно использовать ref,
            // чтобы передать ссылку на массив по ссылке.
            // То есть если без ref то ссылка копируется в стеке, и получается две ссылки на один и тот же массив,
            // и изменения в одном месте будут видны в другом месте, так как обе ссылки указывают на один и тот же массив.
            // но изменения самой ссылки в методе не повлияют на исходную ссылку, так как она копируется в стеке.
            // Поэтому для изменения ссылки на массив нужно использовать ref.
            Console.WriteLine($"До вызова метода NewArray для массива: {String.Join(" ", ints)}");
            NewArray(ref ints);
            Console.WriteLine($"После вызова метода NewArray для массива: {String.Join(" ", ints)}");

            Console.WriteLine(new string('-', 120));
        }

        private static void Increment(int number)
        {
            number++;
        }

        private static void Increment(ref int number)
        {
            number++;
        }

        private static void Increment(ref int number1, ref int number2, ref int number3)
        {
            number1++;
            number2++;
            number3++;
        }

        private static void ChangeString(string str)
        {
            str += str;
        }

        private static void ChangeString(ref string str)
        {
            str += str;
        }

        struct MyStruct
        {
            public int a;
            public double b;
            public float c;
        }

        private static void Increment(ref MyStruct myStruct)
        {
            myStruct.a++;
            myStruct.b++;
            myStruct.c++;
        }

        class MyClass
        {
            public int a;
            public double b;
            public float c;
        }

        private static void Increment(MyClass myClass)
        {
            myClass.a++;
            myClass.b++;
            myClass.c++;
        }

        static void Bar(int[] myArray)
        {
            myArray[0] = 100; // Изменение первого элемента массива
        }

        static void NewArray(ref int[] myArray)
        {
            myArray = new int[] { 5, 4, 3, 2, 1 };
        }

        // Ссылочные локальные переменные. Возвращаемые ссылочные значения
        private static void Lesson_039()
        {
            Console.WriteLine("Hello from Lesson_039  Ссылочные локальные переменные. Возвращаемые ссылочные значения");
            Console.WriteLine();

            // Ссылочная локальная переменная - это переменная, которая хранит ссылку на объект в памяти, а не само значение.
            // Возвращаемые ссылочные значения - это возможность возвращать ссылку на объект из метода, а не само значение.

            int[] arr = { 2, 6, 1 };


            int b = arr[0];
            Console.WriteLine("b - переменная типа int");
            Console.WriteLine($"arr[0]={arr[0]}  b=arr[0] равно {b}");
            b = -5;
            Console.WriteLine($"после b=-5 arr[0]={arr[0]} b={b}");

            //    Ссылочная локальная переменная - это переменная, которая хранит ссылку на объект в памяти, а не само значение.
            //     тогда
            ref int a = ref arr[0]; // Ссылочная локальная переменная, которая ссылается на arr[0] 
            Console.WriteLine("a - переменная типа ref  int");
            Console.WriteLine($"arr[0]={arr[0]}  ref int a = ref arr[0] равно {a}");
            a = -5;
            Console.WriteLine($"после a=-5 arr[0]={arr[0]} a={a}");

            // Ссылочная локальная переменная, которая ссылается на результат метода Foo, который возвращает ссылку на arr[0]
            ref int c = ref Foo(arr);
            Console.WriteLine("c - переменная типа ref  int");
            Console.WriteLine($"arr[0]={arr[0]}  ref int c = ref Foo(arr) равно {c}");
            c = 100;
            Console.WriteLine($"после c=-5 arr[0]={arr[0]} c={c}"); 

            Console.WriteLine(new string('-', 120));
        }

        static ref int Foo(int[] numbers)
        {
            return ref numbers[0]; // Возвращаем ссылку на первый элемент массива
        }

        // КЛЮЧЕВОЕ СЛОВО OUT. РАЗНИЦА между REF и OUT
        private static void Lesson_040()
        {
            Console.WriteLine("Hello from Lesson_040  КЛЮЧЕВОЕ СЛОВО OUT. РАЗНИЦА между REF и OUT");
            Console.WriteLine();
            
            // КЛЮЧЕВОЕ СЛОВО OUT - это ключевое слово в C#, которое используется для передачи аргумента по ссылке в метод,
            // но с обязательным присвоением значения внутри метода.
            // В отличие от ref, аргумент, переданный с помощью out, не должен (но может) быть инициализирован
            // до вызова метода, но должен быть обязательно присвоен внутри метода.
            
            int number;
            
            //Console.WriteLine(number); // Ошибка! Переменная number не инициализирована
            Initialize(out number);
            Console.WriteLine($"Значение переменной number после вызова метода Initialize(out int number): {number}"); // Вывод: 100

            // Можно так
            Initialize(out int number1);
            Console.WriteLine($"Значение переменной number1 после вызова метода Initialize(out int number1): {number1}"); // Вывод: 100

            Console.WriteLine(new string('-', 120));
        }

        private static void Initialize(out int number)
        {
            number = 100; // Присваиваем значение параметру out
        }
    }
}
