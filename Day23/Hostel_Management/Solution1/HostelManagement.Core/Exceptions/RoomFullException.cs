using System;

namespace HostelManagement.Core.Exceptions
{
    public class RoomFullException : Exception
    {
        public RoomFullException(string message) : base(message) { }
    }
}