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
    public class StaffService : IStaffService
    {
        private readonly IRepository<Staff> _staffRepo;

        public StaffService(IRepository<Staff> staffRepo)
        {
            _staffRepo = staffRepo;
        }

        public async Task<StaffResponseDTO> AddStaff(StaffRequestDTO request)
        {
            if (request == null)
            {
                throw new ValidationException("Request cannot be null");
            }

            if (string.IsNullOrWhiteSpace(request.Name))
            {
                throw new ValidationException("Staff Name is required.");
            }

            var staff = new Staff
            {
                Name = request.Name,
                Role = request.Role
            };

            await _staffRepo.AddAsync(staff);

            return MapToResponse(staff);
        }

        public async Task<StaffResponseDTO> GetStaffById(int id)
        {
            var staff = await _staffRepo.GetByIdAsync(id);

            if (staff == null)
            {
                throw new NotFoundException("Staff not found.");
            }

            return MapToResponse(staff);
        }

        public async Task<StaffResponseDTO> UpdateStaff(StaffRequestDTO staffDto, int id)
        {
            var existingStaff = await _staffRepo.GetByIdAsync(id);

            if (existingStaff == null)
            {
                throw new NotFoundException("Staff not found.");
            }

            existingStaff.Name = staffDto.Name;
            existingStaff.Role = staffDto.Role;

            await _staffRepo.UpdateAsync(existingStaff);

            return MapToResponse(existingStaff);
        }

        public async Task DeleteStaff(int id)
        {
            var staff = await _staffRepo.GetByIdAsync(id);

            if (staff == null)
            {
                throw new NotFoundException("Staff not found.");
            }
            if (staff.Students.Count > 0)
            {
                throw new StaffHasStudentsException("This staff member is assigned to students and cannot be deleted.");
            }

            await _staffRepo.DeleteAsync(staff);
        }

        public async Task<IEnumerable<StaffResponseDTO>> GetAllStaff()
        {
            var staffs = await _staffRepo.GetAllAsync();
            return staffs.Select(MapToResponse);
        }

        private StaffResponseDTO MapToResponse(Staff staff)
        {
            return new StaffResponseDTO
            {
                StaffId = staff.StaffId,
                Name = staff.Name,
                Role = staff.Role,
                Students = staff.Students?.Select(s => s.Name).ToList() ?? new List<string>()
            };
        }
    }
}