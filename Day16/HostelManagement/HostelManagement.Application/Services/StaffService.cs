using HostelManagement.Core.DTOs;
using HostelManagement.Core.Entities;
using HostelManagement.Core.Interfaces;

namespace HostelManagement.Application.Services
{
    public class StaffService : IStaffService
    {
        private readonly IRepository<Staff> _staffRepo;

        public StaffService(IRepository<Staff> staffRepo)
        {
            _staffRepo = staffRepo;
        }

        public StaffResponseDTO Create(StaffRequestDTO request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
                throw new ArgumentException("Name required");

            var staff = new Staff
            {
                Name = request.Name,
                Role = request.Role,
              
            };

            _staffRepo.Add(staff);

            return new StaffResponseDTO
            {
                Id = staff.Id,
                Name = staff.Name,
                Role = staff.Role,
                Capacity = staff.Capacity,
                StudentNames = staff.Students.Select(s => s.Name).ToList()
            };
        }

        public IEnumerable<StaffResponseDTO> GetAll()
        {
            return _staffRepo.GetAll().Select(s => new StaffResponseDTO
            {
                Id = s.Id,
                Name = s.Name,
                Role = s.Role,
                Capacity = s.Capacity,
                StudentNames = s.Students.Select(st => st.Name).ToList()
            });
        }

        public StaffResponseDTO? GetById(int id)
        {
            var s = _staffRepo.GetById(id);
            if (s == null) return null;

            return new StaffResponseDTO
            {
                Id = s.Id,
                Name = s.Name,
                Role = s.Role,
                Capacity = s.Capacity,
                StudentNames = s.Students.Select(st => st.Name).ToList()
            };
        }
    }
}
