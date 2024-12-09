using System;

namespace LabRab2
{
    // Интерфейс, который определяет методы для отображения деталей и получения информации
    public interface IDisplayable
    {
        void ShowDetails();  // Метод для отображения деталей объекта
        string GetInfo();    // Метод для получения информации об объекте
    }

    // Абстрактный класс "Персона", представляющий общего человека
    public abstract class Person : IDisplayable
    {
        public string Name { get; set; } // Свойство для хранения имени человека

        // Конструктор для инициализации имени
        public Person(string name)
        {
            Name = name;
        }

        // Переопределение метода ToString для получения текстового представления объекта
        public override string ToString()
        {
            return $"Персона: {Name}";
        }

        // Абстрактный метод для вывода деталей (реализуется в дочерних классах)
        public abstract void ShowDetails();

        // Виртуальный метод для получения общей информации о человеке
        public virtual string GetInfo()
        {
            return $"Информация о человеке: {Name}";
        }
    }

    // Класс "Служащий", наследуется от Person
    public class Employee : Person
    {
        public string Position { get; set; } // Свойство для должности

        // Конструктор для инициализации имени и должности
        public Employee(string name, string position) : base(name)
        {
            Position = position;
        }

        // Реализация метода ShowDetails для отображения деталей о служащем
        public override void ShowDetails()
        {
            Console.WriteLine($"Employee: {Name}, Position: {Position}");
        }

        // Переопределение метода GetInfo для получения информации о служащем
        public override string GetInfo()
        {
            return $"Служащий: {Name}, Должность: {Position}";
        }
    }

    // Класс "Студент", наследуется от Person
    public class Student : Person
    {
        public string Major { get; set; } // Свойство для специальности

        // Конструктор для инициализации имени и специальности
        public Student(string name, string major) : base(name)
        {
            Major = major;
        }

        // Реализация метода ShowDetails для отображения деталей о студенте
        public override void ShowDetails()
        {
            Console.WriteLine($"Student: {Name}, Major: {Major}");
        }

        // Переопределение метода GetInfo для получения информации о студенте
        public override string GetInfo()
        {
            return $"Студент: {Name}, Специальность: {Major}";
        }
    }

    // Класс "Рабочий", наследуется от Person
    public class Worker : Person
    {
        public string JobTitle { get; set; } // Свойство для должности

        // Конструктор для инициализации имени и должности
        public Worker(string name, string jobTitle) : base(name)
        {
            JobTitle = jobTitle;
        }

        // Реализация метода ShowDetails для отображения деталей о рабочем
        public override void ShowDetails()
        {
            Console.WriteLine($"Работа: {Name}, Рабочая таблица: {JobTitle}");
        }

        // Переопределение метода GetInfo для получения информации о рабочем
        public override string GetInfo()
        {
            return $"Рабочий: {Name}, Должность: {JobTitle}";
        }
    }

    // Класс программы для демонстрации работы с иерархией классов
    class Program
    {
        static void Main(string[] args)
        {
            // Создаем массив объектов разных классов
            Person[] people = new Person[]
            {
                new Employee("Кокунов Андрей", "Лидер"), // Объект класса Employee
                new Student("Зоркольцев Илья", "Компьютерный мастер"), // Объект класса Student
                new Worker("Савченко Владислав", "Электронщик") // Объект класса Worker
            };

            // Перебираем массив и вызываем методы для каждого объекта
            foreach (var person in people)
            {
                person.ShowDetails();  // Вызов переопределенного метода ShowDetails
                Console.WriteLine(person.GetInfo());  // Вызов переопределенного метода GetInfo
            }
        }
    }
}
