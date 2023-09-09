
using System;
using System.Collections.Generic;

namespace CourseProject
{
    class NewProgram
    {
        Dictionary<string, int> myDictionary = new Dictionary<string, int>();

        PersonClass person = new PersonClass("John", "Doe", 30);
    }
    class PersonNew
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public PersonNew(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }
    }
}
