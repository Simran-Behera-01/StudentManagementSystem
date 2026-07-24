using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Models
{
    internal abstract class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        protected Person(int id, string firstName, string lastName, int age)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }
        public abstract void DisplayInfo();
    }
}
