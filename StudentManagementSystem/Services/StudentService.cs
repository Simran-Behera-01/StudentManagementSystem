using StudentManagementSystem.Common;
using StudentManagementSystem.Constants;
using StudentManagementSystem.Data;
using StudentManagementSystem.Delegates;
using StudentManagementSystem.Exceptions;
using StudentManagementSystem.Interfaces;
using StudentManagementSystem.Models;
using StudentManagementSystem.Utilities;
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
            if(!ValidationHelper.ValidateEmail(student.Email)) throw new InvalidEmailException(Messages.Validation.InvalidEmail);
            if(!ValidationHelper.ValidateAge(student.Age)) throw new InvalidAgeException(Messages.Validation.InvalidAge);
            if(!ValidationHelper.ValidatePercentage(student.Percentage)) throw new InvalidPercentageException(Messages.Validation.InvalidPercentage);
            if(!ValidationHelper.ValidatePhoneNumber(student.PhoneNumber)) throw new InvalidPhoneNumberException(Messages.Validation.InvalidPhoneNumber);
        }

        private void ValidateDuplicateStudent(int rollNumber,int id)
        {
            var students = studentRepository.GetAllStudents();
            foreach (var student in students)
            {
                if (student.RollNumber == rollNumber || student.Id == id)
                {
                    throw new DuplicateStudentException(Messages.Error.DuplicateStudent);
                }
            }
        }

        public Result<Student> AddStudent(Student student)
        {
            try
            {
                var students = studentRepository.GetAllStudents();
                ValidateDuplicateStudent(student.RollNumber, student.Id);
                ValidateStudent(student);
                students.Add(student);
                return Result<Student>.Success(student, Messages.Success.StudentAdded);
            }
            catch (Exception ex)
            {
                return Result<Student>.Failure(ex.Message);
            }
        }

        public Result<Student> DeleteStudent(int rollNumber)
        {
            try
            {
                var students = studentRepository.GetAllStudents();
                Student? studentToDelete = FindStudentByRollNumber(rollNumber);
                if (studentToDelete == null)
                {
                    throw new StudentNotFoundException(Messages.Error.StudentNotFound);
                }
                students.Remove(studentToDelete);
                return Result<Student>.Success(studentToDelete, Messages.Success.StudentDeleted);
            }
            catch (Exception ex)
            {
                return Result<Student>.Failure(ex.Message);
            }
        }

        public Result<List<Student>> GetAllStudents()
        {
            try
            {
                var students = studentRepository.GetAllStudents();
                if (students.Count == 0)
                {
                    return Result<List<Student>>.Failure(Messages.Error.NoDataFound);
                }
                return Result<List<Student>>.Success(studentRepository.GetAllStudents(), null);
            }
            catch (Exception ex)
            {
                return Result<List<Student>>.Failure(ex.Message);
            }
        }

        public Result<Student> GetStudentByRollNumber(int rollNumber)
        {
            try
            {
                Student? student = FindStudentByRollNumber(rollNumber);
                if (student == null)
                {
                    throw new StudentNotFoundException(Messages.Error.StudentNotFound);
                }
                return Result<Student>.Success(student, null);
            }
            catch (Exception ex)
            {
                return Result<Student>.Failure(ex.Message);
            }
        }

        public void LoadFromFile(string filePath)
        {
            var students = studentRepository.GetAllStudents();
            FileHelper.Load(filePath, students);
        }

        public void SaveToFile(string filePath)
        {
            var students = studentRepository.GetAllStudents();
            FileHelper.Save(filePath, students);
        }

        public Result<List<Student>> SearchStudentsByName(string name)
        {
            try
            {
                var students = studentRepository.GetAllStudents();
                var nameParts = name.Split(" ");
                var result = new List<Student>();
                foreach (var student in students)
                {
                    if ((nameParts.Length == 1 && string.Equals(nameParts[0].Trim(),student.FirstName,StringComparison.OrdinalIgnoreCase) || string.Equals(nameParts[0].Trim(), student.LastName, StringComparison.OrdinalIgnoreCase)))
                    {
                        result.Add(student);
                    }
                    else if(nameParts.Length == 2 && string.Equals(nameParts[0].Trim(), student.FirstName, StringComparison.OrdinalIgnoreCase) && string.Equals(nameParts[1].Trim(), student.LastName, StringComparison.OrdinalIgnoreCase))
                    {
                        result.Add(student);
                    }
                }
                if (result.Count == 0)
                {
                    return Result<List<Student>>.Failure(Messages.Error.NoDataFound);
                }
                return Result<List<Student>>.Success(result, null);
            }
            catch (Exception ex)
            {
                return Result<List<Student>>.Failure(ex.Message);
            }
        }

        public Result<Student> UpdateStudent(Student updatedStudent)
        {
            try
            {
                ValidateStudent(updatedStudent);

                Student? student = FindStudentByRollNumber(updatedStudent.RollNumber);
                if (student == null)
                {
                    throw new StudentNotFoundException(Messages.Error.StudentNotFound);
                }
                student.FirstName = updatedStudent.FirstName;
                student.LastName = updatedStudent.LastName;
                student.Department = updatedStudent.Department;
                student.Email = updatedStudent.Email;
                student.PhoneNumber = updatedStudent.PhoneNumber;
                student.Percentage = updatedStudent.Percentage;
                return Result<Student>.Success(student, Messages.Success.StudentUpdated);
            }
            catch (Exception ex)
            {
                return Result<Student>.Failure(ex.Message);
            }
        }
    }
}
