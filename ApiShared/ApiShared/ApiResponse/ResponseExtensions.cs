namespace ApiShared;

public static class ResponseExtensions
{
    public static ResponseError Fail(this ResponseError x, string message)
    {
        return new ResponseError
            (
                message: message,
                isSuccess: false
            );
    }
    public static ResponseError<T> Fail<T>(this ResponseError x, string message, T content) where T : class, new()
    {
        return new ResponseError<T>
            (
                message: message,
                isSuccess: false,
                content: content
            );
    }

    public static ResponseError NoErrors(this ResponseError x, string message)
    {
        return new ResponseError
            (
                message: message,
                isSuccess: true
            );
    }

    public static Response Success(this Response x, string message)
    {
        return new Response
            (
                message: message,
                isSuccess: true
            );
    }
    public static Response<T> Success<T>(this Response x, T content, string message) where T : class, new()
    {
        return new Response<T>
            (
                message: message,
                isSuccess: true,
                content: content
            );
    }
}

