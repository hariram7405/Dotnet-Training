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
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (string.IsNullOrWhiteSpace(request.Name))
                throw new ArgumentException("Name required");
            if (string.IsNullOrWhiteSpace(request.Role))
                throw new ArgumentException("Role required");

            var staff = new Staff
            {
                Name = request.Name,
                Role = request.Role,
               
            };

            _staffRepo.Add(staff);
            return MapToResponseDTO(staff);
        }

        public IEnumerable<StaffResponseDTO> GetAll()
        {
            return _staffRepo.GetAll().Select(MapToResponseDTO);
        }

        public StaffResponseDTO? GetById(int id)
        {
            var staff = _staffRepo.GetById(id);
            return staff == null ? null : MapToResponseDTO(staff);
        }

        public void Delete(int id)
        {
            var staff = _staffRepo.GetById(id);
            if (staff == null)
                throw new ArgumentException("Invalid Id");

            if (staff.Students.Count > 0)
                throw new InvalidOperationException("Staff is assigned to students cannot be deleted");

            _staffRepo.Delete(id);
        }

        public void Update(StaffRequestDTO request, int id)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var existingStaff = _staffRepo.GetById(id);
            if (existingStaff == null)
                throw new ArgumentException("Invalid Id");

            existingStaff.Name = request.Name;
            existingStaff.Role = request.Role;
        }

        private StaffResponseDTO MapToResponseDTO(Staff staff)
        {
            return new StaffResponseDTO
            {
                Id = staff.Id,
                Name = staff.Name,
                Role = staff.Role,
                Capacity = staff.Capacity,
                StudentNames = staff.Students.Select(s => s.Name).ToList()
            };
        }
    }
}