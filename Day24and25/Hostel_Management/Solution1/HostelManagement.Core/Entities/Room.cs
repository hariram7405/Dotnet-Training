using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostelManagement.Core.Entities
{
    public  class Room
    {
        public int RoomId { get; set; }
        public string RoomNumber { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public virtual ICollection<Student> Students { get; set; } = new List<Student>();
        
    }
}
