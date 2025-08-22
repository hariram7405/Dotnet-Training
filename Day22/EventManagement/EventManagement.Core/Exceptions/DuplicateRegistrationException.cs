namespace EventManagement.Core.Exceptions
{
    public class DuplicateRegistrationException : Exception
    {
        public DuplicateRegistrationException(string message) : base(message) { }
        public DuplicateRegistrationException(string message, Exception innerException) : base(message, innerException) { }
    }
}
