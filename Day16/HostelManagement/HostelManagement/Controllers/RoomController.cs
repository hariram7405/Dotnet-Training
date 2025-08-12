using Microsoft.AspNetCore.Mvc;
using HostelManagement.Core.DTOs;
using HostelManagement.Core.Interfaces;

namespace HostelManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _service;
        public RoomController(IRoomService service) => _service = service;

        [HttpPost]
        public ActionResult<RoomResponseDTO> Create([FromBody] RoomRequestDTO dto)
        {
            var created = _service.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpGet]
        public ActionResult<IEnumerable<RoomResponseDTO>> GetAll() => Ok(_service.GetAll());

        [HttpGet("{id:int}")]
        public ActionResult<RoomResponseDTO> GetById(int id)
        {
            var r = _service.GetById(id);
            if (r == null) return NotFound();
            return Ok(r);
        }
    }
}
