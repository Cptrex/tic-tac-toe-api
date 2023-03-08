using TicTacToe.Utils;

namespace TicTacToe.ViewModels
{
    public class ResponseViewModel
    {
        public ResponseAPICode ResponseCode { get; set; }
        public string Message { get; set; }
        public RoomViewModel Body { get; set; }

        public ResponseViewModel() { }

        public ResponseViewModel(ResponseAPICode response, string message)
        {
            ResponseCode = response;
            Message = message;
        }

        public ResponseViewModel(ResponseAPICode response, string message, RoomViewModel body)
        {
            ResponseCode = response;
            Body = body;
            Message = message;
        }
    }
}