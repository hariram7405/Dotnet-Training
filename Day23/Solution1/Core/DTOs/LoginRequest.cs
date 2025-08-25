using System.Text.Json.Serialization;

namespace BugTracker.Core.DTOs
{
    public class LoginRequest
    {
  
        public required string UserName { get; set; }

       
        public required string Password { get; set; }


       public required string Role { get; set; }
    }
}
