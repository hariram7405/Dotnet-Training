using BankManagement.Core.Entities;
using BankManagement.Core.Interfaces;

namespace BankManagement.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly List<Account> _accounts = new();
      

        public async Task<IEnumerable<Account>> GetAllAsync()
        {
            return await Task.FromResult(_accounts.AsEnumerable());
        }

        public async Task<Account?> GetByIdAsync(string id)
        {
            return await Task.FromResult(_accounts.FirstOrDefault(a => a.Id == id));
        }

        public async Task<Account?> GetByAccountNumberAsync(string accountNumber)
        {
            return await Task.FromResult(_accounts.FirstOrDefault(a => a.AccountNumber == accountNumber));
        }

        public async Task<IEnumerable<Account>> GetByCustomerIdAsync(string customerId)
        {
            return await Task.FromResult(_accounts.Where(a => a.CustomerId == customerId));
        }

        public async Task<Account> AddAsync(Account entity)
        {
            entity.AccountNumber = GenerateAccountNumber();
            _accounts.Add(entity);
            return await Task.FromResult(entity);
        }

        public async Task<Account> UpdateAsync(Account entity)
        {
            var existing = _accounts.FirstOrDefault(a => a.Id == entity.Id);
            if (existing != null)
            {
                existing.Balance = entity.Balance;
                existing.AccountType = entity.AccountType;
                existing.IsActive = entity.IsActive;
            }
            return await Task.FromResult(entity);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var account = _accounts.FirstOrDefault(a => a.Id == id);
            if (account != null)
            {
                account.IsActive = false;
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }

        private string GenerateAccountNumber()
        {
            return $"ACC{DateTime.Now.Ticks}";
        }
    }
}
