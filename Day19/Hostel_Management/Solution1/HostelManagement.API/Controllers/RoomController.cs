using HostelManagement.Core.DTOs;
using HostelManagement.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HostelManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        // GET: api/room
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomResponseDTO>>> GetAllRooms()
        {
            var rooms = await _roomService.GetAllRoom();
            return Ok(rooms);
        }

        // GET: api/room/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomResponseDTO>> GetRoomById(int id)
        {
            try
            {
                var room = await _roomService.GetRoomById(id);
                return Ok(room);
            }
            catch (ArgumentException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        // POST: api/room
        [HttpPost]
        public async Task<ActionResult<RoomResponseDTO>> CreateRoom([FromBody] RoomRequestDTO roomDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var createdRoom = await _roomService.AddRoom(roomDto);
                return CreatedAtAction(nameof(GetRoomById), new { id = createdRoom.RoomId }, createdRoom);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        // PUT: api/room/5
        [HttpPut("{id}")]
        public async Task<ActionResult<RoomResponseDTO>> UpdateRoom(int id, [FromBody] RoomRequestDTO roomDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var updatedRoom = await _roomService.UpdateRoom(roomDto, id);
                return Ok(updatedRoom);
            }
            catch (ArgumentException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        // DELETE: api/room/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            try
            {
                await _roomService.DeleteRoom(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }
    }
}
