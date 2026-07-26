using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Common
{
    internal class Result<T> where T : class
    {
        public bool IsSuccess { get; set; }
        public T? Data { get; set; }
        public string? Message { get; set; }
        public Result(bool isSuccess, T? data, string? message) 
        {
            IsSuccess = isSuccess;
            Data = data;
            Message = message;
        }

        public static Result<T> Success(T data, string? message)
        {
            return new Result<T>(true, data, message);
        }
        public static Result<T> Failure(string message)
        {
            return new Result<T>(false, null, message);
        }
    }
}
