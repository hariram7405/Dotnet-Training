using BankManagement.Core.Entities;
using BankManagement.Core.Interfaces;

namespace BankManagement.Infrastructure.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly List<Transaction> _transactions = new();

        public async Task<IEnumerable<Transaction>> GetAllAsync()
        {
            return await Task.FromResult(_transactions.AsEnumerable());
        }

        public async Task<Transaction?> GetByIdAsync(string id)
        {
            return await Task.FromResult(_transactions.FirstOrDefault(t => t.Id == id));
        }

        public async Task<IEnumerable<Transaction>> GetByAccountIdAsync(string accountId, int page = 1, int pageSize = 10)
        {
            var transactions = _transactions
                .Where(t => t.FromAccountId == accountId || t.ToAccountId == accountId)
                .OrderByDescending(t => t.TransactionDate)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);
            
            return await Task.FromResult(transactions);
        }

        public async Task<Transaction> AddAsync(Transaction entity)
        {
            _transactions.Add(entity);
            return await Task.FromResult(entity);
        }

        public async Task<Transaction> UpdateAsync(Transaction entity)
        {
            var existing = _transactions.FirstOrDefault(t => t.Id == entity.Id);
            if (existing != null)
            {
                existing.Status = entity.Status;
                existing.Description = entity.Description;
            }
            return await Task.FromResult(entity);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var transaction = _transactions.FirstOrDefault(t => t.Id == id);
            if (transaction != null)
            {
                _transactions.Remove(transaction);
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }
    }
}
