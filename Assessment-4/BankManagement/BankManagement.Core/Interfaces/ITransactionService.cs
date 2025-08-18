using BankManagement.Core.DTOs;

namespace BankManagement.Core.Interfaces
{
    public interface ITransactionService
    {
        Task<TransactionResponseDTO> TransferMoneyAsync(TransactionRequestDTO request);
        Task<IEnumerable<TransactionResponseDTO>> GetTransactionHistoryAsync(string accountId, int page = 1, int pageSize = 10);
        Task<TransactionResponseDTO?> GetTransactionByIdAsync(string id);
        Task<IEnumerable<TransactionResponseDTO>> GetAllTransactionsAsync();
    }
}
