namespace ApiShared;

public class ResponseError : Response
{
    public ResponseError()
    {

    }
    public ResponseError(string message, bool isSuccess) : base(message, isSuccess)
    {

    }
}

public class ResponseError<T> : ResponseError where T : class
{
    public ResponseError(string message, bool isSuccess, T content) : base(message, isSuccess)
    {
        Content = content;
    }

    public T Content { get; set; }

}

