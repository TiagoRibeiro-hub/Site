using MassTransit;

namespace Data.Infrastructure.Events;
public interface IInitializeGameEvent
{
    public Guid IdGame { get; set; }
    public Dictionary<string, string> PossibleMoves { get; set; }
}


