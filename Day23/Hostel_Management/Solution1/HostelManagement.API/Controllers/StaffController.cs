using HostelManagement.Application.Services;
using HostelManagement.Core.DTOs;
using HostelManagement.Core.Interfaces;
using HostelManagement.Core.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace HostelManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _staffService;

        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StaffResponseDTO>>> GetAllStaff()
        {
            var staffs = await _staffService.GetAllStaff();
            return Ok(staffs);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<ActionResult<StaffResponseDTO>> GetStaffById(int id)
        {
            var staff = await _staffService.GetStaffById(id);
            return Ok(staff);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<StaffResponseDTO>> CreateStaff([FromBody] StaffRequestDTO staffDto)
        {
            var createdStaff = await _staffService.AddStaff(staffDto);
            return CreatedAtAction(nameof(GetStaffById), new { id = createdStaff.StaffId }, createdStaff);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<ActionResult<StaffResponseDTO>> UpdateStaff(int id, [FromBody] StaffRequestDTO staffDto)
        {
            var updatedStaff = await _staffService.UpdateStaff(staffDto, id);
            return Ok(updatedStaff);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaff(int id)
        {
            await _staffService.DeleteStaff(id);
            return NoContent();
        }
    }
}