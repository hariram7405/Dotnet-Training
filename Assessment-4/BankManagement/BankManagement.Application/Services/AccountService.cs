using AutoMapper;
using BankManagement.Core.DTOs;
using BankManagement.Core.Entities;
using BankManagement.Core.Interfaces;

namespace BankManagement.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public AccountService(IAccountRepository accountRepository, ICustomerRepository customerRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<AccountResponseDTO> CreateAccountAsync(AccountRequestDTO request)
        {
            var customer = await _customerRepository.GetByIdAsync(request.CustomerId);
            if (customer == null)
                throw new ArgumentException("Customer not found");
         var account = _mapper.Map<Account>(request);
            var createdAccount = await _accountRepository.AddAsync(account);
            return _mapper.Map<AccountResponseDTO>(createdAccount);
        }

        public async Task<AccountResponseDTO?> GetAccountByIdAsync(string id)
        {
            var account = await _accountRepository.GetByIdAsync(id);
            return account != null ? _mapper.Map<AccountResponseDTO>(account) : null;
        }
      
        public async Task<IEnumerable<AccountResponseDTO>> GetAllAccountsAsync()
        {
            var accounts = await _accountRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<AccountResponseDTO>>(accounts);
        }

        public async Task<IEnumerable<AccountResponseDTO>> GetAccountsByCustomerIdAsync(string customerId)
        {
            var accounts = await _accountRepository.GetByCustomerIdAsync(customerId);
            return _mapper.Map<IEnumerable<AccountResponseDTO>>(accounts);
        }

        public async Task<AccountResponseDTO> UpdateAccountAsync(string id, AccountRequestDTO request)
        {
            var existingAccount = await _accountRepository.GetByIdAsync(id);
            if (existingAccount == null)
                throw new ArgumentException("Account not found");

            existingAccount.AccountType = request.AccountType;
            var updatedAccount = await _accountRepository.UpdateAsync(existingAccount);
            return _mapper.Map<AccountResponseDTO>(updatedAccount);
        }

        public async Task<bool> DeleteAccountAsync(string id)
        {
            return await _accountRepository.DeleteAsync(id);
        }
    }
}
