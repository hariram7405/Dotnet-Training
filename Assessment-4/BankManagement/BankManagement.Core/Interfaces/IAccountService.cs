using BankManagement.Core.DTOs;

namespace BankManagement.Core.Interfaces
{
    public interface IAccountService
    {
        Task<AccountResponseDTO> CreateAccountAsync(AccountRequestDTO request);
        Task<AccountResponseDTO?> GetAccountByIdAsync(string id);
        Task<IEnumerable<AccountResponseDTO>> GetAllAccountsAsync();
        Task<IEnumerable<AccountResponseDTO>> GetAccountsByCustomerIdAsync(string customerId);
        Task<AccountResponseDTO> UpdateAccountAsync(string id, AccountRequestDTO request);
        Task<bool> DeleteAccountAsync(string id);
    }
}
