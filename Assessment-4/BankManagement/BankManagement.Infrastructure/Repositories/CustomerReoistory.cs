using BankManagement.Core.Entities;
using BankManagement.Core.Interfaces;

namespace BankManagement.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly List<Customer> _customers = new();

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await Task.FromResult(_customers.AsEnumerable());
        }

        public async Task<Customer?> GetByIdAsync(string id)
        {
            return await Task.FromResult(_customers.FirstOrDefault(c => c.Id == id));
        }

        public async Task<Customer?> GetByEmailAsync(string email)
        {
            return await Task.FromResult(_customers.FirstOrDefault(c => c.Email == email));
        }

        public async Task<Customer> AddAsync(Customer entity)
        {
            _customers.Add(entity);
            return await Task.FromResult(entity);
        }

        public async Task<Customer> UpdateAsync(Customer entity)
        {
            var existing = _customers.FirstOrDefault(c => c.Id == entity.Id);
            if (existing != null)
            {
                existing.Name = entity.Name;
                existing.Email = entity.Email;
                existing.Phone = entity.Phone;
            }
            return await Task.FromResult(entity);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var customer = _customers.FirstOrDefault(c => c.Id == id);
            if (customer != null)
            {
                _customers.Remove(customer);
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }
    }
}
