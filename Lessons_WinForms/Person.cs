using System;

namespace Lessons_WinForms
{
    public class Person
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string SecondName { get; set; }

        public Contacts Contacts { get; set; }

        // ОПЕРАТОР NULL-COALESCING. ОПЕРАТОР ОБЪЕДИНЕНИЯ С NULL - ?? . ПРИМЕР
        public string GetFullName()
        {
            return $"Фамилия: {SecondName ?? "отсутствует"} | Имя: {FirstName ?? "отсутствует"} | Отчество: {MiddleName ?? "отсутствует"}";
        }
        public string GetPhoneNumber()
        {
            return $"Номер телефона: {Contacts?.PhoneNumber ?? "отсутствует"}";
        }
    }

    public class Contacts
    {
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
