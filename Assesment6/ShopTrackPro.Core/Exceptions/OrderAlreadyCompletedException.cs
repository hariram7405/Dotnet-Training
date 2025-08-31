namespace ShopTrackPro.Core.Exceptions;

public class OrderAlreadyCompletedException : BusinessException
{
    public OrderAlreadyCompletedException(string message) : base(message) { }
}