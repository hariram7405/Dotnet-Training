using BugTracker.Core.DTOs;
using BugTracker.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BugController : ControllerBase
    {
        private readonly IBugService _service;

        public BugController(IBugService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BugResponseDTO>> GetAll()
        {
            var bugs = _service.GetAllBugs();
            return Ok(bugs);
        }

        [HttpGet("{id}")]
        public ActionResult<BugResponseDTO> GetById(int id)
        {
            var bug = _service.GetBugById(id);
            if (bug == null)
                return NotFound();

            return Ok(bug);
        }

        [HttpPost]
        public ActionResult Create([FromBody] BugRequestDTO dto)
        {
            var id = _service.CreateBug(dto);
            return CreatedAtAction(nameof(GetById), new { id }, "Bug created successfully.");
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] BugRequestDTO dto)
        {
            var existing = _service.GetBugById(id);
            if (existing == null)
                return NotFound();

            _service.UpdateBug(id, dto);
            return Ok("Bug updated successfully.");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var existing = _service.GetBugById(id);
            if (existing == null)
                return NotFound();

            _service.DeleteBug(id);
            return Ok("Bug deleted successfully.");
        }
    }
}
