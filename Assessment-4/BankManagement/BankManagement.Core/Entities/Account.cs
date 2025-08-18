namespace BankManagement.Core.Entities
{
    public class Account
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();//A unique Identifier
        
        public string AccountNumber { get; set; } = string.Empty;
        public string CustomerId { get; set; } = string.Empty;
        public decimal Balance { get; set; }
        public string AccountType { get; set; } = "Savings";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;
    }
}
