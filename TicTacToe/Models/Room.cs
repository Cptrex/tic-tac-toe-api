using TicTacToe.Utils;
using TicTacToe.Models.Context;

namespace TicTacToe.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string RoomCode { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Winner { get; set; } = null!;
        public string CurrentTurnTeam { get; set; } = GameTeam.TEAM_X;

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

        public Room() { }

        public Room(string roomCode, string creator, string creatorSelectedSide)
        {
            RoomCode = roomCode;
            Creator = creator;
            Created = DateTime.Now;
            CurrentTurnTeam = creatorSelectedSide;
            PlayersInRoom = new Dictionary<string, string>()
                {
                    {GameTeam.TEAM_X, Creator},
                    {GameTeam.TEAM_O, "" }
                };
            GameArea = new Dictionary<int, string>() {
                    {1, "" }, {2, "" }, {3, "" }, {4, "" },  {5, "" }, {6, "" }, {7, "" }, {8, "" },{9, "" }
                };

            PlayersInRoom[CurrentTurnTeam] = Creator;
        }

        public async Task<MoveStatus> MakeMove(TicTacToeContext context, int fieldID, string teamMark)
        {
            if (IsSelectedGameAreaFree(fieldID) == false) return MoveStatus.Failed;
            this.GameArea[fieldID] = teamMark;

            context.Update(this);
            await context.SaveChangesAsync();

            return MoveStatus.Success;
        }

        public void EnterRoom(string login)
        {
            if (this.PlayersInRoom[GameTeam.TEAM_X] == "") this.PlayersInRoom[GameTeam.TEAM_X] = login;
            else this.PlayersInRoom[GameTeam.TEAM_O] = login;
        }

        public bool IsUserCreator(string login)
        {
            return this.Creator == login;
        }

        private bool IsSelectedGameAreaFree(int fieldId)
        {
            return this.GameArea[fieldId] == "" ? true : false;
        }

        public async Task<bool> SwitchTurnTeam(TicTacToeContext context)
        {
            if (this.CurrentTurnTeam == GameTeam.TEAM_X) this.CurrentTurnTeam = GameTeam.TEAM_O;
            else this.CurrentTurnTeam = GameTeam.TEAM_X;

            context.Update(this);

            await context.SaveChangesAsync();

            return true;
        }

        public async Task<string> SetWinner(TicTacToeContext context, string teamWinner)
        {
            this.Winner = this.PlayersInRoom.FirstOrDefault(p => p.Key == teamWinner).Value;

            context.Update(this);
            await context.SaveChangesAsync();

            return this.Winner;
        }

        public bool IsCurrentTeamTurn(string team)
        {
            return this.CurrentTurnTeam == team ? true : false;
        }
    }
}