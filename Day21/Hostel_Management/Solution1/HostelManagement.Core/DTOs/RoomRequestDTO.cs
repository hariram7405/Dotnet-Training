using HostelManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostelManagement.Core.DTOs
{
    public class RoomRequestDTO
    {
      
        public string RoomNumber { get; set; } = string.Empty;
        public int Capacity { get; set; }
       
    }
}
