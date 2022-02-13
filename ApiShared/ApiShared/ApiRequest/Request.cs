namespace ApiShared;
public class Request<T> where T : class
{
    public T Content { get; set; }
}

