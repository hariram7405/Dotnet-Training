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
            var room = _service.GetById(id);
            if (room == null) return NotFound();
            return Ok(room);
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
        public ActionResult Update( int id, [FromBody] RoomRequestDTO dto)
        {
            try
            {
                _service.Update(dto, id);
                return NoContent();
            }
            catch(ArgumentException e)
            {
                return NotFound(new { error = e.Message }); 
            }
        }
       

    }
}
