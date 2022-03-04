using Data._DbContext;

namespace _01.Games.RegisterPlayer.Infrastructure;
public static class Extensions
{
    public static RegisteredPlayersEntity SetGameEntity(this RegisterPlayerRecord x)
    {
        return new RegisteredPlayersEntity
            (
                playerName: x.PlayerName,
                playerEmail: x.PlayerEmail
            );
    }
}
