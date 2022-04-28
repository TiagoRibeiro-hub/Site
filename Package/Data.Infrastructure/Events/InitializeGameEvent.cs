namespace Data.Infrastructure.Events;
public interface InitializeGameEvent
{
    public Guid IdGame { get; set; }
    public Dictionary<string, string> PossibleMoves { get; set; }
}



