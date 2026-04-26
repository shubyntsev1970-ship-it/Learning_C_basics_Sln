using System;
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
    }
}
