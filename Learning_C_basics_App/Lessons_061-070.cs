using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Learning_C_basics_App
{
    public static partial class Program
    {
        // Статический конструктор класса. Как работает ключевое слово static
        private static void Lesson_061()
        {
            Console.WriteLine("Hello from Lesson_061  Статический конструктор класса. Как работает ключевое слово static");
            Console.WriteLine();

            // Статический конструктор класса - это специальный конструктор, который вызывается автоматически
            // при первом обращении к классу или его статическим членам. Он используется для инициализации
            // статических полей или выполнения других действий, которые должны быть выполнены только один раз для всего класса.

            // При первом обращении к классу MyClass3 будет вызван статический конструктор, а затем обычный конструктор
            MyClass3 myclass1 = new MyClass3();

            // При втором обращении к классу MyClass3 статический конструктор уже не будет вызван,
            // так как он вызывается только один раз, при первом обращении к классу
            // Будет вызван только обычный конструктор
            MyClass3 myclass2 = new MyClass3();

            Console.WriteLine();

            // При обращении к статическому методу Foo() класса MyClass3 будет вызван статический конструктор,
            // если он еще не был вызван, а затем будет вызван статический метод Foo()
            MyClass4.Foo();

            // При повторном обращении к статическому методу Foo() класса MyClass3
            // статический конструктор уже не будет вызван,
            // так как он вызывается только один раз, при первом обращении к классу или его статическим членам
            MyClass4.Foo();

            // Здесь не будет вызван статический конструктор, так как он уже был вызван при первом обращении к классу MyClass4
            new MyClass4();

            Console.WriteLine();

            DbRepository dbRepository = new DbRepository();
            // При обращении к нестатическому методу GetData() класса DbRepository,
            // но в котором используется статическое поле connectionString,
            // будет вызван статический конструктор класса DbRepository,
            dbRepository.GetData();

            // При повторном обращении к нестатическому методу GetData() класса DbRepository,
            // статический конструктор класса DbRepository уже не будет вызван, так как он вызывается только один раз,
            dbRepository.GetData();

            Console.WriteLine(new string('-', 120));
        }

        class MyClass3
        {
            public MyClass3()
            {
                Console.WriteLine("Конструктор");
            }

            // Статический конструктор класса
            // Статический конструктор вызывается автоматически при первом обращении к классу или его статическим членам
            // Статический конструктор не может иметь модификаторов доступа и не может принимать параметры
            // Статический конструктор не может быть перегружен,
            // так как он вызывается автоматически и не может быть вызван напрямую
            static MyClass3()
            {
                Console.WriteLine("Статический конструктор");
            }

            public static void Foo()
            {
                Console.WriteLine("Статический метод Foo()");
            }
        }
        class MyClass4
        {
            public MyClass4()
            {
                Console.WriteLine("Конструктор");
            }

            // Статический конструктор класса
            // Статический конструктор вызывается автоматически при первом обращении к классу или его статическим членам
            // Статический конструктор не может иметь модификаторов доступа и не может принимать параметры
            // Статический конструктор не может быть перегружен,
            // так как он вызывается автоматически и не может быть вызван напрямую
            static MyClass4()
            {
                Console.WriteLine("Статический конструктор");
            }

            public static void Foo()
            {
                Console.WriteLine("Статический метод Foo()");
            }
        }
        class DbRepository
        {
            private static string connectionString = "DefaultConnectionString";


            static DbRepository()
            {
                Console.WriteLine("Статический конструктор");
                ConfigurationManager configurationManager = new ConfigurationManager();
                connectionString = configurationManager.GetConnectionString();
            }

            public void GetData()
            {
                Console.WriteLine("Использую: " + connectionString);
            }
        }
        class ConfigurationManager
        {
            public string GetConnectionString()
            {
                return "local DB";
            }
        }

        // Статический класс. Как работает ключевое слово static
        private static void Lesson_062()
        {
            Console.WriteLine("Hello from Lesson_062  Статический класс. Как работает ключевое слово static");
            Console.WriteLine();

            // Статический класс - это класс, который не может быть инстанцирован и может содержать только статические члены.
            // Он используется для группировки связанных методов и данных, которые не требуют создания экземпляра класса.
            // Статический класс не может быть наследован и не может реализовывать интерфейсы,
            // так как он не может быть инстанцирован.

            // MyClass5 myClass5 = new MyClass5(); // Ошибка компиляции, так как статический класс не может быть инстанцирован
            MyClass5.Foo();

            Console.WriteLine(new string('-', 120));
        }

        static class MyClass5
        {
            // Статический класс не может содержать конструкторы, так как он не может быть инстанцирован
            // public MyClass5()
            // {
            //
            // }

            // Статический класс не может содержать нестатические члены, так как он не может быть инстанцирован
            // int a;

            // Статический класс не может содержать нестатические члены, так как он не может быть инстанцирован
            // public void Bar()
            // {
            // }

            static int a;

            public static void Foo()
            {
                Console.WriteLine("Foo");
            }
        }

        // Методы расширения. Extension методы
        private static void Lesson_063()
        {
            Console.WriteLine("Hello from Lesson_063  Методы расширения. Extension методы");
            Console.WriteLine();

            // Методы расширения - это статические методы, которые позволяют добавлять новые методы к существующим типам
            // без необходимости создавать новый тип или изменять существующий тип.
            // Методы расширения определяются в статическом классе и используют ключевое слово this в качестве
            // первого параметра, чтобы указать тип, который они расширяют.

            string str = "Hello, World!";
            int length = StringExtensions.GetLength(str); // Вызов метода расширения GetLength() для типа string
            Console.WriteLine($"Длина строки: {length}");
            length = MyExtensions.GetLength(str); // Вызов метода расширения GetLength() для типа string
            Console.WriteLine($"Длина строки: {length}");
            Console.WriteLine();

            DateTime currentDateTime = DateTime.Now;
            Console.WriteLine(currentDateTime);
            Console.WriteLine(currentDateTime.GetDTShiftHour());
            currentDateTime.Print();
            Console.WriteLine();

            // Вызов метода расширения IsDayOfWeek() для типа DateTime с передачей аргумента DayOfWeek.Tuesday
            // Метод возвращает true, если текущий день недели соответствует переданному аргументу, и false в противном случае
            Console.WriteLine($"Сегодня {DayOfWeek.Tuesday} ? {(currentDateTime.IsDayOfWeek(DayOfWeek.Tuesday) ? "Да" : "Нет")}");
            Console.WriteLine($"Сегодня {DayOfWeek.Thursday} ? {(currentDateTime.IsDayOfWeek(DayOfWeek.Thursday) ? "Да" : "Нет")}");
            Console.WriteLine();

            // Вызов метода расширения GetFullName() для типа Student2
            // Метод возвращает полное имя студента, состоящее из фамилии и имени, разделенных пробелом
            Student2 student = new Student2() { FirstName = "Иван", LastName = "Иванов" };
            Console.WriteLine(student.GetFullName());

            Console.WriteLine(new string('-', 120));
        }

        // Partial класс. Частичные типы. partial методы
        private static void Lesson_064()
        {
            Console.WriteLine("Hello from Lesson_064  Partial класс. Частичные типы. partial методы");
            Console.WriteLine();

            // Partial класс - это класс, который может быть определен в нескольких файлах.
            // Он используется для разделения определения класса на несколько частей,
            // что может быть полезно при работе с большими классами или при совместной работе над проектом
            // несколькими разработчиками.
            // Частичные классы объединяются компилятором в один класс при компиляции.
            // partial методы - это методы, которые могут быть определены в одной части partial класса
            // и реализованы в другой части partial класса.

            Console.WriteLine("Эти уроки используют частичный класс:  public static partial class Program.");
            Console.WriteLine("Они находятся в разных файлах.");

            Console.WriteLine(new string('-', 120));
        }

        // Const vs readonly. Разница между const и readonly. const и static
        private static void Lesson_065()
        {
            Console.WriteLine("Hello from Lesson_065  Const vs readonly. Разница между const и readonly. const и static");
            Console.WriteLine();

            // const - это константа, значение которой известно на этапе компиляции и не может быть изменено
            // во время выполнения программы.
            // const поля являются статическими по умолчанию, так как они принадлежат типу, а не экземпляру класса.
            // const поля должны быть инициализированы при объявлении, и их значение не может быть изменено после этого.

            // readonly - это поле, значение которого может быть установлено только в конструкторе класса
            // или при объявлении поля.
            // readonly поля могут быть как статическими, так и нестатическими.
            // readonly поля могут быть инициализированы при объявлении или в конструкторе класса,
            // но не могут быть изменены после этого.

            // Получаем значение константного поля A класса MyClass6 
            // по аналогии с тем, как мы получаем значение статического поля класса,
            // так как const поля являются статическими по умолчанию
            int f = MyClass6.A;
            Console.WriteLine(f);

            MyClass6 myclass = new MyClass6(10);
            Console.WriteLine(myclass.b);
            myclass.Foo();

            Console.WriteLine(new string('-', 120));
        }

        class MyClass6
        {
            // const поле должно быть инициализировано при объявлении, и его значение не может быть изменено после этого
            // public const int a;  // Нельзя оставить const поле без инициализации,
            // так как его значение должно быть известно на этапе компиляции
            public const int A = 11;

            // readonly поле может быть инициализировано при объявлении или в конструкторе класса,
            // но не может быть изменено после этого
            public readonly int b;

            public MyClass6(int b)
            {
                //A = 3; // Ошибка компиляции, так как значение const поля не может быть изменено после его инициализации
                this.b = b; // Значение readonly поля может быть установлено в конструкторе класса,
                            // так как оно может быть изменено только в конструкторе
            }

            public void Foo()
            {
                //A = 9; // Ошибка компиляции, так как значение const поля не может быть изменено после его инициализации
                // b = 8; // Ошибка компиляции, так как значение readonly поля не может быть изменено после его инициализации,
                // даже в методе класса
                Console.WriteLine(A);
            }
        }

        // Синтаксис инициализации объектов класса. ООП
        private static void Lesson_066()
        {
            Console.WriteLine("Hello from Lesson_066  Синтаксис инициализации объектов класса. ООП");
            Console.WriteLine();

            // Синтаксис инициализации объектов класса - это способ создания и инициализации объектов класса с помощью
            // литералов инициализации.
            // Литералы инициализации позволяют устанавливать значения свойств объекта при его создании,
            // что делает код более читаемым и удобным для понимания.

            // Создаем объект класса Student4 и устанавливаем значения его свойств с помощью литералов инициализации
            // В данном случае мы создаем объект student1 класса Student4
            // и устанавливаем значения его свойств FirstName, LastName и Age
            Student4 student1 = new Student4();
            student1.FirstName = "Иван";
            student1.LastName = "Иванов";
            student1.Age = 30;
            Console.WriteLine($"Студент: {student1.FirstName} {student1.LastName}, возраст: {student1.Age}");

            // Создаем объект класса Student4 и устанавливаем значения его свойств с помощью литералов инициализации
            // В данном случае мы создаем объект student2 класса Student4 и устанавливаем значения его свойств FirstName и LastName
            Student4 student2 = new Student4 { FirstName = "Иван1", LastName = "Иванов1" };
            Console.WriteLine($"Студент: {student2.FirstName} {student2.LastName}, возраст: {student2.Age}");

            // Создаем объект класса Student4 и устанавливаем значения его свойств с помощью литералов инициализации
            // В данном случае мы создаем объект student3 класса Student4
            // и устанавливаем значения его свойств FirstName, LastName, Age и Address
            Student4 student3 = new Student4
            {
                FirstName = "Иван2",
                LastName = "Иванов2",
                Age = 47,
                Address = new Address
                {
                    Street = "ул. Бандеры, д. 1",
                    City = "Киев",
                    State = "Киевская область"
                }
            };
            Console.WriteLine($"Студент: {student3.FirstName} {student3.LastName}, возраст: {student3.Age}, адрес: {student3.Address.Street}, {student3.Address.City}, {student3.Address.State}");

            Console.WriteLine(new string('-', 120));
        }

        class Student4
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; } = 20;
            public Address Address { get; set; }
        }

        class Address
        {
            public string Street { get; set; }
            public string City { get; set; }
            public string State { get; set; }
        }

        // Наследование. Что такое наследование в ООП
        private static void Lesson_067()
        {
            Console.WriteLine("Hello from Lesson_067  Наследование. Что такое наследование в ООП");
            Console.WriteLine();

            // Наследование - это механизм, который позволяет создавать новый класс на основе существующего класса.
            // Новый класс (наследник) наследует все члены (поля, свойства, методы) базового класса (родителя),
            // что позволяет повторно использовать код и расширять функциональность существующих классов.
            // Множественное наследование в C# не поддерживается, то есть класс может наследовать
            // только от одного базового класса.

            Person person = new Person { FirstName = "Иван", LastName = "Иванов" };
            person.PrintName();
            //person.Learn(); // Ошибка компиляции, так как метод Learn() не определен в классе Person

            // Создаем объект класса Student5, который наследует от класса Person
            // Класс Student5 наследует все члены класса Person, включая свойства FirstName и LastName,
            // а также метод PrintName(), который выводит имя студента на консоль
            Student5 student = new Student5 { FirstName = "Петр", LastName = "Петров" };
            student.PrintName();
            student.Learn();

            // Создаем объект класса Person, но присваиваем ему ссылку на объект класса Student5
            // Так можно потому что класс Student5 наследует от класса Person,
            // и поэтому объект класса Student5 является объектом класса Person 
            Person person1 = new Student5 { FirstName = "Сидор", LastName = "Сидорров" };
            person1.PrintName();
            // person1.Learn(); // Ошибка компиляции, так как метод Learn() не определен в классе Person,
            // а переменная person1 имеет тип Person

            PrintFullName(person1);
            PrintFullName(student);

            Console.WriteLine(new string('-', 120));
        }

        static void PrintFullName(Person person)
        {
            Console.WriteLine($"Фамилия: {person.LastName}\t Имя: {person.FirstName}");
        }

        class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }

            public void PrintName()
            {
                Console.WriteLine($"Меня зовут {FirstName}");
            }
        }

        class Student5 : Person
        {
            public void Learn()
            {
                Console.WriteLine("Я учусь !");
            }
        }

        // Ключевое слово base. Наследование и конструктор класса
        private static void Lesson_068()
        {
            Console.WriteLine("Hello from Lesson_068  Ключевое слово base. Наследование и конструктор класса");
            Console.WriteLine();

            // Ключевое слово base используется для вызова конструктора базового класса из конструктора производного класса.
            // Оно позволяет передавать параметры в конструктор базового класса и инициализировать его члены.

            // Создаем объект класса Point3D, который наследует от класса Point2D
            // Порядок вызова конструкторов: сначала вызывается конструктор базового класса Test,
            // затем конструктор класса Point2D, и наконец конструктор класса Point3D
            Point3D point3D = new Point3D();
            Console.WriteLine($"x = {point3D.X}, y = {point3D.Y}, z = {point3D.Z}");

            point3D = new Point3D(1, 2, 3);
            Console.WriteLine($"x = {point3D.X}, y = {point3D.Y}, z = {point3D.Z}");

            Console.WriteLine();
            point3D.Print3D();


            Console.WriteLine(new string('-', 120));
        }

        class Test
        {
            public Test()
            {
                Console.WriteLine("Вызван конструктор класса Test");
            }
        }

        class Point2D : Test
        {
            public int X { get; set; }
            public int Y { get; set; }

            public Point2D(int x, int y)
            {
                X = x;
                Y = y;
                Console.WriteLine("Вызван конструктор класса Point2D");
            }

            public void Print2D()
            {
                Console.WriteLine("Print from  class Point2D");
                Console.WriteLine($"X:\t{X}");
                Console.WriteLine($"Y:\t{Y}");
            }
        }
        class Point3D : Point2D
        {
            public int Z { get; set; }

            // Если в классе предке Point2D нет конструктора без параметров, то в классе наследнике Point3D
            // необходимо вызвать конструктор базового класса Point2D с параметрами через ключевое слово base
            public Point3D() : base(0, 0) // Вызов конструктора базового класса Point2D с параметрами x=0 и y=0
            {
                Console.WriteLine("Вызван конструктор класса Point3D");
            }
            public Point3D(int x, int y, int z) : base(x, y) // Вызов конструктора базового класса Point2D с параметрами x и y
            {
                Z = z;
                Console.WriteLine("Вызван конструктор класса Point3D");
            }

            public void Print3D()
            {
                Console.WriteLine("Print from  class Point3D");
                base.Print2D(); // Вызов метода Print2D() базового класса Point2D
                Console.WriteLine($"Z:\t{Z}");
            }
        }

        // Операторы as is. Наследование и приведение типов
        private static void Lesson_069()
        {
            Console.WriteLine("Hello from Lesson_069  Операторы as is. Наследование и приведение типов");
            Console.WriteLine();

            // Операторы as и is используются для проверки и приведения типов в C#
            // Оператор is проверяет, является ли объект экземпляром указанного типа
            // Оператор as выполняет безопасное приведение типа и возвращает null, если приведение невозможно

            object obj = "Hello, World!";
            if (obj is string str)
            {
                Console.WriteLine($"Строка: {str}");
            }

            object obj2 = 123;
            string str2 = obj2 as string;
            if (str2 == null)
            {
                Console.WriteLine("Приведение типа невозможно");
            }

            object obj3 = new Point3D { X = 3, Y = 5 };

            Foo1(obj3);
            Bar1(obj3);

            Console.WriteLine(new string('-', 120));
        }

        static void Foo1(object obj)
        {
            // С помощью оператора as мы пытаемся привести объект obj к типу Point3D.
            // Если obj является экземпляром Point3D, то переменная point будет ссылаться на этот объект.
            // Если obj не является экземпляром Point3D, то переменная point будет равна null.
            // Не вызывается исключение InvalidCastException, как при обычном приведении типов,
            // если obj не является экземпляром Point3D.

            //Point3D point = (Point3D)obj; // Может вызывать исключение InvalidCastException, если obj не является экземпляром Point3D 

            Point3D point = obj as Point3D;

            if (point != null)
            {
                point.Print3D();
            }
        }

        static void Bar1(object obj)
        {
            // С помощью оператора is мы проверяем, является ли объект obj экземпляром типа Point3D.
            // Если obj является экземпляром Point3D, то переменная point будет ссылаться на этот объект.
            // Если obj не является экземпляром Point3D, то переменная point будет равна null.

            if (obj is Point3D point)
            {
                point.Print3D();
            }
        }

        // Наследование и модификаторы доступа. Модификатор protected.  Модификатор private protected
        private static void Lesson_070()
        {
            Console.WriteLine("Hello from Lesson_070  Наследование и модификаторы доступа. Модификатор protected");
            Console.WriteLine();

            // Модификатор доступа protected позволяет членам класса быть доступными только внутри этого класса
            // и в производных классах (наследниках), даже вне сборки. Это означает, что члены класса с модификатором protected
            // не могут быть доступны из других классов, которые не являются наследниками.
            // Модификатор private protected позволяет членам класса быть доступными только внутри этого класса и в
            // производных классах, которые находятся в той же сборке (assembly). Это означает, что члены класса
            // с модификатором private protected не могут быть доступны из других классов, которые не являются наследниками,
            // или из производных классов, которые находятся в другой сборке.

            A varA = new A();
            varA.publicFiled = 23;  // public - доступен везде, как внутри класса, так и за его пределами   
            /*
            varA.privateFiled; // private - доступен только внутри класса, в котором он объявлен
            varA.protectedField; // protected - доступен внутри класса, в котором он объявлен,
                                 // и в производных классах (наследниках)
            varA.privateprotectedField; // private protected - доступен внутри класса, в котором он объявлен,
                                        // и в производных классах (наследниках), которые находятся в той же сборке
            */

            B varB = new B();
            varA.publicFiled = 23;  // public - доступен везде, как внутри класса, так и за его пределами   
            // varB.privateFiled; // private - доступен только внутри класса, в котором он объявлен
            // varB.protectedField = 33; // protected - доступен внутри класса, в котором он объявлен,
                                    // и в производных классах (наследниках) тоже внутри а не вне класса наследника
                                    // то есть не через экземпляр класса наследника

            Console.WriteLine(new string('-', 120));
        }

        class A
        {
            // Модификаторы работают аналогично со свойствами и методами класса, а также с конструкторами класса

            public int publicFiled;  // public - доступен везде, как внутри класса, так и за его пределами   
            private int privateFiled; // private - доступен только внутри класса, в котором он объявлен
            protected int protectedField; // protected - доступен внутри класса, в котором он объявлен,
                                          // и в производных классах (наследниках)
            private protected int privateprotectedField; // private protected - доступен внутри класса, в котором он объявлен,
                                                         // и в производных классах (наследниках), которые находятся в той же сборке

            public A()
            {
                Console.WriteLine(publicFiled);             // поле доступно внутри класса
                Console.WriteLine(privateFiled);            // поле доступно внутри класса
                Console.WriteLine(protectedField);          // поле доступно внутри класса
                Console.WriteLine(privateprotectedField);   // поле доступно внутри класса
            }
        }

        class B : A 
        {
            public B()
            {
                Console.WriteLine(publicFiled);             // поле доступно везьде
                // Console.WriteLine(privateFiled);            // Ошибка компиляции, так как поле privateFiled
                                                            // недоступно в классе наследнике
                Console.WriteLine(protectedField);          // поле доступно внутри класса наследника
                Console.WriteLine(privateprotectedField);   // поле доступно внутри класса наследника,
                                                            // который находится в той же сборке
            }
        }
    }




    static class StringExtensions
    {
        public static int GetLength(this string str)
        {
            return str.Length;
        }
    }

    static class MyExtensions
    {
        public static int GetDTShiftHour(this DateTime DT)
        {
            return 5 + DT.Hour;
        }

        public static void Print(this DateTime DT)
        {
            Console.WriteLine(DT);
        }
        // Метод расширения для типа DateTime, который проверяет, соответствует ли текущий день недели переданному аргументу
        // Метод принимает два параметра: this DateTime dateTime - это объект типа DateTime,
        // для которого вызывается метод расширения, и DayOfWeek dayOfWeek - это аргумент типа DayOfWeek,
        // который указывает день недели, который нужно проверить
        public static bool IsDayOfWeek(this DateTime dateTime, DayOfWeek dayOfWeek)
        {
            return dateTime.DayOfWeek == dayOfWeek;
        }

        public static int GetLength(this string str)
        {
            return str.Length;
        }

        public static string GetFullName(this Student2 student)
        {
            return student.LastName + " " + student.FirstName;
        }
    }

    // Запрещаем наследование от класса Student, так как он объявлен как sealed
    //class MyClass : Student2
    //{ 
    //}
    sealed class Student2
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}



