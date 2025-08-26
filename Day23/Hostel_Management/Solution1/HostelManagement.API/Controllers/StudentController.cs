using HostelManagement.Core.DTOs;
using HostelManagement.Core.Interfaces;
using HostelManagement.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HostelManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // GET: api/student
        [Authorize(Roles = "Admin,Staff")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentResponseDTO>>> GetAllStudents()
        {
            var students = await _studentService.GetAllStudent();
            return Ok(students);
        }

        // GET: api/student/5
        [Authorize(Roles = "Admin,Staff")]
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentResponseDTO>> GetStudentById(int id)
        {
            var student = await _studentService.GetStudentById(id);

            if (student == null)
            {
                return NotFound(new ErrorResponseDTO { StatusCode = 404, Message = $"Student with ID {id} not found." });
            }

            return Ok(student);
        }

        // POST: api/student
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<StudentResponseDTO>> AddStudent([FromBody] StudentRequestDTO requestDto)
        {
            var createdStudent = await _studentService.AddStudent(requestDto);
            return CreatedAtAction(nameof(GetStudentById), new { id = createdStudent.Id }, createdStudent);
        }

        // PUT: api/student/5
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<ActionResult<StudentResponseDTO>> UpdateStudent(int id, [FromBody] StudentRequestDTO requestDto)
        {
            var updatedStudent = await _studentService.UpdateStudent(requestDto, id);
            return Ok(updatedStudent);
        }

        // DELETE: api/student/5
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            await _studentService.DeleteStudent(id);
            return NoContent();
        }
    }
}