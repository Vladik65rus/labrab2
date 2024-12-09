using Xunit;
using LabRab2;  // Пространство имен для подключения методов расширений и класса Password

namespace LabRab2.Tests
{
    public class PasswordTests
    {
        // Тест оператора "минус" для замены последнего символа пароля
        [Fact]
        public void TestOperatorMinus()
        {
            Password password = new Password("123456");
            password = password - 'X';  // Заменяем последний символ на 'X'
            Assert.Equal("12345X", password.Value);  // Проверяем, что последний символ изменился
        }

        // Тест оператора "не равно" для проверки неравенства двух паролей
        [Fact]
        public void TestOperatorNotEqual()
        {
            Password p1 = new Password("123456");
            Password p2 = new Password("password123");
            Assert.True(p1 != p2);  // Проверка на неравенство: пароли должны быть разными
        }

        // Тест оператора "равно" для проверки равенства двух паролей
        [Fact]
        public void TestOperatorEqual()
        {
            Password p1 = new Password("password123");
            Password p2 = new Password("password123");
            Assert.True(p1 == p2);  // Проверка на равенство: пароли одинаковые
        }

        // Тест оператора инкремента (сброс на значение по умолчанию)
        [Fact]
        public void TestOperatorIncrement()
        {
            Password password = new Password("123456");
            password++;  // Пароль должен быть сброшен на "default"
            Assert.Equal("default", password.Value);  // Проверяем, что пароль стал "default"
        }

        // Тест оператора "неявное преобразование в bool" для пароля с длиной >= 8
        [Fact]
        public void TestOperatorTrue()
        {
            Password password = new Password("12345678");
            Assert.True(password);  // Пароль с длиной >= 8 должен быть преобразован в true
        }

        // Тест оператора "неявное преобразование в bool" для пароля с длиной < 8
        [Fact]
        public void TestOperatorFalse()
        {
            Password password = new Password("12345");
            Assert.False(password);  // Пароль с длиной < 8 должен быть преобразован в false
        }

        // Тест метода расширения для нахождения среднего символа строки
        [Fact]
        public void TestMiddleCharacter()
        {
            string testString = "HelloWorld";
            Assert.Equal('o', testString.MiddleCharacter());  // Средний символ строки "HelloWorld" должен быть "o"
        }

        // Тест метода расширения для проверки длины пароля
        [Fact]
        public void TestIsValidPasswordLength()
        {
            string testString = "HelloWorld";
            Assert.True(testString.IsValidPasswordLength());  // Проверяем, что длина пароля >= 6
        }
    }
}
