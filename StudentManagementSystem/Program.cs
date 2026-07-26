using StudentManagementSystem.Constants;
using StudentManagementSystem.Delegates;
using StudentManagementSystem.Interfaces;
using StudentManagementSystem.Models;
using StudentManagementSystem.Services;
using StudentManagementSystem.Utilities;

namespace StudentManagementSystem
{
    internal class Program
    {
        static private readonly IStudentService _studentService = new StudentService();
        static void Main(string[] args)
        {
            FileHelper.fileLoadedHandler = DisplayFileLoadedMessage;
            FileHelper.fileSavedHandler = DisplayFileSavedMessage;
            Console.WriteLine("Student Management System");
            _studentService.LoadFromFile("D:\\.NET\\StudentManagementSystem\\StudentManagementSystem\\Students.txt");
            while (true)
            {
                try
                {
                    Console.WriteLine("Menu");
                    Console.WriteLine("1. Add Student");
                    Console.WriteLine("2. Update Student");
                    Console.WriteLine("3. Delete Student");
                    Console.WriteLine("4. Search Student by Name");
                    Console.WriteLine("5. Search Student by Roll Number");
                    Console.WriteLine("6. Display All Students");
                    Console.WriteLine("7. Exit");
                    Console.WriteLine("Enter your choice: ");
                    int choice = ConsoleHelper.ReadInt();
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Enter student details:");
                            Console.WriteLine(_studentService.AddStudent(ConsoleHelper.ReadStudent()).Message);
                            break;
                        case 2:
                            Console.WriteLine("Enter student details to update:");
                            Console.WriteLine(_studentService.UpdateStudent(ConsoleHelper.ReadStudent()).Message);
                            break;
                        case 3:
                            Console.WriteLine("Enter Roll Number of student to delete: ");
                            var rollNumber = ConsoleHelper.ReadInt();
                            Console.WriteLine(_studentService.DeleteStudent(rollNumber).Message);
                            break;
                        case 4:
                            Console.WriteLine("Enter name of student to search:");
                            string name = ConsoleHelper.ReadString();
                            var resultList = _studentService.SearchStudentsByName(name);
                            if (!resultList.IsSuccess)
                            {
                                Console.WriteLine(resultList.Message);
                                break;
                            }
                            ConsoleHelper.DisplayStudentsInfo(resultList.Data);
                            break;
                        case 5:
                            Console.WriteLine("Enter Roll Number of student to search: ");
                            rollNumber = ConsoleHelper.ReadInt();
                            var result = _studentService.GetStudentByRollNumber(rollNumber);
                            if (!result.IsSuccess)
                            {
                                Console.WriteLine(result.Message);
                                break;
                            }
                            var student = result.Data;
                            student.DisplayInfo();
                            Console.WriteLine("--------------------");
                            break;
                        case 6:
                            Console.WriteLine("Displaying all students:");
                            resultList = _studentService.GetAllStudents();
                            if (!resultList.IsSuccess)
                            {
                                Console.WriteLine(resultList.Message);
                                break;
                            }
                            ConsoleHelper.DisplayStudentsInfo(resultList.Data);
                            break;
                        case 7:
                            Console.WriteLine("Exiting...");
                            _studentService.SaveToFile("D:\\.NET\\StudentManagementSystem\\StudentManagementSystem\\Students.txt");
                            return;
                        default:
                            Console.WriteLine(Messages.Error.InvalidInput);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
        public static void DisplayFileLoadedMessage()
        {
            Console.WriteLine("Student data loaded from file.");
        }
        public static void DisplayFileSavedMessage()
        {
            Console.WriteLine("Student data saved to file.");
        }
    }
}
