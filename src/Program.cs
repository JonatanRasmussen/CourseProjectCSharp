using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CourseProject;

class Program
{
    // Define a sample data object
    PersonClass person = new PersonClass("John", "Doe", 30);
    // This is a single-line comment

    /*
        This is a multi-line comment.
        You can add more lines here.
    */
    public static int yolo = 5;
    static void Main(string[] args)
    {          // Variables and data types
        int age = 25;
        string name = "John";
        double price = 19.99;
        bool isStudent = true;
        Dictionary<string, int> myDictionary = new Dictionary<string, int>();

        // Console output
        Console.WriteLine($"Hello, {name}!");
        Console.WriteLine($"You are {age} years old.");
        Console.WriteLine($"The price is {price:C2}");
        Console.WriteLine($"Are you a student? {isStudent}");

        // Control structures
        if (age < 18)
        {
            Console.WriteLine("You are a minor.");
        }
        else if (age >= 18 && age < 65)
        {
            Console.WriteLine("You are an adult.");
        }
        else
        {
            Console.WriteLine("You are a senior citizen.");
        }

        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"Iteration {i + 1}");
        }

        // Arrays
        int[] numbers = { 1, 2, 3, 4, 5 };
        foreach (var number in numbers)
        {
            Console.WriteLine($"Number: {number}");
        }

        // Functions
        int sum = AddNumbers(3, 4);
        Console.WriteLine($"Sum: {sum}");

        // regex test
        string htmlTest = HtmlInfoParser.HtmlTestInput();
        Dictionary<string, string> dct = HtmlInfoParser.ParseAllInfo(htmlTest);
        foreach (KeyValuePair<string, string> kvp in dct)
        {
            Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
        }
    }

    // Function definition
    static int AddNumbers(int a, int b) {
        return a + b;
    }
}


public class PersonClass
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public PersonClass(string firstName, string lastName, int age)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
    }
}