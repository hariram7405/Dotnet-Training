﻿namespace BugTrcaker.MVC.Models
{
    public class BugViewModel
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ProjectId { get; set; }
    }
}
