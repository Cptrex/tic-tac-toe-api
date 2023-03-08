using TicTacToe.Utils;

namespace TicTacToe.ViewModels
{
    public class RoomViewModel
    {
        public string Creator { get; set; }
        public string CurrentTurnTeam { get; set; } = GameTeam.TEAM_X;
        public string RoomCode { get; set; }
        public string Winner { get; set; }
        public Dictionary<string, string> PlayersInRoom { get; set; } = new Dictionary<string, string>()
        {
            {GameTeam.TEAM_X, "" },
            {GameTeam.TEAM_O, "" }
        };

        public Dictionary<int, string> GameArea { get; set; } = new Dictionary<int, string>()
        {
            {1, "" },
            {2, "" },
            {3, "" },
            {4, "" },
            {5, "" },
            {6, "" },
            {7, "" },
            {8, "" },
            {9, "" }
        };

        public RoomViewModel() { }
        public RoomViewModel(string creator, string roomCode, string currentTurnTeam, Dictionary<string, string> playersInRoom, Dictionary<int, string> gameArea, string winner) 
        {
            Creator = creator;
            RoomCode = roomCode;
            CurrentTurnTeam = currentTurnTeam;
            PlayersInRoom = playersInRoom;
            GameArea = gameArea;
            Winner = winner;
        }

        public RoomViewModel(string creator, string roomCode, string currentTurnTeam, Dictionary<string, string> playersInRoom, Dictionary<int, string> gameArea)
        {
            Creator = creator;
            RoomCode = roomCode;
            CurrentTurnTeam = currentTurnTeam;
            PlayersInRoom = playersInRoom;
            GameArea = gameArea;
        }
    }
}
