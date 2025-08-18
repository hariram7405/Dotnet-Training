namespace BankManagement.Core.DTOs
{
    public class AccountRequestDTO
    {
        public string CustomerId { get; set; } = string.Empty;
        public decimal InitialBalance { get; set; }
        public string AccountType { get; set; } = "Savings";
    }
}
