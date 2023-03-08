namespace TicTacToe.Utils
{
    public class RouteValidation
    {
        public static bool IsContentTypeJson(HttpContext context)
        {
            if (context.Request.Headers["Content-Type"] != "application/json")
            {
                return false;
            }
            else
            {
                context.Response.ContentType = "application/json";
                return true;
            }
        }
    }
}
