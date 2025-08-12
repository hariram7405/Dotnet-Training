using Microsoft.AspNetCore.Mvc;
using HostelManagement.Core.DTOs;
using HostelManagement.Core.Interfaces;

namespace HostelManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;
        public StudentController(IStudentService service) => _service = service;

        [HttpPost]
        public ActionResult<StudentResponseDTO> Create([FromBody] StudentRequestDTO dto)
        {
            try
            {
                var created = _service.Create(dto);
                return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<StudentResponseDTO>> GetAll() => Ok(_service.GetAll());

        [HttpGet("{id:int}")]
        public ActionResult<StudentResponseDTO> GetById(int id)
        {
            var s = _service.GetById(id);
            if (s == null) return NotFound();
            return Ok(s);
        }
    }
}
