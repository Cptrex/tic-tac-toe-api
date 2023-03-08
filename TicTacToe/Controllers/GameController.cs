using Microsoft.AspNetCore.Mvc;
using TicTacToe.DTOs;
using TicTacToe.Utils;
using TicTacToe.Repository;
using TicTacToe.Models.Context;
using TicTacToe.ViewModels;

namespace TicTacToe.Controllers
{
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly TicTacToeContext _context;
        public GameController(TicTacToeContext context) 
        {
            _context = context;
        }
        [HttpPut]
        [Route("api/v1/game/make-move")]
        public async Task<IActionResult> MakeMove([FromBody] MakeMoveDto moveDto)
        {
            if (RouteValidation.IsContentTypeJson(HttpContext) == false) return Redirect("");

            var room = await RoomRepository.GetRoomByRoomCode(_context, moveDto.RoomCode);
            ResponseViewModel response = new ResponseViewModel(ResponseAPICode.RoomNotFound, "room id not found", new RoomViewModel());

            if (room == null) return Ok(response);

            if (room.IsCurrentTeamTurn(moveDto.Team) == false)
            {
                response.Message = "error turn queue";
                response.ResponseCode = ResponseAPICode.WrongQuequeTurn;
                return Ok(response);
            }

            MoveStatus moveResult = await room.MakeMove(_context, moveDto.FieldID, moveDto.Team);
            if (moveResult == MoveStatus.Failed)
            {
                response.Message = "make move error";
                response.ResponseCode = ResponseAPICode.MakeMoveError;
                return Ok(response);
            }

            string winResult = GameRepository.CheckWin(room);
            if (winResult == WinCondition.CONTINUE_PLAY)
            {
                response.Message = "continue play";
                response.ResponseCode = ResponseAPICode.ContinuePlay;
                await room.SwitchTurnTeam(_context);
            }
            else if(winResult == WinCondition.DRAW)
            {
                response.Message = "draw";
                response.ResponseCode = ResponseAPICode.Draw;
            }
            else
            {
                response.Message = "win";
                response.ResponseCode = ResponseAPICode.Win;
                await room.SetWinner(_context, winResult);
            }

            response.Body = new RoomViewModel(room.Creator, room.RoomCode, room.CurrentTurnTeam, room.PlayersInRoom, room.GameArea, room.Winner);

            return Ok(response);
        }

        [HttpGet]
        [Route("api/v1/game/client-update")]
        public async Task<IActionResult> ForceUpdateGameSession([FromBody] UpdateGameSessionDto updateSessionDto)
        {
            if (RouteValidation.IsContentTypeJson(HttpContext) == false) return Redirect("");

            var room = await RoomRepository.GetRoomByRoomCode(_context, updateSessionDto.RoomCode);
            RoomViewModel roomViewModel = new RoomViewModel(room.Creator, room.RoomCode, room.CurrentTurnTeam, room.PlayersInRoom, room.GameArea);
            ResponseViewModel response = new ResponseViewModel(ResponseAPICode.RoomNotFound, "room id not found", roomViewModel);
           
            return Ok(response);
        }
    }
}