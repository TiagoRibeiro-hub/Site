using TicTacToe;

namespace TicTacToeClass;
public static class RequaestExtensions
{
    public static Player PlayerAsHuman(this PlayerRequest x)
    {
        return new Player()
        {
            Name = x.Name,
            Email = x.Email,
            StartFirst = x.StartFirst,
        };
    }

    public static Game GameInit(this RegisterPlayersRequest x)
    {
        return new Game()
        {
            IsComputer = x.IsComputer,
            Easy = x.Easy,
            Intermediate = x.Intermediate,
            Hard = x.Hard,
        };
    }
    public static Player GetPlayersFromPlayersRequestList(this RegisterPlayersRequest x)
    {
        Player player = new();
        foreach (var item in x.ListPlayers)
        {
            player = item.PlayerAsHuman();
            x.ListPlayers.Remove(item);
            break;
        }

        return player;
    }

}

