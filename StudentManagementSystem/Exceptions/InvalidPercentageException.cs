using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Exceptions
{
    internal class InvalidPercentageException : Exception
    {
        public InvalidPercentageException(string message) : base(message)
        {
        }
    }
}
