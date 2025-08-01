using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupportDesk.Core.Entities;

namespace SupportDesk.Core.Interfaces
{
   public  interface ITicketService
    {
        List<Ticket> GetAllTickets();
        List<Ticket> GetAllTicketsWithUsers();
        List<Ticket> GetAllTicketsWithTags();
        List<Ticket> GetUsersWithTickets();
        List<(string TagName, int TicketCount)> GetTagTicketCounts();
        List<(string UserName, int TicketCount)> GetTagTicketCountByUser();
        List<Ticket> GetTicketsByUserId(int userId);
        List<Ticket> GetTicketsByTagId(int tagId);
        List<object> GetTicketsWithUserandTagNames();




    }

}
