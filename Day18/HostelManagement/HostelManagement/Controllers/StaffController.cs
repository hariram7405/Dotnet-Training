using Microsoft.AspNetCore.Mvc;
using HostelManagement.Core.DTOs;
using HostelManagement.Core.Interfaces;

namespace HostelManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _service;
        public StaffController(IStaffService service) => _service = service;

        [HttpPost]
        public ActionResult<StaffResponseDTO> Create([FromBody] StaffRequestDTO dto)
        {
            var created = _service.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpGet]
        public ActionResult<IEnumerable<StaffResponseDTO>> GetAll() => Ok(_service.GetAll());

        [HttpGet("{id:int}")]
        public ActionResult<StaffResponseDTO> GetById(int id)
        {
            var staff = _service.GetById(id);
            if (staff == null) return NotFound();
            return Ok(staff);
        }
        [HttpDelete("{id:int}")]

        public ActionResult Delete(int id)
        {
            try
            {
                _service.Delete(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(new { error = ex.Message });
            }

            catch (InvalidOperationException ex)
            {
                return Conflict(new { error = ex.Message }); // 409 Conflict
            }
        }
        [HttpPut("{id:int}")]
        public ActionResult Update(int id, [FromBody] StaffRequestDTO dto)
        {
            try
            {
                _service.Update(dto, id);
                return NoContent(); // 204 No Content on success
            }
            catch (ArgumentException ex)
            {
                return NotFound(new { error = ex.Message }); // 404 if student not found
            }
        }

    }
}
