using BankManagement.Core.Entities;

namespace BankManagement.Core.Interfaces
{
    public interface IAccountRepository : IRepository<Account>
    {
        Task<Account?> GetByAccountNumberAsync(string accountNumber);
        Task<IEnumerable<Account>> GetByCustomerIdAsync(string customerId);
    }
}
