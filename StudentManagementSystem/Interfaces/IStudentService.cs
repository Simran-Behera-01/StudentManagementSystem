using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Interfaces
{
    internal interface IStudentService
    {
        void AddStudent(Student student);
        void UpdateStudent(Student updatedStudent);
        void DeleteStudent(int rollNumber);
        Student GetStudentByRollNumber(int rollNumber);
        List<Student> SearchStudentsByName(string name);
        List<Student> GetAllStudents();
        void SaveToFile(string filePath);
        void LoadFromFile(string filePath);
    }
}
