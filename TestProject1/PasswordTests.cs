using Xunit;
using LabRab2;  // ������������ ���� ��� ����������� ������� ���������� � ������ Password

namespace LabRab2.Tests
{
    public class PasswordTests
    {
        // ���� ��������� "�����" ��� ������ ���������� ������� ������
        [Fact]
        public void TestOperatorMinus()
        {
            Password password = new Password("123456");
            password = password - 'X';  // �������� ��������� ������ �� 'X'
            Assert.Equal("12345X", password.Value);  // ���������, ��� ��������� ������ ���������
        }

        // ���� ��������� "�� �����" ��� �������� ����������� ���� �������
        [Fact]
        public void TestOperatorNotEqual()
        {
            Password p1 = new Password("123456");
            Password p2 = new Password("password123");
            Assert.True(p1 != p2);  // �������� �� �����������: ������ ������ ���� �������
        }

        // ���� ��������� "�����" ��� �������� ��������� ���� �������
        [Fact]
        public void TestOperatorEqual()
        {
            Password p1 = new Password("password123");
            Password p2 = new Password("password123");
            Assert.True(p1 == p2);  // �������� �� ���������: ������ ����������
        }

        // ���� ��������� ���������� (����� �� �������� �� ���������)
        [Fact]
        public void TestOperatorIncrement()
        {
            Password password = new Password("123456");
            password++;  // ������ ������ ���� ������� �� "default"
            Assert.Equal("default", password.Value);  // ���������, ��� ������ ���� "default"
        }

        // ���� ��������� "������� �������������� � bool" ��� ������ � ������ >= 8
        [Fact]
        public void TestOperatorTrue()
        {
            Password password = new Password("12345678");
            Assert.True(password);  // ������ � ������ >= 8 ������ ���� ������������ � true
        }

        // ���� ��������� "������� �������������� � bool" ��� ������ � ������ < 8
        [Fact]
        public void TestOperatorFalse()
        {
            Password password = new Password("12345");
            Assert.False(password);  // ������ � ������ < 8 ������ ���� ������������ � false
        }

        // ���� ������ ���������� ��� ���������� �������� ������� ������
        [Fact]
        public void TestMiddleCharacter()
        {
            string testString = "HelloWorld";
            Assert.Equal('o', testString.MiddleCharacter());  // ������� ������ ������ "HelloWorld" ������ ���� "o"
        }

        // ���� ������ ���������� ��� �������� ����� ������
        [Fact]
        public void TestIsValidPasswordLength()
        {
            string testString = "HelloWorld";
            Assert.True(testString.IsValidPasswordLength());  // ���������, ��� ����� ������ >= 6
        }
    }
}
