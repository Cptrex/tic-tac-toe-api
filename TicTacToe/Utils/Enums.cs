namespace TicTacToe.Utils
{
    public enum ResponseAPICode
    {
        RoomNotFound = 1,
        MakeMoveError = 2,
        WrongQuequeTurn = 4,
        ContinuePlay = 5,
        EndPlay = 6,
        Draw = 7,
        RoomCreated = 8,
        RoomDeleted = 9,
        RoomEntered = 10,
        LeaveRoom = 11,
        Win = 12
    }

    public enum MoveStatus
    {
        Failed = 0,
        Success = 1
    }
}
