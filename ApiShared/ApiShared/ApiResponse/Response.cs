namespace ApiShared;
public class Response
{
    public Response()
    {

    }

    public Response(bool isSuccess)
    {
        IsSuccess = isSuccess;
    }

    public Response(string message, bool isSuccess)
    {
        Message = message;
        IsSuccess = isSuccess;
    }

    public string Message { get; set; }
    public bool IsSuccess { get; set; }

}

public class Response<T> : Response where T : class
{
    public Response()
    {

    }

    public Response(string message, bool isSuccess, T content) : base(message, isSuccess)
    {
        Content = content;
    }
    public Response(bool isSuccess, T content) : base(isSuccess)
    {
        Content = content;
    }
    public T Content { get; set; }

}
