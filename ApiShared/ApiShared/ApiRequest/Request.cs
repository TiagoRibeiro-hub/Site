namespace TicTacToe;
#nullable disable
public class Request<T> where T : class
{
    public T Content { get; set; }
}

