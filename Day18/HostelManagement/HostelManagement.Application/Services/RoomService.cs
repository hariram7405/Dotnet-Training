using HostelManagement.Core.DTOs;
using HostelManagement.Core.Entities;
using HostelManagement.Core.Interfaces;

namespace HostelManagement.Application.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRepository<Room> _roomRepo;

        public RoomService(IRepository<Room> roomRepo)
        {
            _roomRepo = roomRepo;
        }

        public RoomResponseDTO Create(RoomRequestDTO request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (string.IsNullOrWhiteSpace(request.RoomNumber))
                throw new ArgumentException("RoomNumber required");

            var room = new Room
            {
                RoomNumber = request.RoomNumber,
                Capacity = request.Capacity
            };

            _roomRepo.Add(room);
            return MapToResponseDTO(room);
        }

        public IEnumerable<RoomResponseDTO> GetAll()
        {
            return _roomRepo.GetAll().Select(MapToResponseDTO);
        }

        public RoomResponseDTO? GetById(int id)
        {
            var room = _roomRepo.GetById(id);
            return room == null ? null : MapToResponseDTO(room);
        }

        public void Delete(int id)
        {
            var room = _roomRepo.GetById(id);
            if (room == null)
                throw new ArgumentException("Room Id is Invalid");

            if (room.Students.Count > 0)
                throw new InvalidOperationException("Room is allocated to student.Room cannot be deleted");

            _roomRepo.Delete(id);
        }

        public void Update(RoomRequestDTO request, int id)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var existingRoom = _roomRepo.GetById(id);
            if (existingRoom == null)
                throw new ArgumentException("Room Id is invalid");

            existingRoom.RoomNumber = request.RoomNumber;
            existingRoom.Capacity = request.Capacity;
            
            _roomRepo.Update(existingRoom);  // ✅ Save changes to database
        }

        private RoomResponseDTO MapToResponseDTO(Room room)
        {
            return new RoomResponseDTO
            {
                Id = room.Id,
                RoomNumber = room.RoomNumber,
                Capacity = room.Capacity,
                StudentNames = room.Students.Select(s => s.Name).ToList()
            };
        }
    }
}