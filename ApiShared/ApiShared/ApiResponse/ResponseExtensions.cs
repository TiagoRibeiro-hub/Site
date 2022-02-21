namespace ApiShared;

public static class ResponseExtensions
{
    public static Response Fail(this Response x, string message)
    {
        return new Response
            (
                message: message,
                isSuccess: false
            );
    }

    public static Response<T> Fail<T>(this Response x, T content) where T : class, new()
    {
        return new Response<T>
            (
                isSuccess: false,
                content: content
            );
    }

    public static Response<T> Fail<T>(this Response x, string message, T content) where T : class, new()
    {
        return new Response<T>
            (
                message: message,
                isSuccess: false,
                content: content
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

