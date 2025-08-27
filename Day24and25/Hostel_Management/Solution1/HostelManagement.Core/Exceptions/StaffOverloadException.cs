using System;

namespace HostelManagement.Core.Exceptions
{
    public class StaffOverloadException : Exception
    {
        public StaffOverloadException(string message) : base(message) { }
    }
}