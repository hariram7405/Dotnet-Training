using System;

namespace HostelManagement.Core.Exceptions
{
    public class RoomHasStudentsException : Exception
    {
        public RoomHasStudentsException(string message) : base(message) { }
    }
}