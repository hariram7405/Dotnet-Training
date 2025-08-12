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
            var s = _service.GetById(id);
            if (s == null) return NotFound();
            return Ok(s);
        }
    }
}
