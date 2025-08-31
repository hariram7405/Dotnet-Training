namespace ShopTrackPro.Core.Exceptions;

public class DuplicateEmailException : BusinessException
{
    public DuplicateEmailException(string message) : base(message) { }
}