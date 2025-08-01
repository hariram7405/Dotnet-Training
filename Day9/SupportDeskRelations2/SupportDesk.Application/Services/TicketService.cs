using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SupportDesk.Core.Entities;
using SupportDesk.Core.Interfaces;
using SupportDesk.Infrastructure.Data;



namespace SupportDesk.Application.Services
{
    public  class TicketService:ITicketService
    {
        private readonly AppDBContext _context;
        public TicketService(AppDBContext context)
        {
            _context = context;
        }
        List<Ticket> GetAllTickets()
        {
            return _context.Tickets.ToList();
        }
        List<Ticket> GetAllTicketsWithUsers()
        {
            return _context.Tickets
                .Include(t=>t.User)
                .Where(t=>t.User != null)
                .ToList();
        }
        List<Ticket> GetAllTicketsWithTags() {
           
        }
        List<Ticket> GetUsersWithTickets() { 
        }
        List<(string TagName, int TicketCount)> GetTagTicketCounts() {
            return _context.Tags
                .Select(t => new
                {
                    t.Name,
                    TicketCount=t.TicketTags.Count
                }).ToList()
                .Select(t=>(t.Name,t.TicketCount))
                .ToList();
        }
        List<(string UserName, int TicketCount)> GetTagTicketCountByUser() { 

        }
        List<Ticket> GetTicketsByUserId(int userId) { }
        List<Ticket> GetTicketsByTagId(int tagId) { }
        List<object> GetTicketsWithUserandTagNames() { }
    }
}
