using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SupportDesk.Core.Entities;
using SupportDesk.Core.Interfaces;
using SupportDesk.Infrastructure.Data;



namespace SupportDesk.Application.Services
{
    public class TicketService : ITicketService
    {
        private readonly AppDBContext _context;

        public TicketService(AppDBContext context)
        {
            _context = context;
        }

        public List<Ticket> GetAllTickets()
        {
            return _context.Tickets.ToList();
        }

        public List<Ticket> GetAllTicketsWithUsers()
        {
            return _context.Tickets
                .Include(t => t.User)
                .Where(t => t.User != null)
                .ToList();
        }

        public List<Ticket> GetAllTicketsWithTags()
        {
            return _context.Tickets
                .Include(t => t.TicketTags)
                    .ThenInclude(tt => tt.Tag)
                .ToList();
        }

        public List<Ticket> GetUsersWithTickets()
        {
            return _context.Tickets
                .Include(t => t.User)
                .Where(t => t.User != null)
                .ToList();
        }

        public List<(string TagName, int TicketCount)> GetTagTicketCounts()
        {
            return _context.Tags
                .Select(t => new
                {
                    t.TagName,
                    TicketCount = t.TicketTags.Count
                })
                .ToList()
                .Select(t => (t.TagName, t.TicketCount))
                .ToList();
        }

        public List<(string UserName, int TicketCount)> GetTagTicketCountByUser()
        {
            return _context.Users
                .Select(u => new
                {
                    u.Name,
                    TicketCount = u.Tickets.Count
                })
                .ToList()
                .Select(u => (u.Name, u.TicketCount))
                .ToList();
        }

        public List<Ticket> GetTicketsByUserId(int userId)
        {
            return _context.Tickets
                .Where(t => t.UserId == userId)
                .ToList();
        }

        public List<Ticket> GetTicketsByTagId(int tagId)
        {
            return _context.Tickets
                .Where(t => t.TicketTags.Any(tt => tt.TagId == tagId))
                .Include(t => t.TicketTags)
                    .ThenInclude(tt => tt.Tag)
                .ToList();
        }

        

public List<dynamic> GetTicketsWithUserandTagNames()
    {
        var result = new List<dynamic>();

        var tickets = _context.Tickets
            .Include(t => t.User)
            .Include(t => t.TicketTags)
                .ThenInclude(tt => tt.Tag)
            .ToList();

        foreach (var t in tickets)
        {
            dynamic obj = new ExpandoObject();
            obj.TicketId = t.TicketId;
            obj.Title = t.TicketTitle;
            obj.UserName = t.User != null ? t.User.Name : "No User";
            obj.Tags = t.TicketTags.Select(tt => tt.Tag.TagName).ToList();

            result.Add(obj);
        }

        return result;
    }




}

}
