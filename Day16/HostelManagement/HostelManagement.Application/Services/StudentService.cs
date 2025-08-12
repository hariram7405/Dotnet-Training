using HostelManagement.Core.DTOs;
using HostelManagement.Core.Entities;
using HostelManagement.Core.Interfaces;

namespace HostelManagement.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IRepository<Student> _studentRepo;
        private readonly IRepository<Staff> _staffRepo;
        private readonly IRepository<Room> _roomRepo;

        public StudentService(IRepository<Student> studentRepo,
                              IRepository<Staff> staffRepo,
                              IRepository<Room> roomRepo)
        {
            _studentRepo = studentRepo;
            _staffRepo = staffRepo;
            _roomRepo = roomRepo;
        }

        public StudentResponseDTO Create(StudentRequestDTO request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
                throw new ArgumentException("Name required");
            if (string.IsNullOrWhiteSpace(request.Department))
                throw new ArgumentException("Department required");

            // pick staff with available capacity (lowest Id first)
            var staff = _staffRepo.GetAll()
                .OrderBy(s => s.Id)
                .FirstOrDefault(s => s.Students.Count < s.Capacity);

            if (staff == null)
                throw new InvalidOperationException("No available staff to assign");

            // pick room with available capacity
            var room = _roomRepo.GetAll()
                .OrderBy(r => r.Id)
                .FirstOrDefault(r => r.Students.Count < r.Capacity);

            if (room == null)
                throw new InvalidOperationException("No available room to assign");

            var student = new Student
            {
                Name = request.Name,
                Department = request.Department,
                StaffId = staff.Id,
                Staff = staff,
                RoomId = room.Id,
                Room = room
            };

            _studentRepo.Add(student);

            // link student to staff and room (in-memory)
            staff.Students.Add(student);
            room.Students.Add(student);

            return new StudentResponseDTO
            {
                Id = student.Id,
                Name = student.Name,
                Department = student.Department,
                StaffId = staff.Id,
                StaffName = staff.Name,
                RoomId = room.Id,
                RoomNumber = room.RoomNumber
            };
        }

        public IEnumerable<StudentResponseDTO> GetAll()
        {
            return _studentRepo.GetAll().Select(s => new StudentResponseDTO
            {
                Id = s.Id,
                Name = s.Name,
                Department = s.Department,
                StaffId = s.StaffId,
                StaffName = s.Staff?.Name ?? string.Empty,
                RoomId = s.RoomId,
                RoomNumber = s.Room?.RoomNumber ?? string.Empty
            });
        }

        public StudentResponseDTO? GetById(int id)
        {
            var s = _studentRepo.GetById(id);
            if (s == null) return null;
            return new StudentResponseDTO
            {
                Id = s.Id,
                Name = s.Name,
                Department = s.Department,
                StaffId = s.StaffId,
                StaffName = s.Staff?.Name ?? string.Empty,
                RoomId = s.RoomId,
                RoomNumber = s.Room?.RoomNumber ?? string.Empty
            };
        }
    }
}
