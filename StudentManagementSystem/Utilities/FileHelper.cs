using StudentManagementSystem.Data;
using StudentManagementSystem.Delegates;
using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Utilities
{
    internal static class FileHelper
    {
        public static FileLoadedHandler fileLoadedHandler;
        public static FileSavedHandler fileSavedHandler;

        public static void Save(string filePath, List<Student> students)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var student in students)
                {
                    writer.WriteLine($"{student.Id},{student.RollNumber},{student.FirstName} {student.LastName},{student.Age},{student.Department},{student.Email},{student.PhoneNumber},{student.Percentage}");
                }
            }
            fileSavedHandler?.Invoke();
        }
        public static void Load(string filePath, List<Student> students) 
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (line != null)
                    {
                        var studentDetails = line.Split(",");
                        Student student = new Student(int.Parse(studentDetails[0].Trim()), studentDetails[2].Split(" ")[0].Trim(), studentDetails[2].Split(" ")[1].Trim(), int.Parse(studentDetails[3].Trim()), int.Parse(studentDetails[1].Trim()), studentDetails[4].Trim(), studentDetails[5].Trim(), studentDetails[6].Trim(), double.Parse(studentDetails[7].Trim()));
                        students.Add(student);
                    }
                }
            }
            fileLoadedHandler?.Invoke();
        }
    }
}
