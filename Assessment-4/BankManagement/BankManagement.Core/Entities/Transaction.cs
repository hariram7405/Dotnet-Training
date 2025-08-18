namespace BankManagement.Core.Entities
{
    public class Transaction
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string FromAccountId { get; set; } = string.Empty;
        public string ToAccountId { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string TransactionType { get; set; } = string.Empty; // Transfer, Deposit, Withdrawal
        public DateTime TransactionDate { get; set; } = DateTime.UtcNow;
        public string Description { get; set; } = string.Empty;
        public string Status { get; set; } = "Completed";
    }
}
