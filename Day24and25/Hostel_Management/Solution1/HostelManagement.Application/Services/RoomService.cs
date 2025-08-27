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

            if (request.Capacity <= 0)
            {
                throw new ValidationException("Room Capacity must be greater than 0");
            }

            var newRoom = new Room
            {
                RoomNumber = request.RoomNumber,
                Capacity = request.Capacity
            };

            await _roomrepo.AddAsync(newRoom);

            return MapToResponse(newRoom);
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
            if (room == null)
                throw new ValidationException("Request cannot be null");

            if (string.IsNullOrWhiteSpace(room.RoomNumber))
                throw new ValidationException("Room Number is Required");

            if (room.Capacity <= 0)
                throw new ValidationException("Room Capacity must be greater than 0");

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
            if (room.Students?.Count > 0)
                throw new RoomHasStudentsException("Room is allocated to student.Room cannot be deleted");

            await _roomrepo.DeleteAsync(room);
        }
        
        public async Task<IEnumerable<RoomResponseDTO>> GetAllRooms(){
            var rooms = await _roomrepo.GetAllAsync();
            return rooms.Select(MapToResponse);

        }
   


        private RoomResponseDTO MapToResponse(Room room)
        {
            return new RoomResponseDTO
            {
                RoomId = room.RoomId,
                RoomNumber = room.RoomNumber,
                Capacity = room.Capacity,
                Students = room.Students?.Select(s => s.Name).ToList() ?? new List<string>()
            };
        }
    }
}
