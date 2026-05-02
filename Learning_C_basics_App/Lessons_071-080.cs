using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Learning_C_basics_App
{
    public static partial class Program
    {
        // Полиморфизм. Виртуальные методы. virtual override
        public static void Lesson_071()
        {
            Console.WriteLine("Hello from Lesson_071  Полиморфизм. Виртуальные методы. virtual override");
            Console.WriteLine();

            // Полиморфизм - это способность объектов разных классов реагировать на один и тот же метод по-разному.
            // В C# полиморфизм достигается с помощью виртуальных методов и переопределения методов в производных классах.
            // Пример полиморфизма с использованием виртуальных методов и переопределения методов в C#

            // Создаем объект класса Animal
            Animal animal = new Animal();
            animal.MakeSound(); // Выводит "Animal sound"
            // Создаем объект класса Dog, который наследует Animal
            Dog dog = new Dog();
            dog.MakeSound(); // Выводит "Dog bark"
            // Создаем объект класса Cat, который наследует Animal
            Cat cat = new Cat();
            cat.MakeSound(); // Выводит "Cat meow"

            // Используем полиморфизм
            Animal polyAnimal1 = new Dog();
            polyAnimal1.MakeSound(); // Выводит "Dog bark"
            Animal polyAnimal2 = new Cat();
            polyAnimal2.MakeSound(); // Выводит "Cat meow"

            Person2 person = new Person2();

            person.Drive(new Car1());

            person.Drive(new SportCar());

            Console.WriteLine(new string('-', 120));
        }
        internal class Animal
        {
            public virtual void MakeSound()
            {
                Console.WriteLine("Animal sound");
            }
        }

        internal class Dog : Animal
        {
            public override void MakeSound()
            {
                Console.WriteLine("Dog bark");
            }
        }

        internal class Cat : Animal
        {
            public override void MakeSound()
            {
                Console.WriteLine("Cat meow");
            }
        }
        class Car1
        {
            protected virtual void StartEngine()
            {
                Console.WriteLine("Двигатель запущен!");
            }
            public virtual void Drive()
            {
                StartEngine();
                Console.WriteLine("Я машина, я еду!");
            }
        }

        class Person2
        {
            public void Drive(Car1 car)
            {
                car.Drive();
            }
        }

        class SportCar : Car1
        {

            protected override void StartEngine()
            {
                Console.WriteLine("Рон дон дон!");
            }
            public override void Drive()
            {
                StartEngine();
                Console.WriteLine("Я спортивная машина, я еду очень быстро!");
            }
        }

        // Абстрактные классы. Зачем нужны абстрактные методы. abstract. Полиморфизм
        public static void Lesson_072()
        {
            Console.WriteLine("Hello from Lesson_072  Абстрактные классы. Зачем нужны абстрактные методы. abstract. Полиморфизм");
            Console.WriteLine();

            // Пример использования абстрактных классов и методов в C#
            // Абстрактный класс - это класс, который не может быть инстанцирован напрямую, но может быть унаследован другими классами.
            // Он может содержать абстрактные методы, которые должны быть реализованы в производных классах.

            // Weapon weapon = new Weapon(); // Ошибка: невозможно создать экземпляр абстрактного класса

            Player player = new Player();
            Gun1 gun = new Gun1();
            player.Fire(gun);
            player.Fire(new Bow());
            player.Fire(new LaserGun());

            Console.WriteLine();

            Weapon[] inventory = { new Gun1(), new LaserGun(), new Bow() };

            foreach (var item in inventory)
            {

                player.CheckInfo(item);
                player.Fire(item);
                Console.WriteLine();
            }

            Console.WriteLine(new string('-', 120));
        }

        abstract class Weapon
        {
            // Могут быть обычные свойства и методы с реализацией
            public abstract int Damage { get; }

            // Абстрактный метод, который должен быть реализован в производных классах
            // Абстрактный метод может быть только в абстрактном классе и не имеет реализации в базовом классе.
            public abstract void Fire();

            // В абстрактном классе также могут быть обычные методы с реализацией,
            // которые могут быть использованы в производных классах.
            public void ShowInfo()
            {
                Console.WriteLine($"{GetType().Name} Урон: {Damage}");
            }
        }

        class Gun1 : Weapon
        {
            public override int Damage { get { return 5; } }

            public override void Fire()
            {
                Console.WriteLine("Пыщ!");
            }
        }

        class LaserGun : Weapon
        {
            public override int Damage => 8;

            public override void Fire()
            {
                Console.WriteLine("Пиу!");
            }
        }

        class Bow : Weapon
        {
            public override int Damage { get { return 3; } }

            // HACK: example HACK
            public override void Fire()
            {
                Console.WriteLine("Чпуньк!");
            }
        }

        class Player
        {
            // UNDONE: example UNDONE
            public void Fire(Weapon weapon)
            {
                weapon.Fire();
            }
            // TODO: example TODO 
            public void CheckInfo(Weapon weapon)
            {
                weapon.ShowInfo();
            }
        }

        // Интерфейсы и полиморфизм. Зачем нужны и как используются
        public static void Lesson_073()
        {
            Console.WriteLine("Hello from Lesson_073  Интерфейсы и полиморфизм. Зачем нужны и как используются");
            Console.WriteLine();

            // Интерфейс - это контракт, который определяет набор методов и свойств, которые должны быть реализованы классами,
            // которые его реализуют.
            // Интерфейсы позволяют создавать гибкие и расширяемые архитектуры.

            IDataProcessor dataProcessor = new ConsoleDataProcessor();
            dataProcessor.ProcessData(new DbDataProvider());
            dataProcessor.ProcessData(new FileDataProvider());
            dataProcessor.ProcessData(new APIDataProvider());

            Console.WriteLine();

            PlayerLesson073 player = new PlayerLesson073();

            WeaponLesson073[] inventory = { new GunLesson073(), new LaserGunLesson073(), new BowLesson073() };

            foreach (var item in inventory)
            {
                player.Fire(item);
                player.CheckInfo(item);
                Console.WriteLine();
            }

            Console.WriteLine(new string('-', 120));
        }

        interface IDataProvider
        {
            string GetData();
        }

        class DbDataProvider : IDataProvider
        {
            public string GetData()
            {
                return "Данные из базы данных";
            }
        }

        class FileDataProvider : IDataProvider
        {
            public string GetData()
            {
                return "Данные из файла";
            }
        }

        class APIDataProvider : IDataProvider
        {
            public string GetData()
            {
                return "Данные из API";
            }
        }

        interface IDataProcessor
        {
            void ProcessData(IDataProvider dataProvider);
        }

        class ConsoleDataProcessor : IDataProcessor
        {
            public void ProcessData(IDataProvider dataProvider)
            {
                Console.WriteLine(dataProvider.GetData());
            }

        }

        interface IHasInfo
        {
            void ShowInfo();
        }
        interface IWeapon
        {
            int Damage { get; }
            void Fire();
        }

        // Класс WeaponLesson073 реализует интерфейсы IHasInfo и IWeapon,
        // что позволяет использовать его объекты в полиморфном контексте.
        abstract class WeaponLesson073 : IHasInfo, IWeapon
        {
            public abstract int Damage { get; }

            public abstract void Fire();

            public void ShowInfo()
            {
                Console.WriteLine($"{GetType().Name} Урон: {Damage}");
            }
        }

        class GunLesson073 : WeaponLesson073
        {
            public override int Damage { get { return 5; } }

            public override void Fire()
            {
                Console.WriteLine("Пыщ!");
            }
        }

        class LaserGunLesson073 : WeaponLesson073
        {
            public override int Damage => 8;

            public override void Fire()
            {
                Console.WriteLine("Пиу!");
            }
        }

        class BowLesson073 : WeaponLesson073
        {
            public override int Damage { get { return 3; } }


            public override void Fire()
            {
                Console.WriteLine("Чпуньк!");
            }
        }

        class PlayerLesson073
        {

            public void Fire(WeaponLesson073 weapon)
            {
                weapon.Fire();
            }

            public void CheckInfo(WeaponLesson073 weapon)
            {
                weapon.ShowInfo();
            }
        }

        // Наследование интерфейсов. Множественное наследование интерфейсов
        public static void Lesson_074()
        {
            Console.WriteLine("Hello from Lesson_074  Наследование интерфейсов. Множественное наследование интерфейсов");
            Console.WriteLine();

            // Интерфейсы могут наследовать другие интерфейсы, что позволяет создавать более сложные контракты.
            // Класс может реализовывать несколько интерфейсов, что обеспечивает множественное наследование интерфейсов.

            PlayerLesson074 player = new PlayerLesson074();

            IWeaponLesson074[] inventory = { new GunLesson074(), new LaserGunLesson074(), new KnifeLesson074() };

            foreach (var item in inventory)
            {
                player.Fire(item);
                Console.WriteLine();
            }

            player.Throw(new KnifeLesson074());


            Console.WriteLine(new string('-', 120));
        }

        interface IWeaponLesson074
        {
            void Fire();
        }

        interface IThrowingWeaponLesson074 : IWeaponLesson074
        {
            void Throw();
        }

        class GunLesson074 : IWeaponLesson074
        {
            public void Fire()
            {
                Console.WriteLine($"{GetType().Name}: Пыщ!");
            }
        }

        class LaserGunLesson074 : IWeaponLesson074
        {
            public void Fire()
            {
                Console.WriteLine($"{GetType().Name}: Пиу!");
            }
        }

        class KnifeLesson074 : IThrowingWeaponLesson074
        {
            public void Fire()
            {
                Console.WriteLine($"{GetType().Name}: Хыщ!");
            }

            public void Throw()
            {
                Console.WriteLine($"{GetType().Name}: Фьють!");
            }
        }

        class PlayerLesson074
        {
            public void Fire(IWeaponLesson074 weapon)
            {
                weapon.Fire();
            }

            public void Throw(IThrowingWeaponLesson074 throwingWeapong)
            {
                throwingWeapong.Throw();
            }
        }

        // Интерфейсы. ЯВНАЯ РЕАЛИЗАЦИЯ интерфейса
        public static void Lesson_075()
        {
            Console.WriteLine("Hello from Lesson_075  Интерфейсы. ЯВНАЯ РЕАЛИЗАЦИЯ интерфейса");
            Console.WriteLine();

            // Явная реализация интерфейса позволяет реализовать методы интерфейса таким образом,
            // чтобы они были доступны только через ссылку на интерфейс, а не через объект класса.

            MyClassLesson075 myClass = new MyClassLesson075();
            Foo(myClass);
            Bar(myClass);

            Console.WriteLine();

            MyOtherClassLesson075 myOtherClass = new MyOtherClassLesson075();
            Foo(myOtherClass);
            Bar(myOtherClass);

            Console.WriteLine();

            IFirstInterface firstInterface = myOtherClass;
            firstInterface.Action(); // Вызывает метод Action() из IFirstInterface

            // или так с помощью приведения типа
            ((IFirstInterface)myOtherClass).Action(); // Вызывает метод Action() из IFirstInterface
            Console.WriteLine();
            ((ISecondInterface)myOtherClass).Action(); // Вызывает метод Action() из ISecondInterface

            // или так безопасней

            if (myOtherClass is IFirstInterface first2Interface)
            {
                first2Interface.Action();
            }

            if (myOtherClass is ISecondInterface first3Interface)
            {
                first3Interface.Action();
            }


            object obj = new object();

            if (obj is IFirstInterface first1Interface)
            {
                first1Interface.Action();
            }

            Console.WriteLine(new string('-', 120));
        }

        interface IFirstInterface
        {
            void Action();
        }

        interface ISecondInterface
        {
            void Action();
        }


        // Пример неявной реализации интерфейса в C#
        class MyClassLesson075 : IFirstInterface, ISecondInterface
        {
            public void Action()
            {
                Console.WriteLine("MyClass Action...");
            }
        }

        // Пример явной реализации интерфейса в C#
        // Важно обратить внимание на отсутствие модификатора доступа public у методов интерфейса в классе MyOtherClassLesson075.
        // Это означает, что методы Action() будут доступны только через ссылку на интерфейс, а не через объект класса.
        class MyOtherClassLesson075 : IFirstInterface, ISecondInterface
        {
            void IFirstInterface.Action()
            {
                Console.WriteLine("MyOtherClass Action for IFirstInterface...");
            }

            void ISecondInterface.Action()
            {
                Console.WriteLine("MyOtherClass Action for ISecondInterface...");
            }
        }

        static void Foo(IFirstInterface firstInterface)
        {
            firstInterface.Action();
        }

        static void Bar(ISecondInterface secondInterface)
        {
            secondInterface.Action();
        }

        // Реализация интерфейса по умолчанию
        public static void Lesson_076()
        {
            Console.WriteLine("Hello from Lesson_076  Реализация интерфейса по умолчанию");
            Console.WriteLine();

            // В C# 8.0 и выше интерфейсы могут содержать реализацию методов по умолчанию.
            // Это позволяет добавлять новые методы в интерфейсы без необходимости изменять все классы, которые их реализуют.

            ILogger consoleLogger = new ConsoleLogger();

            consoleLogger.Log(LogLevel.Debug, "some event");      // "некоторое событие"
            consoleLogger.Log(LogLevel.Error, "some fatal error"); // "некоторая ошибка"
            consoleLogger.Log(LogLevel.Info, "some info");      // "некоторая информация"
            consoleLogger.Log(LogLevel.Warning, "some warning");  // "некоторое предупреждение"
            consoleLogger.Log(LogLevel.Fatal, "some fatal error"); // "некоторая фатальная ошибка"

            // До этого момента работает все хорошо здесь в .NET Framework 4.7.2
            // Далее смотри в проекте Lessons_Net_Core

            Console.WriteLine(new string('-', 120));
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

            // До этого момента работает все хорошо здесь в .NET Framework 4.7.2 (C# 7.3)
            // Когда начинаем реализовывать метод LogError  то получаем ошибку компиляции
            // используйте версию C# 8.0 или выше для использования реализации интерфейса по умолчанию.
            // Далее смотри в проекте Lessons_Net_Core

            /*
             void LogError(LogLevel logLevel, string message)
             {
                 Console.WriteLine($"{logLevel}: {message}");
             }
            */

            // Далее смотри в проекте Lessons_Net_Core

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

        // Структуры. Структуры и классы отличия. struct vs class
        public static void Lesson_077()
        {
            Console.WriteLine("Hello from Lesson_077  Структуры. Структуры и классы отличия. struct vs class");
            Console.WriteLine();

            // Структуры в C# - это значимые типы, которые обычно используются для представления небольших объектов,
            // таких как точки, прямоугольники, цвета и т.д. Они хранятся в стеке, а не в куче, что делает их более эффективными
            // для небольших объектов.
            // А классы в C# - это ссылочные типы, которые обычно используются для представления более сложных объектов.
            // Если используется большой объем данных то лучше использовать классы,
            // так как они хранятся в куче и управляются сборщиком мусора. Также при передачи этого большого объема данных
            // в методы и функции, классы передаются по ссылке, что экономит память и время на копирование данных.
            // Структуры лучше использовать для небольших объектов,
            // которые часто создаются и уничтожаются, таких как точки, прямоугольники, цвета и т.д.
            // И структуры м классы могут реализовывать интерфейсы,
            // но структуры не могут наследоваться от других структур или классов.

            // Смотри также проект Benchmark1

            ClassPoint classPoint = new ClassPoint();

            StructPoint structPoint = new StructPoint();

            Console.WriteLine("Before increment");
            Console.Write("ClassPoint params: ");
            classPoint.Print();
            Console.Write("StructPoint params: ");
            structPoint.Print();

            Console.WriteLine("After increment");
            Console.Write("ClassPoint params: ");
            Foo(classPoint);
            classPoint.Print(); // Изменятся значения так как ClassPoint является ссылочным типом
                                // и передается по ссылке в метод Foo

            Console.Write("StructPoint params: ");
            Bar(structPoint);
            structPoint.Print(); // Не изменятся значения так как StructPoint является значимым типом
                                 // и передается по значению в метод Bar

            ClassPoint classPoint1 = new ClassPoint { X = 2, Y = 3 };
            ClassPoint classPoint2 = new ClassPoint { X = 2, Y = 3 };

            bool classesAreEqual = classPoint1.Equals(classPoint2); // false так как сравниваются ссылки на объекты, а не их значения

            StructPoint structPoint1 = new StructPoint { X = 2, Y = 3 };
            StructPoint structPoint2 = new StructPoint { X = 2, Y = 3 };

            bool structsAreEqual = structPoint1.Equals(structPoint2); // true так как сравниваются значения объектов, а не ссылки на них

            Console.WriteLine(new string('-', 120));
        }

        static void Foo(ClassPoint classPoint)
        {
            classPoint.X++;
            classPoint.Y++;
        }

        static void Bar(StructPoint structPoint)
        {
            structPoint.X++;
            structPoint.Y++;
        }
        public class ClassPoint
        {
            public int X { get; set; }
            public int Y { get; set; }

            public void Print()
            {
                Console.WriteLine($"X:{X}\tY:{Y}");
            }
        }

        public struct StructPoint
        {
            public int X { get; set; }
            public int Y { get; set; }

            public void Print()
            {
                Console.WriteLine($"X:{X}\tY:{Y}");
            }
        }

        // Упаковка и распаковка значимых типов.boxing and unboxing
        public static void Lesson_078()
        {
            Console.WriteLine("Hello from Lesson_078  Упаковка и распаковка значимых типов.boxing and unboxing");
            Console.WriteLine();

            // Упаковка (boxing) - это процесс преобразования значимого типа в ссылочный тип.
            // Распаковка (unboxing) - это процесс извлечения значимого типа из ссылочного типа.

            int value = 123; // Значимый тип
            object boxedValue = value; // Упаковка: преобразование int в object
            int unboxedValue = (int)boxedValue; // Распаковка: извлечение int из object
            Console.WriteLine($"Значимый тип: {value}");
            Console.WriteLine($"Упакованный тип: {boxedValue}");
            Console.WriteLine($"Распакованный тип: {unboxedValue}");

            // decimal d = (decimal)boxedValue; // Ошибка во время выполнения: невозможно распаковать object в decimal,
            // так как boxedValue содержит int

            // Смотри также проект Benchmark1

            PointLesson_078 point = new PointLesson_078 { X = 2, Y = 4 };

            // Здесь происходит упаковка PointLesson_078 в IPrintable
            Print(point);

            // Здесь тоже происходит упаковка
            var t = value.GetType();

            Console.WriteLine(new string('-', 120));
        }

        interface IPrintable
        {
            void Print();
        }

        struct PointLesson_078 : IPrintable
        {
            public int X { get; set; }
            public int Y { get; set; }

            public void Print()
            {
                Console.WriteLine($"X:{X}\tY{Y}");
            }
        }
        static void Print(IPrintable printable)
        {
            printable.Print();
        }

        // Обобщения. generics. generic типы методы и классы
        public static void Lesson_079()
        {
            Console.WriteLine("Hello from Lesson_079  Обобщения. generics. generic типы методы и классы");
            Console.WriteLine();

            // Обобщения (generics) позволяют создавать классы, методы и структуры, которые могут работать с любыми типами данных.
            // Это позволяет создавать более гибкие и переиспользуемые компоненты.
            // Решить проблему упакки и распаковки значимых типов можно с помощью обобщений (generics).

            int a = 1, b = 5;

            Console.WriteLine($"a = {a}\t b = {b}");

            Swap(ref a, ref b);

            Console.WriteLine($"a = {a}\t b = {b}");

            SwapGeneric(ref a, ref b);

            Console.WriteLine($"a = {a}\t b = {b}");
            Console.WriteLine();

            string str1 = "Hello";
            string str2 = "World";

            Console.WriteLine($"str1 = {str1}\t str2 = {str2}");
            SwapGeneric(ref str1, ref str2);
            Console.WriteLine($"str1 = {str1}\t str2 = {str2}");
            Console.WriteLine();

            //FooGeneric(); // Выдаст ошибку так как тип данных не указан, так как метод FooGeneric()
            // возвращает значение по умолчанию для типа T, который не был указан.

            Console.WriteLine(FooGeneric<int>()); // 0
            Console.WriteLine(FooGeneric<string>()); // null
            Console.WriteLine(FooGeneric<bool>()); // false
            Console.WriteLine();

            // List тоже использует обобщения, так как может хранить элементы любого типа данных,
            // но при этом все элементы должны быть одного типа.
            List<int> list = new List<int>();
            list.Add(2);
            list.Add(3);
            Console.WriteLine(list[0]);
            list[0] = 11;
            Console.WriteLine(list[0]);
            Console.WriteLine();

            MyList<int> myList = new MyList<int>();
            myList.Add(5);
            myList.Add(7);
            myList.Add(9);
            myList.Add(45);

            for (int i = 0; i < myList.Count; i++)
            {
                Console.WriteLine(myList[i]);
            }

            Console.WriteLine(new string('-', 120));
        }

        public class MyList<T>
        {
            private T[] _array = Array.Empty<T>();

            public T this[int index]
            {
                get
                {
                    return _array[index];
                }
                set
                {
                    _array[index] = value;
                }
            }

            public int Count { get { return _array.Length; } }

            public void Add(T value)
            {
                var newArray = new T[_array.Length + 1];

                for (int i = 0; i < _array.Length; i++)
                {
                    newArray[i] = _array[i];
                }

                newArray[_array.Length] = value;
                _array = newArray;
            }
        }

        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        // тип данных может быть любой но идентичный для обоих параметров метода
        static void SwapGeneric<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        static T FooGeneric<T>()
        {
            return default(T);
        }

        // Обобщения. Производительность. Коллекции. list vs arraylist
        public static void Lesson_080()
        {
            Console.WriteLine("Hello from Lesson_080  Обобщения. Производительность. Коллекции. list vs arraylist");
            Console.WriteLine();

            // List<T> - это обобщенная коллекция, которая хранит элементы одного типа данных.
            // ArrayList - это не обобщенная коллекция, которая может хранить элементы любого типа данных.
            // При использовании ArrayList происходит упаковка и распаковка значимых типов, что может негативно сказаться на
            // производительности.
            // List<T> использует обобщения, что позволяет избежать упаковки и распаковки значимых типов и улучшить производительность.

            List<int> list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            // list.Add("ttt"); // Ошибка компиляции: невозможно добавить строку в List<int>

            ArrayList arrayList = new ArrayList();
            arrayList.Add(1);
            arrayList.Add(2);
            arrayList.Add(3);
            arrayList.Add("ttt");
            arrayList.Add(2 == 2);
            arrayList.Add(3 > 9);

            Console.WriteLine("List<int>:");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("ArrayList:");
            foreach (var item in arrayList)
            {
                Console.WriteLine(item);
            }

            // -> Смотри также проект Benchmark1

            Console.WriteLine(new string('-', 120));
        }
    }
}
