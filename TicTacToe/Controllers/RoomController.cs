using Microsoft.AspNetCore.Mvc;
using TicTacToe.DTOs;
using TicTacToe.Models;
using TicTacToe.Models.Context;
using TicTacToe.Repository;
using TicTacToe.Utils;
using TicTacToe.ViewModels;

namespace TicTacToe.Controllers
{
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly TicTacToeContext _context;
        public RoomController(TicTacToeContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("api/v1/room/create")]
        public async Task<IActionResult> CreateRoom([FromBody] CreateRoomDto createRoomDto)
        {
            if (RouteValidation.IsContentTypeJson(HttpContext) == false) return Redirect("");

            Room room = await RoomRepository.CreateRoom(_context, createRoomDto);
            RoomViewModel roomViewModel = new RoomViewModel(room.Creator, room.RoomCode, room.CurrentTurnTeam, room.PlayersInRoom, room.GameArea);
            ResponseViewModel response = new ResponseViewModel(ResponseAPICode.RoomCreated, "Room has been created", roomViewModel);

            return Ok(response);
        }

        [HttpDelete]
        [Route("api/v1/room/delete")]
        public async Task<IActionResult> DeleteRoom([FromBody] DeleteRoomDto deleteRoomDto)
        {
            if (RouteValidation.IsContentTypeJson(HttpContext) == false) return Redirect("");

            await RoomRepository.DeleteRoom(_context, deleteRoomDto.RoomCode);
            
            ResponseViewModel response = new ResponseViewModel(ResponseAPICode.RoomDeleted, "Room has been deleted", null);

            return Ok(response);
        }

        [HttpPut]
        [Route("api/v1/room/enter")]
        public async Task<IActionResult> EnterRoom([FromBody] EnterRoomDto enterRoomDto)
        {
            if (RouteValidation.IsContentTypeJson(HttpContext) == false) return Redirect("");

            Room room = await RoomRepository.GetRoomByRoomCode(_context, enterRoomDto.RoomCode);
            ResponseViewModel response;
            if (room == null)
            {
                response = new ResponseViewModel(ResponseAPICode.RoomNotFound, "Enter room filed. RoomCode not found", null);
            }
            else
            {
                room.EnterRoom(enterRoomDto.Login);
                _context.SaveChanges();

                RoomViewModel roomViewModel = new RoomViewModel(room.Creator, room.RoomCode, room.CurrentTurnTeam, room.PlayersInRoom, room.GameArea);
                response = new ResponseViewModel(ResponseAPICode.RoomEntered, "Enter room success", roomViewModel);
            }
         
            return Ok(response);
        }

        [HttpPut]
        [Route("api/v1/room/leave")]
        public async Task<IActionResult> LeaveRoom([FromBody] LeaveRoomDto leaveRoomDto)
        {
            if (RouteValidation.IsContentTypeJson(HttpContext) == false) return Redirect("");

            Room room = await RoomRepository.GetRoomByRoomCode(_context, leaveRoomDto.RoomCode);
            ResponseViewModel response;
            if (room == null) return Ok();

            if(room.IsUserCreator(leaveRoomDto.Login))
            {
                await RoomRepository.DeleteRoom(_context, leaveRoomDto.RoomCode);
                response = new ResponseViewModel(ResponseAPICode.RoomDeleted, "Creator has been left. Room Deleted", null);
            }
            else
            {
                RoomRepository.LeaveRoom(_context, room, leaveRoomDto);
                response = new ResponseViewModel(ResponseAPICode.LeaveRoom, "User has been left from room. Game reseted", null);
            }
            return Ok(response);
        }
    }
}