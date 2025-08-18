namespace BankManagement.Core.DTOs
{
    public class AccountResponseDTO
    {
        public string Id { get; set; } = string.Empty;
        public string AccountNumber { get; set; } = string.Empty;
        public string CustomerId { get; set; } = string.Empty;
        public decimal Balance { get; set; }
        public string AccountType { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
        
    }
}
