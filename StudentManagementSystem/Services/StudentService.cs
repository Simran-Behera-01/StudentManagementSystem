using StudentManagementSystem.Data;
using StudentManagementSystem.Exceptions;
using StudentManagementSystem.Interfaces;
using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StudentManagementSystem.Services
{
    internal class StudentService : IStudentService
    {
        private readonly StudentRepository studentRepository = new StudentRepository();
        private Student? FindStudentByRollNumber(int rollNumber)
        {
            var students = studentRepository.GetAllStudents();
            foreach (var student in students)
            {
                if (student.RollNumber == rollNumber)
                {
                    return student;
                }
            }
            return null;
        }
        private void ValidateStudent(Student student)
        {
            if (student.Age < 18)
            {
                throw new InvalidAgeException("Student age must be 18 or above.");
            }
            if (student.Percentage < 0 || student.Percentage > 100)
            {
                throw new InvalidPercentageException("Percentage value should be between 0 and 100.");
            }
            if (!Regex.IsMatch(student.PhoneNumber,@"^\d{10}$"))
            {
                throw new InvalidPhoneNumberException("Give valid phone number.");
            }
        }

        private void ValidateDuplicateStudent(int rollNumber,int id)
        {
            var students = studentRepository.GetAllStudents();
            foreach (var student in students)
            {
                if (student.RollNumber == rollNumber || student.Id == id)
                {
                    throw new DuplicateStudentException("A student with this roll number/id already exists.");
                }
            }
        }

        public void AddStudent(Student student)
        {

            var students = studentRepository.GetAllStudents();
            ValidateDuplicateStudent(student.RollNumber, student.Id);
            ValidateStudent(student);

            students.Add(student);
        }

        public void DeleteStudent(int rollNumber)
        {
            var students = studentRepository.GetAllStudents();
            Student? studentToDelete = FindStudentByRollNumber(rollNumber);
            if (studentToDelete == null)
            {
                throw new StudentNotFoundException("Student with the given roll number was not found.");
            }
            students.Remove(studentToDelete);
        }

        public List<Student> GetAllStudents()
        {
            return studentRepository.GetAllStudents();
        }

        public Student GetStudentByRollNumber(int rollNumber)
        {
            Student? student = FindStudentByRollNumber(rollNumber);
            if (student == null)
            {
                throw new StudentNotFoundException("Student with the given roll number was not found.");
            }
            return student;
        }

        public void LoadFromFile(string filePath)
        {
            using(StreamReader reader = new StreamReader(filePath))
            {
                var students = studentRepository.GetAllStudents();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if(line != null)
                    {
                        var studentDetails = line.Split(",");
                        Student student = new Student(int.Parse(studentDetails[0].Trim()), studentDetails[2].Split(" ")[0].Trim(), studentDetails[2].Split(" ")[1].Trim(), int.Parse(studentDetails[3].Trim()), int.Parse(studentDetails[1].Trim()), studentDetails[4].Trim(), studentDetails[5].Trim(), studentDetails[6].Trim(), double.Parse(studentDetails[7].Trim()));
                        students.Add(student);
                    }
                }

            }

        }

        public void SaveToFile(string filePath)
        {
            var students = studentRepository.GetAllStudents();
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var student in students)
                {
                    writer.WriteLine($"{student.Id},{student.RollNumber},{student.FirstName} {student.LastName},{student.Age},{student.Department},{student.Email},{student.PhoneNumber},{student.Percentage}");
                }
            }
        }

        public List<Student> SearchStudentsByName(string name)
        {
            var students = studentRepository.GetAllStudents();
            var nameParts = name.Split(" ");
            var result = new List<Student>();
            foreach (var student in students)
            {
                if (nameParts[0].Trim().ToLower() == student.FirstName.ToLower() || (nameParts.Length == 2 && nameParts[1].Trim().ToLower() == student.LastName.ToLower()))
                {
                    result.Add(student);
                }
            }
            return result;
        }

        public void UpdateStudent(Student updatedStudent)
        {
            ValidateStudent(updatedStudent);

            Student? student = FindStudentByRollNumber(updatedStudent.RollNumber);
            if (student == null)
            {
                throw new StudentNotFoundException("Student with the given roll number was not found.");
            }
            student.FirstName = updatedStudent.FirstName;
            student.LastName = updatedStudent.LastName;
            student.Department = updatedStudent.Department;
            student.Email = updatedStudent.Email;
            student.PhoneNumber = updatedStudent.PhoneNumber;
            student.Percentage = updatedStudent.Percentage; 
        }
    }
}
