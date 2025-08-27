using HostelManagement.Core.DTOs;
using HostelManagement.Core.Entities;
using HostelManagement.Core.Interfaces;
using HostelManagement.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<StudentResponseDTO> AddStudent(StudentRequestDTO request)
        {
            if (request == null)
                throw new ValidationException("Request cannot be null");

            if (string.IsNullOrWhiteSpace(request.Name))
                throw new ValidationException("Name is required");
            if (string.IsNullOrWhiteSpace(request.Department))
                throw new ValidationException("Department is required");

            var staff = await _staffRepo.GetFirstAvailableStaffAsync();

            if (staff == null)
                throw new StaffOverloadException("No available staff to assign");

            var room = await _roomRepo.GetFirstAvailableRoomAsync();

            if (room == null)
                throw new RoomFullException("No available room to assign");

            var student = new Student
            {
                Name = request.Name,
                Department = request.Department,
                StaffId = staff.StaffId,
                RoomId = room.RoomId
            };

            await _studentRepo.AddAsync(student);
            return MapToResponseDTO(student);
        }

        public async Task<IEnumerable<StudentResponseDTO>> GetAllStudents()
        {
            var students = await _studentRepo.GetAllAsync();
            return students.Select(MapToResponseDTO);
        }

        public async Task<StudentResponseDTO?> GetStudentById(int id)
        {
            var student = await _studentRepo.GetByIdAsync(id);
            return student == null ? null : MapToResponseDTO(student);
        }

        public async Task DeleteStudent(int id)
        {
            var student = await _studentRepo.GetByIdAsync(id);
            if (student == null)
                throw new NotFoundException("Student with the given ID not found.");

            await _studentRepo.DeleteAsync(student);
        }

        public async Task<StudentResponseDTO> UpdateStudent(StudentRequestDTO request, int id)
        {
            if (request == null)
                throw new ValidationException("Request cannot be null");

            if (string.IsNullOrWhiteSpace(request.Name))
                throw new ValidationException("Name is required");

            if (string.IsNullOrWhiteSpace(request.Department))
                throw new ValidationException("Department is required");

            var existingStudent = await _studentRepo.GetByIdAsync(id);
            if (existingStudent == null)
                throw new NotFoundException("Student with the given ID not found.");

            existingStudent.Name = request.Name;
            existingStudent.Department = request.Department;

            await _studentRepo.UpdateAsync(existingStudent);

            return MapToResponseDTO(existingStudent);
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
