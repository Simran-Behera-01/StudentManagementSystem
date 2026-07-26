using StudentManagementSystem.Common;
using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Interfaces
{
    internal interface IStudentService
    {
        Result<Student> AddStudent(Student student);
        Result<Student> UpdateStudent(Student updatedStudent);
        Result<Student> DeleteStudent(int rollNumber);
        Result<Student> GetStudentByRollNumber(int rollNumber);
        Result<List<Student>> SearchStudentsByName(string name);
        Result<List<Student>> GetAllStudents();
        void SaveToFile(string filePath);
        void LoadFromFile(string filePath);
    }
}
