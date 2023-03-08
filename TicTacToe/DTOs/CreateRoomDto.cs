using TicTacToe.Utils;

namespace TicTacToe.DTOs
{
    public class CreateRoomDto
    {
        public string Login { get; set; }
        public string Team { get; set; } = GameTeam.TEAM_X;
        public string FirstTurnTeam { get; set; } = GameTeam.TEAM_X;
    }
}