using System;
using LabRab2;
using System.Threading.Tasks;
using System.Text;

namespace LabRab2
{
    class Program
    {
        // Основной метод программы, отвечает за выбор задачи и выполнение
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8; // Устанавливаем кодировку UTF-8 для консольного вывода

            // Бесконечный цикл, который позволяет пользователю выбрать задачу
            while (true)
            {
                Console.WriteLine("Выберите задачу для выполнения:");
                Console.WriteLine("1 - Часть 1"); // Пример задачи 1
                Console.WriteLine("2 - Часть 2"); // Пример задачи 2
                Console.WriteLine("0 - Выйти"); // Выход из программы

                string choice = Console.ReadLine(); // Ввод пользователя для выбора задачи
                Task selectedTask = null;

                // Определяем, какую задачу выполнять в зависимости от ввода пользователя
                switch (choice)
                {
                    case "1":
                        selectedTask = Task1(); // Выбор первой задачи
                        break;
                    case "2":
                        selectedTask = Task2(); // Выбор второй задачи
                        break;
                    case "0":
                        Console.WriteLine("Выход из программы."); // Сообщение об выходе
                        return; // Выход из программы
                    default:
                        Console.WriteLine("Некорректный ввод. Попробуйте еще раз."); // Обработка неверного ввода
                        break;
                }

                // Если задача была выбрана, выполняем её асинхронно
                if (selectedTask != null)
                {
                    await selectedTask;  // Ожидаем завершения выполнения задачи
                    Console.WriteLine("");  // Печатаем пустую строку для разделения
                    Console.WriteLine("Задача завершена."); // Сообщение о завершении задачи
                }

                Console.WriteLine(""); // Печатаем пустую строку для разделения
            }
        }

        // Задача 1. Пример работы с классом Password и его операторами
        static async Task Task1()
        {
            // Пример создания пароля с начальным значением
            Password password = new Password("12345678");

            // Пример использования оператора "минус" для замены последнего символа пароля
            password = password - 'X';  // Заменяем последний символ на 'X'
            Console.WriteLine($"Изменённый пароль: {password.Value}"); // Выводим изменённый пароль

            // Пример использования оператора "не равно" для сравнения двух паролей
            Password p1 = new Password("password123");
            Password p2 = new Password("password123");
            Console.WriteLine($"Пароли одинаковые: {p1 == p2}"); // Проверяем на равенство

            // Пример использования оператора "равно" для сравнения двух разных паролей
            Password p3 = new Password("testpassword");
            Console.WriteLine($"Пароли разные: {p1 != p3}"); // Проверяем на неравенство

            // Пример использования оператора инкремента для сброса пароля на значение "default"
            password++;
            Console.WriteLine($"После инкремента пароль: {password.Value}"); // Выводим пароль после инкремента (сброс на "default")

            // Пример проверки длины пароля с использованием неявного преобразования в bool
            if (password) // Если длина пароля >= 8, то пароль считается стойким
            {
                Console.WriteLine("Пароль стойкий.");
            }
            else
            {
                Console.WriteLine("Пароль слабый."); // Если длина пароля < 8, то пароль считается слабым
            }

            // Пример использования метода расширения для строки, который находит средний символ строки
            string testString = "HelloWorld";
            Console.WriteLine($"Средний символ строки: {testString.MiddleCharacter()}"); // Выводим средний символ строки

            // Пример использования метода расширения для проверки длины пароля
            // Здесь также добавим вывод количества символов в пароле
            Console.WriteLine($"{testString.IsValidPasswordLength()}"); // Проверяем, что длина пароля >= 6 символов
        }

        // Заглушка для задачи 2 (пока не реализована)
        static async Task Task2()
        {
            // Сообщение о том, что задача 2 ещё не реализована
            Console.WriteLine("Часть 2 еще не реализована.");
            await Task.Delay(1000);  // Симуляция задержки, чтобы процесс был асинхронным
        }
    }
}
