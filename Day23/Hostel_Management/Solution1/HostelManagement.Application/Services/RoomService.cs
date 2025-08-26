using HostelManagement.Core.DTOs;
using HostelManagement.Core.Entities;
using HostelManagement.Core.Interfaces;
using HostelManagement.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostelManagement.Application.Services
{
    public class RoomService:IRoomService
    {
        private readonly IRepository<Room> _roomrepo;

        public RoomService(IRepository<Room> roomrepo)
        {
            _roomrepo = roomrepo;
        }

        public async Task<RoomResponseDTO> AddRoom(RoomRequestDTO request)
        {
            if (request == null)
            {
                throw new ValidationException("Request cannot be null");
            }

            if (string.IsNullOrWhiteSpace(request.RoomNumber))
            {
                throw new ValidationException("Room Number is Required");
            }

            var room1 = new Room
            {
                RoomNumber = request.RoomNumber,
                Capacity = request.Capacity
            };

            await _roomrepo.AddAsync(room1);

            return MapToResponse(room1);
        }

        public async Task<RoomResponseDTO> GetRoomById(int id)
        {
            var room = await _roomrepo.GetByIdAsync(id);

            if (room == null)
            {
                throw new NotFoundException("Room not found");
            }

            return MapToResponse(room);
        }

        public async Task<RoomResponseDTO> UpdateRoom(RoomRequestDTO room, int id)
        {
            var existingRoom = await _roomrepo.GetByIdAsync(id);

            if (existingRoom == null)
            {
                throw new NotFoundException("Room not found");
            }

            existingRoom.RoomNumber = room.RoomNumber;
            existingRoom.Capacity = room.Capacity;

            await _roomrepo.UpdateAsync(existingRoom);

            return MapToResponse(existingRoom);
        }

        public async Task DeleteRoom(int id)
        {
            var room = await _roomrepo.GetByIdAsync(id);

            if (room == null)
            {
                throw new NotFoundException("Room not found");
            }
            if (room.Students.Count > 0)
                throw new RoomHasStudentsException("Room is allocated to student.Room cannot be deleted");

            await _roomrepo.DeleteAsync(room);
        }
        
         public async Task<IEnumerable<RoomResponseDTO>> GetAllRoom(){
            var rooms = await _roomrepo.GetAllAsync();
            return rooms.Select(MapToResponse);

        }
   


        private RoomResponseDTO MapToResponse(Room room1)
        {
            return new RoomResponseDTO
            {
                RoomId = room1.RoomId,
                RoomNumber = room1.RoomNumber,
                Capacity = room1.Capacity,
                Students = room1.Students?.Select(s => s.Name).ToList() ?? new List<string>()
            };
        }
    }
}
