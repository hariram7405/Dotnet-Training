using HostelManagement.Core.DTOs;

namespace HostelManagement.Core.Interfaces
{
    public interface IRoomService
    {
        RoomResponseDTO Create(RoomRequestDTO request);
        IEnumerable<RoomResponseDTO> GetAll();
        RoomResponseDTO? GetById(int id);
        void Delete(int id);
         void Update(RoomRequestDTO roomRequest, int id);
    }
}
