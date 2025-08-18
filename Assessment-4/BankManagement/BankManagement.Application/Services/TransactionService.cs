using AutoMapper;
using BankManagement.Core.DTOs;
using BankManagement.Core.Entities;
using BankManagement.Core.Interfaces;

namespace BankManagement.Application.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public TransactionService(ITransactionRepository transactionRepository, IAccountRepository accountRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public async Task<TransactionResponseDTO> TransferMoneyAsync(TransactionRequestDTO request)
        {
            // Get sender and receiver accounts
            var senderAccount = await _accountRepository.GetByAccountNumberAsync(request.FromAccountNumber);
            var receiverAccount = await _accountRepository.GetByAccountNumberAsync(request.ToAccountNumber);

            // Validate accounts exist
            if (senderAccount == null)
                throw new ArgumentException("Sender account not found");
            if (receiverAccount == null)
                throw new ArgumentException("Receiver account not found");

            // Validate accounts are active
            if (!senderAccount.IsActive)
                throw new InvalidOperationException("Sender account is inactive");
            if (!receiverAccount.IsActive)
                throw new InvalidOperationException("Receiver account is inactive");

            // Validate sufficient balance
            if (senderAccount.Balance < request.Amount)
                throw new InvalidOperationException("Insufficient funds");

            // Validate amount is positive
            if (request.Amount <= 0)
                throw new ArgumentException("Amount must be positive");

            // Perform transfer
            senderAccount.Balance -= request.Amount;
            receiverAccount.Balance += request.Amount;

            // Update accounts
            await _accountRepository.UpdateAsync(senderAccount);
            await _accountRepository.UpdateAsync(receiverAccount);

            // Create transaction record
            var transaction = new Transaction
            {
                FromAccountId = senderAccount.Id,
                ToAccountId = receiverAccount.Id,
                Amount = request.Amount,
                TransactionType = "Transfer",
                Description = request.Description,
                Status = "Completed"
            };

            var createdTransaction = await _transactionRepository.AddAsync(transaction);
            return _mapper.Map<TransactionResponseDTO>(createdTransaction);
        }

        public async Task<IEnumerable<TransactionResponseDTO>> GetTransactionHistoryAsync(string accountId, int page = 1, int pageSize = 10)
        {
            var transactions = await _transactionRepository.GetByAccountIdAsync(accountId, page, pageSize);
            return _mapper.Map<IEnumerable<TransactionResponseDTO>>(transactions);
        }

        public async Task<TransactionResponseDTO?> GetTransactionByIdAsync(string id)
        {
            var transaction = await _transactionRepository.GetByIdAsync(id);
            return transaction != null ? _mapper.Map<TransactionResponseDTO>(transaction) : null;
        }

        public async Task<IEnumerable<TransactionResponseDTO>> GetAllTransactionsAsync()
        {
            var transactions = await _transactionRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<TransactionResponseDTO>>(transactions);
        }
    }
}
