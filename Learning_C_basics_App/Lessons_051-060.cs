using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Learning_C_basics_App
{
    public static partial class Program
    {
        // Что такое класс. ООП. Что такое объект класса. Экземпляр класса
        private static void Lesson_051()
        {
            Console.WriteLine("Hello from Lesson_051  Что такое класс. ООП. Что такое объект класса. Экземпляр класса");
            Console.WriteLine();

            //Класс - это шаблон или чертеж для создания объектов. Он определяет свойства и методы,
            //которые объекты этого класса будут иметь.
            //ООП (Объектно-ориентированное программирование) - это парадигма программирования,
            //которая использует объекты и классы для организации кода и данных.
            //Объект класса - это конкретный экземпляр класса, который имеет свои собственные значения свойств
            //и может выполнять методы, определенные в классе.
            //Экземпляр класса - это термин, который используется для обозначения конкретного объекта,
            //созданного на основе класса.

            Point p1 = new Point(); // Создание объекта класса Point. p1 - это экземпляр класса Point
            p1.x = 10; // Установка значения свойства x для объекта point1
            p1.y = 20; // Установка значения свойства y для объекта point1
            p1.color = Color.Green; // Установка значения свойства color для объекта point1

            // Выводит на консоль: Point p1: x = 10, y = 20, color = Green
            Console.WriteLine($"Point p1: x = {p1.x}, y = {p1.y}, color = {p1.color}");

            // Мы можем создать несколько объектов класса Point, и каждый из них будет иметь
            // свои собственные значения свойств.
            // Например, мы можем создать другой объект класса Point с другими координатами и цветом:
            Point p2 = new Point { x = 5, y = 6, color = Color.Red };

            // Выводит на консоль: Point p2: x = 5, y = 6, color = Red
            Console.WriteLine($"Point p2: x = {p2.x}, y = {p2.y}, color = {p2.color}");

            // Класс - это ссылочный тип данных, поэтому переменная p1 содержит ссылку на объект класса Point.
            // Когда мы присваиваем p1 значение null, мы удаляем ссылку на объект, и он может быть удален сборщиком мусора,
            // если на него больше нет ссылок.
            p1 = null;
            // p1.x = 7; // Ошибка! Невозможно обратиться к члену 'Point.x', так как переменная 'p1' содержит значение null
            // NullReferenceException

            var firstStudent = GetStudent();

            Print(firstStudent);

            Console.WriteLine(new string('-', 120));
        }

        // Пример класса Point, который представляет точку на плоскости с координатами x и y
        class Point
        {
            public int x; // Поле
            public int y; // Поле
            public Color color; // Поле типа Color (перечисление)

        }

        enum Color
        {
            Red,    // 0
            Green,  // 1
            Blue    // 2
        }
        class Student
        {
            public Guid id;
            public string firstName;
            public string lastName;
            public string middleName;
            public int age;
            public string group;
        }
        static void Print(Student student)
        {
            Console.WriteLine("Информация о студенте:");
            Console.WriteLine($"Id: {student.id}");
            Console.WriteLine($"Фамилия: {student.lastName}");
            Console.WriteLine($"Имя: {student.firstName}");
            Console.WriteLine($"Отчество: {student.middleName}");
            Console.WriteLine($"Возраст: {student.age}");
            Console.WriteLine($"Группа: {student.group}");
        }

        static Student GetStudent()
        {
            Student student = new Student();

            student.firstName = "Мартин";
            student.middleName = "Игоревич";
            student.lastName = "Дугин";
            student.age = 19;
            student.id = Guid.NewGuid();
            student.group = "ЙЦУКЕН_1";

            return student;
        }

        // Методы и классы. ООП и вызов метода объекта класса
        private static void Lesson_052()
        {
            Console.WriteLine("Hello from Lesson_052  Методы и классы. ООП и вызов метода объекта класса");
            Console.WriteLine();

            // Метод - это блок кода, который выполняет определенную задачу и может быть вызван для выполнения этой задачи.
            // Класс - это шаблон для создания объектов, который может содержать методы и свойства.
            // Вызов метода объекта класса - это процесс обращения к методу, который принадлежит объекту класса,
            // для выполнения определенной задачи.

            var student = GetStudent1();
            student.Print();
            Console.WriteLine(student.GetFullName());

            Console.WriteLine();
            Console.WriteLine("\t== Car 1 ==");
            var car1 = new Car();
            car1.PrintSpeed();
            car1.DriveForward();
            car1.PrintSpeed();
            car1.DriveBackward();
            car1.PrintSpeed();
            car1.Stop();
            car1.PrintSpeed();

            Console.WriteLine();
            Console.WriteLine("\t== Car 2 ==");
            var car2 = new Car();
            car2.PrintSpeed();
            car2.DriveBackward();
            car2.PrintSpeed();
            car2.DriveForward();
            car2.PrintSpeed();
            car2.Stop();
            car2.PrintSpeed();

            Console.WriteLine(new string('-', 120));
        }

        class Student1
        {
            public Guid id;
            public string firstName;
            public string lastName;
            public string middleName;
            public int age;
            public string group;

            public void Print()
            {
                Console.WriteLine("Информация о студенте:");
                Console.WriteLine($"Id: {id}");
                Console.WriteLine($"Фамилия: {lastName}");
                Console.WriteLine($"Имя: {firstName}");
                Console.WriteLine($"Отчество: {middleName}");
                Console.WriteLine($"Возраст: {age}");
                Console.WriteLine($"Группа: {group}");
            }

            public string GetFullName()
            {
                return $"{lastName} {firstName} {middleName}";
            }
        }

        static Student1 GetStudent1()
        {
            Student1 student = new Student1();

            student.firstName = "Мартин";
            student.middleName = "Игоревич";
            student.lastName = "Дугин";
            student.age = 19;
            student.id = Guid.NewGuid();
            student.group = "ЙЦУКЕН_1";

            return student;
        }
        class Car
        {
            private int speed = 0;

            public void PrintSpeed()
            {
                if (speed == 0)
                {
                    Console.WriteLine("Стоим на месте...");
                }
                if (speed > 0)
                {
                    Console.WriteLine($"Едем вперёд со скоростью {speed} км\\ч");
                }
                if (speed < 0)
                {
                    Console.WriteLine($"Едем назад со скоростью {-speed} км\\ч");
                }
            }

            public void DriveForward()
            {
                speed = 60;
            }

            public void Stop()
            {
                speed = 0;
            }

            public void DriveBackward()
            {
                speed = -5;
            }
        }

        // Модификаторы доступа. РАЗНИЦА МЕЖДУ public и private
        private static void Lesson_053()
        {
            Console.WriteLine("Hello from Lesson_053  Модификаторы доступа. РАЗНИЦА МЕЖДУ public и private");
            Console.WriteLine();

            // Модификаторы доступа — это ключевые слова, которые определяют уровень доступности типа или его членов
            // (классов, интерфейсов, методов, свойств и т.д.) из других частей программы.
            // В C# существуют следующие модификаторы доступа:
            // 1. public - доступен из любого места (любая сборка, любой код).
            // 2. private - доступен только внутри того же класса.
            // 3. protected - доступен внутри класса и его наследников (наследники могут быть даже в другой сборке).
            // 4. internal - доступен любому коду внутри той же сборки (assembly), независимо от класса или наследования
            // 5. protected internal - доступен либо из той же сборки, либо из любого наследника (в любой сборке)
            // 6. private protected - доступен только в наследниках, которые находятся в той же сборке
            // Сборка(assembly) — это: .exe или.dll обычно соответствует проекту в Visual Studio

            Point1 point = new Point1();

            point.x = 5; // Мы можем обратиться к полю x, потому что оно объявлено как public
                         // point.y = 5; // Ошибка! Невозможно обратиться к полю 'Point1.y', так как оно объявлено как private
                         // point.z = 8; // Мы не можем обратиться к полю z, потому что оно объявлено без модификатора доступа,
                         // и по умолчанию оно будет private. 
                         // Однако, так как мы находимся внутри класса Point1, мы можем обратиться к этому полю.
            point.PrintY(); // Мы можем вызвать метод PrintY(), потому что он объявлен как public
            point.PrintPoint(); // Мы можем вызвать метод PrintPoint(), потому что он объявлен как public.
                                // Внутри метода PrintPoint() мы можем обратиться к приватным членам класса,
                                // таким как поле y и метод PrintX()

            // point.PrintX(); // Ошибка! Невозможно обратиться к методу 'Point1.PrintX()', так как он объявлен как private

            // это не считается нарушением инкапсуляции в C#, потому что ты используется
            // рефлексия — осознанный “обход” ограничений, а не обычный доступ.
            var typeInfo = typeof(Point1).
                GetFields(BindingFlags.Instance |
                BindingFlags.NonPublic |
                BindingFlags.Public);

            foreach (var field in typeInfo)
            {
                Console.WriteLine($"Field: {field.Name}\t Value: {field.GetValue(point)}\t " +
                    $"IsPrivate: {field.IsPrivate}\t IsPublic: {field.IsPublic}");
            }
            Console.WriteLine();

            Console.WriteLine(new string('-', 120));
        }

        class Point1
        {
            int z = 3; // Если не указать модификатор доступа, то по умолчанию будет private.
                       // Это означает, что поле z доступно только внутри класса Point1

            public int x = 1;

            private int y = 44;

            private void PrintX()
            {
                Console.WriteLine($"X: {x}");
            }

            public void PrintY()
            {
                Console.WriteLine($"Y: {y}");
                Console.WriteLine($"Z: {z}");
            }

            public void PrintPoint()
            {
                PrintX(); // Внутри класса мы можем обращаться к приватным членам
                Console.WriteLine($"Y: {y}");
            }
        }

        // ИНКАПСУЛЯЦИЯ. Примеры инкапсуляции с объяснением
        private static void Lesson_054()
        {
            Console.WriteLine("Hello from Lesson_054  ИНКАПСУЛЯЦИЯ. Примеры инкапсуляции с объяснением");
            Console.WriteLine();

            // Инкапсуляция — это принцип, при котором данные(поля) и поведение(методы, свойства), работающие с этими данными,
            // объединяются внутри одного объекта(класса) и при этом
            // контролируется доступ к этим данным через определённый интерфейс(методы/ свойства), скрывая внутреннюю реализацию.

            // ИЛИ

            // Инкапсуляция — это принцип объектно-ориентированного программирования, который заключается
            // в сокрытии внутренней реализации объекта и предоставлении доступа к данным и поведению объекта
            // только через определенные методы (интерфейс).

            Gun gun = new Gun();
            gun.Shoot();

            Console.WriteLine(new string('-', 120));
        }

        class Gun
        {
            public Gun()
            {
                Reload();
            }

            public Gun(bool isLoaded)
            {
                _isLoaded = isLoaded;
            }

            private bool _isLoaded;

            private void Reload()
            {
                Console.WriteLine("Заряжаю...");

                _isLoaded = true;

                Console.WriteLine("Заряжено!");
            }

            public void Shoot()
            {
                if (!_isLoaded)
                {
                    Console.WriteLine("Орудие не заряжено!");
                    Reload();
                }
                Console.WriteLine("Пыщ - Пыщ\n");
                _isLoaded = false;
            }
        }

        // Что такое конструктор класса. Для чего он нужен. Конструктор по умолчанию
        private static void Lesson_055()
        {
            Console.WriteLine("Hello from Lesson_055  Что такое конструктор класса. Для чего он нужен. Конструктор по умолчанию");
            Console.WriteLine();

            // Конструктор класса — это специальный метод, который вызывается при создании объекта класса.
            // Он используется для инициализации объекта, то есть для установки начальных значений его полей или выполнения
            // других действий, необходимых для подготовки объекта к использованию.
            // Конструктор по умолчанию — это конструктор, который не принимает никаких параметров и автоматически создается
            // компилятором, если в классе не определено ни одного конструктора. Он обычно используется для создания
            // объектов с начальными значениями по умолчанию.

            Point2 point = new Point2(); // Вызов конструктора по умолчанию
            Console.WriteLine($"Point: x = {point.x}, y = {point.y}");


            Gun gun = new Gun(); // Вызов конструктора по умолчанию для класса Gun.

            gun.Shoot();

            gun.Shoot();

            Gun gun1 = new Gun(true); // Вызов конструктора, который принимает параметр isLoaded и устанавливает его
                                      // значение в true. Это означает, что орудие будет заряжено при создании объекта gun1.

            gun1.Shoot();

            gun1.Shoot();

            Console.WriteLine(new string('-', 120));
        }

        internal class Point2
        {
            public int x;
            public int y;

            // Конструктор по умолчанию
            public Point2()
            {
                x = 0;
                y = 0;
            }
        }

        // Перегрузка конструкторов класса. Что такое перегрузка
        private static void Lesson_056()
        {
            Console.WriteLine("Hello from Lesson_056  Перегрузка конструкторов класса. Что такое перегрузка");
            Console.WriteLine();

            // Перегрузка — это возможность создавать несколько методов (или конструкторов) с одним и тем же именем,
            // но с разными параметрами.
            // Это позволяет использовать одно и то же имя для разных действий, в зависимости от того,
            // какие аргументы передаются при вызове метода.

            Point3 point1 = new Point3(); // Вызов конструктора по умолчанию
            Console.WriteLine($"Point1: x = {point1.x}, y = {point1.y}");

            Point3 point2 = new Point3(5, 10); // Вызов конструктора с параметрами
            Console.WriteLine($"Point2: x = {point2.x}, y = {point2.y}");
            Console.WriteLine();

            Student3 student1 = new Student3("Йцукенов", new DateTime(2000, 10, 5));
            student1.Print();
            Console.WriteLine();

            Student3 student2 = new Student3("Йцукенов", "Йцукен", "Йцукенович", new DateTime(2000, 10, 5));
            student2.Print();
            Console.WriteLine();

            Student3 student3 = student2; // Тут простое копирование
            student2.Print();
            student3.Print();
            Console.WriteLine();

            student2.SetLastName("###########"); // и изменения в одном объекте отразятся на другом,
                                                 // потому что student2 и student3 ссылаются на один и тот же объект в памяти
            student2.Print();
            student3.Print();
            Console.WriteLine();

            // Поэтому нужен конструктор копирования, который позволяет создавать новый объект на основе существующего,
            // копируя его данные, но при этом создавая новый объект в памяти, чтобы изменения в одном объекте
            // не влияли на другой.
            Student3 student4 = new Student3(student3);
            student3.SetLastName("===========");
            student3.Print();
            student4.Print();


            Console.WriteLine(new string('-', 120));
        }

        internal class Point3
        {
            public int x;
            public int y;

            // Конструктор по умолчанию
            public Point3()
            {
                x = 0;
                y = 0;
            }

            // Перегруженный конструктор, который принимает два параметра для инициализации полей x и y
            public Point3(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }
        class Student3
        {
            public Student3(string lastName, DateTime birthday)
            {
                _lastName = lastName;
                _birthday = birthday;
            }

            public Student3(string lastName, string firstName, string middleName, DateTime birthday)
            {
                _lastName = lastName;
                _firstName = firstName;
                _middleName = middleName;
                _birthday = birthday;
            }

            // Это конструктор копирования, который принимает другой объект Student3 и копирует его данные в новый объект.
            // Он нужен для того, чтобы создать новый объект, который имеет те же данные, что и существующий объект,
            // но при этом является отдельным объектом в памяти, чтобы изменения в новом объекте не влияли
            // на существующий объект.
            public Student3(Student3 student)
            {
                _lastName = student._lastName;
                _firstName = student._firstName;
                _middleName = student._middleName;
                _birthday = student._birthday;
            }

            public void SetLastName(string lastName)
            {
                _lastName = lastName;
            }

            private string _firstName;
            private string _middleName;
            private string _lastName;
            private DateTime _birthday;

            public void Print()
            {
                Console.WriteLine($"Имя: {_firstName}\nФамилия: {_lastName}\nОтчество: {_middleName}\nДата рождения: {_birthday}");
            }
        }

        // Ключевое слово this. ООП.this в конструкторе
        private static void Lesson_057()
        {
            Console.WriteLine("Hello from Lesson_057  Ключевое слово this. ООП.this в конструкторе");
            Console.WriteLine();

            // Ключевое слово this в C# используется внутри класса для ссылки на текущий экземпляр этого класса.
            // Оно позволяет обращаться к членам класса (полям, методам, свойствам) и конструкторам, а также
            // передавать текущий экземпляр в другие методы или конструкторы.

            Point4 point1 = new Point4(5, 10);
            Console.WriteLine($"Point coordinates: x = {point1.x}, y = {point1.y}");

            Point4 point2 = new Point4(15, 110);
            Console.WriteLine($"Point coordinates: x = {point2.x}, y = {point2.y}");

            Point4 point3 = new Point4(25, 210, 35);
            Console.WriteLine($"Point coordinates: x = {point3.x}, y = {point3.y}, z = {point3.z}");

            Console.WriteLine(new string('-', 120));
        }

        internal class Point4
        {
            public int x;
            public int y;
            public int z;

            // this используется когда есть неоднозначность между полями класса и параметрами конструктора.
            // В данном случае, параметры конструктора имеют те же имена, что и поля класса (x и y).
            // Использование this.x и this.y позволяет явно указать, что мы обращаемся к полям класса,
            // а не к параметрам конструктора.
            public Point4(int x, int y)
            {
                this.x = x; // this.x - это поле класса Point4, а x - это параметр конструктора
                this.y = y; // this.y - это поле класса Point4, а y - это параметр конструктора
            }

            // Вызов другого конструктора внутри конструктора. Это позволяет избежать дублирования кода и
            // повторного присваивания значений полей x и y.
            public Point4(int x, int y, int z) : this(x, y)
            {
                this.z = z; // this.z - это поле класса Point4, а z - это параметр конструктора
            }
        }

        // Свойства get set. Ключевое слово value. Автоматические свойства
        private static void Lesson_058()
        {
            Console.WriteLine("Hello from Lesson_058  Свойства get set. Ключевое слово value. Автоматические свойства");
            Console.WriteLine();
            
            // Свойства в C# - это члены класса, которые предоставляют механизм для чтения, записи или вычисления
            // значений полей класса.
            // Они используются для инкапсуляции данных и обеспечения контроля над доступом к ним.
            // Ключевое слово value используется внутри сеттера свойства для представления значения,
            // которое присваивается этому свойству.
            // Автоматические свойства - это синтаксический сахар, который позволяет создавать свойства
            // без явного определения поля для хранения данных.
            
            Point5 point = new Point5();
            point.X = 10; // Вызов сеттера свойства X
            point.Y = 20; // Вызов сеттера свойства Y
            Console.WriteLine($"Point coordinates: x = {point.X}, y = {point.Y}"); // Вызов геттеров свойств X и Y
            
            Console.WriteLine(new string('-', 120));
        }
        internal class Point5
        {
            // Автоматические свойства
            public int X { get; set; } // Это автоматическое свойство, которое автоматически создает
                                       // скрытое поле для хранения значения X

            private int y; // Явное поле для хранения значения Y

            public int Y
            {
                get { return y; } // Геттер свойства Y возвращает значение поля y
                set // Сеттер свойства Y присваивает значение полю y, используя ключевое слово value
                {
                    if (value < 1)
                    {
                        y = 1;
                        return;
                    }

                    if (value > 5)
                    {
                        y = 5;
                        return;
                    }

                    y = value; 
                } 
            }

            // Сеттер свойства Y с дополнительной логикой для ограничения значения y в диапазоне от 1 до 5
            public void SetY(int y)
            {
                if (y < 1)
                {
                    this.y = 1;
                    return;
                }

                if (y > 5)
                {
                    this.y = 5;
                    return;
                }

                this.y = y;
            }

            // Геттер для получения значения y
            public int GetY()
            {
                return y;
            }
        }
    }
}
