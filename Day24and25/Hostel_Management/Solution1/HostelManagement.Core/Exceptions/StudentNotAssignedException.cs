using System;

namespace HostelManagement.Core.Exceptions
{
    public class StudentNotAssignedException : Exception
    {
        public StudentNotAssignedException(string message) : base(message) { }
    }
}