using System;

namespace HostelManagement.Core.Exceptions
{
    public class StaffHasStudentsException : Exception
    {
        public StaffHasStudentsException(string message) : base(message) { }
    }
}