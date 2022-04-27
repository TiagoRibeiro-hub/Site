using _02.Play.TicTacToe.Core.Repository;
using MassTransit;

namespace _02.Play.TicTacToe.Core.Events;

public interface IInitializeGameEvent
{
    public Guid IdGame { get; set; }
    public Dictionary<string, string> PossibleMoves { get; set; }
}

public class InitializeGameConsumer : IConsumer<IInitializeGameEvent>
{
    public Task Consume(ConsumeContext<IInitializeGameEvent> context)
    {
        throw new NotImplementedException();
    }
}