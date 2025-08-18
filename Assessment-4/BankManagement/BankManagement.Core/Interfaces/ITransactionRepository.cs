using BankManagement.Core.Entities;

namespace BankManagement.Core.Interfaces
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
        Task<IEnumerable<Transaction>> GetByAccountIdAsync(string accountId, int page = 1, int pageSize = 10);
    }
}
