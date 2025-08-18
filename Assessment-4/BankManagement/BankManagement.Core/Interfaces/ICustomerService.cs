using BankManagement.Core.DTOs;

namespace BankManagement.Core.Interfaces
{
    public interface ICustomerService
    {
        Task<CustomerResponseDTO> CreateCustomerAsync(CustomerRequestDTO request);
        Task<CustomerResponseDTO?> GetCustomerByIdAsync(string id);
        Task<IEnumerable<CustomerResponseDTO>> GetAllCustomersAsync();
        Task<CustomerResponseDTO> UpdateCustomerAsync(string id, CustomerRequestDTO request);
        Task<bool> DeleteCustomerAsync(string id);
    }
}
