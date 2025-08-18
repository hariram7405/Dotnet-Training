using AutoMapper;
using BankManagement.Application.Mapping;
using BankManagement.Application.Services;
using BankManagement.Core.DTOs;
using BankManagement.Core.Entities;
using BankManagement.Core.Interfaces;
using Moq;
using Xunit;

namespace BankManagement.Tests.Services
{
    public class TransactionServiceTests
    {
        private readonly Mock<ITransactionRepository> _mockTransactionRepo;
        private readonly Mock<IAccountRepository> _mockAccountRepo;
        private readonly IMapper _mapper;
        private readonly TransactionService _transactionService;

        public TransactionServiceTests()
        {
            _mockTransactionRepo = new Mock<ITransactionRepository>();
            _mockAccountRepo = new Mock<IAccountRepository>();
            
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            _mapper = config.CreateMapper();
            
            _transactionService = new TransactionService(_mockTransactionRepo.Object, _mockAccountRepo.Object, _mapper);
        }

        [Fact]
        public async Task TransferMoney_ValidTransfer_ShouldSucceed()
        {
            // Arrange
            var senderAccount = new Account
            {
                Id = "1",
                AccountNumber = "ACC001",
                Balance = 1000,
                IsActive = true
            };
            
            var receiverAccount = new Account
            {
                Id = "2",
                AccountNumber = "ACC002",
                Balance = 500,
                IsActive = true
            };

            var request = new TransactionRequestDTO
            {
                FromAccountNumber = "ACC001",
                ToAccountNumber = "ACC002",
                Amount = 200,
                Description = "Test transfer"
            };

            _mockAccountRepo.Setup(x => x.GetByAccountNumberAsync("ACC001"))
                .ReturnsAsync(senderAccount);
            _mockAccountRepo.Setup(x => x.GetByAccountNumberAsync("ACC002"))
                .ReturnsAsync(receiverAccount);
            _mockTransactionRepo.Setup(x => x.AddAsync(It.IsAny<Transaction>()))
                .ReturnsAsync((Transaction t) => t);

            // Act
            var result = await _transactionService.TransferMoneyAsync(request);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.Amount);
            Assert.Equal("Transfer", result.TransactionType);
            Assert.Equal(800, senderAccount.Balance);
            Assert.Equal(700, receiverAccount.Balance);
        }

        [Fact]
        public async Task TransferMoney_InsufficientFunds_ShouldThrowException()
        {
            // Arrange
            var senderAccount = new Account
            {
                Id = "1",
                AccountNumber = "ACC001",
                Balance = 100,
                IsActive = true
            };
            
            var receiverAccount = new Account
            {
                Id = "2",
                AccountNumber = "ACC002",
                Balance = 500,
                IsActive = true
            };

            var request = new TransactionRequestDTO
            {
                FromAccountNumber = "ACC001",
                ToAccountNumber = "ACC002",
                Amount = 200,
                Description = "Test transfer"
            };

            _mockAccountRepo.Setup(x => x.GetByAccountNumberAsync("ACC001"))
                .ReturnsAsync(senderAccount);
            _mockAccountRepo.Setup(x => x.GetByAccountNumberAsync("ACC002"))
                .ReturnsAsync(receiverAccount);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(
                () => _transactionService.TransferMoneyAsync(request));
        }

        [Fact]
        public async Task GetTransactionHistory_ValidAccountId_ShouldReturnTransactions()
        {
            // Arrange
            var transactions = new List<Transaction>
            {
                new Transaction { Id = "1", FromAccountId = "ACC001", Amount = 100 },
                new Transaction { Id = "2", ToAccountId = "ACC001", Amount = 50 }
            };

            _mockTransactionRepo.Setup(x => x.GetByAccountIdAsync("ACC001", 1, 10))
                .ReturnsAsync(transactions);

            // Act
            var result = await _transactionService.GetTransactionHistoryAsync("ACC001");

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }
    }
}