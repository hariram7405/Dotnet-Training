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
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (string.IsNullOrWhiteSpace(request.Name))
                throw new ArgumentException("Name required");
            if (string.IsNullOrWhiteSpace(request.Department))
                throw new ArgumentException("Department required");

            var staff = _staffRepo.GetAll()
                .OrderBy(s => s.Id)
                .FirstOrDefault(s => s.Students.Count < s.Capacity);

            if (staff == null)
                throw new InvalidOperationException("No available staff to assign");

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
            staff.Students.Add(student);
            room.Students.Add(student);

            return MapToResponseDTO(student);
        }

        public IEnumerable<StudentResponseDTO> GetAll()
        {
            return _studentRepo.GetAll().Select(MapToResponseDTO);
        }

        public StudentResponseDTO? GetById(int id)
        {
            var student = _studentRepo.GetById(id);
            return student == null ? null : MapToResponseDTO(student);
        }

        public void Delete(int id)
        {
            var student = _studentRepo.GetById(id);
            if (student == null)
                throw new ArgumentException("Student with the given ID not found.");

            var staff = _staffRepo.GetById(student.StaffId);
            staff?.Students.Remove(student);

            var room = _roomRepo.GetById(student.RoomId);
            room?.Students.Remove(student);

            _studentRepo.Delete(id);
        }

        public void Update(StudentRequestDTO request, int id)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var existingStudent = _studentRepo.GetById(id);
            if (existingStudent == null)
                throw new ArgumentException("Student with the given ID not found.");

            existingStudent.Name = request.Name;
            existingStudent.Department = request.Department;
        }

        private StudentResponseDTO MapToResponseDTO(Student student)
        {
            return new StudentResponseDTO
            {
                Id = student.Id,
                Name = student.Name,
                Department = student.Department,
                StaffId = student.StaffId,
                StaffName = student.Staff?.Name ?? string.Empty,
                RoomId = student.RoomId,
                RoomNumber = student.Room?.RoomNumber ?? string.Empty
            };
        }
    }
}