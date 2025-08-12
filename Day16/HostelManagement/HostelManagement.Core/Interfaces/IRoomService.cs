using HostelManagement.Core.DTOs;

namespace HostelManagement.Core.Interfaces
{
    public interface IRoomService
    {
        RoomResponseDTO Create(RoomRequestDTO request);
        IEnumerable<RoomResponseDTO> GetAll();
        RoomResponseDTO? GetById(int id);
    }
}
