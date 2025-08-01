namespace Assessment.Services
{
    public interface ITicketService
    {
        void CreateUser();
        void CreateTicket();
        void AddTags();
        void ChangeStatus();
        void ViewTickets();
        void DeleteTicket();
    }
}
