using HostelManagement.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostelManagement.Core.Interfaces
{
    public interface IUserService
    {
        Task<RegisterResponse> RegisterAsync(RegisterRequest request);
        Task<AuthResponse> LoginAsync(AuthRequest request);
    }
}