using System;
using System.Diagnostics;
using System.Text;

namespace Learning_C_basics_App
{
    public static partial class Program
    {
        private static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8; // Изменяем кодировку консоли
            Lesson_001(); // Типы данных в C#
            Lesson_002(); // Переменные в С#. Объявление, инициализация, присвоение значенмй (помещение данных) 
            Lesson_003(); // Ввод данных в консоль
            Lesson_004(); // Конвертация строки в число. Класс Convert
            Lesson_005(); // Преобразование строк. Parse string. TryParse string.
            Lesson_006(); // ОПЕРАТОРЫ.
            Lesson_007(); // ИНКРЕМЕНТ И ДЕКРЕМЕНТ. ПОСТФИКСНЫЙ И ПРЕФИКСНЫЙ
            Lesson_008(); // ОПЕРАЦИИ СРАВНЕНИЯ. ОПЕРАТОРЫ ОТНОШЕНИЯ
            Lesson_009(); // IF ELSE. КОНСТРУКЦИЯ ЛОГИЧЕСКОГО ВЫБОРА. ВЕТВЛЕНИЕ
            Lesson_010(); // ЛОГИЧЕСКИЕ ОПЕРАТОРЫ. СОКРАЩЁННЫЕ ЛОГИЧЕСКИЕ ОПЕРАЦИИ
            Lesson_011(); // Условный оператор SWITCH. ЧТО ЭТО. ПРИМЕР. СИНТАКСИС. ОПЕРАТОР МНОЖЕСТВЕННОГО ВЫБОРА
            Lesson_012(); // ЦИКЛ WHILE. ЧТО ЭТО. КАК РАБОТАЕТ
            Lesson_013(); // ЦИКЛ DO WHILE. ЧТО ЭТО. КАК РАБОТАЕТ
        }
    }
}
