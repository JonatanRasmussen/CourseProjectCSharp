namespace TestingNameSpace;

using CourseProject;
using Xunit;

public class MyTests
{
    [Fact]
    public void MyTest1()
    {
        // Arrange
        int a = 1;
        int b = 2;

        // Act
        int result = a + b;

        // Assert
        Assert.Equal(3, result);
    }

    [Fact]
    public void MyTest2()
    {
        // Arrange
        string message = "Hello, World!";

        // Act
        string actual = message.ToUpper();

        // Assert
        Assert.Equal("HELLO, WORLD!", actual);
    }

    [Fact]
    public void MyTest3()
    {
        // Arrange
        PersonClass person = new("hey","hey",30);

        // Assert
        Assert.Equal(30, person.Age);
    }

    [Fact]
    public void MyTest4()
    {
        // Arrange
        PersonClass person = new("hey","hey",30);

        // Assert
        Assert.Equal(30, person.Age);
    }
}