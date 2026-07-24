using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Models
{
    internal class Student : Person
    {
        public int RollNumber { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public double Percentage { get; set; }
        public Student(int id, string firstName, string lastName, int age, int rollNumber, string department, string email, string phoneNumber, double percentage) : base(id, firstName, lastName, age)
        {
            RollNumber = rollNumber;
            Department = department;
            Email = email;
            PhoneNumber = phoneNumber;
            Percentage = percentage;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Roll Number: {RollNumber}");
            Console.WriteLine($"Name: {FirstName} {LastName}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine($"Department: {Department}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Phone Number: {PhoneNumber}");
            Console.WriteLine($"Percentage: {Percentage}");
        }
    }
}
