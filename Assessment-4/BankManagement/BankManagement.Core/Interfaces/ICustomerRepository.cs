using BankManagement.Core.Entities;

namespace BankManagement.Core.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<Customer?> GetByEmailAsync(string email);
    }
}
