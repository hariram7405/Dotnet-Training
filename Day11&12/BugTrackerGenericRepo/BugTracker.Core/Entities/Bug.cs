using System;

namespace BugTracker.Core.Entities
{
    public class Bug
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }
        public DateTime CreatedDate { get; set; }
        public User CreatedBy { get; set; }
        public Project Project { get; set; }
    }
}
