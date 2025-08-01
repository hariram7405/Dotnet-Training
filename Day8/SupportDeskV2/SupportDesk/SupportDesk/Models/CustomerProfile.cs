using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportDesk.Models
{
    public class CustomerProfile
    {
        public int Id { get; set; }
        public string Address { get; set; } = "";
        public string Phone { get; set; } = "";

        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;
    }
}
