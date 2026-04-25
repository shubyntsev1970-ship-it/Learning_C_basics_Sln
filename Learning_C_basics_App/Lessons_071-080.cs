using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            public override void  Drive()
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
            public override int Damage { get { return 5;  }  }

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

            public override void Fire()
            {
                Console.WriteLine("Чпуньк!");
            }
        }

        class Player
        {
            public void Fire(Weapon weapon)
            { 
                weapon.Fire();
            }

            public void CheckInfo(Weapon weapon)
            {
                weapon.ShowInfo();
            }
        }
    }
}
