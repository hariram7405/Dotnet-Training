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
            if (string.IsNullOrWhiteSpace(request.RoomNumber))
                throw new ArgumentException("RoomNumber required");

            var room = new Room
            {
                RoomNumber = request.RoomNumber,
                Capacity = request.Capacity
            };

            _roomRepo.Add(room);

            return new RoomResponseDTO
            {
                Id = room.Id,
                RoomNumber = room.RoomNumber,
                Capacity = room.Capacity,
                StudentNames = room.Students.Select(s => s.Name).ToList()
            };
        }

        public IEnumerable<RoomResponseDTO> GetAll()
        {
            return _roomRepo.GetAll().Select(r => new RoomResponseDTO
            {
                Id = r.Id,
                RoomNumber = r.RoomNumber,
                Capacity = r.Capacity,
                StudentNames = r.Students.Select(s => s.Name).ToList()
            });
        }

        public RoomResponseDTO? GetById(int id)
        {
            var r = _roomRepo.GetById(id);
            if (r == null) return null;
            return new RoomResponseDTO
            {
                Id = r.Id,
                RoomNumber = r.RoomNumber,
                Capacity = r.Capacity,
                StudentNames = r.Students.Select(s => s.Name).ToList()
            };
        }
    }
}
