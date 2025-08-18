using HostelManagement.Core.DTOs;

namespace HostelManagement.Core.Interfaces
{
    public interface IStaffService
    {
        StaffResponseDTO Create(StaffRequestDTO request);
        IEnumerable<StaffResponseDTO> GetAll();
        StaffResponseDTO? GetById(int id);

        void Delete(int id);
        void Update(StaffRequestDTO staffRequest, int id);
    }
}
