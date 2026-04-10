using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_03
{
    internal static class Program
    {
        static void Main()
        {
            Console.WriteLine("Домашнее задание 3 - Напишите простой конвертер валют (без возможности динамического выбора \r\n" +
                "валюты пользователем). Валюты заданы хардкодом и не изменяются. Тип валют на выбор программиста.");
            double UsdToEurRate = 0.95;
            double UsdToUahRate = 45.23;

            Console.WriteLine("Введите сумму в долларах:");
            if (!double.TryParse(Console.ReadLine(), out double usd))
            {
                Console.WriteLine("Ошибка формата. По умолчанию usd = 11.55");
                usd = 11.55;
            }

            Console.WriteLine($"{usd} USD в Euro = {usd*UsdToEurRate}");
            Console.WriteLine($"{usd} USD в UAH = {usd * UsdToUahRate}");  
            
        }
    }
}
