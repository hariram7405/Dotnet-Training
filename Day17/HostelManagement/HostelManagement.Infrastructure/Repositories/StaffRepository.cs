using HostelManagement.Core.Entities;
using HostelManagement.Core.Interfaces;

namespace HostelManagement.Infrastructure.Repositories
{
    public class StaffRepository : IRepository<Staff>
    {
        private readonly List<Staff> _staffs = new List<Staff>();
        private int _nextId = 5000;

        public void Add(Staff entity)
        {
            _nextId++;
            entity.Id = _nextId;
            _staffs.Add(entity);
        }

        public Staff? GetById(int id) => _staffs.FirstOrDefault(s => s.Id == id);

        public IEnumerable<Staff> GetAll() => _staffs;
        public void Delete(int id)
        {
            var staff = GetById(id);
            if (staff != null)
            {
                _staffs.Remove(staff);
            }
        }

    }
}
