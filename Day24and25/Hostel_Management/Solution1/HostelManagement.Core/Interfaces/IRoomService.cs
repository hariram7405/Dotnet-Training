using HostelManagement.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HostelManagement.Core.Interfaces
{
    public interface IRoomService
    {
        Task<RoomResponseDTO> AddRoom(RoomRequestDTO request);
        Task<RoomResponseDTO> GetRoomById(int id);
        Task<RoomResponseDTO> UpdateRoom(RoomRequestDTO request, int id);
        Task DeleteRoom(int id);
        Task<IEnumerable<RoomResponseDTO>> GetAllRooms();
    }
}
