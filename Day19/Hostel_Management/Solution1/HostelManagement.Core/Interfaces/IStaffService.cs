using HostelManagement.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostelManagement.Core.Interfaces
{
    public interface IStaffService
    {
        Task<StaffResponseDTO> AddStaff(StaffRequestDTO request);
        Task<StaffResponseDTO> GetStaffById(int id);
        Task<StaffResponseDTO> UpdateStaff(StaffRequestDTO request, int id);
        Task DeleteStaff(int id);
        Task<IEnumerable<StaffResponseDTO>> GetAllStaff();
    }
}
