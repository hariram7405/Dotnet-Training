using HostelManagement.Core.Entities;
using HostelManagement.Core.Interfaces;

namespace HostelManagement.Infrastructure.Repositories
{
    public class RoomRepository : IRepository<Room>
    {
        private readonly List<Room> _rooms = new List<Room>();
        private int _nextId = 2000;

        public void Add(Room entity)
        {
            _nextId++;
            entity.Id = _nextId;
            _rooms.Add(entity);
        }

        public Room? GetById(int id) => _rooms.FirstOrDefault(r => r.Id == id);

        public IEnumerable<Room> GetAll() => _rooms;
        public void Delete(int id)
        {
            var room = GetById(id);
            if (room != null)
            {
                _rooms.Remove(room);
            }
        }
        
    }
}
