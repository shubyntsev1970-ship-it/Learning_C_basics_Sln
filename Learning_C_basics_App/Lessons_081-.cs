using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Learning_C_basics_App
{
    public static partial class Program
    {
        // Enumerable и IEnumerator: как работает цикл foreach и при чём тут паттерн. Итератор
        public static void Lesson_081()
        {
            Console.WriteLine("Hello from Lesson_081 Enumerable и IEnumerator: как работает цикл foreach и при чём тут паттерн. Итератор");
            Console.WriteLine();

            // Enumerable и IEnumerator - это интерфейсы в C#, которые используются для работы с коллекциями и последовательностями
            // данных. Они позволяют перебирать элементы коллекции без необходимости знать внутреннюю структуру коллекции.

            IEnumerable<int> sequence = new NumberSequence(start: 10, count: 3);

            foreach (var number in sequence)
            {
                Console.WriteLine(number);

            }

            Console.WriteLine(new string('-', 120));
        }

        public class NumberSequence : IEnumerable<int>
        {
            private readonly int _start;
            private readonly int _count;

            public NumberSequence(int start, int count)
            {
                _start = start;
                _count = count;
            }

            public IEnumerator<int> GetEnumerator()
            {
                return new NumberEnumerator(_start, _count);
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }

        public class NumberEnumerator : IEnumerator<int>
        {
            private readonly int _start;
            private readonly int _count;
            private int _currentIndex;

            public NumberEnumerator(int start, int count)
            {
                _start = start;
                _count = count;
                _currentIndex = -1;
            }

            public int Current
            {
                get
                {
                    if (_currentIndex < 0 || _currentIndex >= _count)
                        throw new InvalidOperationException(
                            "Enumerator is in an invalid state.");

                    return _start + _currentIndex;
                }
            }
            object IEnumerator.Current => Current;

            public bool MoveNext()
            {
                if (_currentIndex + 1 < _count)
                {
                    _currentIndex++;
                    return true;
                }

                return false;
            }
            public void Reset()
            {
                _currentIndex = -1;
            }

            public void Dispose()
            {

            }
        }

        // Ключевое слово yield. Для чего нужен yield return и как он устроен
        public static void Lesson_082()
        {
            Console.WriteLine("Hello from Lesson_082 Ключевое слово yield. Для чего нужен yield return и как он устроен");
            Console.WriteLine();

            // Ключевое слово yield используется в C# для создания итераторов, которые позволяют возвращать элементы
            // последовательности по одному за раз.
            // Оно упрощает реализацию методов, которые возвращают коллекции или последовательности данных.
            // Используют также для оптимизации памяти и производительности,
            // так как элементы последовательности создаются по мере необходимости, а не все сразу.

            // Пример без yield
            IEnumerable<int> sequence = new NumberSequence(start: 100, count: 5);

            var enumerator = sequence.GetEnumerator();

            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }

            Console.WriteLine();

            // Пример с yield
            IEnumerable<int> sequence1 = new NumberSequenceYield(start: 100, count: 5);

            var enumerator1 = sequence1.GetEnumerator();

            while (enumerator1.MoveNext())
            {
                Console.WriteLine(enumerator1.Current);
            }

            Console.WriteLine();

            foreach (var student in GetStudentsByYield())
            {
                Console.WriteLine(student.Name);
            }

            // -> Смотри также проект Benchmark1

            Console.WriteLine(new string('-', 120));
        }

        // Пример с yield
        public class NumberSequenceYield : IEnumerable<int>
        {
            private readonly int _start;
            private readonly int _count;

            public NumberSequenceYield(int start, int count)
            {
                _start = start;
                _count = count;
            }

            public IEnumerator<int> GetEnumerator()
            {
                for (int i = 0; i < _count; i++)
                {
                    yield return _start + i;
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }

        public class StudentLesson_082
        {
            public string Name { get; set; }
        }
        private static IEnumerable<StudentLesson_082> GetStudentsByYield()
        {
            yield return new StudentLesson_082 { Name = "Max" };
            yield return new StudentLesson_082 { Name = "James" };
            yield return new StudentLesson_082 { Name = "Olivia " };
        }

        // yield break. Что это такое и зачем использовать
        public static void Lesson_083()
        {
            Console.WriteLine("Hello from Lesson_083 yield break. Что это такое и зачем использовать");
            Console.WriteLine();

            // yield break используется для завершения итерации в методе, который использует yield return.
            // Когда встречается yield break, выполнение метода прекращается, и итератор больше не возвращает элементы.

            foreach (var number in GetNumbers())
            {
                Console.WriteLine(number);
            }

            Console.WriteLine();

            var numbers = new int[] { 1, 2, 3, 4, 5, 6 };

            foreach (var number in FilterEvenNumbers(numbers))
            {
                Console.WriteLine(number);
            }

            Console.WriteLine();

            foreach (var number in GetNumbersWithTimeout(timeout: TimeSpan.FromMilliseconds(1)))
            {
                Console.WriteLine(number);
            }

            Console.WriteLine(new string('-', 120));
        }

        public static IEnumerable<int> GetNumbers()
        {
            yield return 1;
            yield return 2;
            yield break;
            yield return 3; // Этот элемент не будет возвращён, так как выполнение метода завершится на yield break
        }

        public static IEnumerable<int> FilterEvenNumbers(IEnumerable<int> numbers)
        {
            if (numbers == null)
            {
                yield break; // Завершаем итерацию, если входная последовательность равна null
            }

            foreach (var number in numbers)
            {
                if (number % 2 == 0)
                {
                    yield return number;
                }
            }
        }

        public static IEnumerable<int> GetNumbersWithTimeout(TimeSpan timeout)
        {
            var stopwatch = Stopwatch.StartNew();

            for (int i = 0; ; i++)
            {
                if (stopwatch.Elapsed >= timeout)
                {
                    Console.WriteLine("Timeout reached. Stopping iteration...");
                    yield break;
                }

                yield return i;
            }
        }

        // Делегаты и Лямбда - выражения. Multicast Delegates
        public static void Lesson_084()
        {
            Console.WriteLine("Hello from Lesson_084 Делегаты и Лямбда - выражения. Multicast Delegates");
            Console.WriteLine();

            // Делегаты - это типы, которые представляют методы с определённой сигнатурой.
            // Они позволяют передавать методы как параметры, хранить их в переменных и вызывать их динамически.
            // Лямбда-выражения - это краткая форма записи анонимных методов, которые могут быть использованы
            // для создания делегатов.

            Func<int, int, int> add = (x, y) => x + y;
            Func<int, int, int> multiply = (x, y) => x * y;
            Console.WriteLine($"Add: {add(3, 4)}");
            Console.WriteLine($"Multiply: {multiply(3, 4)}");

            Func<int, int, int> mathOperation = SumLesson_084;

            var result = mathOperation(5, 10);

            Console.WriteLine(result);

            Func<int, int, int> mathOperation1 = MultiplyLesson_084;

            PerformMathOperation(mathOperation1, 5, 10);

            PerformMathOperation(SumLesson_084, 5, 10);

            MyOperation operation = SumLesson_084;
            PerformMathOperation1(operation, 5, 10);
            PerformMathOperation1(MultiplyLesson_084, 5, 10);

            var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var result1 = numbers.Where(IsEven);
            // или
            var result2 = numbers.Where(delegate (int number)
            {
                return number % 2 == 0;
            });
            // или
            var result3 = numbers.Where((int number) =>
            {
                return number % 2 == 0;
            });

            // или
            var result4 = numbers.Where(number => number % 2 == 0);

            foreach (var number in result1)
            {
                Console.WriteLine(number);
            }

            foreach (var number in result2)
            {
                Console.WriteLine(number);
            }

            foreach (var number in result3)
            {
                Console.WriteLine(number);
            }

            foreach (var number in result4)
            {
                Console.WriteLine(number);
            }

            // Multicast Delegates
            // Делегаты могут содержать ссылки на несколько методов.
            // Когда вызывается такой делегат, все методы в списке вызываются последовательно.
            Console.WriteLine();
            Notify notify = SendSms; // Создание делегата и присвоение ему метода SendSms
            notify("Some information"); // Выведет "SMS: Some information"
            Console.WriteLine();
            notify += SendEmail; // Добавление метода SendEmail к делегату
            notify("Some information"); // Выведет "SMS: Some information" и "Email: Some information"
            Console.WriteLine();
            notify -= SendSms; // Удаление метода SendSms из делегата
            notify("Some information"); // Выведет "Email: Some information"

            // Встроенный делегат Action - это делегат, который представляет метод, не возвращающий значение (void)
            // и может принимать до 16 параметров.
            // То есть можно так
            Console.WriteLine();
            Action<string> action = SendSms;
            action("Some information"); // Выведет "SMS: Some information"
            Console.WriteLine();
            action += SendEmail;
            action("Some information"); // Выведет "SMS: Some information" и "Email: Some information"

            Console.WriteLine(new string('-', 120));
        }

        delegate void Notify(string message);

        static void SendSms(string message)
        {
            Console.WriteLine($"SMS: {message}");
        }

        static void SendEmail(string message)
        {
            Console.WriteLine($"Email: {message}");
        }

        static bool IsEven(int number)
        {
            return number % 2 == 0;
        }

        delegate int MyOperation(int a, int b);

        static void PerformMathOperation1(MyOperation mathOperation, int a, int b)
        {
            Console.WriteLine("My very important code");

            var operationResult = mathOperation(a, b);

            Console.WriteLine(operationResult);

            Console.WriteLine("My super important code");
        }

        static int SumLesson_084(int a, int b)
        {
            return a + b;
        }

        static int MultiplyLesson_084(int a, int b)
        {
            return a * b;
        }

        // Делегат может быть передан в метод в качестве параметра. Это позволяет создавать более гибкие
        // и переиспользуемые методы, которые могут выполнять различные операции в зависимости от переданного делегата.
        static void PerformMathOperation(Func<int, int, int> mathOperation, int a, int b)
        {
            Console.WriteLine("very important code");

            var operationResult = mathOperation(a, b);

            Console.WriteLine(operationResult);

            Console.WriteLine("super important code");
        }

        // Cобытия(Events). Проблемы Инкапсуляции и Делегаты
        public static void Lesson_085()
        {
            Console.WriteLine("Hello from Lesson_085 Cобытия(Events). Проблемы Инкапсуляции и Делегаты");
            Console.WriteLine();

            // События в C# - это механизм, который позволяет объектам уведомлять другие объекты о произошедших
            // изменениях или событиях.
            // Они основаны на делегатах и обеспечивают безопасный способ подписки и отписки на события.


            // Пример без использования событий
            var publisher = new MessagePublisher();

            var smsSubscriber = new SmsSubscriber();
            var emailSubscriber = new EmailSubscriber();

            publisher.OnNotify += smsSubscriber.ReceiveSms;
            publisher.OnNotify += emailSubscriber.ReceiveEmail;

            publisher.RaiseEvent("Hello World!");
            Console.WriteLine();

            #region что тут не так

            // 1. Прямой вызов делегата извне.
            // publisher.OnNotify.Invoke("Direct invocation!");

            // 2. Полный сброс списка подписчиков.
            // publisher.OnNotify = null;

            //publisher.RaiseEvent("Hello World!");

            #endregion

            // События позволяют реализовать инкапсуляцию, предотвращая прямой доступ к делегату извне класса.
            var publisher1 = new MessagePublisherEvent();

            publisher1.OnNotify += smsSubscriber.ReceiveSms;
            publisher1.OnNotify += emailSubscriber.ReceiveEmail;

            publisher1.RaiseEvent("Hello World!");
            
            Console.WriteLine();

            publisher.OnNotify("Hello World!"); // Можем где не используется событие - и это плохо
            //publisher1.OnNotify("Hello World!"); // Не можем где  используется событие - и это хорошо
            publisher.OnNotify = null; // Можем где не используется событие - и это плохо
            // publisher1.OnNotify = null; // Не можем где  используется событие - и это хорошо
            

            // Можем только так
            publisher1.OnNotify -= smsSubscriber.ReceiveSms;
            publisher1.OnNotify -= emailSubscriber.ReceiveEmail;
            publisher1.RaiseEvent("Hello World!");
            Console.WriteLine();

            Console.WriteLine(new string('-', 120));
        }
        
        public delegate void Notify1(string message);

        class MessagePublisherEvent
        {
            public event Notify1 OnNotify;

            public void RaiseEvent(string message)
            {
                OnNotify?.Invoke(message);
            }
        }


        class MessagePublisher
        {
            public Notify1 OnNotify;

            public void RaiseEvent(string message)
            {
                OnNotify?.Invoke(message);
            }
        }

        class SmsSubscriber
        {
            public void ReceiveSms(string message)
            {
                Console.WriteLine($"SMS: {message}");
            }
        }

        class EmailSubscriber
        {
            public void ReceiveEmail(string message)
            {
                Console.WriteLine($"Email: {message}");
            }
        }
    }
}