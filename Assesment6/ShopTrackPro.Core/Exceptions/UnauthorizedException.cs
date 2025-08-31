namespace ShopTrackPro.Core.Exceptions;

public class UnauthorizedException : BusinessException
{
    public UnauthorizedException(string message) : base(message) { }
}