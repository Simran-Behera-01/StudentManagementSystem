using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Data
{
    internal class StudentRepository
    {
        private readonly List<Student> studentsList = new();
        public List<Student> GetAllStudents()
        {
            return studentsList;
        }
    }
}
