using StudentManagementSystem.Constants;
using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Utilities
{
    internal static class ConsoleHelper
    {
        public static int ReadInt()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int value))
                {
                    return value;
                }
                Console.WriteLine(Messages.Error.InvalidInput);
            } 
        }
        public static double ReadDouble()
        {
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                Console.WriteLine(Messages.Error.InvalidInput);
            }
        }
        public static string ReadString()
        {
            while (true)
            {
                var input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    return input;
                }
                Console.WriteLine(Messages.Error.InvalidInput);
            }
        }

        public static Student ReadStudent()
        {
            Console.WriteLine("ID: ");
            int id = ReadInt();
            Console.WriteLine("Roll Number: ");
            int rollNumber = ReadInt();
            Console.WriteLine("First Name: ");
            string firstName = ReadString();
            Console.WriteLine("Last Name: ");
            string lastName = ReadString();
            Console.WriteLine("Age: ");
            int age = ReadInt();
            Console.WriteLine("Department: ");
            string department = ReadString();
            Console.WriteLine("Email: ");
            string email = ReadString();
            Console.WriteLine("Phone Number: ");
            string phoneNumber = ReadString();
            Console.WriteLine("Percentage: ");
            double percentage = ReadDouble();
            return new Student(id, firstName, lastName, age, rollNumber, department, email, phoneNumber, percentage);
        }

        public static void DisplayStudentsInfo(List<Student> students)
        {
            foreach (var s in students)
            {
                s.DisplayInfo();
                Console.WriteLine("--------------------");
            }
        }
    }
}
