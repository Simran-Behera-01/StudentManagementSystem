using StudentManagementSystem.Exceptions;
using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StudentManagementSystem.Utilities
{
    internal static class ValidationHelper
    {
        public static bool ValidateEmail(string email)
        {
            if (!Regex.IsMatch(email, @"^[a-zA-Z0-9._]+@[a-zA-Z]+\.[a-zA-Z]{2,}$"))
                return false;
            return true;
        }
        public static bool ValidateAge(int age)
        {
            if (age < 18)
                return false;
            return true;
        }

        public static bool ValidatePhoneNumber(string phoneNumber)
        {
            if (!Regex.IsMatch(phoneNumber, @"^\d{10}$"))
                return false;
            return true;
        }
        public static bool ValidatePercentage(double percentage)
        {
            if (percentage < 0 || percentage > 100)
                return false;
            return true;
        }
    }
}
