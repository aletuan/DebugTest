using System;
using System.Diagnostics;

namespace DebugTest
{
    [DebuggerDisplay("Name = {FirstName} and {LastName}")]
    public class Person
    {
        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        
        public string FirstName { get; set;}
        public string LastName {get; set;}
    }
}