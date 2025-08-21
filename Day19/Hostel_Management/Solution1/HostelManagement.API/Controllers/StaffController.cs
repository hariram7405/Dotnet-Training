using HostelManagement.Application.Services;
using HostelManagement.Core.DTOs;
using HostelManagement.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HostelManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _staffService;

        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        // GET: api/staff
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StaffResponseDTO>>> GetAllStaff()
        {
            var staffs = await _staffService.GetAllStaff();
            return Ok(staffs);
        }

        // GET: api/staff/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StaffResponseDTO>> GetStaffById(int id)
        {
            try
            {
                var staff = await _staffService.GetStaffById(id);
                return Ok(staff);
            }
            catch (ArgumentException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        // POST: api/staff
        [HttpPost]
        public async Task<ActionResult<StaffResponseDTO>> CreateStaff([FromBody] StaffRequestDTO staffDto)
        {
            try
            {
                var createdStaff = await _staffService.AddStaff(staffDto);
                return CreatedAtAction(nameof(GetStaffById), new { id = createdStaff.StaffId }, createdStaff);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        // PUT: api/staff/5
        [HttpPut("{id}")]
        public async Task<ActionResult<StaffResponseDTO>> UpdateStaff(int id, [FromBody] StaffRequestDTO staffDto)
        {
            try
            {
                var updatedStaff = await _staffService.UpdateStaff(staffDto, id);
                return Ok(updatedStaff);
            }
            catch (ArgumentException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        // DELETE: api/staff/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaff(int id)
        {
            try
            {
                await _staffService.DeleteStaff(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { Message = ex.Message });
            }
        }
    }
}