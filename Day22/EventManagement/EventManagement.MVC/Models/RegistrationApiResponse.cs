namespace EventManagement.MVC.Models
{
    public class RegistrationApiResponse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public int EventId { get; set; }
        public string? EventTitle { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}