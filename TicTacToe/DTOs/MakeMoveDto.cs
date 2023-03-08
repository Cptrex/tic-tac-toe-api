namespace TicTacToe.DTOs
{
    public class MakeMoveDto
    {
        public string Login { get; set; }
        public string RoomCode { get; set; } 
        public string Team { get; set; }
        public int FieldID { get; set; }
    }
}
