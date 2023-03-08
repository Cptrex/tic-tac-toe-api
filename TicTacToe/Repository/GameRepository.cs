using TicTacToe.Models;
using TicTacToe.Utils;

namespace TicTacToe.Repository
{
    public class GameRepository
    {
        public static string CheckWin(Room room)
        {
            #region Horzontal Winning Condtion
            //Winning Condition For First Row
            if (room.GameArea[1] == room.GameArea[2] && room.GameArea[2] == room.GameArea[3] && room.GameArea[1] != "") return room.GameArea[1];
            //Winning Condition For Second Row
            else if (room.GameArea[4] == room.GameArea[5] && room.GameArea[5] == room.GameArea[6] && room.GameArea[4] != "") return room.GameArea[4];
            //Winning Condition For Third Row
            else if (room.GameArea[7] == room.GameArea[8] && room.GameArea[8] == room.GameArea[9] && room.GameArea[7] != "") return room.GameArea[6];
            #endregion

            #region vertical Winning Condtion
            //Winning Condition For First Column
            else if (room.GameArea[1] == room.GameArea[4] && room.GameArea[4] == room.GameArea[7] && room.GameArea[1] != "") return room.GameArea[1];
            //Winning Condition For Second Column
            else if (room.GameArea[2] == room.GameArea[5] && room.GameArea[5] == room.GameArea[8] && room.GameArea[2] != "") return room.GameArea[2];
            //Winning Condition For Third Column
            else if (room.GameArea[3] == room.GameArea[6] && room.GameArea[6] == room.GameArea[9] && room.GameArea[3] != "") return room.GameArea[3];
            #endregion

            #region Diagonal Winning Condition
            else if (room.GameArea[1] == room.GameArea[5] && room.GameArea[5] == room.GameArea[9] && room.GameArea[1] != "") return room.GameArea[1];
            else if (room.GameArea[3] == room.GameArea[5] && room.GameArea[5] == room.GameArea[7] && room.GameArea[3] != "") return room.GameArea[3];
            #endregion

            #region Checking For Draw
            else if (room.GameArea.ContainsValue("") == false) return WinCondition.DRAW;
            #endregion

            else return WinCondition.CONTINUE_PLAY;
        }

        public static Dictionary<int, string> ResetGameArea()
        {
            return new Dictionary<int, string>() {
                    {1, "" }, {2, "" }, {3, "" }, {4, "" },  {5, "" }, {6, "" }, {7, "" }, {8, "" },{9, "" }
                };
        }

    }
}