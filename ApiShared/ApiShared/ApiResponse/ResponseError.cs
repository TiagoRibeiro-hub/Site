namespace ApiShared;
public class ResponseError : Response
{
    public ResponseError(string message, bool isSuccess)
    {
        Message = message;
        IsSuccess = isSuccess;
    }
    public ResponseError(bool isSuccess)
    {
        IsSuccess = isSuccess;
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