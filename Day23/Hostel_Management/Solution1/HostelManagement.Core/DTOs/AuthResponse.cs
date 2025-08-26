using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostelManagement.Core.DTOs
{
public class AuthResponse
    {
        public  required string Token {  get; set; }
        public DateTime Expiration { get; set; }

    }
}
