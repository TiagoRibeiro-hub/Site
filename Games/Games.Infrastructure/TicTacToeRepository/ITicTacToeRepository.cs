namespace Games.Infrastructure;

public interface ITicTacToeRepository : IDisposable
{
    ITicTacToeWrite TicTacToeWrite { get; }
    ITicTacToeRead TicTacToeRead { get; }
    Task Complete();
}