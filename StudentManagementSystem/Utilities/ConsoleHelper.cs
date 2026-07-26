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
                Console.WriteLine("Invalid input. Please try again.");
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
                Console.WriteLine("Invalid input. Please try again.");
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
                Console.WriteLine("Invalid input. Please try again.");
            }
        }

    }
}
