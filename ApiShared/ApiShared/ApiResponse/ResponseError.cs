using TicTacToe;

namespace ApiShared;
public class ResponseError : Response
{
    public ResponseError(string message)
    {
        Message = message;
        IsSuccess = false;
    }

}

public class ResponseErrorException : Response
{
    public IEnumerable<string> Errors { get; set; } = new HashSet<string>();

    public ResponseErrorException(IEnumerable<string> errors, string message)
    {
        Message = message;
        IsSuccess = false;
        Errors = errors;
    }
}