using Microsoft.EntityFrameworkCore;
using TicTacToe.DTOs;
using TicTacToe.Models;
using TicTacToe.Models.Context;

namespace TicTacToe.Repository
{
    public class RoomRepository
    {
        public static async Task<bool> DeleteRoom(TicTacToeContext context, string roomCode)
        {
            var room = await GetRoomByRoomCode(context, roomCode);
            if (room == null) return false;

            context.Rooms.Remove(room);
            context.SaveChanges();

            return true;
        }

        public static async Task<Room> CreateRoom(TicTacToeContext context, CreateRoomDto createRoomDto)
        {
            string roomId = await GenerateRoomID(context);

            Room room = new Room(roomId, createRoomDto.Login, createRoomDto.FirstTurnTeam);
            context.Rooms.Add(room);

            context.SaveChanges();

            return room;
        }

        public static void LeaveRoom(TicTacToeContext context, Room room, LeaveRoomDto leaveRoomDto)
        {
            room.PlayersInRoom[leaveRoomDto.Team] = "";
            room.GameArea = GameRepository.ResetGameArea();

            context.Update(room);

            context.SaveChanges();
        }

        public static async Task<string> GenerateRoomID(TicTacToeContext context)
        {
            Random random = new Random();
            while (true)
            {
                int randomNum = random.Next(10001, 99999);

                string roomId = $"{randomNum}-{randomNum / 1000 * 2}".ToUpper();

                if (await CheckIsRoomIdExistInDB(context, roomId) == false) return roomId;
            }
        }

        public static async Task<bool> CheckIsRoomIdExistInDB(TicTacToeContext context, string roomCode)
        {
            return await context.Rooms.FirstOrDefaultAsync(t => t.RoomCode == roomCode) == null ? false : true;
        }

        public static async Task<Room> GetRoomByRoomCode(TicTacToeContext context, string roomCode)
        {
            return await context.Rooms.FirstOrDefaultAsync(r => r.RoomCode == roomCode);
        }
    }
}