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
            var room = await _roomService.GetRoomById(id);
            return Ok(room);
        }

        // POST: api/room
        [HttpPost]
        public async Task<ActionResult<RoomResponseDTO>> CreateRoom([FromBody] RoomRequestDTO roomDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdRoom = await _roomService.AddRoom(roomDto);
            return CreatedAtAction(nameof(GetRoomById), new { id = createdRoom.RoomId }, createdRoom);
        }

        // PUT: api/room/5
        [HttpPut("{id}")]
        public async Task<ActionResult<RoomResponseDTO>> UpdateRoom(int id, [FromBody] RoomRequestDTO roomDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedRoom = await _roomService.UpdateRoom(roomDto, id);
            return Ok(updatedRoom);
        }

        // DELETE: api/room/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            await _roomService.DeleteRoom(id);
            return NoContent();
        }
    }
}
