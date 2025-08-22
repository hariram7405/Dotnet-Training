namespace EventManagement.MVC.Models
{
    public class RegistartionViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public int EventId { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
