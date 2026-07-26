using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Constants
{
    internal static class Messages
    {
        public static class Success
        {
            public const string StudentAdded = "Student Added Successfully.";
            public const string StudentUpdated = "Student Updated Successfully.";
            public const string StudentDeleted = "Student Deleted Successfully.";
        }
        public static class Error 
        {
            public const string InvalidInput = "Invalid input. Please try again.";
            public const string StudentNotFound = "Student Not Found.";
            public const string DuplicateStudent = "A student with this roll number/id already exists.";
        }
        public static class Validation 
        {
            public const string InvalidAge = "Invalid Age. Age must be greater than 18.";
            public const string InvalidEmail = "Invalid Email. Please enter a valid email address.";
            public const string InvalidPhoneNumber = "Invalid Phone Number. Phone number must be 10 digits.";
            public const string InvalidPercentage = "Invalid Percentage. Percentage must be between 0 and 100.";
        }
       
    }
}
