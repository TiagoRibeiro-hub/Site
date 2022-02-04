namespace TicTacToe;
#nullable disable
public class Response
{
    public string Message { get; set; } = "Everthing Ok";
    public bool IsSuccess { get; set; } = true;

}

public class Response<T> : Response where T : class
{
    public T Content { get; set; }

}

