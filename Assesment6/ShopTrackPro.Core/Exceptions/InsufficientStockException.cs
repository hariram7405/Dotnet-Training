namespace ShopTrackPro.Core.Exceptions;

public class InsufficientStockException : BusinessException
{
    public InsufficientStockException(string message) : base(message) { }
}