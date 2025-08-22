using System;

namespace HostelManagement.Core.Exceptions
{
    public class DeleteOperationException : Exception
    {
        public DeleteOperationException(string message) : base(message) { }
    }
}