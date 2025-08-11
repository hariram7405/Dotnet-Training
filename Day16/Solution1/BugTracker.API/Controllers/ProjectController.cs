using Microsoft.AspNetCore.Mvc;
using BugTracker.Core.DTOs;
using BugTracker.Core.Interfaces;

namespace BugTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        // POST: api/Project
        [HttpPost]
        public IActionResult CreateProject([FromBody] ProjectRequestDTO request)
        {
            if (request == null)
            {
                return BadRequest("Project data is required.");
            }

            _projectService.CreateProject(request);
            return Ok("Project created successfully.");
        }

        // GET: api/Project/{id}
        [HttpGet("{id}")]
        public IActionResult GetProjectById(int id)
        {
            var project = _projectService.GetProjectById(id);
            if (project == null)
            {
                return NotFound($"Project with ID {id} not found.");
            }

            return Ok(project);
        }

        // GET: api/Project
        [HttpGet]
        public IActionResult GetAllProjects()
        {
            var projects = _projectService.GetAllProjects();
            return Ok(projects);
        }
    }
}
