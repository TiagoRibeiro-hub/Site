using Data.Infrastructure.Data.Game;
using Data.Infrastructure.Data.Game.Player;

namespace Data.Infrastructure.Events;
public interface InitializeGameEvent
{
    public Guid IdGame { get;}
    public GameOptions GameOptions { get; }
    public string Player1_Name { get; }
    public string StartFirst { get; }
    public VsComputer VsComputer { get; }
    public VsHuman VsHuman { get;}
}



