using System;

namespace LabRab2
{
    public class Password
    {
        // Свойство для хранения значения пароля
        public string Value { get; private set; }

        // Конструктор для инициализации пароля
        public Password(string value)
        {
            Value = value;
        }

        // Оператор "минус" для замены последнего символа пароля
        public static Password operator -(Password password, char newChar)
        {
            if (password.Value.Length == 0)
                return password;  // Если пароль пустой, ничего не меняем

            // Создаем новый объект с измененным значением пароля
            string newValue = password.Value.Substring(0, password.Value.Length - 1) + newChar;
            return new Password(newValue);  // Возвращаем новый объект с обновленным паролем
        }

        // Оператор "не равно" для сравнения двух паролей
        public static bool operator !=(Password left, Password right)
        {
            // Если один из паролей null, то они считаются не равными
            if (left is null || right is null)
                return false;

            // Сравниваем значения паролей
            return left.Value != right.Value;
        }

        // Оператор "равно" для сравнения двух паролей
        public static bool operator ==(Password left, Password right)
        {
            // Если оба пароля null, они равны
            if (left is null || right is null)
                return left is null && right is null;

            // Сравниваем значения паролей
            return left.Value == right.Value;
        }

        // Оператор инкремента (сброс на значение по умолчанию "default")
        public static Password operator ++(Password password)
        {
            // Создаем новый объект с паролем по умолчанию
            return new Password("default");
        }

        // Переопределение метода Equals для корректного сравнения объектов
        public override bool Equals(object obj)
        {
            // Сравниваем объекты по значению пароля
            return obj is Password password && Value == password.Value;
        }

        // Переопределение метода GetHashCode для корректной работы с коллекциями
        public override int GetHashCode()
        {
            return Value.GetHashCode();  // Используем хэш-код пароля для корректной работы с коллекциями
        }

        // Неявное преобразование типа Password в bool
        public static implicit operator bool(Password password)
        {
            // Возвращаем true, если длина пароля >= 8 символов
            return password != null && password.Value.Length >= 8;
        }

        // Явный метод для проверки, является ли пароль стойким (длина >= 8 символов)
        public bool IsStrongPassword()
        {
            return Value.Length >= 8;  // Пароль стойкий, если его длина >= 8
        }

        // Явный метод для проверки, является ли пароль слабым (длина < 8 символов)
        public bool IsWeakPassword()
        {
            return Value.Length < 8;  // Пароль слабый, если его длина < 8
        }
    }

    // Класс расширений для строки
    public static class StringExtensions
    {
        // Метод расширения для нахождения среднего символа строки
        public static char MiddleCharacter(this string str)
        {
            // Если строка пустая или null, выбрасываем исключение
            if (string.IsNullOrEmpty(str)) throw new ArgumentException("String is null or empty.");
            int middleIndex = str.Length / 2;  // Находим индекс среднего символа
            return str[middleIndex];  // Возвращаем средний символ
        }

        // Метод расширения для проверки длины пароля
        public static bool IsValidPasswordLength(this string str)
        {
            // Выводим количество символов в пароле для информации
            Console.WriteLine($"Количество символов в пароле: {str.Length}");

            // Возвращаем true, если длина пароля >= 6, иначе false
            // Также выводим сообщение, указывающее на длину пароля
            Console.WriteLine("Длина пароля больше или равна 6?", str);
            return str.Length >= 6;  // Пароль считается валидным, если его длина >= 6
        }
    }
}
